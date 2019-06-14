using MMRando.Extensions;
using MMRando.Models;
using MMRando.Models.Rom;
using MMRando.Models.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MMRando.Utils
{

    public static class MessageUtils
    {

        const int GOSSIP_START_ID = 0x20B0;
        const int GOSSIP_END_ID = 0x2116;

        static ReadOnlyCollection<int> GossipExclude
            = new ReadOnlyCollection<int>(new int[] {
                0x20D0,
                0x20D1,
                0x20D2,
                0x20F3,
                0x20F7,
                0x20F8,
                0x20F9,

                //non-existing entries
                0x20C8,
                0x20C9,
                0x20CA,
                0x20CB,
                0x20CC,
                0x20CD,
                0x20CE,
                0x20CF,
                0x20D3,
                0x20E8,
                0x20E9,
                0x20EA,
                0x20EB,
                0x20EC,
                0x20ED,
                0x20EE,
                0x20EF,
                0x20F0,
                0x20F1,
                0x20F2,
                0x20F4,
                0x20F5,
                0x20F6,
                0x20FA,
                0x20FB,
                0x20FC,
                0x20FD,
                0x20FE,
                0x20FF,
                0x2100,
                0x2101,
                0x2102,
            });

        static ReadOnlyCollection<byte> MessageHeader
            = new ReadOnlyCollection<byte>(new byte[] {
                2, 0, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
        });


        public static List<Gossip> GetGossipList()
        {
            var gossipList = new List<Gossip>();

            string[] gossipLines = Properties.Resources.GOSSIP
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            for (int i = 0; i < gossipLines.Length; i += 2)
            {
                var sourceMessage = gossipLines[i].Split(';');
                var destinationMessage = gossipLines[i + 1].Split(';');
                var nextGossip = new Gossip
                {
                    SourceMessage = sourceMessage,
                    DestinationMessage = destinationMessage
                };

                gossipList.Add(nextGossip);
            }
            return gossipList;
        }

        private static bool IsBadMessage(string message)
        {
            return message.Contains("a segment of health") || message.Contains("currency") ||
                message.Contains("money") || message.Contains("cash") ||
                message.Contains("wealth") || message.Contains("riches and stuff") ||
                message.Contains("increased life") || message.Contains("Rupee") ||
                message.Contains("Heart");
        }

        public static List<MessageEntry> MakeGossipQuotes(SettingsObject settings, List<ItemObject> items, Random random)
        {
            if (!settings.EnableGossipHints)
                return new List<MessageEntry>();

            var hints = new List<string>();
            var GossipList = settings.ClearHints
                ? items
                .Where(io => !ItemUtils.IsFakeItem(io.ID))
                .Select(io => new Gossip
                {
                    SourceMessage = new string[] { Items.LOCATION_NAMES[io.ID] },
                    DestinationMessage = new string[] { Items.ITEM_NAMES[io.ID] },
                }).ToList()
                : GetGossipList();

            foreach (var item in items)
            {
                if (!item.ReplacesAnotherItem)
                {
                    continue;
                }

                if (settings.ClearHints)
                {
                    // skip free items
                    if (item.ReplacesItemId == Items.MaskDeku || item.ReplacesItemId == Items.SongHealing)
                    {
                        continue;
                    }
                }

                // skip non-randomized items.
                if (!settings.UseCustomItemList)
                {
                    if (settings.ExcludeSongOfSoaring && item.ID == Items.SongSoaring)
                    {
                        continue;
                    }

                    if (!settings.AddDungeonItems && ItemUtils.IsDungeonItem(item.ID))
                    {
                        continue;
                    }

                    if (!settings.AddShopItems && ItemUtils.IsShopItem(item.ID))
                    {
                        continue;
                    }

                    if (!settings.AddOther && ItemUtils.IsOtherItem(item.ID))
                    {
                        continue;
                    }

                    if (!settings.RandomizeBottleCatchContents && ItemUtils.IsBottleCatchContent(item.ID))
                    {
                        continue;
                    }

                    if (!settings.AddMoonItems && ItemUtils.IsMoonItem(item.ID))
                    {
                        continue;
                    }
                }

                int sourceItemId = ItemUtils.SubtractItemOffset(item.ReplacesItemId);
                int toItemId = ItemUtils.SubtractItemOffset(item.ID);

                if (settings.UseCustomItemList)
                {
                    if (!settings.CustomItemList.Contains(toItemId))
                    {
                        continue;
                    }
                }

                ushort soundEffectId = 0x690C;
                if (!settings.ClearHints)
                {
                    // 5% chance of being fake
                    bool isFake = random.Next(100) < 5;
                    if (isFake)
                    {
                        sourceItemId = random.Next(GossipList.Count);
                        soundEffectId = 0x690A;
                    }
                }

                if (IsBadMessage(GossipList[toItemId].DestinationMessage[0]) && (settings.ClearHints || random.Next(8) != 0))
                {
                    continue;
                }

                int sourceMessageLength = GossipList[sourceItemId]
                    .SourceMessage
                    .Length;

                int destinationMessageLength = GossipList[toItemId]
                    .DestinationMessage
                    .Length;

                // Randomize messages
                string sourceMessage = GossipList[sourceItemId]
                    .SourceMessage[random.Next(sourceMessageLength)];

                string destinationMessage = GossipList[toItemId]
                    .DestinationMessage[random.Next(destinationMessageLength)];

                var quote = BuildGossipQuote(soundEffectId, sourceMessage, destinationMessage, random);

                hints.Add(quote);
            }

            if (!settings.ClearHints)
            {
                hints.AddRange(Gossip.JunkMessages);
            }

            var numberOfGossipStones = GOSSIP_END_ID - GOSSIP_START_ID - GossipExclude.Count;
            while (hints.Count < numberOfGossipStones)
            {
                var hintsToAdd = numberOfGossipStones - hints.Count;
                hints.AddRange(Gossip.JunkMessages.Take(hintsToAdd));
            }

            //trim the pool of messages
            List<MessageEntry> finalHints = new List<MessageEntry>();

            for (ushort textId = GOSSIP_START_ID; textId < GOSSIP_END_ID; textId++)
            {
                if (GossipExclude.Contains(textId))
                {
                    continue;
                }

                int selectedIndex = random.Next(hints.Count);
                string selectedHint = hints[selectedIndex];

                MessageEntry message = new MessageEntry()
                {
                    Id = textId,
                    Message = selectedHint,
                    Header = MessageHeader.ToArray()
                };


                finalHints.Add(message);
                hints.RemoveAt(selectedIndex);
            }
            return finalHints;
        }


        private static string BuildGossipQuote(ushort soundEffectId, string sourceMessage, string destinationMessage, Random random)
        {
            int startIndex = random.Next(Gossip.MessageStartSentences.Count);
            int midIndex = random.Next(Gossip.MessageMidSentences.Count);
            string start = Gossip.MessageStartSentences[startIndex];
            string mid = Gossip.MessageMidSentences[midIndex];

            string sfx = $"{(char)((soundEffectId >> 8) & 0xFF)}{(char)(soundEffectId & 0xFF)}";

            return $"\x1E{sfx}{start} \x01{sourceMessage}\x00 {mid} \x06{destinationMessage}\x00...\xBF".Wrap(35, "\x11");
        }
    }
}