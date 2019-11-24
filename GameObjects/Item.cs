using MMRando.Attributes;
using MMRando.Models.Settings;

namespace MMRando.GameObjects
{
    public enum Item
    {
        // free
        [StartingItem(0xC5CE41, 0x32)]
        [ItemName("Deku Mask"), LocationName("Starting Item"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a woodland spirit")]
        [ShopText("Wear it to assume Deku form.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x78)]
        MaskDeku,

        // items
        [StartingItem(0xC5CE25, 0x01)]
        [StartingItem(0xC5CE6F, 0x01)]
        [ItemName("Hero's Bow"), LocationName("Hero's Bow Chest"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("Use it to shoot arrows.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x02223000 + 0xAA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x22)]
        ItemBow,

        [StartingItem(0xC5CE26, 0x02)]
        [ItemName("Fire Arrow"), LocationName("Fire Arrow Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("the power of fire", "a magical item")]
        [ShopText("Arm your bow with arrows that burst into flame.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x02336000 + 0xCA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x25)]
        ItemFireArrow,

        [StartingItem(0xC5CE27, 0x03)]
        [ItemName("Ice Arrow"), LocationName("Ice Arrow Chest"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("the power of ice", "a magical item")]
        [ShopText("Arm your bow with arrows that freeze.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x0292F000 + 0x11E, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x26)]
        ItemIceArrow,

        [StartingItem(0xC5CE28, 0x04)]
        [ItemName("Light Arrow"), LocationName("Light Arrow Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("the power of light", "a magical item")]
        [ShopText("Arm your bow with arrows infused with sacred light.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x0212B000 + 0xB2, ChestAttribute.AppearanceType.AppearsSwitch, 0x02192000 + 0x8E)]
        [GetItemIndex(0x27)]
        ItemLightArrow,

        [StartingItem(0xC5CE2A, 0x06)]
        [StartingItem(0xC5CE6F, 0x08)]
        [ItemName("Bomb Bag"), LocationName("Bomb Bag Purchase"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town shop"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 0)]
        [ShopText("This can hold up to a maximum of 20 bombs.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x1B)]
        ItemBombBag,

        [Repeatable, Temporary, CycleRepeatable]
        //[StartingItem(0xC5CE2E, 0x0A)]
        [ItemName("Magic Bean"), LocationName("Bean Man"), Region(Region.DekuPalace)]
        [GossipLocationHint("a hidden merchant", "a gorging merchant"), GossipItemHint("a plant seed")]
        [ShopText("Plant it in soft soil.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x11E)]
        ItemMagicBean,

        [Repeatable, CycleRepeatable]
        //[StartingItem(0xC5CE30, 0x0C)]
        [ItemName("Powder Keg"), LocationName("Powder Keg Challenge"), Region(Region.GoronVillage)]
        [GossipLocationHint("a large goron"), GossipItemHint("gunpowder", "a dangerous item", "an explosive barrel")]
        [ShopText("Both its power and its size are immense!")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x123)]
        ItemPowderKeg,

        [StartingItem(0xC5CE31, 0x0D)]
        [ItemName("Pictobox"), LocationName("Koume"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a witch"), GossipItemHint("a light recorder", "a capture device")]
        [ShopText("Use it to snap pictographs.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x43)]
        ItemPictobox,

        [StartingItem(0xC5CE32, 0x0E)]
        [ItemName("Lens of Truth"), LocationName("Lens of Truth Chest"), Region(Region.GoronVillage)]
        [GossipLocationHint("a lonely peak"), GossipItemHint("eyeglasses", "the truth", "focused vision")]
        [ShopText("Uses magic to see what the naked eye cannot.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x02EB8000 + 0x9A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x42)]
        ItemLens,

        [StartingItem(0xC5CE33, 0x0F)]
        [ItemName("Hookshot"), LocationName("Hookshot Chest"), Region(Region.PiratesFortressInterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("a chain and grapple")]
        [ShopText("Use it to grapple objects.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x0238B000 + 0x14A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x41)]
        ItemHookshot,

        [StartingItem(0xC5CDED, 0x30)]
        [StartingItem(0xC5CDF4, 0x01)]
        [ItemName("Magic Power"), LocationName("Town Great Fairy Non-Human"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a magical being"), GossipItemHint("magic power")]
        [ShopText("Grants the ability to use magic.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12C)]
        FairyMagic,
        
        // todo allow as starting item
        [ItemName("Spin Attack"), LocationName("Woodfall Great Fairy"), Region(Region.Woodfall)]
        [GossipLocationHint("a magical being"), GossipItemHint("a magic attack"), GossipCompetitiveHint(3, nameof(SettingsObject.AddStrayFairies))]
        [ShopText("Increases the power of your spin attack.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12D)]
        FairySpinAttack,

        [StartingItem(0xC5CDED, 0x60)]
        [StartingItem(0xC5CDF4, 0x01)]
        [StartingItem(0xC5CDF5, 0x01)]
        [ItemName("Extended Magic Power"), LocationName("Snowhead Great Fairy"), Region(Region.Snowhead)]
        [GossipLocationHint("a magical being"), GossipItemHint("magic power"), GossipCompetitiveHint(3, nameof(SettingsObject.AddStrayFairies))]
        [ShopText("Grants the ability to use lots of magic.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12E)]
        FairyDoubleMagic,

        [StartingItem(0xC5CDF6, 0x01)]
        [StartingItem(0xC5CE87, 0x14)]
        [ItemName("Double Defense"), LocationName("Ocean Great Fairy"), Region(Region.ZoraCape)]
        [GossipLocationHint("a magical being"), GossipItemHint("magical defense"), GossipCompetitiveHint(3, nameof(SettingsObject.AddStrayFairies))]
        [ShopText("Take half as much damage from enemies.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12F)]
        FairyDoubleDefense,

        [StartingItem(0xC5CE34, 0x10)]
        [ItemName("Great Fairy's Sword"), LocationName("Ikana Great Fairy"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("a magical being"), GossipItemHint("a black rose", "a powerful blade"), GossipCompetitiveHint(3, nameof(SettingsObject.AddStrayFairies))]
        [ShopText("The most powerful sword has black roses etched in its blade.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x130)]
        ItemFairySword,

        //[StartingItem(0xC5CE36, 0x12)]
        [Repeatable, Temporary, Overwritable] // specially handled to turn into Red Potion on subsequent times
        [ItemName("Bottle with Red Potion"), LocationName("Kotake"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("the sleeping witch"), GossipItemHint("a vessel of health", "bottled fortitude")]
        [ShopText("Replenishes your life energy. Comes with an Empty Bottle.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x59)]
        ItemBottleWitch,

        //[StartingItem(0xC5CE37, 0x12)]
        [Repeatable, Temporary, Overwritable] // specially handled to turn into Milk on subsequent times
        [ItemName("Bottle with Milk"), LocationName("Aliens Defense"), Region(Region.RomaniRanch)]
        [GossipLocationHint("the ranch girl", "a good deed"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings. Comes with an Empty Bottle.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x60)]
        ItemBottleAliens,

        [RupeeRepeatable]
        //[StartingItem(0xC5CE38, 0x12)]
        [Repeatable, Temporary, Overwritable] // specially handled to turn into Gold Dust on subsequent times
        [ItemName("Bottle with Gold Dust"), LocationName("Goron Race"), Region(Region.TwinIslands)]
        [GossipLocationHint("a sporting event"), GossipItemHint("a gleaming powder"), GossipCompetitiveHint]
        [ShopText("It's very high quality. Comes with an Empty Bottle.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x6A)]
        ItemBottleGoronRace,

        //[StartingItem(0xC5CE39, 0x12)]
        [ItemName("Empty Bottle"), LocationName("Beaver Race #1"), Region(Region.ZoraCape)]
        [GossipLocationHint("a river dweller"), GossipItemHint("an empty vessel", "a glass container"), GossipCompetitiveHint(-2)]
        [ShopText("Carry various items in this.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x5A)]
        ItemBottleBeavers,

        //[StartingItem(0xC5CE3A, 0x12)]
        [ItemName("Empty Bottle"), LocationName("Dampe Digging"), Region(Region.IkanaGraveyard)]
        [GossipLocationHint("a fearful basement"), GossipItemHint("an empty vessel", "a glass container"), GossipCompetitiveHint]
        [ShopText("Carry various items in this.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x0261E000 + 0x1FE, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x64)]
        ItemBottleDampe,

        //[StartingItem(0xC5CE3B, 0x12)]
        [Repeatable, Temporary, Overwritable] // specially handled to turn into Chateau Romani on subsequent times
        [ItemName("Bottle with Chateau Romani"), LocationName("Madame Aroma in Bar"), Region(Region.EastClockTown)]
        [GossipLocationHint("an important lady"), GossipItemHint("a dairy product", "an adult beverage")]
        [ShopText("Drink it to get lasting stamina for your magic power. Comes with an Empty Bottle.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x6F)]
        ItemBottleMadameAroma,

        [StartingItem(0xC5CE71, 0x04)]
        [ItemName("Bombers' Notebook"), LocationName("Bombers' Hide and Seek"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a group of children", "a town game"), GossipItemHint("a handy notepad", "a quest logbook")]
        [ShopText("Allows you to keep track of people's schedules.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x50)]
        ItemNotebook,

        //upgrades
        [Repeatable]
        [StartingItem(0xC5CE21, 0x02)]
        [StartingItem(0xC5CE00, 0x4E)]
        [ItemName("Razor Sword"), LocationName("Mountain Smithy Day 1"), Region(Region.MountainVillage)]
        [GossipLocationHint("the mountain smith"), GossipItemHint("a sharp blade")]
        [ShopText("A sharp sword forged at the smithy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x38)]
        UpgradeRazorSword,

        [Downgradable, Repeatable]
        [StartingItem(0xC5CE21, 0x03)]
        [StartingItem(0xC5CE00, 0x4F)]
        [ItemName("Gilded Sword"), LocationName("Mountain Smithy Day 2"), Region(Region.MountainVillage)]
        [GossipLocationHint("the mountain smith"), GossipItemHint("a sharp blade")]
        [ShopText("A very sharp sword forged from gold dust.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x39)]
        UpgradeGildedSword,

        [Downgradable]
        [StartingItem(0xC5CE21, 0x20)]
        [ItemName("Mirror Shield"), LocationName("Mirror Shield Chest"), Region(Region.BeneathTheWell)]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a reflective guard", "echoing protection")]
        [ShopText("It can reflect certain rays of light.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x029FE000 + 0x1AA, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x33)]
        UpgradeMirrorShield,

        [RupeeRepeatable]
        [StartingItem(0xC5CE25, 0x01)]
        [StartingItem(0xC5CE6F, 0x02)]
        [ItemName("Large Quiver"), LocationName("Town Archery #1"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town activity"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("This can hold up to a maximum of 40 arrows.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x23)]
        UpgradeBigQuiver,

        [RupeeRepeatable]
        [Downgradable]
        [StartingItem(0xC5CE25, 0x01)]
        [StartingItem(0xC5CE6F, 0x03)]
        [ItemName("Largest Quiver"), LocationName("Swamp Archery #1"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("This can hold up to a maximum of 50 arrows.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x24)]
        UpgradeBiggestQuiver,

        [Downgradable]
        [StartingItem(0xC5CE2A, 0x06)]
        [StartingItem(0xC5CE6F, 0x10)]
        [ItemName("Big Bomb Bag"), LocationName("Big Bomb Bag Purchase"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town shop"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x52)]
        [ShopRoom(ShopRoomAttribute.Room.CuriosityShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.CuriosityShop, 2)]
        [ShopText("This can hold up to a maximum of 30 bombs.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x1C)]
        UpgradeBigBombBag,

        [Downgradable]
        [StartingItem(0xC5CE2A, 0x06)]
        [StartingItem(0xC5CE6F, 0x18)]
        [ItemName("Biggest Bomb Bag"), LocationName("Biggest Bomb Bag Purchase"), Region(Region.GoronVillage)]
        [GossipLocationHint("a northern merchant"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopText("This can hold up to a maximum of 40 bombs.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x1D)]
        UpgradeBiggestBombBag,

        [StartingItem(0xC5CE6E, 0x10)]
        [ItemName("Adult Wallet"), LocationName("Bank Reward #1"), Region(Region.WestClockTown)]
        [GossipLocationHint("a keeper of wealth"), GossipItemHint("a coin case", "great wealth")]
        [ShopText("This can hold up to a maximum of 200 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x08)]
        UpgradeAdultWallet,

        [Downgradable]
        [StartingItem(0xC5CE6E, 0x20)]
        [ItemName("Giant Wallet"), LocationName("Ocean Spider House Day 1 Reward"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a gold spider"), GossipItemHint("a coin case", "great wealth"), GossipCompetitiveHint(0, nameof(SettingsObject.AddSkulltulaTokens))]
        [ShopText("This can hold up to a maximum of 500 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x09)]
        UpgradeGiantWallet,

        //trades
        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Moon's Tear"), LocationName("Astronomy Telescope"), Region(Region.TerminaField)]
        [GossipLocationHint("a falling star"), GossipItemHint("a lunar teardrop", "celestial sadness")]
        [ShopText("A shining stone from the moon.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x96)]
        TradeItemMoonTear,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Land Title Deed"), LocationName("Clock Town Scrub Trade"), Region(Region.SouthClockTown)]
        [GossipLocationHint("a town merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Clock Town.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x97)]
        TradeItemLandDeed,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Swamp Title Deed"), LocationName("Swamp Scrub Trade"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a southern merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Southern Swamp.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x98)]
        TradeItemSwampDeed,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Mountain Title Deed"), LocationName("Mountain Scrub Trade"), Region(Region.GoronVillage)]
        [GossipLocationHint("a northern merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower near Goron Village.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x99)]
        TradeItemMountainDeed,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Ocean Title Deed"), LocationName("Ocean Scrub Trade"), Region(Region.ZoraHall)]
        [GossipLocationHint("a western merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Zora Hall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x9A)]
        TradeItemOceanDeed,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Room Key"), LocationName("Inn Reservation"), Region(Region.EastClockTown)]
        [GossipLocationHint("checking in", "check-in"), GossipItemHint("a door opener", "a lock opener")]
        [ShopText("With this, you can go in and out of the Stock Pot Inn at night.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xA0)]
        TradeItemRoomKey,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Letter to Kafei"), LocationName("Midnight Meeting"), Region(Region.EastClockTown)]
        [GossipLocationHint("a late meeting"), GossipItemHint("a lover's plight", "a lover's letter")]
        [ShopText("A love letter from Anju to Kafei.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xAA)]
        TradeItemKafeiLetter,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Pendant of Memories"), LocationName("Kafei"), Region(Region.LaundryPool)]
        [GossipLocationHint("a posted letter"), GossipItemHint("a cherished necklace", "a symbol of trust")]
        [ShopText("Kafei's symbol of trust for Anju.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xAB)]
        TradeItemPendant,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Letter to Mama"), LocationName("Curiosity Shop Man #2"), Region(Region.LaundryPool)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("an important note", "a special delivery")]
        [ShopText("It's a parcel for Kafei's mother.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xA1)]
        TradeItemMamaLetter,

        //notebook hp
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Mayor"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town leader", "an upstanding figure"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x03)]
        HeartPieceNotebookMayor,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Postman's Game"), Region(Region.WestClockTown)]
        [GossipLocationHint("a hard worker", "a delivery person"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xCE)]
        HeartPieceNotebookPostman,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Rosa Sisters"), Region(Region.WestClockTown)]
        [GossipLocationHint("traveling sisters", "twin entertainers"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x2B)]
        HeartPieceNotebookRosa,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Toilet Hand"), Region(Region.EastClockTown)]
        [GossipLocationHint("a mystery appearance", "a strange palm"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x2C)]
        HeartPieceNotebookHand,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Grandma Short Story"), Region(Region.EastClockTown)]
        [GossipLocationHint("an old lady"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x2D)]
        HeartPieceNotebookGran1,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Grandma Long Story"), Region(Region.EastClockTown)]
        [GossipLocationHint("an old lady"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x2F)]
        HeartPieceNotebookGran2,

        //other hp
        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Keaton Quiz"), Region(Region.NorthClockTown)]
        [GossipLocationHint("the ghost of a fox", "a mysterious fox"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x30)]
        HeartPieceKeatonQuiz,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Deku Playground Three Days"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a game for scrubs", "a playground", "a town game"), GossipItemHint("a segment of health"), GossipCompetitiveHint]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x31)]
        HeartPieceDekuPlayground,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Town Archery #2"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health"), GossipCompetitiveHint(1)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x90)]
        HeartPieceTownArchery,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Honey and Darling Three Days"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health"), GossipCompetitiveHint(-2)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x94)]
        HeartPieceHoneyAndDarling,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Swordsman's School"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x9F)]
        HeartPieceSwordsmanSchool,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Postbox"), Region(Region.SouthClockTown)]
        [GossipLocationHint("an information carrier", "a correspondence box"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA2)]
        HeartPiecePostBox,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Gossip Stones"), Region(Region.TerminaField)]
        [GossipLocationHint("mysterious stones"), GossipItemHint("a segment of health"), GossipCompetitiveHint(-2)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA3)]
        HeartPieceTerminaGossipStones,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Business Scrub Purchase"), Region(Region.TerminaField)]
        [GossipLocationHint("a hidden merchant"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA5)]
        HeartPieceTerminaBusinessScrub,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Swamp Archery #2"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health"), GossipCompetitiveHint(1)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA6)]
        HeartPieceSwampArchery,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Pictograph Contest Winner"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA7)]
        HeartPiecePictobox,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Boat Archery"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health"), GossipCompetitiveHint]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xA8)]
        HeartPieceBoatArchery,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Frog Choir"), Region(Region.MountainVillage)]
        [GossipLocationHint("a reunion", "a chorus", "an amphibian choir"), GossipItemHint("a segment of health"), GossipCompetitiveHint(2)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xAC)]
        HeartPieceChoir,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Beaver Race #2"), Region(Region.ZoraCape)]
        [GossipLocationHint("a river dweller", "a race in the water"), GossipItemHint("a segment of health"), GossipCompetitiveHint(1)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xAD)]
        HeartPieceBeaverRace,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Seahorses"), Region(Region.PinnacleRock)]
        [GossipLocationHint("a reunion"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xAE)]
        HeartPieceSeaHorse,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Fisherman Game"), Region(Region.GreatBayCoast), GossipCompetitiveHint(-1)]
        [GossipLocationHint("an ocean game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xAF)]
        HeartPieceFishermanGame,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Evan"), Region(Region.ZoraHall)]
        [GossipLocationHint("a muse", "a composition", "a musician", "plagiarism"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB0)]
        HeartPieceEvan,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Dog Race"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a sporting event"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB1)]
        HeartPieceDogRace,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Poe Hut"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("a game of ghosts"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB2)]
        HeartPiecePoeHut,

        [RupeeRepeatable]
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Treasure Chest Game Goron"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x00F43F10 + 0xFAA, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x17)]
        HeartPieceTreasureChestGame,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Peahat Grotto"), Region(Region.TerminaField)]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02ED3000 + 0x76, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x18)]
        HeartPiecePeahat,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Dodongo Grotto"), Region(Region.TerminaField)]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02EBD000 + 0x76, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x20)]
        HeartPieceDodong,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Woodfall Bridge Chest"), Region(Region.Woodfall)]
        [GossipLocationHint("the swamp lands", "an exposed chest"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02884000 + 0x252, ChestAttribute.AppearanceType.Normal, 0x02884000 + 0xA52)]
        [GetItemIndex(0x29)]
        HeartPieceWoodFallChest,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Twin Islands Underwater Ramp Chest"), Region(Region.TwinIslands)]
        [GossipLocationHint("a spring treasure", "a defrosted land", "a submerged chest"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C23000 + 0x2B6, ChestAttribute.AppearanceType.Normal, 0x02C34000 + 0x19A)]
        [GetItemIndex(0x2E)]
        HeartPieceTwinIslandsChest,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Ocean Spider House Chest"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("the strange masks", "coloured faces"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x024DB000 + 0x76, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x14)]
        HeartPieceOceanSpiderHouse,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Iron Knuckle Chest"), Region(Region.IkanaGraveyard)]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x01FAB000 + 0xBA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x44)]
        HeartPieceKnuckle,

        //mask
        [StartingItem(0xC5CE3C, 0x3E)]
        [ItemName("Postman's Hat"), LocationName("Postman's Freedom Reward"), Region(Region.EastClockTown)]
        [GossipLocationHint("a special delivery", "one last job"), GossipItemHint("a hard worker's hat")]
        [ShopText("You can look into mailboxes when you wear this.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x84)]
        MaskPostmanHat,

        [StartingItem(0xC5CE3D, 0x38)]
        [ItemName("All Night Mask"), LocationName("All Night Mask Purchase"), Region(Region.WestClockTown)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("insomnia"), GossipCompetitiveHint(0, nameof(SettingsObject.UpdateShopAppearance))]
        [ShopRoom(ShopRoomAttribute.Room.CuriosityShop, 0x54)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.CuriosityShop, 0)]
        [ShopText("When you wear it you don't get sleepy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x7E)]
        MaskAllNight,

        [StartingItem(0xC5CE3E, 0x47)]
        [ItemName("Blast Mask"), LocationName("Old Lady"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a good deed", "an old lady's struggle"), GossipItemHint("a dangerous mask")]
        [ShopText("Wear it and detonate it...")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8D)]
        MaskBlast,

        [StartingItem(0xC5CE3F, 0x45)]
        [ItemName("Stone Mask"), LocationName("Invisible Soldier"), Region(Region.RoadToIkana)]
        [GossipLocationHint("a hidden soldier", "a stone circle"), GossipItemHint("inconspicuousness")]
        [ShopText("Become as plain as stone so you can blend into your surroundings.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8B)]
        MaskStone,

        [StartingItem(0xC5CE40, 0x40)]
        [ItemName("Great Fairy's Mask"), LocationName("Town Great Fairy"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a magical being"), GossipItemHint("a friend of fairies")]
        [ShopText("The mask's hair will shimmer when you're close to a Stray Fairy.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x131)]
        MaskGreatFairy,

        [StartingItem(0xC5CE42, 0x3A)]
        [ItemName("Keaton Mask"), LocationName("Curiosity Shop Man #1"), Region(Region.LaundryPool)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("a popular mask", "a fox's mask")]
        [ShopText("The mask of the ghost fox, Keaton.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x80)]
        MaskKeaton,

        [StartingItem(0xC5CE43, 0x46)]
        [ItemName("Bremen Mask"), LocationName("Guru Guru"), Region(Region.LaundryPool)]
        [GossipLocationHint("a musician", "an entertainer"), GossipItemHint("a mask of leadership", "a bird's mask")]
        [ShopText("Wear it so young animals will mistake you for their leader.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8C)]
        MaskBremen,

        [StartingItem(0xC5CE44, 0x39)]
        [ItemName("Bunny Hood"), LocationName("Grog"), Region(Region.RomaniRanch)]
        [GossipLocationHint("an ugly but kind heart", "a lover of chickens"), GossipItemHint("the ears of the wild", "a rabbit's hearing")]
        [ShopText("Wear it to be filled with the speed and hearing of the wild.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x7F)]
        MaskBunnyHood,

        [StartingItem(0xC5CE45, 0x42)]
        [ItemName("Don Gero's Mask"), LocationName("Hungry Goron"), Region(Region.MountainVillage)]
        [GossipLocationHint("a hungry goron", "a person in need"), GossipItemHint("a conductor's mask", "an amphibious mask")]
        [ShopText("When you wear it, you can call the Frog Choir members together.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x88)]
        MaskDonGero,

        [RupeeRepeatable]
        [StartingItem(0xC5CE46, 0x48)]
        [ItemName("Mask of Scents"), LocationName("Butler"), Region(Region.DekuPalace)]
        [GossipLocationHint("a servant of royalty", "the royal servant"), GossipItemHint("heightened senses", "a pig's mask"), GossipCompetitiveHint(-1)]
        [ShopText("Wear it to heighten your sense of smell.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8E)]
        MaskScents,

        [StartingItem(0xC5CE48, 0x3C)]
        [ItemName("Romani's Mask"), LocationName("Cremia"), Region(Region.RomaniRanch)]
        [GossipLocationHint("the ranch lady", "an older sister"), GossipItemHint("proof of membership", "a cow's mask"), GossipCompetitiveHint]
        [ShopText("Wear it to show you're a member of the Milk Bar, Latte.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x82)]
        MaskRomani,

        [StartingItem(0xC5CE49, 0x3D)]
        [ItemName("Circus Leader's Mask"), LocationName("Gorman"), Region(Region.EastClockTown)]
        [GossipLocationHint("an entertainer", "a miserable leader"), GossipItemHint("a mask of sadness")]
        [ShopText("People related to Gorman will react to this.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x83)]
        MaskCircusLeader,

        [StartingItem(0xC5CE4A, 0x37)]
        [ItemName("Kafei's Mask"), LocationName("Madame Aroma in Office"), Region(Region.EastClockTown)]
        [GossipLocationHint("an important lady", "an esteemed woman"), GossipItemHint("the mask of a missing one", "a son's mask")]
        [ShopText("Wear it to inquire about Kafei's whereabouts.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8F)]
        MaskKafei,

        [StartingItem(0xC5CE4B, 0x3F)]
        [ItemName("Couple's Mask"), LocationName("Anju and Kafei"), Region(Region.EastClockTown)]
        [GossipLocationHint("a reunion", "a lovers' reunion"), GossipItemHint("a sign of love", "the mark of a couple"), GossipCompetitiveHint(2)]
        [ShopText("When you wear it, you can soften people's hearts.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x85)]
        MaskCouple,

        [StartingItem(0xC5CE4C, 0x36)]
        [ItemName("Mask of Truth"), LocationName("Swamp Spider House Reward"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a gold spider"), GossipItemHint("a piercing gaze"), GossipCompetitiveHint(0, nameof(SettingsObject.AddSkulltulaTokens))]
        [ShopText("Wear it to read the thoughts of Gossip Stones and animals.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x8A)]
        MaskTruth,

        [StartingItem(0xC5CE4E, 0x43)]
        [ItemName("Kamaro's Mask"), LocationName("Kamaro"), Region(Region.TerminaField)]
        [GossipLocationHint("a ghostly dancer", "a dancer"), GossipItemHint("dance moves")]
        [ShopText("Wear this to perform a mysterious dance.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x89)]
        MaskKamaro,

        [StartingItem(0xC5CE4F, 0x41)]
        [ItemName("Gibdo Mask"), LocationName("Pamela's Father"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("a healed spirit", "a lost father"), GossipItemHint("a mask of monsters")]
        [ShopText("Even a real Gibdo will mistake you for its own kind.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x87)]
        MaskGibdo,

        [RupeeRepeatable]
        [StartingItem(0xC5CE50, 0x3B)]
        [ItemName("Garo's Mask"), LocationName("Gorman Bros Race"), Region(Region.MilkRoad)]
        [GossipLocationHint("a sporting event"), GossipItemHint("the mask of spies")]
        [ShopText("This mask can summon the hidden Garo ninjas.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x81)]
        MaskGaro,

        [StartingItem(0xC5CE51, 0x44)]
        [ItemName("Captain's Hat"), LocationName("Captain Keeta's Chest"), Region(Region.IkanaGraveyard)]
        [GossipLocationHint("a ghostly battle", "a skeletal leader"), GossipItemHint("a commanding presence")]
        [ShopText("Wear it to pose as Captain Keeta.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x0280D000 + 0x392, ChestAttribute.AppearanceType.Normal, 0x0280D000 + 0x6FA)]
        [GetItemIndex(0x7C)]
        MaskCaptainHat,

        [StartingItem(0xC5CE52, 0x49)]
        [ItemName("Giant's Mask"), LocationName("Giant's Mask Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a growth spurt")]
        [ShopText("If you wear it in a certain room, you'll grow into a giant.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x020F1000 + 0x1C2, ChestAttribute.AppearanceType.AppearsSwitch, 0x02164000 + 0x19E)]
        [GetItemIndex(0x7D)]
        MaskGiant,

        [StartingItem(0xC5CE47, 0x33)]
        [ItemName("Goron Mask"), LocationName("Darmani"), Region(Region.MountainVillage)]
        [GossipLocationHint("a healed spirit", "the lost champion"), GossipItemHint("a mountain spirit")]
        [ShopText("Wear it to assume Goron form.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x79)]
        MaskGoron,

        [StartingItem(0xC5CE4D, 0x34)]
        [ItemName("Zora Mask"), LocationName("Mikau"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a healed spirit", "a fallen guitarist"), GossipItemHint("an ocean spirit")]
        [ShopText("Wear it to assume Zora form.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x7A)]
        MaskZora,

        //song
        [StartingItem(0xC5CE72, 0x20)]
        [ItemName("Song of Healing"), LocationName("Starting Song"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a soothing melody")]
        [ShopText("This melody will soothe restless spirits.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x124)]
        SongHealing,

        [StartingItem(0xC5CE72, 0x80)]
        [ItemName("Song of Soaring"), LocationName("Swamp Music Statue"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a stone tablet"), GossipItemHint("white wings")]
        [ShopText("This melody sends you to a stone bird statue in an instant.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x70)]
        SongSoaring,

        [RupeeRepeatable]
        [StartingItem(0xC5CE72, 0x40)]
        [ItemName("Epona's Song"), LocationName("Romani's Game"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a reunion"), GossipItemHint("a horse's song", "a song of the field")]
        [ShopText("This melody calls your horse, Epona.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x71)]
        SongEpona,

        [StartingItem(0xC5CE71, 0x01)]
        [ItemName("Song of Storms"), LocationName("Day 1 Grave Tablet"), Region(Region.IkanaGraveyard)]
        [GossipLocationHint("a hollow ground", "a stone tablet"), GossipItemHint("rain and thunder", "stormy weather")]
        [ShopText("This melody is the turbulent tune that blows curses away.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x72)]
        SongStorms,

        [StartingItem(0xC5CE73, 0x40)]
        [ItemName("Sonata of Awakening"), LocationName("Imprisoned Monkey"), Region(Region.DekuPalace)]
        [GossipLocationHint("a prisoner", "a false imprisonment"), GossipItemHint("a royal song", "an awakening melody")]
        [ShopText("This melody awakens those who have fallen into a deep sleep.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x73)]
        SongSonata,

        [StartingItem(0xC5CE73, 0x80)]
        [ItemName("Goron Lullaby"), LocationName("Baby Goron"), Region(Region.GoronVillage)]
        [GossipLocationHint("a lonely child", "an elder's son"), GossipItemHint("a sleepy melody", "a father's lullaby")]
        [ShopText("This melody blankets listeners in calm while making eyelids grow heavy.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x74)]
        SongLullaby,

        [StartingItem(0xC5CE72, 0x01)]
        [ItemName("New Wave Bossa Nova"), LocationName("Baby Zoras"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("the lost children", "the pirates' loot"), GossipItemHint("an ocean roar", "a song of newborns")]
        [ShopText("It's the melody taught by the Zora children that invigorates singing voices.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x75)]
        SongNewWaveBossaNova,

        [StartingItem(0xC5CE72, 0x02)]
        [ItemName("Elegy of Emptiness"), LocationName("Ikana King"), Region(Region.IkanaCastle)]
        [GossipLocationHint("a fallen king", "a battle in darkness"), GossipItemHint("empty shells", "skin shedding")]
        [ShopText("It's a mystical song that allows you to shed a shell shaped in your current image.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x76)]
        SongElegy,

        [StartingItem(0xC5CE72, 0x04)]
        [ItemName("Oath to Order"), LocationName("Boss Blue Warp"), Region(Region.Misc)]
        [GossipLocationHint("cleansed evil", "a fallen evil"), GossipItemHint("a song of summoning", "a song of giants")]
        [ShopText("This melody will call the giants at the right moment.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x77)]
        SongOath,

        //areas/other
        AreaSouthAccess,

        [EntranceName("Woodfall")]
        AreaWoodFallTempleAccess,

        AreaWoodFallTempleClear,
        AreaNorthAccess,

        [EntranceName("Snowhead")]
        AreaSnowheadTempleAccess,

        AreaSnowheadTempleClear,
        OtherEpona,
        AreaWestAccess,
        AreaPiratesFortressAccess,

        [EntranceName("Great Bay")]
        AreaGreatBayTempleAccess,

        AreaGreatBayTempleClear,
        AreaEastAccess,
        AreaIkanaCanyonAccess,
        AreaStoneTowerTempleAccess,

        [EntranceName("Inverted Stone Tower")]
        AreaInvertedStoneTowerTempleAccess,

        AreaStoneTowerClear,
        OtherExplosive,
        OtherArrow,
        AreaWoodfallNew,
        AreaSnowheadNew,
        AreaGreatBayNew,
        AreaLANew, // ??
        AreaInvertedStoneTowerNew, // Seemingly not used

        //keysanity items
        [StartingItem(0xC5CE74, 0x04)]
        [ItemName("Woodfall Map"), LocationName("Woodfall Map Chest"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Woodfall Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x0221F000 + 0x12A, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x3E)]
        ItemWoodfallMap,

        [StartingItem(0xC5CE74, 0x02)]
        [ItemName("Woodfall Compass"), LocationName("Woodfall Compass Chest"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Woodfall Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02215000 + 0xFA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x3F)]
        ItemWoodfallCompass,

        [Repeatable, Temporary]
        [ItemName("Woodfall Boss Key"), LocationName("Woodfall Boss Key Chest"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Woodfall Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.BossKey), Chest(0x02227000 + 0x11A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x3D)]
        ItemWoodfallBossKey,

        [Repeatable, Temporary]
        [ItemName("Woodfall Small Key"), LocationName("Woodfall Small Key Chest"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Woodfall Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02218000 + 0x1CA, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x3C)]
        ItemWoodfallKey1,

        [StartingItem(0xC5CE75, 0x04)]
        [ItemName("Snowhead Map"), LocationName("Snowhead Map Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02346000 + 0x13A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x54)]
        ItemSnowheadMap,

        [StartingItem(0xC5CE75, 0x02)]
        [ItemName("Snowhead Compass"), LocationName("Snowhead Compass Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x022F2000 + 0x1BA, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x57)]
        ItemSnowheadCompass,

        [Repeatable, Temporary]
        [ItemName("Snowhead Boss Key"), LocationName("Snowhead Boss Key Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.BossKey), Chest(0x0230C000 + 0x57A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x4E)]
        ItemSnowheadBossKey,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Block Room Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02306000 + 0x12A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x46)]
        ItemSnowheadKey1,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Icicle Room Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0233A000 + 0x23A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x47)]
        ItemSnowheadKey2,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Bridge Room Chest"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x022F9000 + 0x19A, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x48)]
        ItemSnowheadKey3,

        [StartingItem(0xC5CE76, 0x04)]
        [ItemName("Great Bay Map"), LocationName("Great Bay Map Chest"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Great Bay Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02905000 + 0x19A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x55)]
        ItemGreatBayMap,

        [StartingItem(0xC5CE76, 0x02)]
        [ItemName("Great Bay Compass"), LocationName("Great Bay Compass Chest"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Great Bay Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02914000 + 0x21A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x58)]
        ItemGreatBayCompass,

        [Repeatable, Temporary]
        [ItemName("Great Bay Boss Key"), LocationName("Great Bay Boss Key Chest"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Great Bay Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.BossKey), Chest(0x02914000 + 0x1FA, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x4F)]
        ItemGreatBayBossKey,

        [Repeatable, Temporary]
        [ItemName("Great Bay Small Key"), LocationName("Great Bay Small Key Chest"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Great Bay Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02914000 + 0x20A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x40)]
        ItemGreatBayKey1,

        [StartingItem(0xC5CE77, 0x04)]
        [ItemName("Stone Tower Map"), LocationName("Stone Tower Map Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x0210F000 + 0x222, ChestAttribute.AppearanceType.Normal, 0x02182000 + 0x21E)]
        [GetItemIndex(0x56)]
        ItemStoneTowerMap,

        [StartingItem(0xC5CE77, 0x02)]
        [ItemName("Stone Tower Compass"), LocationName("Stone Tower Compass Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02104000 + 0x292, ChestAttribute.AppearanceType.Normal, 0x02177000 + 0x2DE)]
        [GetItemIndex(0x6C)]
        ItemStoneTowerCompass,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Boss Key"), LocationName("Stone Tower Boss Key Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.BossKey), Chest(0x02130000 + 0x82, ChestAttribute.AppearanceType.Normal, 0x02198000 + 0xCE)]
        [GetItemIndex(0x53)]
        ItemStoneTowerBossKey,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Armor Room Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0210F000 + 0x202, ChestAttribute.AppearanceType.AppearsSwitch, 0x02182000 + 0x1FE)]
        [GetItemIndex(0x49)]
        ItemStoneTowerKey1,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Eyegore Room Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020F1000 + 0x1D2, ChestAttribute.AppearanceType.Normal, 0x02164000 + 0x1AE)]
        [GetItemIndex(0x4A)]
        ItemStoneTowerKey2,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Updraft Room Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02104000 + 0x282, ChestAttribute.AppearanceType.AppearsSwitch, 0x02177000 + 0x2CE)]
        [GetItemIndex(0x4B)]
        ItemStoneTowerKey3,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Death Armos Maze Chest"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020FC000 + 0x252, ChestAttribute.AppearanceType.Normal, 0x0216E000 + 0x1CE)]
        [GetItemIndex(0x4D)]
        ItemStoneTowerKey4,

        //shop items
        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Red Potion"), LocationName("Trading Post Red Potion"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 7)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 7)]
        [ShopText("Replenishes your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xCD)]
        ShopItemTradingPostRedPotion,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Green Potion"), LocationName("Trading Post Green Potion"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a magic potion", "a green drink")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x62)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 2)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 3)]
        [ShopText("Replenishes your magic power.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xBB)]
        ShopItemTradingPostGreenPotion,

        [Repeatable, CycleRepeatable]
        [ItemName("Hero's Shield"), LocationName("Trading Post Hero's Shield"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a basic guard", "protection")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 3)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 6)]
        [ShopText("Use it to defend yourself.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0xBC)]
        ShopItemTradingPostShield,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Fairy"), LocationName("Trading Post Fairy"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a winged friend", "a healer")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x5C)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 0)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 0)]
        [ShopText("Recovers life energy. If you run out of life energy you'll automatically use this.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xBD)]
        ShopItemTradingPostFairy,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Deku Stick"), LocationName("Trading Post Deku Stick"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a flammable weapon", "a flimsy weapon")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 4)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 5)]
        [ShopText("Deku Sticks burn well. You can only carry 10.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xBE)]
        ShopItemTradingPostStick,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("30 Arrows"), LocationName("Trading Post 30 Arrows"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 5)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xBF)]
        ShopItemTradingPostArrow30,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Deku Nuts"), LocationName("Trading Post 10 Deku Nuts"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a flashing impact")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 6)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 4)]
        [ShopText("Its flash blinds enemies.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC0)]
        ShopItemTradingPostNut10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("50 Arrows"), LocationName("Trading Post 50 Arrows"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x64)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 2)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC1)]
        ShopItemTradingPostArrow50,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Blue Potion"), LocationName("Witch Shop Blue Potion"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("consumable strength", "a magic potion", "a blue drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 2)]
        [ShopText("Replenishes both life energy and magic power.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xC2)]
        ShopItemWitchBluePotion,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Red Potion"), LocationName("Witch Shop Red Potion"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 0)]
        [ShopText("Replenishes your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xC3)]
        ShopItemWitchRedPotion,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Green Potion"), LocationName("Witch Shop Green Potion"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("a magic potion", "a green drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 1)]
        [ShopText("Replenishes your magic power.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xC4)]
        ShopItemWitchGreenPotion,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Bombs"), LocationName("Bomb Shop 10 Bombs"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 3)]
        [ShopText("Explosives. You need a Bomb Bag to carry them.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC5)]
        ShopItemBombsBomb10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Bombchu"), LocationName("Bomb Shop 10 Bombchu"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town merchant"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 2)]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC6)]
        ShopItemBombsBombchu10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Bombs"), LocationName("Goron Shop 10 Bombs"), Region(Region.GoronVillage)]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 0)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 0)]
        [ShopText("Explosives. You need a Bomb Bag to carry them.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC7)]
        ShopItemGoronBomb10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Arrows"), LocationName("Goron Shop 10 Arrows"), Region(Region.GoronVillage)]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xC8)]
        ShopItemGoronArrow10,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Red Potion"), LocationName("Goron Shop Red Potion"), Region(Region.GoronVillage)]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 2)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 2)]
        [ShopText("Replenishes your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xC9)]
        ShopItemGoronRedPotion,

        [Repeatable, CycleRepeatable]
        [ItemName("Hero's Shield"), LocationName("Zora Shop Hero's Shield"), Region(Region.ZoraHall)]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("a basic guard", "protection")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 0)]
        [ShopText("Use it to defend yourself.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0xCA)]
        ShopItemZoraShield,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Arrows"), LocationName("Zora Shop 10 Arrows"), Region(Region.ZoraHall)]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xCB)]
        ShopItemZoraArrow10,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Red Potion"), LocationName("Zora Shop Red Potion"), Region(Region.ZoraHall)]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 2)]
        [ShopText("Replenishes your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0xCC)]
        ShopItemZoraRedPotion,

        //bottle catch
        [ItemName("Bottle: Fairy"), LocationName("Bottle: Fairy"), Region(Region.BottleCatch)]
        [GossipLocationHint("a wandering healer"), GossipItemHint("a winged friend", "a healer")]
        [GetBottleItemIndices(0x00, 0x0D)]
        BottleCatchFairy,

        [ItemName("Bottle: Deku Princess"), LocationName("Bottle: Deku Princess"), Region(Region.BottleCatch)]
        [GossipLocationHint("a captured royal", "an imprisoned daughter"), GossipItemHint("a princess", "a woodland royal")]
        [GetBottleItemIndices(0x08)]
        BottleCatchPrincess,

        [ItemName("Bottle: Fish"), LocationName("Bottle: Fish"), Region(Region.BottleCatch)]
        [GossipLocationHint("a swimming creature", "a water dweller"), GossipItemHint("something fresh")]
        [GetBottleItemIndices(0x01)]
        BottleCatchFish,

        [ItemName("Bottle: Bug"), LocationName("Bottle: Bug"), Region(Region.BottleCatch)]
        [GossipLocationHint("an insect", "a scuttling creature"), GossipItemHint("an insect", "a scuttling creature")]
        [GetBottleItemIndices(0x02, 0x03)]
        BottleCatchBug,

        [ItemName("Bottle: Poe"), LocationName("Bottle: Poe"), Region(Region.BottleCatch)]
        [GossipLocationHint("a wandering ghost"), GossipItemHint("a captured spirit")]
        [GetBottleItemIndices(0x0B)]
        BottleCatchPoe,

        [ItemName("Bottle: Big Poe"), LocationName("Bottle: Big Poe"), Region(Region.BottleCatch)]
        [GossipLocationHint("a huge ghost"), GossipItemHint("a captured spirit")]
        [GetBottleItemIndices(0x0C)]
        BottleCatchBigPoe,

        [ItemName("Bottle: Spring Water"), LocationName("Bottle: Spring Water"), Region(Region.BottleCatch)]
        [GossipLocationHint("a common liquid"), GossipItemHint("a common liquid", "a fresh drink")]
        [GetBottleItemIndices(0x04)]
        BottleCatchSpringWater,

        [ItemName("Bottle: Hot Spring Water"), LocationName("Bottle: Hot Spring Water"), Region(Region.BottleCatch)]
        [GossipLocationHint("a hot liquid", "a boiling liquid"), GossipItemHint("a boiling liquid", "a hot liquid")]
        [GetBottleItemIndices(0x05, 0x06)]
        BottleCatchHotSpringWater,

        [ItemName("Bottle: Zora Egg"), LocationName("Bottle: Zora Egg"), Region(Region.BottleCatch)]
        [GossipLocationHint("a lost child"), GossipItemHint("a lost child")]
        [GetBottleItemIndices(0x07)]
        BottleCatchEgg,

        [ItemName("Bottle: Mushroom"), LocationName("Bottle: Mushroom"), Region(Region.BottleCatch)]
        [GossipLocationHint("a strange fungus"), GossipItemHint("a strange fungus")]
        [GetBottleItemIndices(0x0A)]
        BottleCatchMushroom,

        //other chests and grottos
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Lens Cave Invisible Chest"), Region(Region.GoronVillage)]
        [GossipLocationHint("a lonely peak"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02EB8000 + 0xAA, ChestAttribute.AppearanceType.Invisible)]
        [GetItemIndex(0xDD)]
        ChestLensCaveRedRupee,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Lens Cave Rock Chest"), Region(Region.GoronVillage)]
        [GossipLocationHint("a lonely peak"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02EB8000 + 0xDA, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xF4)]
        ChestLensCavePurpleRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Bean Grotto"), Region(Region.DekuPalace)]
        [GossipLocationHint("a merchant's cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02ECC000 + 0xFA, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xDE)]
        ChestBeanGrottoRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Hot Spring Water Grotto"), Region(Region.TwinIslands)]
        [GossipLocationHint("a steaming cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02ED7000 + 0xC6, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xDF)]
        ChestHotSpringGrottoRedRupee,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Day 1 Grave Bats"), Region(Region.IkanaGraveyard)]
        [GossipLocationHint("a cloud of bats"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x01F97000 + 0xCE, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0xF5)]
        ChestBadBatsGrottoPurpleRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("5 Bombchu"), LocationName("Secret Shrine Grotto"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("a waterfall cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02080000 + 0x93, 0x02080000 + 0x1E3, 0x02080000 + 0x2EB)]
        [GetItemIndex(0xD1)]
        ChestIkanaSecretShrineGrotto,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Lower Chest"), Region(Region.PiratesFortressInterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x020A2000 + 0x256, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE0)]
        ChestPiratesFortressRedRupee1,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Upper Chest"), Region(Region.PiratesFortressInterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x020A2000 + 0x266, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE1)]
        ChestPiratesFortressRedRupee2,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Tank Chest"), Region(Region.PiratesFortressInterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x023B7000 + 0x66, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE2)]
        ChestInsidePiratesFortressTankRedRupee,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Pirates' Fortress Interior Guard Room Chest"), Region(Region.PiratesFortressInterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x023BB000 + 0x56, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xFB)]
        ChestInsidePiratesFortressGuardSilverRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Cage Room Shallow Chest"), Region(Region.PiratesFortressSewer)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x023E6000 + 0x24E, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE3)]
        ChestInsidePiratesFortressHeartPieceRoomRedRupee,

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Pirates' Fortress Cage Room Deep Chest"), Region(Region.PiratesFortressSewer)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x023E6000 + 0x25E, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x105)]
        ChestInsidePiratesFortressHeartPieceRoomBlueRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Maze Chest"), Region(Region.PiratesFortressSewer)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x023F0000 + 0xDE, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE4)]
        ChestInsidePiratesFortressMazeRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pinnacle Rock Lower Chest"), Region(Region.PinnacleRock)]
        [GossipLocationHint("a marine trench"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02428000 + 0x24E, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE5)]
        ChestPinacleRockRedRupee1,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pinnacle Rock Upper Chest"), Region(Region.PinnacleRock)]
        [GossipLocationHint("a marine trench"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02428000 + 0x25E, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE6)]
        ChestPinacleRockRedRupee2,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Bombers' Hideout Chest"), Region(Region.EastClockTown)]
        [GossipLocationHint("a secret hideout"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x024F1000 + 0x1DE, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xFC)]
        ChestBomberHideoutSilverRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Bombchu"), LocationName("Termina Field Pillar Grotto"), Region(Region.TerminaField)]
        [GossipLocationHint("a hollow pillar"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x025C5000 + 0x583)]
        [GetItemIndex(0xD7)]
        ChestTerminaGrottoBombchu,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Grass Grotto"), Region(Region.TerminaField)]
        [GossipLocationHint("a grassy cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x025C5000 + 0x593)]
        [GetItemIndex(0xDC)]
        ChestTerminaGrottoRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Underwater Chest"), Region(Region.TerminaField)]
        [GossipLocationHint("a sunken chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x025C5000 + 0xD52, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE7)]
        ChestTerminaUnderwaterRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Grass Chest"), Region(Region.TerminaField)]
        [GossipLocationHint("a grassy chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x025C5000 + 0xD62, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE8)]
        ChestTerminaGrassRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Stump Chest"), Region(Region.TerminaField)]
        [GossipLocationHint("a tree's chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x025C5000 + 0xD72, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xE9)]
        ChestTerminaStumpRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Great Bay Coast Grotto"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a beach cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x026DE000 + 0x43F, 0x026DE000 + 0xFE3)]
        [GetItemIndex(0xD4)]
        ChestGreatBayCoastGrotto, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Zora Cape Ledge Without Tree Chest"), Region(Region.ZoraCape)]
        [GossipLocationHint("a high place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02715000 + 0x42A, ChestAttribute.AppearanceType.Normal, 0x02715000 + 0xB16)]
        [GetItemIndex(0xEA)]
        ChestGreatBayCapeLedge1, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Zora Cape Ledge With Tree Chest"), Region(Region.ZoraCape)]
        [GossipLocationHint("a high place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02715000 + 0x43A, ChestAttribute.AppearanceType.Normal, 0x02715000 + 0xB26)]
        [GetItemIndex(0xEB)]
        ChestGreatBayCapeLedge2, //contents? 

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Bombchu"), LocationName("Zora Cape Grotto"), Region(Region.ZoraCape)]
        [GossipLocationHint("a beach cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02715000 + 0x45B, 0x02715000 + 0xB47)]
        [GetItemIndex(0xD2)]
        ChestGreatBayCapeGrotto, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Zora Cape Underwater Chest"), Region(Region.ZoraCape)]
        [GossipLocationHint("a sunken chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02715000 + 0x48A, ChestAttribute.AppearanceType.Normal, 0x02715000 + 0xB56)]
        [GetItemIndex(0xF6)]
        ChestGreatBayCapeUnderwater, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Log Chest"), Region(Region.PiratesFortressExterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02740000 + 0x196, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xEC)]
        ChestPiratesFortressEntranceRedRupee1,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Sand Chest"), Region(Region.PiratesFortressExterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02740000 + 0x1A6, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xED)]
        ChestPiratesFortressEntranceRedRupee2,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Corner Chest"), Region(Region.PiratesFortressExterior)]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02740000 + 0x1B6, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xEE)]
        ChestPiratesFortressEntranceRedRupee3,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Swamp Grotto"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a southern cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x027C1000 + 0x33B)]
        [GetItemIndex(0xDB)]
        ChestToSwampGrotto, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Doggy Racetrack Roof Chest"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a day at the races"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x027D4000 + 0xB6, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xF7)]
        ChestDogRacePurpleRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("5 Bombchu"), LocationName("Ikana Graveyard Grotto"), Region(Region.IkanaGraveyard)]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [GossipLocationHint("a circled cave"), GossipItemHint("explosive mice")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x0280D000 + 0x353, 0x0280D000 + 0x54B)]
        [GetItemIndex(0xD5)]
        ChestGraveyardGrotto, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Near Swamp Spider House Grotto"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a southern cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x01F3A000 + 0x227, 0x02855000 + 0x2AF)]
        [GetItemIndex(0xDA)]
        ChestSwampGrotto,  //contents? 

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Behind Woodfall Owl Chest"), Region(Region.Woodfall)]
        [GossipLocationHint("a swamp chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02884000 + 0x232, ChestAttribute.AppearanceType.Normal, 0x02884000 + 0xA62)]
        [GetItemIndex(0x106)]
        ChestWoodfallBlueRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Entrance to Woodfall Chest"), Region(Region.Woodfall)]
        [GossipLocationHint("a swamp chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02884000 + 0x242, ChestAttribute.AppearanceType.Normal, 0x02884000 + 0xA32)]
        [GetItemIndex(0xEF)]
        ChestWoodfallRedRupee,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Well Right Path Chest"), Region(Region.BeneathTheWell)]
        [GossipLocationHint("a frightful exchange"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x029EA000 + 0xE6, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0xF8)]
        ChestWellRightPurpleRupee,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Well Left Path Chest"), Region(Region.BeneathTheWell)]
        [GossipLocationHint("a frightful exchange"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x029F0000 + 0x106, ChestAttribute.AppearanceType.Invisible)]
        [GetItemIndex(0xF9)]
        ChestWellLeftPurpleRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Mountain Waterfall Chest"), Region(Region.MountainVillage)]
        [GossipLocationHint("the springtime"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02BDD000 + 0x2E2, ChestAttribute.AppearanceType.Invisible, 0x02BDD000 + 0x946)]
        [GetItemIndex(0xF0)]
        ChestMountainVillage, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Mountain Spring Grotto"), Region(Region.MountainVillage)]
        [GossipLocationHint("the springtime"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02BFC000 + 0x1F3, 0x02BFC000 + 0x2B3)]
        [GetItemIndex(0xD8)]
        ChestMountainVillageGrottoRedRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Ikana Pillar Chest"), Region(Region.RoadToIkana)]
        [GossipLocationHint("a high chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02B34000 + 0x442, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xF1)]
        ChestToIkanaRedRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Bombchu"), LocationName("Path to Ikana Grotto"), Region(Region.RoadToIkana)]
        [GossipLocationHint("a blocked cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02B34000 + 0x523)]
        [GetItemIndex(0xD3)]
        ChestToIkanaGrotto, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inverted Stone Tower Right Chest"), Region(Region.StoneTower)]
        [GossipLocationHint("a sky below"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02BC9000 + 0x236, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xFD)]
        ChestInvertedStoneTowerSilverRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Bombchu"), LocationName("Inverted Stone Tower Middle Chest"), Region(Region.StoneTower)]
        [GossipLocationHint("a sky below"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02BC9000 + 0x246, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x10A)]
        ChestInvertedStoneTowerBombchu10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Magic Bean"), LocationName("Inverted Stone Tower Left Chest"), Region(Region.StoneTower)]
        [GossipLocationHint("a sky below"), GossipItemHint("a plant seed")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold), Chest(0x02BC9000 + 0x256, ChestAttribute.AppearanceType.Normal)]
        [ShopText("Plant it in soft soil.")]
        [GetItemIndex(0x109)]
        ChestInvertedStoneTowerBean,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Snowhead Grotto"), Region(Region.PathToSnowhead)]
        [GossipLocationHint("a snowy cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02C04000 + 0xAF, 0x02C04000 + 0x487)]
        [GetItemIndex(0xD0)]
        ChestToSnowheadGrotto, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Twin Islands Cave Chest"), Region(Region.TwinIslands)]
        [GossipLocationHint("the springtime"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C34000 + 0x13A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xF2)]
        ChestToGoronVillageRedRupee,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Secret Shrine Final Chest"), Region(Region.SecretShrine)]
        [GossipLocationHint("a secret place"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C57000 + 0xB6, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x107)]
        ChestSecretShrineHeartPiece,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Dinolfos Chest"), Region(Region.SecretShrine)]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C61000 + 0x9A, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0xFE)]
        ChestSecretShrineDinoGrotto,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Wizzrobe Chest"), Region(Region.SecretShrine)]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C69000 + 0xB2, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0xFF)]
        ChestSecretShrineWizzGrotto,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Wart Chest"), Region(Region.SecretShrine)]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C71000 + 0xA6, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x100)]
        ChestSecretShrineWartGrotto,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Garo Master Chest"), Region(Region.SecretShrine)]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02C75000 + 0x76, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x101)]
        ChestSecretShrineGaroGrotto,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inn Staff Room Chest"), Region(Region.EastClockTown)]
        [GossipLocationHint("an employee room"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02CAB000 + 0x10E, ChestAttribute.AppearanceType.Normal, 0x02CAB000 + 0x242)]
        [GetItemIndex(0x102)]
        ChestInnStaffRoom, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inn Guest Room Chest"), Region(Region.EastClockTown)]
        [GossipLocationHint("a guest bedroom"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02CB1000 + 0xDA, ChestAttribute.AppearanceType.Normal, 0x02CB1000 + 0x212)]
        [GetItemIndex(0x103)]
        ChestInnGuestRoom, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Mystery Woods Grotto"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a mystery cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02CFC000 + 0x5B)]
        [GetItemIndex(0xD9)]
        ChestWoodsGrotto, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("East Clock Town Chest"), Region(Region.EastClockTown)]
        [GossipLocationHint("a shop roof"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02DE4000 + 0x442, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x104)]
        ChestEastClockTownSilverRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("South Clock Town Straw Roof Chest"), Region(Region.SouthClockTown)]
        [GossipLocationHint("a straw roof"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02E5C000 + 0x342, ChestAttribute.AppearanceType.Normal, 0x02E5C000 + 0x806)]
        [GetItemIndex(0xF3)]
        ChestSouthClockTownRedRupee,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("South Clock Town Final Day Chest"), Region(Region.SouthClockTown)]
        [GossipLocationHint("a carnival tower"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02E5C000 + 0x352, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0xFA)]
        ChestSouthClockTownPurpleRupee,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Bank Reward #3"), Region(Region.WestClockTown)]
        [GossipLocationHint("being rich"), GossipItemHint("a segment of health"), GossipCompetitiveHint(-2)]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x108)]
        HeartPieceBank,

        //standing HPs
        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Clock Tower Entrance"), Region(Region.SouthClockTown)]
        [GossipLocationHint("the tower doors"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x10B)]
        HeartPieceSouthClockTown,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("North Clock Town Tree"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a town playground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x10C)]
        HeartPieceNorthClockTown,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Path to Swamp Tree"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a tree of bats"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x10D)]
        HeartPieceToSwamp,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Swamp Tourist Center Roof"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a tourist centre"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x10E)]
        HeartPieceSwampScrub,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Deku Palace West Garden"), Region(Region.DekuPalace)]
        [GossipLocationHint("the home of scrubs"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x10F)]
        HeartPieceDekuPalace,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Goron Village Ledge"), Region(Region.GoronVillage)]
        [GossipLocationHint("a cold ledge"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x110)]
        HeartPieceGoronVillageScrub,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Bio Baba Grotto"), Region(Region.TerminaField)]
        [GossipLocationHint("a beehive"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x111)]
        HeartPieceZoraGrotto,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Lab Fish"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("feeding the fish"), GossipItemHint("a segment of health"), GossipCompetitiveHint(0, nameof(SettingsObject.SpeedupLabFish))]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x112)]
        HeartPieceLabFish,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Zora Cape Like-Like"), Region(Region.ZoraCape)]
        [GossipLocationHint("a shield eater"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x113)]
        HeartPieceGreatBayCapeLikeLike,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Pirates' Fortress Cage"), Region(Region.PiratesFortressSewer)]
        [GossipLocationHint("a timed door"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x114)]
        HeartPiecePiratesFortress,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Lulu's Room Ledge"), Region(Region.ZoraHall)]
        [GossipLocationHint("the singer's room"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x115)]
        HeartPieceZoraHallScrub,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Path to Snowhead Pillar"), Region(Region.PathToSnowhead)]
        [GossipLocationHint("a cold platform"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x116)]
        HeartPieceToSnowhead,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Great Bay Coast Ledge"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a rock face"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x117)]
        HeartPieceGreatBayCoast,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Ikana Canyon Ledge"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("a thief's doorstep"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x118)]
        HeartPieceIkana,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Ikana Castle Pillar"), Region(Region.IkanaCastle)]
        [GossipLocationHint("a fiery pillar"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x119)]
        HeartPieceCastle,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Odolwa Heart Container"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x11A)]
        HeartContainerWoodfall,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Goht Heart Container"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x11B)]
        HeartContainerSnowhead,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Gyorg Heart Container"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x11C)]
        HeartContainerGreatBay,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Twinmold Heart Container"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x11D)]
        HeartContainerStoneTower,

        //maps
        [ItemName("Map of Clock Town"), LocationName("Clock Town Map Purchase"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of Clock Town.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB4)]
        ItemTingleMapTown,

        [ItemName("Map of Woodfall"), LocationName("Woodfall Map Purchase"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the south.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB5)]
        ItemTingleMapWoodfall,

        [ItemName("Map of Snowhead"), LocationName("Snowhead Map Purchase"), Region(Region.RoadToSouthernSwamp)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the north.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB6)]
        ItemTingleMapSnowhead,

        [ItemName("Map of Romani Ranch"), LocationName("Romani Ranch Map Purchase"), Region(Region.MilkRoad)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the ranch.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB7)]
        ItemTingleMapRanch,

        [ItemName("Map of Great Bay"), LocationName("Great Bay Map Purchase"), Region(Region.MilkRoad)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the west.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB8)]
        ItemTingleMapGreatBay,

        [ItemName("Map of Stone Tower"), LocationName("Stone Tower Map Purchase"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the east.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0xB9)]
        ItemTingleMapStoneTower,

        //oops I forgot one
        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Bombchu"), LocationName("Goron Racetrack Grotto"), Region(Region.TwinIslands)]
        [GossipLocationHint("a hidden cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), GrottoChest(0x02C23000 + 0x2D7, 0x02C34000 + 0x1DB)]
        [GetItemIndex(0xD6)]
        ChestToGoronRaceGrotto, //contents?

        [Repeatable]
        [ItemName("Gold Rupee"), LocationName("Canyon Scrub Trade"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("an eastern merchant"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 200 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x125)]
        IkanaScrubGoldRupee,

        //moon items
        OtherOneMask,
        OtherTwoMasks,
        OtherThreeMasks,
        OtherFourMasks,
        AreaMoonAccess,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Deku Trial Bonus"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x11F)]
        HeartPieceDekuTrial,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Goron Trial Bonus"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x120)]
        HeartPieceGoronTrial,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Zora Trial Bonus"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x121)]
        HeartPieceZoraTrial,

        [StartingItem(0xC5CE70, 0x10, true)]
        [ItemName("Piece of Heart"), LocationName("Link Trial Bonus"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x122)]
        HeartPieceLinkTrial,

        [StartingItem(0xC5CE53, 0x35)]
        [ItemName("Fierce Deity's Mask"), LocationName("Majora Child"), Region(Region.TheMoon)]
        [GossipLocationHint("the lonely child"), GossipItemHint("the wrath of a god")]
        [ShopText("A mask that contains the merits of all masks.", isDefinite: true)]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x7B)]
        MaskFierceDeity,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("30 Arrows"), LocationName("Link Trial Garo Master Chest"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02D4B000 + 0x76, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x126)]
        ChestLinkTrialArrow30,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Bombchu"), LocationName("Link Trial Iron Knuckle Chest"), Region(Region.TheMoon)]
        [GossipLocationHint("a masked child's game"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x02D4E000 + 0xC6, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x127)]
        ChestLinkTrialBombchu10,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Deku Nuts"), LocationName("Pre-Clocktown Chest"), Region(Region.BeneathClocktown)]
        [GossipLocationHint("the first chest"), GossipItemHint("a flashing impact")]
        [ShopText("Its flash blinds enemies.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x021D2000 + 0x102, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x128)]
        ChestPreClocktownDekuNut,

        [StartingItem(0xC5CE21, 0x01)]
        [StartingItem(0xC5CE00, 0x4D)]
        [ItemName("Kokiri Sword"), LocationName("Starting Sword"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a forest blade")]
        [ShopText("A sword created by forest folk.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x37)]
        StartingSword,

        [Repeatable, CycleRepeatable]
        [StartingItem(0xC5CE21, 0x10)]
        [ItemName("Hero's Shield"), LocationName("Starting Shield"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a basic guard", "protection")]
        [ShopText("Use it to defend yourself.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x129)]
        StartingShield,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Starting Heart Container #1"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12A)]
        StartingHeartContainer1,

        [StartingItem(0xC5CDE9, 0x10, true)] // add max health
        [StartingItem(0xC5CDEB, 0x10, true)] // add current health
        [StartingItem(0xC40E1B, 0x10, true)] // add respawn health
        [StartingItem(0xBDA683, 0x10, true)] // add minimum Song of Time health
        [StartingItem(0xBDA68F, 0x10, true)] // add minimum Song of Time health
        [ItemName("Heart Container"), LocationName("Starting Heart Container #2"), Region(Region.Misc)]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [GetItemIndex(0x12B)]
        StartingHeartContainer2,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Ranch Cow #1"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x132)]
        ItemRanchBarnMainCowMilk,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Ranch Cow #2"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x182)]
        ItemRanchBarnOtherCowMilk1,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Ranch Cow #3"), Region(Region.RomaniRanch)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A2)]
        ItemRanchBarnOtherCowMilk2,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Cow Beneath the Well"), Region(Region.BeneathTheWell)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x135)]
        ItemWellCowMilk,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Termina Grotto Cow #1"), Region(Region.TerminaField)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x136)]
        ItemTerminaGrottoCowMilk1,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Termina Grotto Cow #2"), Region(Region.TerminaField)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x137)]
        ItemTerminaGrottoCowMilk2,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Great Bay Coast Grotto Cow #1"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x138)]
        ItemCoastGrottoCowMilk1,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Great Bay Coast Grotto Cow #2"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x139)]
        ItemCoastGrottoCowMilk2,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Near Ceiling"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x13A)]
        CollectibleSwampSpiderToken1,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Gold Room Near Ceiling"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x13B)]
        CollectibleSwampSpiderToken2,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Monument Room Torch"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x13C)]
        CollectibleSwampSpiderToken3,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Gold Room Pillar"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x13E)]
        CollectibleSwampSpiderToken4,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Jar"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x13F)]
        CollectibleSwampSpiderToken5,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Grass 1"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x140)]
        CollectibleSwampSpiderToken6,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Grass 2"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x141)]
        CollectibleSwampSpiderToken7,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Water"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x142)]
        CollectibleSwampSpiderToken8,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Lower Left Soft Soil"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x143)]
        CollectibleSwampSpiderToken9,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Monument Room Crate 1"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x144)]
        CollectibleSwampSpiderToken10,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Upper Soft Soil"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x145)]
        CollectibleSwampSpiderToken11,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Lower Right Soft Soil"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x146)]
        CollectibleSwampSpiderToken12,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Monument Room Lower Wall"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x147)]
        CollectibleSwampSpiderToken13,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Monument Room On Monument"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x148)]
        CollectibleSwampSpiderToken14,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Pillar"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x149)]
        CollectibleSwampSpiderToken15,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Pot 1"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14A)]
        CollectibleSwampSpiderToken16,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Pot 2"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14B)]
        CollectibleSwampSpiderToken17,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Gold Room Hive"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14C)]
        CollectibleSwampSpiderToken18,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Upper Pillar"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14D)]
        CollectibleSwampSpiderToken19,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Behind Vines"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14E)]
        CollectibleSwampSpiderToken20,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Tree 1"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x14F)]
        CollectibleSwampSpiderToken21,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Wall"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x150)]
        CollectibleSwampSpiderToken22,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Hive 1"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x151)]
        CollectibleSwampSpiderToken23,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Tree 2"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x152)]
        CollectibleSwampSpiderToken24,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Gold Room Wall"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x153)]
        CollectibleSwampSpiderToken25,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Hive"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x154)]
        CollectibleSwampSpiderToken26,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Monument Room Crate 2"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x155)]
        CollectibleSwampSpiderToken27,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Pot Room Hive 2"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x156)]
        CollectibleSwampSpiderToken28,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Tree Room Tree 3"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x157)]
        CollectibleSwampSpiderToken29,

        [ItemName("Swamp Skulltula Spirit"), LocationName("Swamp Skulltula Main Room Jar"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the swamp spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x158)]
        CollectibleSwampSpiderToken30,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Storage Room Behind Boat"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x159)]
        CollectibleOceanSpiderToken1,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Hole Behind Picture"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15A)]
        CollectibleOceanSpiderToken2,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Hole Behind Cabinet"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15B)]
        CollectibleOceanSpiderToken3,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library On Corner Bookshelf"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15C)]
        CollectibleOceanSpiderToken4,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Ceiling Edge"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15D)]
        CollectibleOceanSpiderToken5,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Ceiling Plank"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15E)]
        CollectibleOceanSpiderToken6,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Ceiling Edge"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x15F)]
        CollectibleOceanSpiderToken7,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Ceiling Edge"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x160)]
        CollectibleOceanSpiderToken8,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Storage Room Ceiling Web"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x161)]
        CollectibleOceanSpiderToken9,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Storage Room Behind Crate"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x162)]
        CollectibleOceanSpiderToken10,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Jar"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x163)]
        CollectibleOceanSpiderToken11,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Entrance Right Wall"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x164)]
        CollectibleOceanSpiderToken12,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Entrance Left Wall"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x165)]
        CollectibleOceanSpiderToken13,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Webbed Hole"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x166)]
        CollectibleOceanSpiderToken14,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Entrance Web"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x167)]
        CollectibleOceanSpiderToken15,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Chandelier 1"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x168)]
        CollectibleOceanSpiderToken16,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Chandelier 2"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x169)]
        CollectibleOceanSpiderToken17,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Chandelier 3"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16A)]
        CollectibleOceanSpiderToken18,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Behind Picture"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16B)]
        CollectibleOceanSpiderToken19,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Behind Picture"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16C)]
        CollectibleOceanSpiderToken20,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Behind Bookcase 1"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16D)]
        CollectibleOceanSpiderToken21,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Storage Room Crate"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16E)]
        CollectibleOceanSpiderToken22,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Webbed Pot"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x16F)]
        CollectibleOceanSpiderToken23,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Upper Pot"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x170)]
        CollectibleOceanSpiderToken24,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Colored Skulls Pot"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x171)]
        CollectibleOceanSpiderToken25,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Storage Room Jar"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x172)]
        CollectibleOceanSpiderToken26,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Lower Pot"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x173)]
        CollectibleOceanSpiderToken27,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula Library Behind Bookcase 2"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x174)]
        CollectibleOceanSpiderToken28,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Behind Skull 1"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x175)]
        CollectibleOceanSpiderToken29,

        [ItemName("Ocean Skulltula Spirit"), LocationName("Ocean Skulltula 2nd Room Behind Skull 2"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a golden spider"), GossipItemHint("a golden token")]
        [ShopText("Collect 30 to lift the curse in the ocean spider house.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x176)]
        CollectibleOceanSpiderToken30,

        [ItemName("Clock Town Stray Fairy"), LocationName("Clock Town Stray Fairy"), Region(Region.LaundryPool)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Return it to the Fairy Fountain in North Clock Town.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x3B)]
        CollectibleStrayFairyClockTown,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Pre-Boss Lower Right Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x177)]
        CollectibleStrayFairyWoodfall1,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Entrance Fairy"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x178)]
        CollectibleStrayFairyWoodfall2,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Pre-Boss Upper Left Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x179)]
        CollectibleStrayFairyWoodfall3,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Pre-Boss Pillar Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17A)]
        CollectibleStrayFairyWoodfall4,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Deku Baba"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17B)]
        CollectibleStrayFairyWoodfall5,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Poison Water Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17C)]
        CollectibleStrayFairyWoodfall6,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Main Room Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17D)]
        CollectibleStrayFairyWoodfall7,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Skulltula"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17E)]
        CollectibleStrayFairyWoodfall8,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Pre-Boss Upper Right Bubble"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x17F)]
        CollectibleStrayFairyWoodfall9,

        // 80 - 83 empty

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Main Room Switch"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x021FB000 + 0x28A, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x184)]
        CollectibleStrayFairyWoodfall10,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Entrance Platform"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02204000 + 0x23A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x185)]
        CollectibleStrayFairyWoodfall11,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Dark Room"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0222E000 + 0x1AA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x186)]
        CollectibleStrayFairyWoodfall12,

        // 87 - 88 empty

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Jar Fairy"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x189)]
        CollectibleStrayFairyWoodfall13,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Bridge Room Hive"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x18A)]
        CollectibleStrayFairyWoodfall14,

        [ItemName("Woodfall Stray Fairy"), LocationName("Woodfall Platform Room Hive"), Region(Region.WoodfallTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Woodfall.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x18B)]
        CollectibleStrayFairyWoodfall15,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Snow Room Bubble"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x18C)]
        CollectibleStrayFairySnowhead1,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Ceiling Bubble"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x18D)]
        CollectibleStrayFairySnowhead2,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Dinolfos 1"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x18E)]
        CollectibleStrayFairySnowhead3,

        // 8F empty

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Bridge Room Ledge Bubble"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x190)]
        CollectibleStrayFairySnowhead4,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Bridge Room Pillar Bubble"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x191)]
        CollectibleStrayFairySnowhead5,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Dinolfos 2"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x192)]
        CollectibleStrayFairySnowhead6,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Map Room Fairy"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x193)]
        CollectibleStrayFairySnowhead7,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Map Room Ledge"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02346000 + 0x12A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x194)]
        CollectibleStrayFairySnowhead8,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Basement"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0230C000 + 0x56A, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x195)]
        CollectibleStrayFairySnowhead9,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Twin Block"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02306000 + 0x11A, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x196)]
        CollectibleStrayFairySnowhead10,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Icicle Room Wall"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0233A000 + 0x22A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x197)]
        CollectibleStrayFairySnowhead11,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Main Room Wall"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0230C000 + 0x58A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x198)]
        CollectibleStrayFairySnowhead12,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Pillar Freezards"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0232E000 + 0x20A, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x199)]
        CollectibleStrayFairySnowhead13,

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Ice Puzzle"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x022F2000 + 0x1AA, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x19A)]
        CollectibleStrayFairySnowhead14,

        // 9B - 9E empty

        [ItemName("Snowhead Stray Fairy"), LocationName("Snowhead Crate"), Region(Region.SnowheadTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Snowhead.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x19F)]
        CollectibleStrayFairySnowhead15,

        // A0 - A3 empty

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Skulltula"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A7)]
        CollectibleStrayFairyGreatBay1,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Pre-Boss Room Underwater Bubble"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A4)]
        CollectibleStrayFairyGreatBay2,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Water Control Room Underwater Bubble"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A5)]
        CollectibleStrayFairyGreatBay3,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Pre-Boss Room Bubble"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A6)]
        CollectibleStrayFairyGreatBay4,

        // A8 empty

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Waterwheel Room Upper"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02940000 + 0x23A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x1A9)]
        CollectibleStrayFairyGreatBay5,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Green Valve"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02959000 + 0x18E, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x1AA)]
        CollectibleStrayFairyGreatBay6,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Seesaw Room"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02945000 + 0x24A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x1AB)]
        CollectibleStrayFairyGreatBay7,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Waterwheel Room Lower"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02940000 + 0x24A, ChestAttribute.AppearanceType.Normal)]
        [GetItemIndex(0x1AC)]
        CollectibleStrayFairyGreatBay8,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Entrance Torches"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02962000 + 0x1F2, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x1AD)]
        CollectibleStrayFairyGreatBay9,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Bio Babas"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02911000 + 0xDA, ChestAttribute.AppearanceType.AppearsClear)]
        [GetItemIndex(0x1AE)]
        CollectibleStrayFairyGreatBay10,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Underwater Barrel"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1AF)]
        CollectibleStrayFairyGreatBay11,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Whirlpool Jar"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1B0)]
        CollectibleStrayFairyGreatBay12,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Whirlpool Barrel"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1B1)]
        CollectibleStrayFairyGreatBay13,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Dexihands Jar"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1B2)]
        CollectibleStrayFairyGreatBay14,

        [ItemName("Great Bay Stray Fairy"), LocationName("Great Bay Ledge Jar"), Region(Region.GreatBayTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Great Bay.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1B3)]
        CollectibleStrayFairyGreatBay15,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Mirror Sun Block"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02119000 + 0x282, ChestAttribute.AppearanceType.Normal, 0x0218B000 + 0x8A)]
        [GetItemIndex(0x1B4)]
        CollectibleStrayFairyStoneTower1,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Eyegore"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020F1000 + 0x1A2, ChestAttribute.AppearanceType.AppearsSwitch, 0x02164000 + 0x17E)]
        [GetItemIndex(0x1B5)]
        CollectibleStrayFairyStoneTower2,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Lava Room Fire Ring"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02122000 + 0x1F6, ChestAttribute.AppearanceType.Normal, 0x02191000 + 0x7A)]
        [GetItemIndex(0x1B6)]
        CollectibleStrayFairyStoneTower3,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Updraft Fire Ring"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02104000 + 0x252, ChestAttribute.AppearanceType.AppearsSwitch, 0x02177000 + 0x29E)]
        [GetItemIndex(0x1B7)]
        CollectibleStrayFairyStoneTower4,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Mirror Sun Switch"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02119000 + 0x272, ChestAttribute.AppearanceType.AppearsSwitch, 0x0218B000 + 0x7A)]
        [GetItemIndex(0x1B8)]
        CollectibleStrayFairyStoneTower5,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Boss Warp"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020E2000 + 0x162, ChestAttribute.AppearanceType.AppearsSwitch, 0x02156000 + 0xFA)]
        [GetItemIndex(0x1B9)]
        CollectibleStrayFairyStoneTower6,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Wizzrobe"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0210F000 + 0x1F2, ChestAttribute.AppearanceType.AppearsSwitch, 0x02182000 + 0x1EE)]
        [GetItemIndex(0x1BA)]
        CollectibleStrayFairyStoneTower7,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Death Armos"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020E2000 + 0x172, ChestAttribute.AppearanceType.AppearsSwitch, 0x02156000 + 0x10A)]
        [GetItemIndex(0x1BB)]
        CollectibleStrayFairyStoneTower8,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Updraft Frozen Eye"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02104000 + 0x262, ChestAttribute.AppearanceType.AppearsSwitch, 0x02177000 + 0x2AE)]
        [GetItemIndex(0x1BC)]
        CollectibleStrayFairyStoneTower9,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Thin Bridge"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0211D000 + 0x1E2, ChestAttribute.AppearanceType.AppearsSwitch, 0x0218C000 + 0x25E)]
        [GetItemIndex(0x1BD)]
        CollectibleStrayFairyStoneTower10,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Basement Ledge"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x0210F000 + 0x212, ChestAttribute.AppearanceType.Normal, 0x02182000 + 0x20E)]
        [GetItemIndex(0x1BE)]
        CollectibleStrayFairyStoneTower11,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Statue Eye"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020E2000 + 0x182, ChestAttribute.AppearanceType.AppearsSwitch, 0x02156000 + 0x11A)]
        [GetItemIndex(0x1BF)]
        CollectibleStrayFairyStoneTower12,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Underwater"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02104000 + 0x272, ChestAttribute.AppearanceType.AppearsSwitch, 0x02177000 + 0x2BE)]
        [GetItemIndex(0x1C0)]
        CollectibleStrayFairyStoneTower13,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Bridge Crystal"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x020F1000 + 0x1B2, ChestAttribute.AppearanceType.AppearsSwitch, 0x02164000 + 0x18E)]
        [GetItemIndex(0x1C1)]
        CollectibleStrayFairyStoneTower14,

        [ItemName("Stone Tower Stray Fairy"), LocationName("Stone Tower Lava Room Ledge"), Region(Region.StoneTowerTemple)]
        [GossipLocationHint("a lost creature"), GossipItemHint("a lost fairy")]
        [ShopText("Collect 15 and return them to the Fairy Fountain in Stone Tower.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold), Chest(0x02122000 + 0x206, ChestAttribute.AppearanceType.Normal, 0x02191000 + 0x8A)]
        [GetItemIndex(0x1C2)]
        CollectibleStrayFairyStoneTower15,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Lottery"), Region(Region.WestClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x86)]
        MundaneItemLotteryPurpleRupee,

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Bank Reward #2"), Region(Region.WestClockTown)]
        [GossipLocationHint(""), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x13D)]
        MundaneItemBankBlueRupee,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Chateau Romani"), LocationName("Milk Bar Chateau"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town shop"), GossipItemHint("a dairy product", "an adult beverage")]
        [ShopText("Drink it to get lasting stamina for your magic power.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x180)]
        ShopItemMilkBarChateau,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Milk Bar Milk"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town shop"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x181)]
        ShopItemMilkBarMilk,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Deku Playground Any Day"), Region(Region.NorthClockTown)]
        [GossipLocationHint("a game for scrubs", "a playground", "a town game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x133)]
        MundaneItemDekuPlaygroundPurpleRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Honey and Darling Any Day"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x183)]
        MundaneItemHoneyAndDarlingPurpleRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Kotake Mushroom Sale"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x187)]
        MundaneItemKotakeMushroomSaleRedRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Pictograph Contest Standard Photo"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x188)]
        MundaneItemPictographContestBlueRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pictograph Contest Good Photo"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a swamp game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x18F)]
        MundaneItemPictographContestRedRupee,

        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("Magic Bean"), LocationName("Swamp Scrub Purchase"), Region(Region.SouthernSwamp)]
        [GossipLocationHint("a southern merchant"), GossipItemHint("a plant seed")]
        [ChestType(ChestTypeAttribute.ChestType.LargeGold)]
        [ShopText("Plant it in soft soil.")]
        [GetItemIndex(0x19B)]
        ShopItemBusinessScrubMagicBean,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Green Potion"), LocationName("Ocean Scrub Purchase"), Region(Region.ZoraHall)]
        [GossipLocationHint("a western merchant"), GossipItemHint("a magic potion", "a green drink")]
        [ShopText("Replenishes your magic power.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x19C)]
        ShopItemBusinessScrubGreenPotion,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Blue Potion"), LocationName("Canyon Scrub Purchase"), Region(Region.IkanaCanyon)]
        [GossipLocationHint("an eastern merchant"), GossipItemHint("consumable strength", "a magic potion", "a blue drink")]
        [ShopText("Replenishes both life energy and magic power.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x19D)]
        ShopItemBusinessScrubBluePotion,

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Zora Hall Stage Lights"), Region(Region.ZoraHall)]
        [GossipLocationHint("a good deed"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x19E)]
        MundaneItemZoraStageLightsBlueRupee,

        [Repeatable, Temporary, CycleRepeatable, Overwritable]
        [ItemName("Milk"), LocationName("Gorman Bros Milk Purchase"), Region(Region.MilkRoad)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x1A0)]
        ShopItemGormanBrosMilk,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Ocean Spider House Day 2 Reward"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a gold spider"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff"), GossipCompetitiveHint(0, nameof(SettingsObject.AddSkulltulaTokens))]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x134)]
        MundaneItemOceanSpiderHouseDay2PurpleRupee,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Ocean Spider House Day 3 Reward"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a gold spider"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff"), GossipCompetitiveHint(0, nameof(SettingsObject.AddSkulltulaTokens))]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1A3)]
        MundaneItemOceanSpiderHouseDay3RedRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Bad Pictograph of Lulu"), Region(Region.ZoraHall)]
        [GossipLocationHint("a fan"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1A8)]
        MundaneItemLuluBadPictographBlueRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Good Pictograph of Lulu"), Region(Region.ZoraHall)]
        [GossipLocationHint("a fan"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1C3)]
        MundaneItemLuluGoodPictographRedRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Treasure Chest Game Human"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x00F43F10 + 0xFA8, ChestAttribute.AppearanceType.AppearsSwitch, 0x00F43F10 + 0xFB0)]
        [GetItemIndex(0x1C4)]
        MundaneItemTreasureChestGamePurpleRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Treasure Chest Game Zora"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x00F43F10 + 0xFAC, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x1C5)]
        MundaneItemTreasureChestGameRedRupee,

        [RupeeRepeatable]
        [Repeatable, Temporary, CycleRepeatable]
        [ItemName("10 Deku Nuts"), LocationName("Treasure Chest Game Deku"), Region(Region.EastClockTown)]
        [GossipLocationHint("a town game"), GossipItemHint("a flashing impact")]
        [ShopText("Its flash blinds enemies.", isMultiple: true)]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden), Chest(0x00F43F10 + 0xFAE, ChestAttribute.AppearanceType.AppearsSwitch)]
        [GetItemIndex(0x1C6)]
        MundaneItemTreasureChestGameDekuNuts,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Curiosity Shop Blue Rupee"), Region(Region.WestClockTown)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1C7)]
        MundaneItemCuriosityShopBlueRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Curiosity Shop Red Rupee"), Region(Region.WestClockTown)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1C8)]
        MundaneItemCuriosityShopRedRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Curiosity Shop Purple Rupee"), Region(Region.WestClockTown)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1C9)]
        MundaneItemCuriosityShopPurpleRupee,

        [RupeeRepeatable]
        [Repeatable]
        [ItemName("Gold Rupee"), LocationName("Curiosity Shop Gold Rupee"), Region(Region.WestClockTown)]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 200 rupees.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallWooden)]
        [GetItemIndex(0x1CA)]
        MundaneItemCuriosityShopGoldRupee,

        [Repeatable, Temporary, Overwritable]
        [ItemName("Seahorse"), LocationName("Fisherman Pictograph"), Region(Region.GreatBayCoast)]
        [GossipLocationHint("a fisherman"), GossipItemHint("a sea creature")]
        [ShopText("It wants to go back home to Pinnacle Rock.")]
        [ChestType(ChestTypeAttribute.ChestType.SmallGold)]
        [GetItemIndex(0x95)]
        MundaneItemSeahorse,

        //[GetItemIndex(0x1A1)]

    }
}
