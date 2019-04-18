using System;
using System.Collections.Generic;

namespace MMRando {
    public class ValidSeedChecker {
        private List<mmrMain.ItemObject> _cleanItemList;

        // Build a deep copy clone to check dependancies and have a clean item list available
        // for randomization attempts if needed. The ItemShuffle() mutates the list so just
        // replacing the 'Replaces' field of each item would result in corrupted item list.
        public ValidSeedChecker(List<mmrMain.ItemObject> itemRuleset) {
            _cleanItemList = DeepCopyItemList(itemRuleset);
        }

        private List<mmrMain.ItemObject> DeepCopyItemList(List<mmrMain.ItemObject> itemList) {
            List <mmrMain.ItemObject> newList = new List<mmrMain.ItemObject>(itemList.Count);
            foreach(mmrMain.ItemObject oldItem in itemList) {
                mmrMain.ItemObject newItem = new mmrMain.ItemObject();
                newList.Add(newItem);

                newItem.ID = oldItem.ID;

                if(oldItem.Dependence != null) {
                    newItem.Dependence = new List<int>(oldItem.Dependence.Count);
                    foreach(int dependanceID in oldItem.Dependence) {
                        newItem.Dependence.Add(dependanceID);
                    }
                }

                if(oldItem.Conditional != null) {
                    newItem.Conditional = new List<List<int>>(oldItem.Conditional.Count);
                    foreach(List<int> oldConditionalList in oldItem.Conditional) {
                        List<int> newConditionalList = new List<int>();
                        newItem.Conditional.Add(newConditionalList);
                        foreach(int conditionalID in oldConditionalList) {
                            newConditionalList.Add(conditionalID);
                        }
                    }
                }

                newItem.Time_Needed = oldItem.Time_Needed;
                newItem.Time_Available = oldItem.Time_Available;

                newItem.Replaces = oldItem.Replaces;

                newItem.Cannot_Require = new List<int>(oldItem.Cannot_Require.Count);
                foreach(int cannotRequireID in oldItem.Cannot_Require) {
                    newItem.Cannot_Require.Add(cannotRequireID);
                }
            }

            return newList;
        }

        public List<mmrMain.ItemObject> GetCleanItemListCopy() {
            return DeepCopyItemList(_cleanItemList);
        }

        // Iterate over the item locations in the seed in waves and check
        // if the locations are reachable with the items we have. This should
        // emulate a player trying to gather all available items before moving
        // on to look in past locations.
        public bool IsValidSeed(List<mmrMain.ItemObject> items) {
            HashSet<int> obtainableItems = new HashSet<int>();

            // Continue searching until no new items are found from a pass
            int oldCount = -1;
            while(obtainableItems.Count > oldCount) {
                oldCount = obtainableItems.Count;

                foreach(mmrMain.ItemObject itemData in items) {
                    if(obtainableItems.Contains(itemData.ID)) {
                        continue;
                    }

                    // If 'Replaces' is -1 then it is a location or special value that isn't moved.
                    // Otherwise check if player obtained all the items necessary to reach where the
                    // item was placed.
                    bool canObtain = false;
                    if(itemData.Replaces == -1) {
                        canObtain = AllDependanciesObtained(obtainableItems, itemData);
                        canObtain &= AnyConditionsObtained(obtainableItems, itemData);
                    } else {
                        canObtain = AllDependanciesObtained(obtainableItems, _cleanItemList[itemData.Replaces]);
                        canObtain &= AnyConditionsObtained(obtainableItems, _cleanItemList[itemData.Replaces]);
                    }

                    if(canObtain) {
                        obtainableItems.Add(itemData.ID);
                    }
                }
            }

            // A valid seed assumes all items are obtainable
            return obtainableItems.Count == items.Count;
        }

        private static bool AllDependanciesObtained(HashSet<int> obtainedItems, mmrMain.ItemObject checkItem) {
            if(checkItem.Dependence == null) {
                return true;
            }

            foreach(int dependance in checkItem.Dependence) {
                if(!obtainedItems.Contains(dependance)) {
                    return false;
                }
            }

            return true;
        }

        private static bool AnyConditionsObtained(HashSet<int> obtainedItems, mmrMain.ItemObject checkItem) {
            if(checkItem.Conditional == null || checkItem.Conditional.Count == 0) {
                return true;
            }

            // Looks for at least one row where all items in that row have been obtained
            foreach(List<int> conditions in checkItem.Conditional) {
                bool allConditionsInRowMet = true;

                foreach(int condition in conditions) {
                    if(!obtainedItems.Contains(condition)) {
                        allConditionsInRowMet = false;
                        break;
                    }
                }

                if(allConditionsInRowMet) {
                    return true;
                }
            }

            return false;
        }
    }
}
