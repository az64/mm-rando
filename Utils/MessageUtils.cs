using MMRando.Attributes;
using MMRando.Extensions;
using MMRando.GameObjects;
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
                var locationMessage = gossipLines[i].Split(';');
                var itemMessage = gossipLines[i + 1].Split(';');
                var nextGossip = new Gossip
                {
                    LocationMessage = locationMessage,
                    ItemMessage = itemMessage
                };

                gossipList.Add(nextGossip);
            }
            return gossipList;
        }

        public static List<MessageEntry> MakeGossipQuotes(SettingsObject settings, List<ItemObject> items, Random random)
        {
            if (!settings.EnableGossipHints)
                return new List<MessageEntry>();

            var GossipList = GetGossipList();

            var unusedItems = new List<ItemObject>();
            var competitiveHints = new List<string>();
            var itemsInRegions = new Dictionary<string, List<ItemObject>>();
            var itemsRequiredByLogic = new List<int>(); // todo
            foreach (var item in items)
            {
                if (!item.ReplacesAnotherItem)
                {
                    continue;
                }

                if (settings.ClearHints)
                {
                    // skip free items
                    if (ItemUtils.IsStartingItem(item.ReplacesItemId))
                    {
                        continue;
                    }
                }

                // skip non-randomized items.
                if (settings.UseCustomItemList)
                {
                    if (!settings.CustomItemList.Contains(ItemUtils.SubtractItemOffset(item.ID)))
                    {
                        continue;
                    }
                }
                else
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

                if ((ItemUtils.IsHeartPiece(item.ID) || ItemUtils.IsOtherItem(item.ID)) && (settings.ClearHints || random.Next(8) != 0))
                {
                    continue;
                }

                if (settings.GossipHintStyle == GossipHintStyle.Competitive)
                {
                    var itemRegion = Items.HINT_REGIONS[item.ReplacesItemId];
                    if (!itemsInRegions.ContainsKey(itemRegion))
                    {
                        itemsInRegions[itemRegion] = new List<ItemObject>();
                    }
                    itemsInRegions[itemRegion].Add(item);

                    if (!Gossip.GuaranteedLocationHints.Contains(item.ReplacesItemId))
                    {
                        continue;
                    }

                    unusedItems.Add(item);
                }

                unusedItems.Add(item);
            }

            foreach (var kvp in itemsInRegions)
            {
                var regionIsWayOfTheHero = kvp.Value.Any(io => itemsRequiredByLogic.Contains(io.ID));

                ushort soundEffectId = 0x690C; // grandma curious
                string start = Gossip.MessageStartSentences.Random(random);

                string sfx = $"{(char)((soundEffectId >> 8) & 0xFF)}{(char)(soundEffectId & 0xFF)}";
                var locationMessage = kvp.Key;
                var mid = "is";
                var itemMessage = regionIsWayOfTheHero
                    ? "on the Way of the Hero"
                    : "a foolish choice";

                competitiveHints.Add($"\x1E{sfx}{start} \x01{locationMessage}\x00 {mid} \x06{itemMessage}\x00...\xBF".Wrap(35, "\x11"));
            }

            List<MessageEntry> finalHints = new List<MessageEntry>();

            foreach (var gossipQuote in Enum.GetValues(typeof(GossipQuote)).Cast<GossipQuote>().OrderBy(gq => random.Next()))
            {
                var isMoonGossipStone = gossipQuote >= GossipQuote.MoonMaskTruth; // or maybe check presence of GossipAlreadyAcquiredTextIdAttribute
                var restrictionAttributes = gossipQuote.GetAttributes<GossipRestrictAttribute>().ToList();
                ItemObject item = null;
                while (item == null)
                {
                    if (restrictionAttributes.Any() && (isMoonGossipStone || settings.GossipHintStyle == GossipHintStyle.Relevant))
                    {
                        var chosen = restrictionAttributes.Random(random);
                        var candidateItem = chosen.Type == GossipRestrictAttribute.RestrictionType.Item
                            ? items.Single(io => io.ID == chosen.Id)
                            : items.Single(io => io.ReplacesItemId == chosen.Id);
                        if (isMoonGossipStone || unusedItems.Contains(candidateItem))
                        {
                            item = candidateItem;
                        }
                        else
                        {
                            restrictionAttributes.Remove(chosen);
                        }
                    }
                    else if (unusedItems.Any())
                    {
                        item = unusedItems.Random(random);
                    }
                    else
                    {
                        break;
                    }
                }

                if (!isMoonGossipStone)
                {
                    unusedItems.Remove(item);
                }

                string messageText = null;
                if (item != null)
                {
                    ushort soundEffectId = 0x690C; // grandma curious
                    string itemName = null;
                    string locationName = null;
                    if (settings.ClearHints)
                    {
                        itemName = Items.ITEM_NAMES[item.ID];
                        locationName = Items.LOCATION_NAMES[item.ReplacesItemId];
                    }
                    else
                    {
                        var itemId = ItemUtils.SubtractItemOffset(item.ID);
                        var locationId = ItemUtils.SubtractItemOffset(item.ReplacesItemId);
                        if (isMoonGossipStone || settings.GossipHintStyle == GossipHintStyle.Competitive || random.Next(100) >= 5) // 5% chance of fake/junk hint if it's not a moon gossip stone or competitive style
                        {
                            itemName = GossipList[itemId].ItemMessage.Random(random);
                            locationName = GossipList[locationId].LocationMessage.Random(random);
                        }
                        else
                        {
                            if (random.Next(2) == 0) // 50% chance for fake hint. otherwise default to junk hint.
                            {
                                soundEffectId = 0x690A; // grandma laugh
                                itemName = GossipList[itemId].ItemMessage.Random(random);
                                locationName = GossipList.Random(random).LocationMessage.Random(random);
                            }
                        }
                    }
                    if (itemName != null && locationName != null)
                    {
                        messageText = BuildGossipQuote(soundEffectId, locationName, itemName, random);
                    }
                }
                if (messageText == null)
                {
                    if (competitiveHints.Any())
                    {
                        messageText = competitiveHints.Random(random);
                        competitiveHints.Remove(messageText);
                    }
                    else
                    {
                        messageText = Gossip.JunkMessages.Random(random);
                    }
                }

                finalHints.Add(new MessageEntry()
                {
                    Id = (ushort)gossipQuote,
                    Message = messageText,
                    Header = MessageHeader.ToArray()
                });

                var alreadyAcquired = gossipQuote.GetAttribute<GossipAlreadyAcquiredTextIdAttribute>();
                if (alreadyAcquired != null)
                {
                    ushort soundEffectId = 0x690C; // grandma curious
                    var itemName = Items.ITEM_NAMES[item.ID];
                    var locationName = Items.LOCATION_NAMES[item.ReplacesItemId];
                    messageText = BuildGossipQuote(soundEffectId, locationName, itemName, random);
                    finalHints.Add(new MessageEntry()
                    {
                        Id = alreadyAcquired.AlreadyAcquiredTextId,
                        Message = messageText,
                        Header = MessageHeader.ToArray()
                    });
                }
            }

            return finalHints;
        }
        
        private static string BuildGossipQuote(ushort soundEffectId, string locationMessage, string itemMessage, Random random)
        {
            int startIndex = random.Next(Gossip.MessageStartSentences.Count);
            int midIndex = random.Next(Gossip.MessageMidSentences.Count);
            string start = Gossip.MessageStartSentences[startIndex];
            string mid = Gossip.MessageMidSentences[midIndex];

            string sfx = $"{(char)((soundEffectId >> 8) & 0xFF)}{(char)(soundEffectId & 0xFF)}";

            return $"\x1E{sfx}{start} \x01{locationMessage}\x00 {mid} \x06{itemMessage}\x00...\xBF".Wrap(35, "\x11");
        }
    }
}