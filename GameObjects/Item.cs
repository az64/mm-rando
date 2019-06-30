using MMRando.Attributes;

namespace MMRando.GameObjects
{
    public enum Item
    {
        // free
        [StartingItem(0xC5CE41, 0x32)]
        [ItemName("Deku Mask"), LocationName("Starting Item #1")]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a woodland spirit")]
        [ShopText("Wear it to assume Deku form.")]
        [GetItemIndex(0x78)]
        MaskDeku = 0,

        // items
        [StartingItem(0xC5CE25, 0x01)]
        [ItemName("Hero's Bow"), LocationName("Hero's Bow Chest"), RegionName("Woodfall Temple")]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("Use it to shoot arrows.")]
        [GetItemIndex(0x22)]
        ItemBow = 1,

        [StartingItem(0xC5CE26, 0x02)]
        [ItemName("Fire Arrow"), LocationName("Fire Arrow Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("the power of fire", "a magical item")]
        [ShopText("Arm your bow with arrows that burst into flame.")]
        [GetItemIndex(0x25)]
        ItemFireArrow = 2,

        [StartingItem(0xC5CE27, 0x03)]
        [ItemName("Ice Arrow"), LocationName("Ice Arrow"), RegionName("Great Bay Temple")]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("the power of ice", "a magical item")]
        [ShopText("Arm your bow with arrows that freeze.")]
        [GetItemIndex(0x26)]
        ItemIceArrow = 3,

        [StartingItem(0xC5CE28, 0x04)]
        [ItemName("Light Arrow"), LocationName("Light Arrow Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("the power of light", "a magical item")]
        [ShopText("Arm your bow with arrows infused with sacred light.")]
        [GetItemIndex(0x27)]
        ItemLightArrow = 4,

        [StartingItem(0xC5CE2A, 0x06)]
        [ItemName("Bomb Bag"), LocationName("Bomb Bag Purchase"), RegionName("West Clock Town")]
        [GossipLocationHint("a town shop"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x48)]
        [ShopRoom(ShopRoomAttribute.Room.CuriosityShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 0)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.CuriosityShop, 1)]
        [ShopText("This can hold up to a maximum of 20 bombs.")]
        [GetItemIndex(0x1B)]
        ItemBombBag = 5,

        [Repeatable]
        [StartingItem(0xC5CE2E, 0x0A)]
        [ItemName("Magic Bean"), LocationName("Bean Man"), RegionName("Deku Palace")]
        [GossipLocationHint("a hidden merchant", "a gorging merchant"), GossipItemHint("a plant seed")]
        [ShopText("Plant it in soft soil.")]
        [GetItemIndex(0x11E)]
        ItemMagicBean = 6,

        [Repeatable]
        [StartingItem(0xC5CE30, 0x0C)]
        [ItemName("Powder Keg"), LocationName("Powder Keg Challenge"), RegionName("Goron Village")]
        [GossipLocationHint("a large goron"), GossipItemHint("gunpowder", "a dangerous item", "an explosive barrel")]
        [ShopText("Both its power and its size are immense!")]
        [GetItemIndex(0x123)]
        ItemPowderKeg = 7,

        [StartingItem(0xC5CE31, 0x0D)]
        [ItemName("Pictobox"), LocationName("Koume"), RegionName("Southern Swamp")]
        [GossipLocationHint("a witch"), GossipItemHint("a light recorder", "a capture device")]
        [ShopText("Use it to snap pictographs.")]
        [GetItemIndex(0x43)]
        ItemPictobox = 8,

        [StartingItem(0xC5CE32, 0x0E)]
        [ItemName("Lens of Truth"), LocationName("Lens of Truth Chest"), RegionName("Goron Village")]
        [GossipLocationHint("a lonely peak"), GossipItemHint("eyeglasses", "the truth", "focused vision")]
        [ShopText("Uses magic to see what the naked eye cannot.")]
        [GetItemIndex(0x42)]
        ItemLens = 9,

        [StartingItem(0xC5CE33, 0x0F)]
        [ItemName("Hookshot"), LocationName("Hookshot Chest"), RegionName("Pirates' Fortress Interior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("a chain and grapple")]
        [ShopText("Use it to grapple objects.")]
        [GetItemIndex(0x41)]
        ItemHookshot = 10,

        [StartingItem(0xC5CE34, 0x10)]
        [ItemName("Great Fairy's Sword"), LocationName("Ikana Great Fairy"), RegionName("Ikana Canyon")]
        [GossipLocationHint("a magical being"), GossipItemHint("a black rose", "a powerful blade")]
        [ShopText("The most powerful sword has black roses etched in its blade.")]
        [GetItemIndex(0x3B)]
        ItemFairySword = 11,

        [StartingItem(0xC5CE36, 0x12)]
        [ItemName("Bottle with Red Potion"), LocationName("Kotake"), RegionName("Southern Swamp")]
        [GossipLocationHint("the sleeping witch"), GossipItemHint("a vessel of health", "bottled fortitude")]
        [ShopText("Replenishes your life energy. Comes with an Empty Bottle.")]
        [GetItemIndex(0x59)]
        ItemBottleWitch = 12,

        [StartingItem(0xC5CE37, 0x12)]
        [ItemName("Bottle with Milk"), LocationName("Aliens Defense"), RegionName("Romani Ranch")]
        [GossipLocationHint("the ranch girl", "a good deed"), GossipItemHint("a dairy product", "the produce of cows")]
        [ShopText("Recover five hearts with one drink. Contains two helpings. Comes with an Empty Bottle.")]
        [GetItemIndex(0x60)]
        ItemBottleAliens = 13,

        [Repeatable, Temporary]
        [StartingItem(0xC5CE38, 0x12)]
        [ItemName("Gold Dust"), LocationName("Goron Race"), RegionName("Twin Islands")]
        [GossipLocationHint("a sporting event"), GossipItemHint("a gleaming powder")]
        [ShopText("It's very high quality.")]
        [GetItemIndex(0x93)] // originally 0x6A for Bottle with Gold Dust
        ItemGoldDust = 14, // originally ItemBottleGoronRace

        [StartingItem(0xC5CE39, 0x12)]
        [ItemName("Empty Bottle"), LocationName("Beaver Race #1"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a river dweller"), GossipItemHint("an empty vessel", "a glass container")]
        [ShopText("Carry various items in this.")]
        [GetItemIndex(0x5A)]
        ItemBottleBeavers = 15,

        [StartingItem(0xC5CE3A, 0x12)]
        [ItemName("Empty Bottle"), LocationName("Dampe Digging"), RegionName("Ikana Graveyard")]
        [GossipLocationHint("a fearful basement"), GossipItemHint("an empty vessel", "a glass container")]
        [ShopText("Carry various items in this.")]
        [GetItemIndex(0x64)]
        ItemBottleDampe = 16,

        [StartingItem(0xC5CE3B, 0x12)]
        [ItemName("Bottle with Chateau Romani"), LocationName("Madame Aroma in Bar"), RegionName("East Clock Town")]
        [GossipLocationHint("an important lady"), GossipItemHint("a dairy product", "an adult beverage")]
        [ShopText("Drink it to get lasting stamina for your magic power. Comes with an Empty Bottle.")]
        [GetItemIndex(0x6F)]
        ItemBottleMadameAroma = 17,

        [StartingItem(0xC5CE71, 0x04)]
        [ItemName("Bombers' Notebook"), LocationName("Bombers' Hide and Seek"), RegionName("North Clock Town")]
        [GossipLocationHint("a group of children", "a town game"), GossipItemHint("a handy notepad", "a quest logbook")]
        [ShopText("Allows you to keep track of people's schedules.")]
        [GetItemIndex(0x50)]
        ItemNotebook = 18,

        //upgrades
        [Repeatable]
        [StartingItem(0xC5CE21, 0x02)]
        [ItemName("Razor Sword"), LocationName("Mountain Smithy Day 1"), RegionName("Mountain Village")]
        [GossipLocationHint("the mountain smith"), GossipItemHint("a sharp blade")]
        [ShopText("A sharp sword forged at the smithy.")]
        [GetItemIndex(0x38)]
        UpgradeRazorSword = 19,

        [Downgradable, Repeatable]
        [StartingItem(0xC5CE21, 0x03)]
        [ItemName("Gilded Sword"), LocationName("Mountain Smithy Day 2"), RegionName("Mountain Village")]
        [GossipLocationHint("the mountain smith"), GossipItemHint("a sharp blade")]
        [ShopText("A very sharp sword forged from gold dust.")]
        [GetItemIndex(0x39)]
        UpgradeGildedSword = 20,

        [Downgradable]
        [StartingItem(0xC5CE21, 0x20)]
        [ItemName("Mirror Shield"), LocationName("Mirror Shield Chest"), RegionName("Beneath the Well")]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a reflective guard", "echoing protection")]
        [ShopText("It can reflect certain rays of light.")]
        [GetItemIndex(0x33)]
        UpgradeMirrorShield = 21,

        [StartingItem(0xC5CE25, 0x01)]
        [ItemName("Large Quiver"), LocationName("Town Archery #1"), RegionName("East Clock Town")]
        [GossipLocationHint("a town activity"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("This can hold up to a maximum of 40 arrows.")]
        [GetItemIndex(0x23)]
        UpgradeBigQuiver = 22,

        [Downgradable]
        [StartingItem(0xC5CE25, 0x01)]
        [ItemName("Largest Quiver"), LocationName("Swamp Archery #1"), RegionName("Road to Southern Swamp")]
        [GossipLocationHint("a swamp game"), GossipItemHint("a projectile", "a ranged weapon")]
        [ShopText("This can hold up to a maximum of 50 arrows.")]
        [GetItemIndex(0x24)]
        UpgradeBiggestQuiver = 23,

        [Downgradable]
        [StartingItem(0xC5CE2A, 0x06)]
        [ItemName("Big Bomb Bag"), LocationName("Big Bomb Bag Purchase"), RegionName("West Clock Town")]
        [GossipLocationHint("a town shop"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x52)]
        [ShopRoom(ShopRoomAttribute.Room.CuriosityShop, 0x5A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.CuriosityShop, 2)]
        [ShopText("This can hold up to a maximum of 30 bombs.")]
        [GetItemIndex(0x1C)]
        UpgradeBigBombBag = 24,

        [Downgradable]
        [StartingItem(0xC5CE2A, 0x06)]
        [ItemName("Biggest Bomb Bag"), LocationName("Biggest Bomb Bag Purchase"), RegionName("Goron Village")]
        [GossipLocationHint("a northern merchant"), GossipItemHint("an item carrier", "a vessel of explosives")]
        [ShopText("This can hold up to a maximum of 40 bombs.")]
        [GetItemIndex(0x1D)]
        UpgradeBiggestBombBag = 25,

        [StartingItem(0xC5CE6E, 0x10)]
        [ItemName("Adult Wallet"), LocationName("Bank Reward #1"), RegionName("West Clock Town")]
        [GossipLocationHint("a keeper of wealth"), GossipItemHint("a coin case", "great wealth")]
        [ShopText("This can hold up to a maximum of 200 rupees.")]
        [GetItemIndex(0x08)]
        UpgradeAdultWallet = 26,

        [Downgradable]
        [StartingItem(0xC5CE6E, 0x20)]
        [ItemName("Giant Wallet"), LocationName("Ocean Spider House Reward"), RegionName("Great Bay Coast")]
        [GossipLocationHint("a gold spider"), GossipItemHint("a coin case", "great wealth")]
        [ShopText("This can hold up to a maximum of 500 rupees.")]
        [GetItemIndex(0x09)]
        UpgradeGiantWallet = 27,

        //trades
        [Repeatable, Temporary]
        [ItemName("Moon's Tear"), LocationName("Astronomy Telescope"), RegionName("Termina Field")]
        [GossipLocationHint("a falling star"), GossipItemHint("a lunar teardrop", "celestial sadness")]
        [ShopText("A shining stone from the moon.")]
        [GetItemIndex(0x96)]
        TradeItemMoonTear = 28,

        [Repeatable, Temporary]
        [ItemName("Land Title Deed"), LocationName("Clock Town Scrub Trade"), RegionName("South Clock Town")]
        [GossipLocationHint("a town merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Clock Town.")]
        [GetItemIndex(0x97)]
        TradeItemLandDeed = 29,

        [Repeatable, Temporary]
        [ItemName("Swamp Title Deed"), LocationName("Swamp Scrub Trade"), RegionName("Southern Swamp")]
        [GossipLocationHint("a southern merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Southern Swamp.")]
        [GetItemIndex(0x98)]
        TradeItemSwampDeed = 30,

        [Repeatable, Temporary]
        [ItemName("Mountain Title Deed"), LocationName("Mountain Scrub Trade"), RegionName("Goron Village")]
        [GossipLocationHint("a northern merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower near Goron Village.")]
        [GetItemIndex(0x99)]
        TradeItemMountainDeed = 31,

        [Repeatable, Temporary]
        [ItemName("Ocean Title Deed"), LocationName("Ocean Scrub Trade"), RegionName("Zora Hall")]
        [GossipLocationHint("a western merchant"), GossipItemHint("a property deal")]
        [ShopText("The title deed to the Deku Flower in Zora Hall.")]
        [GetItemIndex(0x9A)]
        TradeItemOceanDeed = 32,

        [Repeatable, Temporary]
        [ItemName("Room Key"), LocationName("Inn Reservation"), RegionName("East Clock Town")]
        [GossipLocationHint("checking in", "check-in"), GossipItemHint("a door opener", "a lock opener")]
        [ShopText("With this, you can go in and out of the Stock Pot Inn at night.")]
        [GetItemIndex(0xA0)]
        TradeItemRoomKey = 33,

        [Repeatable, Temporary]
        [ItemName("Letter to Kafei"), LocationName("Midnight Meeting"), RegionName("East Clock Town")]
        [GossipLocationHint("a late meeting"), GossipItemHint("a lover's plight", "a lover's letter")]
        [ShopText("A love letter from Anju to Kafei.")]
        [GetItemIndex(0xAA)]
        TradeItemKafeiLetter = 34,

        [Repeatable, Temporary]
        [ItemName("Pendant of Memories"), LocationName("Kafei"), RegionName("Laundry Pool")]
        [GossipLocationHint("a posted letter"), GossipItemHint("a cherished necklace", "a symbol of trust")]
        [ShopText("Kafei's symbol of trust for Anju.")]
        [GetItemIndex(0xAB)]
        TradeItemPendant = 35,

        [Repeatable, Temporary]
        [ItemName("Letter to Mama"), LocationName("Curiosity Shop Man #2"), RegionName("Laundry Pool")]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("an important note", "a special delivery")]
        [ShopText("It's a parcel for Kafei's mother.")]
        [GetItemIndex(0xA1)]
        TradeItemMamaLetter = 36,

        //notebook hp
        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Mayor"), RegionName("East Clock Town")]
        [GossipLocationHint("a town leader", "an upstanding figure"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x03)]
        HeartPieceNotebookMayor = 37,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Postman's Game"), RegionName("West Clock Town")]
        [GossipLocationHint("a hard worker", "a delivery person"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xCE)]
        HeartPieceNotebookPostman = 38,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Rosa Sisters"), RegionName("West Clock Town")]
        [GossipLocationHint("traveling sisters", "twin entertainers"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x2B)]
        HeartPieceNotebookRosa = 39,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Toilet Hand"), RegionName("East Clock Town")]
        [GossipLocationHint("a mystery appearance", "a strange palm"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x2C)]
        HeartPieceNotebookHand = 40,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Grandma Short Story"), RegionName("East Clock Town")]
        [GossipLocationHint("an old lady"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x2D)]
        HeartPieceNotebookGran1 = 41,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Grandma Long Story"), RegionName("East Clock Town")]
        [GossipLocationHint("an old lady"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x2F)]
        HeartPieceNotebookGran2 = 42,

        //other hp
        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Keaton Quiz"), RegionName("North Clock Town")]
        [GossipLocationHint("the ghost of a fox", "a mysterious fox"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x30)]
        HeartPieceKeatonQuiz = 43,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Deku Playground"), RegionName("North Clock Town")]
        [GossipLocationHint("a game for scrubs", "a playground", "a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x31)]
        HeartPieceDekuPlayground = 44,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Town Archery #2"), RegionName("East Clock Town")]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x90)]
        HeartPieceTownArchery = 45,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Honey and Darling"), RegionName("East Clock Town")]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x94)]
        HeartPieceHoneyAndDarling = 46,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Swordsman's School"), RegionName("West Clock Town")]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x9F)]
        HeartPieceSwordsmanSchool = 47,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Postbox"), RegionName("South Clock Town")]
        [GossipLocationHint("an information carrier", "a correspondence box"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA2)]
        HeartPiecePostBox = 48,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Gossip Stones"), RegionName("Termina Field")]
        [GossipLocationHint("mysterious stones"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA3)]
        HeartPieceTerminaGossipStones = 49,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Business Scrub Purchase"), RegionName("Termina Field")]
        [GossipLocationHint("a hidden merchant"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA5)]
        HeartPieceTerminaBusinessScrub = 50,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Swamp Archery #2"), RegionName("Road to Southern Swamp")]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA6)]
        HeartPieceSwampArchery = 51,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Pictograph Contest"), RegionName("Southern Swamp")]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA7)]
        HeartPiecePictobox = 52,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Boat Archery"), RegionName("Southern Swamp")]
        [GossipLocationHint("a swamp game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xA8)]
        HeartPieceBoatArchery = 53,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Frog Choir"), RegionName("Mountain Village")]
        [GossipLocationHint("a reunion", "a chorus", "an amphibian choir"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xAC)]
        HeartPieceChoir = 54,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Beaver Race #2"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a river dweller", "a race in the water"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xAD)]
        HeartPieceBeaverRace = 55,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Seahorse"), RegionName("Pinnacle Rock")]
        [GossipLocationHint("a reunion"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xAE)]
        HeartPieceSeaHorse = 56,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Fisherman Game"), RegionName("Great Bay Coast")]
        [GossipLocationHint("an ocean game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xAF)]
        HeartPieceFishermanGame = 57,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Evan"), RegionName("Zora Hall")]
        [GossipLocationHint("a muse", "a composition", "a musician", "plagiarism"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xB0)]
        HeartPieceEvan = 58,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Dog Race"), RegionName("Romani Ranch")]
        [GossipLocationHint("a sporting event"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xB1)]
        HeartPieceDogRace = 59,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Poe Hut"), RegionName("Ikana Canyon")]
        [GossipLocationHint("a game of ghosts"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0xB2)]
        HeartPiecePoeHut = 60,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Treasure Chest Game"), RegionName("East Clock Town")]
        [GossipLocationHint("a town game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x17)]
        HeartPieceTreasureChestGame = 61,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Peahat Grotto"), RegionName("Termina Field")]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x18)]
        HeartPiecePeahat = 62,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Dodongo Grotto"), RegionName("Termina Field")]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x20)]
        HeartPieceDodong = 63,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Woodfall Heart Piece Chest"), RegionName("Woodfall")]
        [GossipLocationHint("the swamp lands", "an exposed chest"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x29)]
        HeartPieceWoodFallChest = 64,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Twin Islands Heart Piece Chest"), RegionName("Twin Islands")]
        [GossipLocationHint("a spring treasure", "a defrosted land", "a submerged chest"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x2E)]
        HeartPieceTwinIslandsChest = 65,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Ocean Spider House Heart Piece Chest"), RegionName("Great Bay Coast")]
        [GossipLocationHint("the strange masks", "coloured faces"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x14)]
        HeartPieceOceanSpiderHouse = 66,

        [StartingItem(0xC5CE70, 0x10)]
        [ItemName("Heart Piece"), LocationName("Iron Knuckle Chest"), RegionName("Ikana Graveyard")]
        [GossipLocationHint("a hollow ground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x44)]
        HeartPieceKnuckle = 67,

        //mask
        [StartingItem(0xC5CE3C, 0x3E)]
        [ItemName("Postman's Hat"), LocationName("Postman's Freedom Reward"), RegionName("East Clock Town")]
        [GossipLocationHint("a special delivery", "one last job"), GossipItemHint("a hard worker's hat")]
        [ShopText("You can look into mailboxes when you wear this.")]
        [GetItemIndex(0x84)]
        MaskPostmanHat = 68,

        [StartingItem(0xC5CE3D, 0x38)]
        [ItemName("All Night Mask"), LocationName("All Night Mask Purchase"), RegionName("West Clock Town")]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("insomnia")]
        [ShopRoom(ShopRoomAttribute.Room.CuriosityShop, 0x54)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.CuriosityShop, 0)]
        [ShopText("When you wear it you don't get sleepy.")]
        [GetItemIndex(0x7E)]
        MaskAllNight = 69,

        [StartingItem(0xC5CE3E, 0x47)]
        [ItemName("Blast Mask"), LocationName("Old Lady"), RegionName("North Clock Town")]
        [GossipLocationHint("a good deed", "an old lady's struggle"), GossipItemHint("a dangerous mask")]
        [ShopText("Wear it and detonate it...")]
        [GetItemIndex(0x8D)]
        MaskBlast = 70,

        [StartingItem(0xC5CE3F, 0x45)]
        [ItemName("Stone Mask"), LocationName("Invisible Soldier"), RegionName("Road to Ikana")]
        [GossipLocationHint("a hidden soldier", "a stone circle"), GossipItemHint("inconspicuousness")]
        [ShopText("Become as plain as stone so you can blend into your surroundings.")]
        [GetItemIndex(0x8B)]
        MaskStone = 71,

        [StartingItem(0xC5CE40, 0x40)]
        [ItemName("Great Fairy's Mask"), LocationName("Clock Town Great Fairy"), RegionName("North Clock Town")]
        [GossipLocationHint("a magical being"), GossipItemHint("a friend of fairies")]
        [ShopText("The mask's hair will shimmer when you're close to a Stray Fairy.")]
        [GetItemIndex(0x86)]
        MaskGreatFairy = 72,

        [StartingItem(0xC5CE42, 0x3A)]
        [ItemName("Keaton Mask"), LocationName("Curiosity Shop Man #1"), RegionName("Laundry Pool")]
        [GossipLocationHint("a shady gentleman", "a dodgy seller", "a shady dealer"), GossipItemHint("a popular mask", "a fox's mask")]
        [ShopText("The mask of the ghost fox, Keaton.")]
        [GetItemIndex(0x80)]
        MaskKeaton = 73,

        [StartingItem(0xC5CE43, 0x46)]
        [ItemName("Bremen Mask"), LocationName("Guru Guru"), RegionName("Laundry Pool")]
        [GossipLocationHint("a musician", "an entertainer"), GossipItemHint("a mask of leadership", "a bird's mask")]
        [ShopText("Wear it so young animals will mistake you for their leader.")]
        [GetItemIndex(0x8C)]
        MaskBremen = 74,

        [StartingItem(0xC5CE44, 0x39)]
        [ItemName("Bunny Hood"), LocationName("Grog"), RegionName("Romani Ranch")]
        [GossipLocationHint("an ugly but kind heart", "a lover of chickens"), GossipItemHint("the ears of the wild", "a rabbit's hearing")]
        [ShopText("Wear it to be filled with the speed and hearing of the wild.")]
        [GetItemIndex(0x7F)]
        MaskBunnyHood = 75,

        [StartingItem(0xC5CE45, 0x42)]
        [ItemName("Don Gero's Mask"), LocationName("Hungry Goron"), RegionName("Mountain Village")]
        [GossipLocationHint("a hungry goron", "a person in need"), GossipItemHint("a conductor's mask", "an amphibious mask")]
        [ShopText("When you wear it, you can call the Frog Choir members together.")]
        [GetItemIndex(0x88)]
        MaskDonGero = 76,

        [StartingItem(0xC5CE46, 0x48)]
        [ItemName("Mask of Scents"), LocationName("Butler"), RegionName("Deku Palace")]
        [GossipLocationHint("a servant of royalty", "the royal servant"), GossipItemHint("heightened senses", "a pig's mask")]
        [ShopText("Wear it to heighten your sense of smell.")]
        [GetItemIndex(0x8E)]
        MaskScents = 77,

        [StartingItem(0xC5CE48, 0x3C)]
        [ItemName("Romani Mask"), LocationName("Cremia"), RegionName("Romani Ranch")]
        [GossipLocationHint("the ranch lady", "an older sister"), GossipItemHint("proof of membership", "a cow's mask")]
        [ShopText("Wear it to show you're a member of the Milk Bar, Latte.")]
        [GetItemIndex(0x82)]
        MaskRomani = 78,

        [StartingItem(0xC5CE49, 0x3D)]
        [ItemName("Circus Leader's Mask"), LocationName("Gorman"), RegionName("East Clock Town")]
        [GossipLocationHint("an entertainer", "a miserable leader"), GossipItemHint("a mask of sadness")]
        [ShopText("People related to Gorman will react to this.")]
        [GetItemIndex(0x83)]
        MaskCircusLeader = 79,

        [StartingItem(0xC5CE4A, 0x37)]
        [ItemName("Kafei's Mask"), LocationName("Madame Aroma in Office"), RegionName("East Clock Town")]
        [GossipLocationHint("an important lady", "an esteemed woman"), GossipItemHint("the mask of a missing one", "a son's mask")]
        [ShopText("Wear it to inquire about Kafei's whereabouts.")]
        [GetItemIndex(0x8F)]
        MaskKafei = 80,

        [StartingItem(0xC5CE4B, 0x3F)]
        [ItemName("Couple's Mask"), LocationName("Anju and Kafei"), RegionName("East Clock Town")]
        [GossipLocationHint("a reunion", "a lovers' reunion"), GossipItemHint("a sign of love", "the mark of a couple")]
        [ShopText("When you wear it, you can soften people's hearts.")]
        [GetItemIndex(0x85)]
        MaskCouple = 81,

        [StartingItem(0xC5CE4C, 0x36)]
        [ItemName("Mask of Truth"), LocationName("Swamp Spider House Reward"), RegionName("Southern Swamp")]
        [GossipLocationHint("a gold spider"), GossipItemHint("a piercing gaze")]
        [ShopText("Wear it to read the thoughts of Gossip Stones and animals.")]
        [GetItemIndex(0x8A)]
        MaskTruth = 82,

        [StartingItem(0xC5CE4E, 0x43)]
        [ItemName("Kamaro's Mask"), LocationName("Kamaro"), RegionName("Termina Field")]
        [GossipLocationHint("a ghostly dancer", "a dancer"), GossipItemHint("dance moves")]
        [ShopText("Wear this to perform a mysterious dance.")]
        [GetItemIndex(0x89)]
        MaskKamaro = 83,

        [StartingItem(0xC5CE4F, 0x41)]
        [ItemName("Gibdo Mask"), LocationName("Pamela's Father"), RegionName("Ikana Canyon")]
        [GossipLocationHint("a healed spirit", "a lost father"), GossipItemHint("a mask of monsters")]
        [ShopText("Even a real Gibdo will mistake you for its own kind.")]
        [GetItemIndex(0x87)]
        MaskGibdo = 84,

        [StartingItem(0xC5CE50, 0x3B)]
        [ItemName("Garo's Mask"), LocationName("Gorman Bros Race"), RegionName("Milk Road")]
        [GossipLocationHint("a sporting event"), GossipItemHint("the mask of spies")]
        [ShopText("This mask can summon the hidden Garo ninjas.")]
        [GetItemIndex(0x81)]
        MaskGaro = 85,

        [StartingItem(0xC5CE51, 0x44)]
        [ItemName("Captain's Hat"), LocationName("Captain Keeta's Chest"), RegionName("Ikana Graveyard")]
        [GossipLocationHint("a ghostly battle", "a skeletal leader"), GossipItemHint("a commanding presence")]
        [ShopText("Wear it to pose as Captain Keeta.")]
        [GetItemIndex(0x7C)]
        MaskCaptainHat = 86,

        [StartingItem(0xC5CE52, 0x49)]
        [ItemName("Giant's Mask"), LocationName("Giant's Mask Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a growth spurt")]
        [ShopText("If you wear it in a certain room, you'll grow into a giant.")]
        [GetItemIndex(0x7D)]
        MaskGiant = 87,

        [StartingItem(0xC5CE47, 0x33)]
        [ItemName("Goron Mask"), LocationName("Darmani"), RegionName("Mountain Village")]
        [GossipLocationHint("a healed spirit", "the lost champion"), GossipItemHint("a mountain spirit")]
        [ShopText("Wear it to assume Goron form.")]
        [GetItemIndex(0x79)]
        MaskGoron = 88,

        [StartingItem(0xC5CE4D, 0x34)]
        [ItemName("Zora Mask"), LocationName("Mikau"), RegionName("Great Bay Coast")]
        [GossipLocationHint("a healed spirit", "a fallen guitarist"), GossipItemHint("an ocean spirit")]
        [ShopText("Wear it to assume Zora form.")]
        [GetItemIndex(0x7A)]
        MaskZora = 89,

        //song
        [StartingItem(0xC5CE72, 0x20)]
        [ItemName("Song of Healing"), LocationName("Starting Item #2")]
        [GossipLocationHint("a new file", "a quest's inception"), GossipItemHint("a soothing melody")]
        [ShopText("This melody will soothe restless spirits.")]
        [GetItemIndex(0x124)]
        SongHealing = 90,

        [StartingItem(0xC5CE72, 0x80)]
        [ItemName("Song of Soaring"), LocationName("Swamp Music Statue"), RegionName("Southern Swamp")]
        [GossipLocationHint("a stone tablet"), GossipItemHint("white wings")]
        [ShopText("This melody sends you to a stone bird statue in an instant.")]
        [GetItemIndex(0x70)]
        SongSoaring = 91,

        [StartingItem(0xC5CE72, 0x40)]
        [ItemName("Epona's Song"), LocationName("Romani's Game"), RegionName("Romani Ranch")]
        [GossipLocationHint("a reunion"), GossipItemHint("a horse's song", "a song of the field")]
        [ShopText("This melody calls your horse, Epona.")]
        [GetItemIndex(0x71)]
        SongEpona = 92,

        [StartingItem(0xC5CE71, 0x01)]
        [ItemName("Song of Storms"), LocationName("Day 1 Grave Tablet"), RegionName("Ikana Graveyard")]
        [GossipLocationHint("a hollow ground", "a stone tablet"), GossipItemHint("rain and thunder", "stormy weather")]
        [ShopText("This melody is the turbulent tune that blows curses away.")]
        [GetItemIndex(0x72)]
        SongStorms = 93,

        [StartingItem(0xC5CE73, 0x40)]
        [ItemName("Sonata of Awakening"), LocationName("Imprisoned Monkey"), RegionName("Deku Palace")]
        [GossipLocationHint("a prisoner", "a false imprisonment"), GossipItemHint("a royal song", "an awakening melody")]
        [ShopText("This melody awakens those who have fallen into a deep sleep.")]
        [GetItemIndex(0x73)]
        SongSonata = 94,

        [StartingItem(0xC5CE73, 0x80)]
        [ItemName("Goron Lullaby"), LocationName("Baby Goron"), RegionName("Goron Village")]
        [GossipLocationHint("a lonely child", "an elder's son"), GossipItemHint("a sleepy melody", "a father's lullaby")]
        [ShopText("This melody blankets listeners in calm while making eyelids grow heavy.")]
        [GetItemIndex(0x74)]
        SongLullaby = 95,

        [StartingItem(0xC5CE72, 0x01)]
        [ItemName("New Wave Bossa Nova"), LocationName("Baby Zoras"), RegionName("Great Bay Coast")]
        [GossipLocationHint("the lost children", "the pirates' loot"), GossipItemHint("an ocean roar", "a song of newborns")]
        [ShopText("It's the melody taught by the Zora children that invigorates singing voices.")]
        [GetItemIndex(0x75)]
        SongNewWaveBossaNova = 96,

        [StartingItem(0xC5CE72, 0x02)]
        [ItemName("Elegy of Emptiness"), LocationName("Ikana King"), RegionName("Ikana Castle")]
        [GossipLocationHint("a fallen king", "a battle in darkness"), GossipItemHint("empty shells", "skin shedding")]
        [ShopText("It's a mystical song that allows you to shed a shell shaped in your current image.")]
        [GetItemIndex(0x76)]
        SongElegy = 97,

        [StartingItem(0xC5CE72, 0x04)]
        [ItemName("Oath to Order"), LocationName("Four Giants")]
        [GossipLocationHint("cleansed evil", "a fallen evil"), GossipItemHint("a song of summoning", "a song of giants")]
        [ShopText("This melody will call the giants at the right moment.")]
        [GetItemIndex(0x77)]
        SongOath = 98,

        //areas/other
        AreaSouthAccess = 99,
        AreaWoodFallTempleAccess = 100,
        AreaWoodFallTempleClear = 101,
        AreaNorthAccess = 102,
        AreaSnowheadTempleAccess = 103,
        AreaSnowheadTempleClear = 104,
        OtherEpona = 105,
        AreaWestAccess = 106,
        AreaPiratesFortressAccess = 107,
        AreaGreatBayTempleAccess = 108,
        AreaGreatBayTempleClear = 109,
        AreaEastAccess = 110,
        AreaIkanaCanyonAccess = 111,
        AreaStoneTowerTempleAccess = 112,
        AreaInvertedStoneTowerTempleAccess = 113,
        AreaStoneTowerClear = 114,
        OtherExplosive = 115,
        OtherArrow = 116,
        AreaWoodfallNew = 117,
        AreaSnowheadNew = 118,
        AreaGreatBayNew = 119,
        AreaLANew = 120, // ??
        AreaInvertedStoneTowerNew = 121, // Seemingly not used

        //keysanity items
        [ItemName("Woodfall Map"), LocationName("Woodfall Map Chest"), RegionName("Woodfall Temple")]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Woodfall Temple.")]
        [GetItemIndex(0x3E)]
        ItemWoodfallMap = 122,

        [ItemName("Woodfall Compass"), LocationName("Woodfall Compass Chest"), RegionName("Woodfall Temple")]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Woodfall Temple.")]
        [GetItemIndex(0x3F)]
        ItemWoodfallCompass = 123,

        [Repeatable, Temporary]
        [ItemName("Woodfall Boss Key"), LocationName("Woodfall Boss Key Chest"), RegionName("Woodfall Temple")]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Woodfall Temple.")]
        [GetItemIndex(0x3D)]
        ItemWoodfallBossKey = 124,

        [Repeatable, Temporary]
        [ItemName("Woodfall Small Key"), LocationName("Woodfall Small Key Chest"), RegionName("Woodfall Temple")]
        [GossipLocationHint("Woodfall Temple", "the sleeping temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Woodfall Temple.")]
        [GetItemIndex(0x3C)]
        ItemWoodfallKey1 = 125,

        [ItemName("Snowhead Map"), LocationName("Snowhead Map Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Snowhead Temple.")]
        [GetItemIndex(0x54)]
        ItemSnowheadMap = 126,

        [ItemName("Snowhead Compass"), LocationName("Snowhead Compass Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Snowhead Temple.")]
        [GetItemIndex(0x57)]
        ItemSnowheadCompass = 127,

        [Repeatable, Temporary]
        [ItemName("Snowhead Boss Key"), LocationName("Snowhead Boss Key Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Snowhead Temple.")]
        [GetItemIndex(0x4E)]
        ItemSnowheadBossKey = 128,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Block Room Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [GetItemIndex(0x46)]
        ItemSnowheadKey1 = 129,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Icicle Room Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [GetItemIndex(0x47)]
        ItemSnowheadKey2 = 130,

        [Repeatable, Temporary]
        [ItemName("Snowhead Small Key"), LocationName("Snowhead Bridge Room Chest"), RegionName("Snowhead Temple")]
        [GossipLocationHint("Snowhead Temple", "an icy gale"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Snowhead Temple.")]
        [GetItemIndex(0x48)]
        ItemSnowheadKey3 = 131,

        [ItemName("Great Bay Map"), LocationName("Great Bay Map Chest"), RegionName("Great Bay Temple")]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Great Bay Temple.")]
        [GetItemIndex(0x55)]
        ItemGreatBayMap = 132,

        [ItemName("Great Bay Compass"), LocationName("Great Bay Compass Chest"), RegionName("Great Bay Temple")]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Great Bay Temple.")]
        [GetItemIndex(0x58)]
        ItemGreatBayCompass = 133,

        [Repeatable, Temporary]
        [ItemName("Great Bay Boss Key"), LocationName("Great Bay Boss Key Chest"), RegionName("Great Bay Temple")]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Great Bay Temple.")]
        [GetItemIndex(0x4F)]
        ItemGreatBayBossKey = 134,

        [Repeatable, Temporary]
        [ItemName("Great Bay Small Key"), LocationName("Great Bay Small Key Chest"), RegionName("Great Bay Temple")]
        [GossipLocationHint("Great Bay Temple", "the ocean temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Great Bay Temple.")]
        [GetItemIndex(0x40)]
        ItemGreatBayKey1 = 135,

        [ItemName("Stone Tower Map"), LocationName("Stone Tower Map Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a navigation aid", "a paper guide")]
        [ShopText("The Dungeon Map for Stone Tower Temple.")]
        [GetItemIndex(0x56)]
        ItemStoneTowerMap = 136,

        [ItemName("Stone Tower Compass"), LocationName("Stone Tower Compass Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("a navigation aid", "a magnetic needle")]
        [ShopText("The Compass for Stone Tower Temple.")]
        [GetItemIndex(0x6C)]
        ItemStoneTowerCompass = 137,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Boss Key"), LocationName("Stone Tower Boss Key Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("an important key", "entry to evil's lair")]
        [ShopText("The key for the boss room in Stone Tower Temple.")]
        [GetItemIndex(0x53)]
        ItemStoneTowerBossKey = 138,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Armor Room Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [GetItemIndex(0x49)]
        ItemStoneTowerKey1 = 139,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Eyegore Room Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [GetItemIndex(0x4A)]
        ItemStoneTowerKey2 = 140,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Updraft Room Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [GetItemIndex(0x4B)]
        ItemStoneTowerKey3 = 141,

        [Repeatable, Temporary]
        [ItemName("Stone Tower Small Key"), LocationName("Stone Tower Death Armos Maze Chest"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("Stone Tower Temple", "the cursed temple"), GossipItemHint("access to a locked door", "a useful key")]
        [ShopText("A small key for use in Stone Tower Temple.")]
        [GetItemIndex(0x4D)]
        ItemStoneTowerKey4 = 142,

        //shop items
        [Repeatable, CycleRepeatable]
        [ItemName("Red Potion"), LocationName("Trading Post Red Potion"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 2)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 3)]
        [ShopText("Replenishes your life energy.")]
        [GetItemIndex(0xCD)]
        ShopItemTradingPostRedPotion = 143,

        [Repeatable, CycleRepeatable]
        [ItemName("Green Potion"), LocationName("Trading Post Green Potion"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a magic potion", "a green drink")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x62)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 7)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 7)]
        [ShopText("Replenishes your magic power.")]
        [GetItemIndex(0xBB)]
        ShopItemTradingPostGreenPotion = 144,

        [Repeatable, CycleRepeatable]
        [ItemName("Hero's Shield"), LocationName("Trading Post Hero's Shield"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a basic guard", "protection")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 3)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 6)]
        [ShopText("Use it to defend yourself.")]
        [GetItemIndex(0xBC)]
        ShopItemTradingPostShield = 145,

        [Repeatable, CycleRepeatable]
        [ItemName("Fairy"), LocationName("Trading Post Fairy"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a winged friend", "a healer")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x5C)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 0)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 0)]
        [ShopText("Recovers life energy. If you run out of life energy you'll automatically use this.")]
        [GetItemIndex(0xBD)]
        ShopItemTradingPostFairy = 146,

        [Repeatable, CycleRepeatable]
        [ItemName("Deku Stick"), LocationName("Trading Post Deku Stick"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a flammable weapon", "a flimsy weapon")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 4)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 5)]
        [ShopText("Deku Sticks burn well. You can only carry 10.")]
        [GetItemIndex(0xBE)]
        ShopItemTradingPostStick = 147,

        [Repeatable, CycleRepeatable]
        [ItemName("30 Arrows"), LocationName("Trading Post 30 Arrows"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [GetItemIndex(0xBF)]
        ShopItemTradingPostArrow30 = 148,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Deku Nuts"), LocationName("Trading Post 10 Deku Nuts"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a flashing impact")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 6)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 4)]
        [ShopText("Its flash blinds enemies.", isMultiple: true)]
        [GetItemIndex(0xC0)]
        ShopItemTradingPostNut10 = 149,

        [Repeatable, CycleRepeatable]
        [ItemName("50 Arrows"), LocationName("Trading Post 50 Arrows"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant", "a convenience store", "a market"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.TradingPost, 0x64)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostMain, 5)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.TradingPostPartTimer, 2)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [GetItemIndex(0xC1)]
        ShopItemTradingPostArrow50 = 150,

        [Repeatable, CycleRepeatable]
        [ItemName("Blue Potion"), LocationName("Witch Shop Blue Potion"), RegionName("Southern Swamp")]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("consumable strength", "a magic potion", "a blue drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 2)]
        [ShopText("Replenishes both life energy and magic power.")]
        [GetItemIndex(0xC2)]
        ShopItemWitchBluePotion = 151,

        [Repeatable, CycleRepeatable]
        [ItemName("Red Potion"), LocationName("Witch Shop Red Potion"), RegionName("Southern Swamp")]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 0)]
        [ShopText("Replenishes your life energy.")]
        [GetItemIndex(0xC3)]
        ShopItemWitchRedPotion = 152,

        [Repeatable, CycleRepeatable]
        [ItemName("Green Potion"), LocationName("Witch Shop Green Potion"), RegionName("Southern Swamp")]
        [GossipLocationHint("a sleeping witch", "a southern merchant"), GossipItemHint("a magic potion", "a green drink")]
        [ShopRoom(ShopRoomAttribute.Room.WitchShop, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.WitchShop, 1)]
        [ShopText("Replenishes your magic power.")]
        [GetItemIndex(0xC4)]
        ShopItemWitchGreenPotion = 153,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Bombs"), LocationName("Bomb Shop 10 Bombs"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 3)]
        [ShopText("Explosives. You need a Bomb Bag to carry them.", isMultiple: true)]
        [GetItemIndex(0xC5)]
        ShopItemBombsBomb10 = 154,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Bombchu"), LocationName("Bomb Shop 10 Bombchu"), RegionName("West Clock Town")]
        [GossipLocationHint("a town merchant"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.BombShop, 0x42)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.BombShop, 2)]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [GetItemIndex(0xC6)]
        ShopItemBombsBombchu10 = 155,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Bombs"), LocationName("Goron Shop 10 Bombs"), RegionName("Goron Village")]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("explosives")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x48)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 0)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 0)]
        [ShopText("Explosives. You need a Bomb Bag to carry them.", isMultiple: true)]
        [GetItemIndex(0xC7)]
        ShopItemGoronBomb10 = 156,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Arrows"), LocationName("Goron Shop 10 Arrows"), RegionName("Goron Village")]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 1)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [GetItemIndex(0xC8)]
        ShopItemGoronArrow10 = 157,

        [Repeatable, CycleRepeatable]
        [ItemName("Red Potion"), LocationName("Goron Shop Red Potion"), RegionName("Goron Village")]
        [GossipLocationHint("a northern merchant", "a bored goron"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.GoronShop, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShop, 2)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.GoronShopSpring, 2)]
        [ShopText("Replenishes your life energy.")]
        [GetItemIndex(0xC9)]
        ShopItemGoronRedPotion = 158,

        [Repeatable, CycleRepeatable]
        [ItemName("Hero's Shield"), LocationName("Zora Shop Hero's Shield"), RegionName("Zora Hall")]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("a basic guard", "protection")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x4A)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 0)]
        [ShopText("Use it to defend yourself.")]
        [GetItemIndex(0xCA)]
        ShopItemZoraShield = 159,

        [Repeatable, CycleRepeatable]
        [ItemName("10 Arrows"), LocationName("Zora Shop 10 Arrows"), RegionName("Zora Hall")]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("a quiver refill", "a bundle of projectiles")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x44)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 1)]
        [ShopText("Ammo for your bow.", isMultiple: true)]
        [GetItemIndex(0xCB)]
        ShopItemZoraArrow10 = 160,

        [Repeatable, CycleRepeatable]
        [ItemName("Red Potion"), LocationName("Zora Shop Red Potion"), RegionName("Zora Hall")]
        [GossipLocationHint("a western merchant", "an aquatic shop"), GossipItemHint("consumable strength", "a hearty drink", "a red drink")]
        [ShopRoom(ShopRoomAttribute.Room.ZoraShop, 0x46)]
        [ShopInventory(ShopInventoryAttribute.ShopKeeper.ZoraShop, 2)]
        [ShopText("Replenishes your life energy.")]
        [GetItemIndex(0xCC)]
        ShopItemZoraRedPotion = 161,

        //bottle catch
        [ItemName("Bottle: Fairy"), LocationName("Bottle: Fairy")]
        [GossipLocationHint("a wandering healer"), GossipItemHint("a winged friend", "a healer")]
        [GetBottleItemIndices(0x00, 0x0D)]
        BottleCatchFairy = 162,

        [ItemName("Bottle: Deku Princess"), LocationName("Bottle: Deku Princess")]
        [GossipLocationHint("a captured royal", "an imprisoned daughter"), GossipItemHint("a princess", "a woodland royal")]
        [GetBottleItemIndices(0x08)]
        BottleCatchPrincess = 163,

        [ItemName("Bottle: Fish"), LocationName("Bottle: Fish")]
        [GossipLocationHint("a swimming creature", "a water dweller"), GossipItemHint("something fresh")]
        [GetBottleItemIndices(0x01)]
        BottleCatchFish = 164,

        [ItemName("Bottle: Bug"), LocationName("Bottle: Bug")]
        [GossipLocationHint("an insect", "a scuttling creature"), GossipItemHint("an insect", "a scuttling creature")]
        [GetBottleItemIndices(0x02, 0x03)]
        BottleCatchBug = 165,

        [ItemName("Bottle: Poe"), LocationName("Bottle: Poe")]
        [GossipLocationHint("a wandering ghost"), GossipItemHint("a captured spirit")]
        [GetBottleItemIndices(0x0B)]
        BottleCatchPoe = 166,

        [ItemName("Bottle: Big Poe"), LocationName("Bottle: Big Poe")]
        [GossipLocationHint("a huge ghost"), GossipItemHint("a captured spirit")]
        [GetBottleItemIndices(0x0C)]
        BottleCatchBigPoe = 167,

        [ItemName("Bottle: Spring Water"), LocationName("Bottle: Spring Water")]
        [GossipLocationHint("a common liquid"), GossipItemHint("a common liquid", "a fresh drink")]
        [GetBottleItemIndices(0x04)]
        BottleCatchSpringWater = 168,

        [ItemName("Bottle: Hot Spring Water"), LocationName("Bottle: Hot Spring Water")]
        [GossipLocationHint("a hot liquid", "a boiling liquid"), GossipItemHint("a boiling liquid", "a hot liquid")]
        [GetBottleItemIndices(0x05, 0x06)]
        BottleCatchHotSpringWater = 169,

        [ItemName("Bottle: Zora Egg"), LocationName("Bottle: Zora Egg")]
        [GossipLocationHint("a lost child"), GossipItemHint("a lost child")]
        [GetBottleItemIndices(0x07)]
        BottleCatchEgg = 170,

        [ItemName("Bottle: Mushroom"), LocationName("Bottle: Mushroom")]
        [GossipLocationHint("a strange fungus"), GossipItemHint("a strange fungus")]
        [GetBottleItemIndices(0x0A)]
        BottleCatchMushroom = 171,

        //other chests and grottos
        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Lens Cave Invisible Chest"), RegionName("Goron Village")]
        [GossipLocationHint("a lonely peak"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDD)]
        ChestLensCaveRedRupee = 172,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Lens Cave Rock Chest"), RegionName("Goron Village")]
        [GossipLocationHint("a lonely peak"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF4)]
        ChestLensCavePurpleRupee = 173,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Bean Grotto"), RegionName("Deku Palace")]
        [GossipLocationHint("a merchant's cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDE)]
        ChestBeanGrottoRedRupee = 174,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Hot Spring Water Grotto"), RegionName("Twin Islands")]
        [GossipLocationHint("a steaming cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDF)]
        ChestHotSpringGrottoRedRupee = 175,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Day 1 Grave Bats"), RegionName("Ikana Graveyard")]
        [GossipLocationHint("a cloud of bats"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF5)]
        ChestBadBatsGrottoPurpleRupee = 176,

        [Repeatable]
        [ItemName("Recovery Heart"), LocationName("Secret Shrine Grotto"), RegionName("Ikana Canyon")]
        [GossipLocationHint("a waterfall cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("Recovers a small amount of life energy.")]
        [GetItemIndex(0xD1)]
        ChestIkanaGrottoRecoveryHeart = 177,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Lower Chest"), RegionName("Pirates' Fortress Interior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE0)]
        ChestPiratesFortressRedRupee1 = 178,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Upper Chest"), RegionName("Pirates' Fortress Interior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE1)]
        ChestPiratesFortressRedRupee2 = 179,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Interior Tank Chest"), RegionName("Pirates' Fortress Interior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE2)]
        ChestInsidePiratesFortressTankRedRupee = 180,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Pirates' Fortress Interior Guard Room Chest"), RegionName("Pirates' Fortress Interior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0xFB)]
        ChestInsidePiratesFortressGuardSilverRupee = 181,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Heart Piece Room Shallow Chest"), RegionName("Pirates' Fortress Sewer")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE3)]
        ChestInsidePiratesFortressHeartPieceRoomRedRupee = 182,

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Pirates' Fortress Heart Piece Room Deep Chest"), RegionName("Pirates' Fortress Sewer")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [GetItemIndex(0x105)]
        ChestInsidePiratesFortressHeartPieceRoomBlueRupee = 183,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Maze Chest"), RegionName("Pirates' Fortress Sewer")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE4)]
        ChestInsidePiratesFortressMazeRedRupee = 184,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pinnacle Rock Lower Chest"), RegionName("Pinnacle Rock")]
        [GossipLocationHint("a marine trench"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE5)]
        ChestPinacleRockRedRupee1 = 185,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pinnacle Rock Upper Chest"), RegionName("Pinnacle Rock")]
        [GossipLocationHint("a marine trench"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE6)]
        ChestPinacleRockRedRupee2 = 186,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Bombers' Hideout Chest"), RegionName("East Clock Town")]
        [GossipLocationHint("a secret hideout"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0xFC)]
        ChestBomberHideoutSilverRupee = 187,

        [Repeatable]
        [ItemName("1 Bombchu"), LocationName("Termina Field Pillar Grotto"), RegionName("Termina Field")]
        [GossipLocationHint("a hollow pillar"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [GetItemIndex(0xD7)]
        ChestTerminaGrottoBombchu = 188,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Grass Grotto"), RegionName("Termina Field")]
        [GossipLocationHint("a grassy cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDC)]
        ChestTerminaGrottoRedRupee = 189,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Underwater Chest"), RegionName("Termina Field")]
        [GossipLocationHint("a sunken chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE7)]
        ChestTerminaUnderwaterRedRupee = 190,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Grass Chest"), RegionName("Termina Field")]
        [GossipLocationHint("a grassy chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE8)]
        ChestTerminaGrassRedRupee = 191,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Termina Field Stump Chest"), RegionName("Termina Field")]
        [GossipLocationHint("a tree's chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xE9)]
        ChestTerminaStumpRedRupee = 192,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Great Bay Coast Grotto"), RegionName("Great Bay Coast")]
        [GossipLocationHint("a beach cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xD4)]
        ChestGreatBayCoastGrotto = 193, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Great Bay Cape Ledge Without Tree Chest"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a high place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xEA)]
        ChestGreatBayCapeLedge1 = 194, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Great Bay Cape Ledge With Tree Chest"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a high place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xEB)]
        ChestGreatBayCapeLedge2 = 195, //contents? 

        [Repeatable]
        [ItemName("1 Bombchu"), LocationName("Great Bay Cape Grotto"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a beach cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [GetItemIndex(0xD2)]
        ChestGreatBayCapeGrotto = 196, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Great Bay Cape Underwater Chest"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a sunken chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF6)]
        ChestGreatBayCapeUnderwater = 197, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Log Chest"), RegionName("Pirates' Fortress Exterior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xEC)]
        ChestPiratesFortressEntranceRedRupee1 = 198,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Sand Chest"), RegionName("Pirates' Fortress Exterior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xED)]
        ChestPiratesFortressEntranceRedRupee2 = 199,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Pirates' Fortress Exterior Corner Chest"), RegionName("Pirates' Fortress Exterior")]
        [GossipLocationHint("the home of pirates"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xEE)]
        ChestPiratesFortressEntranceRedRupee3 = 200,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Swamp Grotto"), RegionName("Road to Southern Swamp")]
        [GossipLocationHint("a southern cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDB)]
        ChestToSwampGrotto = 201, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Doggy Racetrack Roof Chest"), RegionName("Romani Ranch")]
        [GossipLocationHint("a day at the races"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF7)]
        ChestDogRacePurpleRupee = 202,

        [Repeatable]
        [ItemName("1 Bombchu"), LocationName("Ikana Graveyard Grotto"), RegionName("Ikana Graveyard")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [GossipLocationHint("a circled cave"), GossipItemHint("explosive mice")]
        [GetItemIndex(0xD5)]
        ChestGraveyardGrotto = 203, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Near Swamp Spider House Grotto"), RegionName("Southern Swamp")]
        [GossipLocationHint("a southern cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xDA)]
        ChestSwampGrotto = 204,  //contents? 

        [Repeatable]
        [ItemName("Blue Rupee"), LocationName("Behind Woodfall Owl Chest"), RegionName("Woodfall")]
        [GossipLocationHint("a swamp chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 5 rupees.")]
        [GetItemIndex(0x106)]
        ChestWoodfallBlueRupee = 205,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Entrance to Woodfall Chest"), RegionName("Woodfall")]
        [GossipLocationHint("a swamp chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xEF)]
        ChestWoodfallRedRupee = 206,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Well Right Path Chest"), RegionName("Beneath the Well")]
        [GossipLocationHint("a frightful exchange"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF8)]
        ChestWellRightPurpleRupee = 207,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Well Left Path Chest"), RegionName("Beneath the Well")]
        [GossipLocationHint("a frightful exchange"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xF9)]
        ChestWellLeftPurpleRupee = 208,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Mountain Waterfall Chest"), RegionName("Mountain Village")]
        [GossipLocationHint("the springtime"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xF0)]
        ChestMountainVillage = 209, //contents? 

        [ItemName("Empty Bottle"), LocationName("Mountain Spring Grotto"), RegionName("Mountain Village")] // originally Red Rupee
        [GossipLocationHint("the springtime"), GossipItemHint("an empty vessel", "a glass container")] // originally "currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("Carry various items in this.")]
        [GetItemIndex(0xD8)]
        ChestMountainVillageGrottoBottle = 210, // originally RedRupee

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Ikana Pillar Chest"), RegionName("Road to Ikana")]
        [GossipLocationHint("a high chest"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xF1)]
        ChestToIkanaRedRupee = 211,

        [Repeatable]
        [ItemName("1 Bombchu"), LocationName("Path to Ikana Grotto"), RegionName("Road to Ikana")]
        [GossipLocationHint("a blocked cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.", isMultiple: true)]
        [GetItemIndex(0xD3)]
        ChestToIkanaGrotto = 212, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inverted Stone Tower Right Chest"), RegionName("Stone Tower")]
        [GossipLocationHint("a sky below"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0xFD)]
        ChestInvertedStoneTowerSilverRupee = 213,

        [Repeatable]
        [ItemName("10 Bombchu"), LocationName("Inverted Stone Tower Middle Chest"), RegionName("Stone Tower")]
        [GossipLocationHint("a sky below"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bombs that are practical, sleek and self-propelled.", isMultiple: true)]
        [GetItemIndex(0x10A)]
        ChestInvertedStoneTowerBombchu10 = 214,

        [Repeatable]
        [ItemName("Magic Bean"), LocationName("Inverted Stone Tower Left Chest"), RegionName("Stone Tower")]
        [GossipLocationHint("a sky below"), GossipItemHint("a plant seed")]
        [ShopText("Plant it in soft soil.")]
        [GetItemIndex(0x109)]
        ChestInvertedStoneTowerBean = 215,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Path to Snowhead Grotto"), RegionName("Path to Snowhead")]
        [GossipLocationHint("a snowy cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xD0)]
        ChestToSnowheadGrotto = 216, //contents? 

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("Twin Islands Cave Chest"), RegionName("Twin Islands")]
        [GossipLocationHint("the springtime"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xF2)]
        ChestToGoronVillageRedRupee = 217,

        [ItemName("Heart Piece"), LocationName("Secret Shrine Heart Piece Chest"), RegionName("Secret Shrine")]
        [GossipLocationHint("a secret place"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x107)]
        ChestSecretShrineHeartPiece = 218, //Heart Piece

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Dinolfos Chest"), RegionName("Secret Shrine")]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0xFE)]
        ChestSecretShrineDinoGrotto = 219,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Wizzrobe Chest"), RegionName("Secret Shrine")]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0xFF)]
        ChestSecretShrineWizzGrotto = 220,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Wart Chest"), RegionName("Secret Shrine")]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0x100)]
        ChestSecretShrineWartGrotto = 221,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Secret Shrine Garo Master Chest"), RegionName("Secret Shrine")]
        [GossipLocationHint("a secret place"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0x101)]
        ChestSecretShrineGaroGrotto = 222,

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inn Staff Room Chest"), RegionName("East Clock Town")]
        [GossipLocationHint("an employee room"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0x102)]
        ChestInnStaffRoom = 223, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("Inn Guest Room Chest"), RegionName("East Clock Town")]
        [GossipLocationHint("a guest bedroom"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0x103)]
        ChestInnGuestRoom = 224, //contents? 

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("Mystery Woods Grotto"), RegionName("Southern Swamp")]
        [GossipLocationHint("a mystery cave"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xD9)]
        ChestWoodsGrotto = 225, //contents? 

        [Repeatable]
        [ItemName("Silver Rupee"), LocationName("East Clock Town Chest"), RegionName("East Clock Town")]
        [GossipLocationHint("a shop roof"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 100 rupees.")]
        [GetItemIndex(0x104)]
        ChestEastClockTownSilverRupee = 226,

        [Repeatable]
        [ItemName("Red Rupee"), LocationName("South Clock Town Straw Roof Chest"), RegionName("South Clock Town")]
        [GossipLocationHint("a straw roof"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 20 rupees.")]
        [GetItemIndex(0xF3)]
        ChestSouthClockTownRedRupee = 227,

        [Repeatable]
        [ItemName("Purple Rupee"), LocationName("South Clock Town Final Day Chest"), RegionName("South Clock Town")]
        [GossipLocationHint("a carnival tower"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 50 rupees.")]
        [GetItemIndex(0xFA)]
        ChestSouthClockTownPurpleRupee = 228,

        [ItemName("Heart Piece"), LocationName("Bank Reward #2"), RegionName("West Clock Town")]
        [GossipLocationHint("being rich"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x108)]
        HeartPieceBank = 229, //Heart Piece

        //standing HPs
        [ItemName("Heart Piece"), LocationName("South Clock Town Heart Piece"), RegionName("South Clock Town")]
        [GossipLocationHint("the tower doors"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x10B)]
        HeartPieceSouthClockTown = 230,

        [ItemName("Heart Piece"), LocationName("North Clock Town Heart Piece"), RegionName("North Clock Town")]
        [GossipLocationHint("a town playground"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x10C)]
        HeartPieceNorthClockTown = 231,

        [ItemName("Heart Piece"), LocationName("Path to Swamp Heart Piece"), RegionName("Road to Southern Swamp")]
        [GossipLocationHint("a tree of bats"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x10D)]
        HeartPieceToSwamp = 232,

        [ItemName("Heart Piece"), LocationName("Swamp Scrub Heart Piece"), RegionName("Southern Swamp")]
        [GossipLocationHint("a tourist centre"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x10E)]
        HeartPieceSwampScrub = 233,

        [ItemName("Heart Piece"), LocationName("Deku Palace Heart Piece"), RegionName("Deku Palace")]
        [GossipLocationHint("the home of scrubs"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x10F)]
        HeartPieceDekuPalace = 234,

        [ItemName("Heart Piece"), LocationName("Goron Village Scrub Heart Piece"), RegionName("Goron Village")]
        [GossipLocationHint("a cold ledge"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x110)]
        HeartPieceGoronVillageScrub = 235,

        [ItemName("Heart Piece"), LocationName("Bio Baba Grotto Heart Piece"), RegionName("Termina Field")]
        [GossipLocationHint("a beehive"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x111)]
        HeartPieceZoraGrotto = 236,

        [ItemName("Heart Piece"), LocationName("Lab Fish Heart Piece"), RegionName("Great Bay Coast")]
        [GossipLocationHint("feeding the fish"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x112)]
        HeartPieceLabFish = 237,

        [ItemName("Heart Piece"), LocationName("Great Bay Like-Like Heart Piece"), RegionName("Great Bay Cape")]
        [GossipLocationHint("a shield eater"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x113)]
        HeartPieceGreatBayCapeLikeLike = 238,

        [ItemName("Heart Piece"), LocationName("Pirates' Fortress Heart Piece"), RegionName("Pirates' Fortress Sewer")]
        [GossipLocationHint("a timed door"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x114)]
        HeartPiecePiratesFortress = 239,

        [ItemName("Heart Piece"), LocationName("Zora Hall Scrub Heart Piece"), RegionName("Zora Hall")]
        [GossipLocationHint("the singer's room"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x115)]
        HeartPieceZoraHallScrub = 240,

        [ItemName("Heart Piece"), LocationName("Path to Snowhead Heart Piece"), RegionName("Path to Snowhead")]
        [GossipLocationHint("a cold platform"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x116)]
        HeartPieceToSnowhead = 241,

        [ItemName("Heart Piece"), LocationName("Great Bay Coast Heart Piece"), RegionName("Great Bay Coast")]
        [GossipLocationHint("a rock face"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x117)]
        HeartPieceGreatBayCoast = 242,

        [ItemName("Heart Piece"), LocationName("Ikana Scrub Heart Piece"), RegionName("Ikana Canyon")]
        [GossipLocationHint("a thief's doorstep"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x118)]
        HeartPieceIkana = 243,

        [ItemName("Heart Piece"), LocationName("Ikana Castle Heart Piece"), RegionName("Ikana Castle")]
        [GossipLocationHint("a fiery pillar"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x119)]
        HeartPieceCastle = 244,

        [ItemName("Heart Container"), LocationName("Odolwa Heart Container"), RegionName("Woodfall Temple")]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [GetItemIndex(0x11A)]
        HeartContainerWoodfall = 245,

        [ItemName("Heart Container"), LocationName("Goht Heart Container"), RegionName("Snowhead Temple")]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [GetItemIndex(0x11B)]
        HeartContainerSnowhead = 246,

        [ItemName("Heart Container"), LocationName("Gyorg Heart Container"), RegionName("Great Bay Temple")]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [GetItemIndex(0x11C)]
        HeartContainerGreatBay = 247,

        [ItemName("Heart Container"), LocationName("Twinmold Heart Container"), RegionName("Stone Tower Temple")]
        [GossipLocationHint("a masked evil"), GossipItemHint("increased life")]
        [ShopText("Permanently increases your life energy.")]
        [GetItemIndex(0x11D)]
        HeartContainerStoneTower = 248,

        //maps
        [ItemName("Map: Clock Town"), LocationName("Clock Town Map Purchase"), RegionName("North Clock Town")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of Clock Town.")]
        [GetItemIndex(0xB4)]
        ItemTingleMapTown = 249,

        [ItemName("Map: Woodfall"), LocationName("Woodfall Map Purchase"), RegionName("Southern Swamp")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the south.")]
        [GetItemIndex(0xB5)]
        ItemTingleMapWoodfall = 250,

        [ItemName("Map: Snowhead"), LocationName("Snowhead Map Purchase"), RegionName("Southern Swamp")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the north.")]
        [GetItemIndex(0xB6)]
        ItemTingleMapSnowhead = 251,

        [ItemName("Map: Romani Ranch"), LocationName("Romani Ranch Map Purchase"), RegionName("Milk Road")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the ranch.")]
        [GetItemIndex(0xB7)]
        ItemTingleMapRanch = 252,

        [ItemName("Map: Great Bay"), LocationName("Great Bay Map Purchase"), RegionName("Milk Road")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the west.")]
        [GetItemIndex(0xB8)]
        ItemTingleMapGreatBay = 253,

        [ItemName("Map: Stone Tower"), LocationName("Stone Tower Map Purchase"), RegionName("Great Bay Coast")]
        [GossipLocationHint("a map maker", "a forest fairy"), GossipItemHint("a world map")]
        [ShopText("Map of the east.")]
        [GetItemIndex(0xB9)]
        ItemTingleMapStoneTower = 254,

        //oops I forgot one
        [Repeatable]
        [ItemName("1 Bombchu"), LocationName("Goron Racetrack Grotto"), RegionName("Twin Islands")]
        [GossipLocationHint("a hidden cave"), GossipItemHint("explosive mice")]
        [ShopText("Mouse-shaped bomb that is practical, sleek and self-propelled.")]
        [GetItemIndex(0xD6)]
        ChestToGoronRaceGrotto = 255, //contents?

        [Repeatable]
        [ItemName("Gold Rupee"), LocationName("Canyon Scrub Trade"), RegionName("Ikana Canyon")]
        [GossipLocationHint("an eastern merchant"), GossipItemHint("currency", "money", "cash", "wealth", "riches and stuff")]
        [ShopText("This is worth 200 rupees.")]
        [GetItemIndex(0x125)]
        IkanaScrubGoldRupee = 256,

        //moon items
        OtherOneMask = 257,
        OtherTwoMasks = 258,
        OtherThreeMasks = 259,
        OtherFourMasks = 260,
        AreaMoonAccess = 261,

        [ItemName("Heart Piece"), LocationName("Deku Trial Heart Piece")]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x11F)]
        HeartPieceDekuTrial = 262,

        [ItemName("Heart Piece"), LocationName("Goron Trial Heart Piece")]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x120)]
        HeartPieceGoronTrial = 263,

        [ItemName("Heart Piece"), LocationName("Zora Trial Heart Piece")]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x121)]
        HeartPieceZoraTrial = 264,

        [ItemName("Heart Piece"), LocationName("Link Trial Heart Piece")]
        [GossipLocationHint("a masked child's game"), GossipItemHint("a segment of health")]
        [ShopText("Collect four to assemble a new Heart Container.")]
        [GetItemIndex(0x122)]
        HeartPieceLinkTrial = 265,

        [ItemName("Fierce Deity's Mask"), LocationName("Majora Child")]
        [GossipLocationHint("the lonely child"), GossipItemHint("the wrath of a god")]
        [ShopText("A mask that contains the merits of all masks.")]
        [GetItemIndex(0x7B)]
        MaskFierceDeity = 266,
    }
}
