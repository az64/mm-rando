using MMRando.Attributes;
using MMRando.Extensions;
using MMRando.GameObjects;
using MMRando.Models;
using MMRando.Models.Rom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace MMRando.Utils
{
    public static class MessageUtils
    {
        static ReadOnlyCollection<byte> MessageHeader
            = new ReadOnlyCollection<byte>(new byte[] {
                2, 0, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
        });

        public static List<MessageEntry> MakeGossipQuotes(RandomizedResult randomizedResult)
        {
            if (randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Default)
                return new List<MessageEntry>();

            var randomizedItems = new List<ItemObject>();
            var competitiveHints = new List<string>();
            var itemsInRegions = new Dictionary<string, List<ItemObject>>();
            foreach (var item in randomizedResult.ItemList)
            {
                if (item.NewLocation == null)
                {
                    continue;
                }

                if (randomizedResult.Settings.ClearHints)
                {
                    // skip free items
                    if (ItemUtils.IsStartingLocation(item.NewLocation.Value))
                    {
                        continue;
                    }
                }

                if (!item.IsRandomized)
                {
                    continue;
                }

                var itemName = item.Item.Name();
                if (randomizedResult.Settings.GossipHintStyle != GossipHintStyle.Competitive 
                    && (itemName.Contains("Heart") || itemName.Contains("Rupee"))
                    && (randomizedResult.Settings.ClearHints || randomizedResult.Random.Next(8) != 0))
                {
                    continue;
                }

                if (randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Competitive)
                {
                    var preventRegions = new List<string> { "The Moon", "Bottle Catch", "Misc" };
                    var itemRegion = item.NewLocation.Value.Region();
                    if (!string.IsNullOrWhiteSpace(itemRegion) && !preventRegions.Contains(itemRegion) && (randomizedResult.Settings.AddSongs || !ItemUtils.IsSong(item.Item)))
                    {
                        if (!itemsInRegions.ContainsKey(itemRegion))
                        {
                            itemsInRegions[itemRegion] = new List<ItemObject>();
                        }
                        itemsInRegions[itemRegion].Add(item);
                    }

                    var competitiveHintInfo = item.NewLocation.Value.GetAttribute<GossipCompetitiveHintAttribute>();
                    if (competitiveHintInfo == null)
                    {
                        continue;
                    }

                    if (competitiveHintInfo.IsOnlyForUsefulItems && !randomizedResult.ItemsRequiredForMoonAccess.Contains(item.Item))
                    {
                        continue;
                    }
                }

                randomizedItems.Add(item);
            }

            var unusedItems = randomizedItems.ToList();

            if (randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Competitive)
            {
                unusedItems.AddRange(randomizedItems);
                var requiredHints = new List<string>();
                var nonRequiredHints = new List<string>();
                foreach (var kvp in itemsInRegions)
                {
                    bool regionHasRequiredItem;
                    if (kvp.Value.Any(io => !io.Item.Name().Contains("Heart") && !ItemUtils.IsStrayFairy(io.Item) && !ItemUtils.IsSkulltulaToken(io.Item) && randomizedResult.ItemsRequiredForMoonAccess.Contains(io.Item)))
                    {
                        regionHasRequiredItem = true;
                    }
                    else if (!kvp.Value.Any(io => !io.Item.Name().Contains("Heart") && randomizedResult.AllItemsOnPathToMoon.Contains(io.Item)))
                    {
                        regionHasRequiredItem = false;
                    }
                    else
                    {
                        continue;
                    }

                    ushort soundEffectId = 0x690C; // grandma curious
                    string start = Gossip.MessageStartSentences.Random(randomizedResult.Random);

                    string sfx = $"{(char)((soundEffectId >> 8) & 0xFF)}{(char)(soundEffectId & 0xFF)}";
                    var locationMessage = kvp.Key;
                    var mid = "is";
                    var itemMessage = regionHasRequiredItem
                        ? "on the Way of the Hero"
                        : "a foolish choice";
                    var list = regionHasRequiredItem
                        ? requiredHints
                        : nonRequiredHints;

                    list.Add($"\x1E{sfx}{start} \x01{locationMessage}\x00 {mid} \x06{itemMessage}\x00...\xBF".Wrap(35, "\x11"));
                }

                var collectionMessageFormat = "\x1E\x69\x0C{0} \u0001collecting {1}\u0000 is \u0006on the Way of the Hero\u0000...\xBF";
                if (randomizedResult.Settings.AddSkulltulaTokens)
                {
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Swamp Skulltula Spirit"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Swamp Skulltula Spirits").Wrap(35, "\x11"));
                    }
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Ocean Skulltula Spirit"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Ocean Skulltula Spirits").Wrap(35, "\x11"));
                    }
                }
                
                if (randomizedResult.Settings.AddStrayFairies)
                {
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Woodfall Stray Fairy"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Woodfall Stray Fairies").Wrap(35, "\x11"));
                    }
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Snowhead Stray Fairy"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Snowhead Stray Fairies").Wrap(35, "\x11"));
                    }
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Great Bay Stray Fairy"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Great Bay Stray Fairies").Wrap(35, "\x11"));
                    }
                    if (randomizedResult.ItemsRequiredForMoonAccess.Any(item => item.Name() == "Stone Tower Stray Fairy"))
                    {
                        competitiveHints.Add(string.Format(collectionMessageFormat, Gossip.MessageStartSentences.Random(randomizedResult.Random), "Stone Tower Stray Fairies").Wrap(35, "\x11"));
                    }
                }

                var numberOfRequiredHints = 3;
                var numberOfNonRequiredHints = 2;

                for (var i = 0; i < numberOfRequiredHints; i++)
                {
                    var chosen = requiredHints.RandomOrDefault(randomizedResult.Random);
                    if (chosen != null)
                    {
                        requiredHints.Remove(chosen);
                        competitiveHints.Add(chosen);
                        competitiveHints.Add(chosen);
                    }
                }

                for (var i = 0; i < numberOfNonRequiredHints; i++)
                {
                    var chosen = nonRequiredHints.RandomOrDefault(randomizedResult.Random);
                    if (chosen != null)
                    {
                        nonRequiredHints.Remove(chosen);
                        competitiveHints.Add(chosen);
                        competitiveHints.Add(chosen);
                    }
                }
            }

            List<MessageEntry> finalHints = new List<MessageEntry>();

            foreach (var gossipQuote in Enum.GetValues(typeof(GossipQuote)).Cast<GossipQuote>().OrderBy(gq => randomizedResult.Random.Next()))
            {
                string messageText = null;
                var isMoonGossipStone = gossipQuote.ToString().StartsWith("Moon");
                if (!isMoonGossipStone && competitiveHints.Any())
                {
                    messageText = competitiveHints.Random(randomizedResult.Random);
                    competitiveHints.Remove(messageText);
                }

                if (messageText == null)
                {
                    var restrictionAttributes = gossipQuote.GetAttributes<GossipRestrictAttribute>().ToList();
                    ItemObject item = null;
                    var forceClear = false;
                    while (item == null)
                    {
                        if (restrictionAttributes.Any() && (isMoonGossipStone || randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Relevant))
                        {
                            var chosen = restrictionAttributes.Random(randomizedResult.Random);
                            var candidateItem = chosen.Type == GossipRestrictAttribute.RestrictionType.Item
                                ? randomizedResult.ItemList.Single(io => io.Item == chosen.Item)
                                : randomizedResult.ItemList.Single(io => io.NewLocation == chosen.Item);
                            if (isMoonGossipStone || unusedItems.Contains(candidateItem))
                            {
                                item = candidateItem;
                                forceClear = chosen.ForceClear;
                            }
                            else
                            {
                                restrictionAttributes.Remove(chosen);
                            }
                        }
                        else if (unusedItems.Any())
                        {
                            if (randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Competitive)
                            {
                                item = unusedItems.GroupBy(io => io.NewLocation.Value.GetAttribute<GossipCompetitiveHintAttribute>().Priority)
                                    .OrderByDescending(g => g.Key)
                                    .First()
                                    .ToList()
                                    .Random(randomizedResult.Random);
                            }
                            else
                            {
                                item = unusedItems.Random(randomizedResult.Random);
                            }
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

                    if (item != null)
                    {
                        ushort soundEffectId = 0x690C; // grandma curious
                        string itemName = null;
                        string locationName = null;
                        if (forceClear || randomizedResult.Settings.ClearHints)
                        {
                            itemName = item.Item.Name();
                            locationName = item.NewLocation.Value.Location();
                        }
                        else
                        {
                            if (isMoonGossipStone || randomizedResult.Settings.GossipHintStyle == GossipHintStyle.Competitive || randomizedResult.Random.Next(100) >= 5) // 5% chance of fake/junk hint if it's not a moon gossip stone or competitive style
                            {
                                itemName = item.Item.ItemHints().Random(randomizedResult.Random);
                                locationName = item.NewLocation.Value.LocationHints().Random(randomizedResult.Random);
                            }
                            else
                            {
                                if (randomizedResult.Random.Next(2) == 0) // 50% chance for fake hint. otherwise default to junk hint.
                                {
                                    soundEffectId = 0x690A; // grandma laugh
                                    itemName = item.Item.ItemHints().Random(randomizedResult.Random);
                                    locationName = randomizedItems.Random(randomizedResult.Random).Item.LocationHints().Random(randomizedResult.Random);
                                }
                            }
                        }
                        if (itemName != null && locationName != null)
                        {
                            messageText = BuildGossipQuote(soundEffectId, locationName, itemName, randomizedResult.Random);
                        }
                    }
                }

                if (messageText == null)
                {
                    messageText = Gossip.JunkMessages.Random(randomizedResult.Random);
                }

                finalHints.Add(new MessageEntry()
                {
                    Id = (ushort)gossipQuote,
                    Message = messageText,
                    Header = MessageHeader.ToArray()
                });
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

        public static string BuildShopDescriptionMessage(string title, int cost, string description)
        {
            return $"\x01{title}: {cost} Rupees\x11\x00{description.Wrap(35, "\x11")}\x1A\xBF";
        }

        public static string BuildShopPurchaseMessage(string title, int cost, Item item)
        {
            return $"{title}: {cost} Rupees\x11 \x11\x02\xC2I'll buy {GetPronoun(item)}\x11No thanks\xBF";
        }

        public static string GetArticle(Item item, string indefiniteArticle = null)
        {
            var shopTexts = item.ShopTexts();
            return shopTexts.IsMultiple
                ? ""
                : shopTexts.IsDefinite
                    ? "the "
                    : indefiniteArticle ?? (Regex.IsMatch(item.Name(), "^[aeiou]", RegexOptions.IgnoreCase)
                        ? "an "
                        : "a ");
        }

        public static string GetPronoun(Item item)
        {
            var shopTexts = item.ShopTexts();
            var itemAmount = Regex.Replace(item.Name(), "[^0-9]", "");
            return shopTexts.IsMultiple && !string.IsNullOrWhiteSpace(itemAmount)
                ? "them"
                : "it";
        }

        public static string GetPronounOrAmount(Item item, string it = " It")
        {
            var shopTexts = item.ShopTexts();
            var itemAmount = Regex.Replace(item.Name(), "[^0-9]", "");
            return shopTexts.IsMultiple
                ? string.IsNullOrWhiteSpace(itemAmount)
                    ? it
                    : " " + itemAmount
                : shopTexts.IsDefinite
                    ? it
                    : " One";
        }

        public static string GetVerb(Item item)
        {
            var shopTexts = item.ShopTexts();
            var itemAmount = Regex.Replace(item.Name(), "[^0-9]", "");
            return shopTexts.IsMultiple && !string.IsNullOrWhiteSpace(itemAmount)
                ? "are"
                : "is";
        }

        public static string GetFor(Item item)
        {
            var shopTexts = item.ShopTexts();
            return shopTexts.IsDefinite
                ? "is"
                : "for";
        }

        public static string GetAlternateName(Item item)
        {
            return Regex.Replace(item.Name(), "[0-9]+ ", "");
        }
    }
}