using MMRando.Constants;
using MMRando.Models;
using MMRando.Models.Rom;
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

        public static List<MessageEntry> MakeGossipQuotes(Settings settings, List<ItemObject> items, Random random)
        {
            if (!settings.EnableGossipHints)
                return new List<MessageEntry>();

            var hints = new List<string>();
            var GossipList = GetGossipList();

            foreach (var item in items)
            {
                if (!item.ReplacesAnotherItem)
                {
                    continue;
                }

                // Skip hints for vanilla bottle content
                if ((!settings.RandomizeBottleCatchContents)
                    && ItemUtils.IsBottleCatchContent(item.ID))
                {
                    continue;
                }

                // Skip hints for vanilla shop items
                if ((!settings.AddShopItems)
                    && ItemUtils.IsShopItem(item.ID))
                {
                    continue;
                }

                // Skip hints for vanilla dungeon items
                if (!settings.AddDungeonItems
                    && ItemUtils.IsDungeonItem(item.ID))
                {
                    continue;
                }

                int sourceItemId = item.ReplacesItemId;
                if (ItemUtils.IsItemDefinedPastAreas(sourceItemId))
                {
                    sourceItemId -= Values.NumberOfAreasAndOther;
                }

                int toItemId = item.ID;
                if (ItemUtils.IsItemDefinedPastAreas(toItemId))
                {
                    toItemId -= Values.NumberOfAreasAndOther;
                }

                // 5% chance of being fake
                bool isFake = (random.Next(100) < 5);
                if (isFake)
                {
                    sourceItemId = random.Next(GossipList.Count);
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

                // Sound differs if hint is fake
                ushort soundEffectId = (ushort)(isFake ? 0x690A : 0x690C);

                var quote = BuildGossipQuote(soundEffectId, sourceMessage, destinationMessage, random);

                hints.Add(quote);
            }

            for (int i = 0; i < Gossip.JunkMessages.Count; i++)
            {
                hints.Add(Gossip.JunkMessages[i]);
            }

            //trim the pool of messages
            List<MessageEntry> finalHints = new List<MessageEntry>();

            for (ushort textId = GOSSIP_START_ID; textId < GOSSIP_END_ID; textId++)
            {
                if (GossipExclude.Contains(textId)) //todo: exclude invalid ids
                {
                    continue;
                }

                int selectedIndex = random.Next(hints.Count);
                string selectedHint = hints[selectedIndex];

                //todo: reimplemement bad hint logic:
                //if (IsBadMessage(selectedHint) && random.Next(8) != 0)
                //{
                //    continue;
                //}

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

            return $"\x1E{sfx}{start} \x01{sourceMessage}\x00\x11{mid} \x06{destinationMessage}\x00" + "...\xBF";
        }
    }
}