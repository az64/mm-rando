using System.Collections.ObjectModel;

namespace MMRando
{

    public class Items
    {
        // free
        public const int MaskDeku = 0;

        // items
        public const int ItemBow = 1;
        public const int ItemFireArrow = 2;
        public const int ItemIceArrow = 3;
        public const int ItemLightArrow = 4;
        public const int ItemBombBag = 5;
        public const int ItemMagicBean = 6;
        public const int ItemPowderKeg = 7;
        public const int ItemPictobox = 8;
        public const int ItemLens = 9;
        public const int ItemHookshot = 10;
        public const int ItemFairySword = 11;
        public const int ItemBottleWitch = 12;
        public const int ItemBottleAliens = 13;
        public const int ItemBottleGoronRace = 14;
        public const int ItemBottleBeavers = 15;
        public const int ItemBottleDampe = 16;
        public const int ItemBottleMadameAroma = 17;
        public const int ItemNotebook = 18;

        //upgrades
        public const int UpgradeRazorSword = 19;
        public const int UpgradeGildedSword = 20;
        public const int UpgradeMirrorShield = 21;
        public const int UpgradeBigQuiver = 22;
        public const int UpgradeBiggestQuiver = 23;
        public const int UpgradeBigBombBag = 24;
        public const int UpgradeBiggestBombBag = 25;
        public const int UpgradeAdultWallet = 26;
        public const int UpgradeGiantWallet = 27;

        //trades
        public const int TradeItemMoonTear = 28;
        public const int TradeItemLandDeed = 29;
        public const int TradeItemSwampDeed = 30;
        public const int TradeItemMountainDeed = 31;
        public const int TradeItemOceanDeed = 32;
        public const int TradeItemRoomKey = 33;
        public const int TradeItemKafeiLetter = 34;
        public const int TradeItemPendant = 35;
        public const int TradeItemMamaLetter = 36;

        //notebook hp
        public const int HeartPieceNotebookMayor = 37;
        public const int HeartPieceNotebookPostman = 38;
        public const int HeartPieceNotebookRosa = 39;
        public const int HeartPieceNotebookHand = 40;
        public const int HeartPieceNotebookGran1 = 41;
        public const int HeartPieceNotebookGran2 = 42;

        //other hp
        public const int HeartPieceKeatonQuiz = 43;
        public const int HeartPieceDekuPlayground = 44;
        public const int HeartPieceTownArchery = 45;
        public const int HeartPieceHoneyAndDarling = 46;
        public const int HeartPieceSwordsmanSchool = 47;
        public const int HeartPiecePostBox = 48;
        public const int HeartPieceTerminaGossipStones = 49;
        public const int HeartPieceTerminaBusinessScrub = 50;
        public const int HeartPieceSwampArchery = 51;
        public const int HeartPiecePictobox = 52;
        public const int HeartPieceBoatArchery = 53;
        public const int HeartPieceChoir = 54;
        public const int HeartPieceBeaverRace = 55;
        public const int HeartPieceSeaHorse = 56;
        public const int HeartPieceFishermanGame = 57;
        public const int HeartPieceEvan = 58;
        public const int HeartPieceDogRace = 59;
        public const int HeartPiecePoeHut = 60;
        public const int HeartPieceTreasureChestGame = 61;
        public const int HeartPiecePeahat = 62;
        public const int HeartPieceDodong = 63;
        public const int HeartPieceWoodFallChest = 64;
        public const int HeartPieceTwinIslandsChest = 65;
        public const int HeartPieceOceanSpiderHouse = 66;
        public const int HeartPieceKnuckle = 67;

        //mask
        public const int MaskPostmanHat = 68;
        public const int MaskAllNight = 69;
        public const int MaskBlast = 70;
        public const int MaskStone = 71;
        public const int MaskGreatFairy = 72;
        public const int MaskKeaton = 73;
        public const int MaskBremen = 74;
        public const int MaskBunnyHood = 75;
        public const int MaskDonGero = 76;
        public const int MaskScents = 77;
        public const int MaskRomani = 78;
        public const int MaskCircusLeader = 79;
        public const int MaskKafei = 80;
        public const int MaskCouple = 81;
        public const int MaskTruth = 82;
        public const int MaskKamaro = 83;
        public const int MaskGibdo = 84;
        public const int MaskGaro = 85;
        public const int MaskCaptainHat = 86;
        public const int MaskGiant = 87;
        public const int MaskGoron = 88;
        public const int MaskZora = 89;

        //song
        public const int SongSoaring = 90;
        public const int SongEpona = 91;
        public const int SongStorms = 92;
        public const int SongSonata = 93;
        public const int SongLullaby = 94;
        public const int SongNewWaveBossaNova = 95;
        public const int SongElegy = 96;
        public const int SongOath = 97;

        //areas/other
        public const int AreaSouthAccess = 98;
        public const int AreaWoodFallTempleAccess = 99;
        public const int AreaWoodFallTempleClear = 100;
        public const int AreaNorthAccess = 101;
        public const int AreaSnowheadTempleAccess = 102;
        public const int AreaSnowheadTempleClear = 103;
        public const int OtherEpona = 104;
        public const int AreaWestAccess = 105;
        public const int AreaPiratesFortressAccess = 106;
        public const int AreaGreatBayTempleAccess = 107;
        public const int AreaGreatBayTempleClear = 108;
        public const int AreaEastAccess = 109;
        public const int AreaIkanaCanyonAccess = 110;
        public const int AreaStoneTowerTempleAccess = 111;
        public const int AreaInvertedStoneTowerTempleAccess = 112;
        public const int AreaStoneTowerClear = 113;
        public const int OtherExplosive = 114;
        public const int OtherArrow = 115;
        public const int AreaWoodfallNew = 116;
        public const int AreaSnowheadNew = 117;
        public const int AreaGreatBayNew = 118;
        public const int AreaLANew = 119; // ??
        public const int AreaInvertedStoneTowerNew = 120; // Seemingly not used

        //keysanity items
        public const int ItemWoodfallMap = 121;
        public const int ItemWoodfallCompass = 122;
        public const int ItemWoodfallBossKey = 123;
        public const int ItemWoodfallKey1 = 124;
        public const int ItemSnowheadMap = 125;
        public const int ItemSnowheadCompass = 126;
        public const int ItemSnowheadBossKey = 127;
        public const int ItemSnowheadKey1 = 128;
        public const int ItemSnowheadKey2 = 129;
        public const int ItemSnowheadKey3 = 130;
        public const int ItemGreatBayMap = 131;
        public const int ItemGreatBayCompass = 132;
        public const int ItemGreatBayBossKey = 133;
        public const int ItemGreatBayKey1 = 134;
        public const int ItemStoneTowerMap = 135;
        public const int ItemStoneTowerCompass = 136;
        public const int ItemStoneTowerBossKey = 137;
        public const int ItemStoneTowerKey1 = 138;
        public const int ItemStoneTowerKey2 = 139;
        public const int ItemStoneTowerKey3 = 140;
        public const int ItemStoneTowerKey4 = 141;

        //shop items
        public const int ShopItemTradingPostRedPotion = 142;
        public const int ShopItemTradingPostGreenPotion = 143;
        public const int ShopItemTradingPostShield = 144;
        public const int ShopItemTradingPostFairy = 145;
        public const int ShopItemTradingPostStick = 146;
        public const int ShopItemTradingPostArrow30 = 147;
        public const int ShopItemTradingPostNut10 = 148;
        public const int ShopItemTradingPostArrow50 = 149;
        public const int ShopItemWitchBluePotion = 150;
        public const int ShopItemWitchRedPotion = 151;
        public const int ShopItemWitchGreenPotion = 152;
        public const int ShopItemBombsBomb10 = 153;
        public const int ShopItemBombsBombchu10 = 154;
        public const int ShopItemGoronBomb10 = 155;
        public const int ShopItemGoronArrow10 = 156;
        public const int ShopItemGoronRedPotion = 157;
        public const int ShopItemZoraShield = 158;
        public const int ShopItemZoraArrow10 = 159;
        public const int ShopItemZoraRedPotion = 160;

        //bottle catch
        public const int BottleCatchFairy = 161;
        public const int BottleCatchPrincess = 162;
        public const int BottleCatchFish = 163;
        public const int BottleCatchBug = 164;
        public const int BottleCatchPoe = 165;
        public const int BottleCatchBigPoe = 166;
        public const int BottleCatchSpringWater = 167;
        public const int BottleCatchHotSpringWater = 168;
        public const int BottleCatchEgg = 169;
        public const int BottleCatchMushroom = 170;

        //other chests and grottos
        public const int ChestLensCaveRedRupee = 171;
        public const int ChestLensCavePurpleRupee = 172;
        public const int ChestBeanGrottoRedRupee = 173;
        public const int ChestHotSpringGrottoRedRupee = 174;
        public const int ChestBadBatsGrotto = 175; // include contents for consistence? unsure what contents are
        public const int ChestIkanaGrotto = 176; 
        public const int ChestPiratesFortressRedRupee1 = 177;
        public const int ChestPiratesFortressRedRupee2 = 178;
        public const int ChestInsidePiratesFortressTankRedRupee = 179;
        public const int ChestInsidePiratesFortressGuardSilverRupee = 180;
        public const int ChestInsidePiratesFortressHeartPieceRoomRedRupee = 181;
        public const int ChestInsidePiratesFortressHeartPieceRoomBlueRupee = 182;
        public const int ChestInsidePiratesFortressMazeRedRupee = 183;
        public const int ChestPinacleRockRedRupee1 = 184;
        public const int ChestPinacleRockRedRupee2 = 185;
        public const int ChestBomberHideoutSilverRupee = 186;
        public const int ChestTerminaGrottoBombchu = 187;
        public const int ChestTerminaGrottoRedRupee = 188;
        public const int ChestTerminaUnderwaterRedRupee = 189;
        public const int ChestTerminaGrassRedRupee = 190;
        public const int ChestTerminaStumpRedRupee = 191;
        public const int ChestGreatBayCoastGrotto = 192; 
        public const int ChestGreatBayCapeLedge1 = 193; 
        public const int ChestGreatBayCapeLedge2 = 194; 
        public const int ChestGreatBayCapeGrotto = 195; 
        public const int ChestGreatBayCapeUnderwater = 196; 
        public const int ChestPiratesFortressEntranceRedRupee1 = 197;
        public const int ChestPiratesFortressEntranceRedRupee2 = 198;
        public const int ChestPiratesFortressEntranceRedRupee3 = 199;
        public const int ChestToSwampGrotto = 200; 
        public const int ChestDogRacePurpleRupee = 201;
        public const int ChestGraveyardGrotto = 202; 
        public const int ChestSwampGrotto = 203; 
        public const int ChestWoodfallBlueRupee = 204;
        public const int ChestWoodfallRedRupee = 205;
        public const int ChestWellRightPurpleRupee = 206;
        public const int ChestWellLeftPurpleRupee = 207;
        public const int ChestMountainVillage = 208; 
        public const int ChestMountainVillageGrotto = 209; 
        public const int ChestToIkanaRedRupee = 210;
        public const int ChestToIkanaGrotto = 211; 
        public const int ChestInvertedStoneTowerSilverRupee = 212;
        public const int ChestInvertedStoneTowerBombchu10 = 213;
        public const int ChestInvertedStoneTowerBean = 214;
        public const int ChestToSnowheadGrotto = 215; 
        public const int ChestToGoronVillageRedRupee = 216; 
        public const int ChestSecretShrineHeartPiece = 217; 
        public const int ChestSecretShrineDinoGrotto = 218; 
        public const int ChestSecretShrineWizzGrotto = 219; 
        public const int ChestSecretShrineWartGrotto = 220; 
        public const int ChestSecretShrineGaroGrotto = 221; 
        public const int ChestInnStaffRoom = 222; 
        public const int ChestInnGuestRoom = 223; 
        public const int ChestWoodsGrotto = 224;
        public const int ChestEastClockTownSilverRupee = 225;
        public const int ChestSouthClockTownRedRupee = 226;
        public const int ChestSouthClockTownPurpleRupee = 227;
        public const int HeartPieceBank = 228;

        //standing HPs
        public const int HeartPieceSouthClockTown = 229;
        public const int HeartPieceNorthClockTown = 230;
        public const int HeartPieceToSwamp = 231;
        public const int HeartPieceSwampScrub = 232;
        public const int HeartPieceDekuPalace = 233;
        public const int HeartPieceGoronVillageScrub = 234;
        public const int HeartPieceZoraGrotto = 235;
        public const int HeartPieceLabFish = 236;
        public const int HeartPieceGreatBayCapeLikeLike = 237;
        public const int HeartPiecePiratesFortress = 238;
        public const int HeartPieceZoraHallScrub = 239;
        public const int HeartPieceToSnowhead = 240;
        public const int HeartPieceGreatBayCoast = 241;
        public const int HeartPieceIkana = 242;
        public const int HeartPieceCastle = 243;
        public const int HeartContainerWoodfall = 244;
        public const int HeartContainerSnowhead = 245;
        public const int HeartContainerGreatBay = 246;
        public const int HeartContainerStoneTower = 247;

        //maps
        public const int ItemTingleMapTown = 248;
        public const int ItemTingleMapWoodfall = 249;
        public const int ItemTingleMapSnowhead = 250;
        public const int ItemTingleMapRanch = 251;
        public const int ItemTingleMapGreatBay = 252;
        public const int ItemTingleMapStoneTower = 253;

        //oops I forgot one
        public const int ChestToGoronRaceGrotto = 254;

        public static readonly ReadOnlyCollection<int> REPEATABLE
            = new ReadOnlyCollection<int>(new int[] {
                TradeItemMoonTear,
                TradeItemLandDeed,
                TradeItemSwampDeed,
                TradeItemMountainDeed,
                TradeItemOceanDeed,
                TradeItemRoomKey,
                TradeItemKafeiLetter,
                TradeItemPendant,
                TradeItemMamaLetter,
                ItemWoodfallBossKey,
                ItemWoodfallKey1,
                ItemSnowheadBossKey,
                ItemSnowheadKey1,
                ItemSnowheadKey2,
                ItemSnowheadKey3,
                ItemGreatBayBossKey,
                ItemGreatBayKey1,
                ItemStoneTowerBossKey,
                ItemStoneTowerKey1,
                ItemStoneTowerKey2,
                ItemStoneTowerKey3,
                ItemStoneTowerKey4,
                ShopItemTradingPostRedPotion,
                ShopItemTradingPostGreenPotion,
                ShopItemTradingPostShield,
                ShopItemTradingPostFairy,
                ShopItemTradingPostStick,
                ShopItemTradingPostArrow30,
                ShopItemTradingPostNut10,
                ShopItemTradingPostArrow50,
                ShopItemWitchBluePotion,
                ShopItemWitchRedPotion,
                ShopItemWitchGreenPotion,
                ShopItemBombsBomb10,
                ShopItemBombsBombchu10,
                ShopItemGoronBomb10,
                ShopItemGoronArrow10,
                ShopItemGoronRedPotion,
                ShopItemZoraShield,
                ShopItemZoraArrow10,
                ShopItemZoraRedPotion,
                UpgradeMirrorShield,
                UpgradeGildedSword,
                UpgradeBiggestQuiver,
                UpgradeBiggestBombBag,
                UpgradeGiantWallet,
                ChestLensCaveRedRupee,
                ChestLensCavePurpleRupee,
                ChestBeanGrottoRedRupee,
                ChestHotSpringGrottoRedRupee,
                ChestBadBatsGrotto,
                ChestIkanaGrotto,
                ChestPiratesFortressRedRupee1,
                ChestPiratesFortressRedRupee2,
                ChestInsidePiratesFortressTankRedRupee,
                ChestInsidePiratesFortressGuardSilverRupee,
                ChestInsidePiratesFortressHeartPieceRoomRedRupee,
                ChestInsidePiratesFortressHeartPieceRoomBlueRupee,
                ChestInsidePiratesFortressMazeRedRupee,
                ChestPinacleRockRedRupee1,
                ChestPinacleRockRedRupee2,
                ChestBomberHideoutSilverRupee,
                ChestTerminaGrottoBombchu,
                ChestTerminaGrottoRedRupee,
                ChestTerminaUnderwaterRedRupee,
                ChestTerminaGrassRedRupee,
                ChestTerminaStumpRedRupee,
                ChestGreatBayCoastGrotto,
                ChestGreatBayCapeLedge1,
                ChestGreatBayCapeLedge2,
                ChestGreatBayCapeUnderwater,
                ChestGreatBayCapeGrotto,
                ChestPiratesFortressEntranceRedRupee1,
                ChestPiratesFortressEntranceRedRupee2,
                ChestPiratesFortressEntranceRedRupee3,
                ChestToSwampGrotto,
                ChestDogRacePurpleRupee,
                ChestGraveyardGrotto,
                ChestSwampGrotto,
                ChestWoodfallBlueRupee,
                ChestWoodfallRedRupee,
                ChestWellRightPurpleRupee,
                ChestWellLeftPurpleRupee,
                ChestMountainVillage,
                ChestMountainVillageGrotto,
                ChestToIkanaGrotto,
                ChestToIkanaRedRupee,
                ChestInvertedStoneTowerBean,
                ChestInvertedStoneTowerBombchu10,
                ChestInvertedStoneTowerSilverRupee,
                ChestToSnowheadGrotto,
                ChestToGoronVillageRedRupee,
                ChestSecretShrineDinoGrotto,
                ChestSecretShrineWizzGrotto,
                ChestSecretShrineWartGrotto,
                ChestSecretShrineGaroGrotto,
                ChestInnStaffRoom,
                ChestInnGuestRoom,
                ChestWoodsGrotto,
                ChestEastClockTownSilverRupee,
                ChestSouthClockTownRedRupee,
                ChestSouthClockTownPurpleRupee,
                ChestToGoronRaceGrotto,
                ChestGreatBayCapeGrotto,
                ChestToIkanaGrotto,
                ChestGraveyardGrotto,
                ChestTerminaGrottoBombchu,
                ChestInvertedStoneTowerBean,
                ChestInvertedStoneTowerBombchu10
        });

        public static readonly ReadOnlyCollection<int> CYCLE_REPEATABLE
            = new ReadOnlyCollection<int>(new int[] {
                ShopItemTradingPostRedPotion,
                ShopItemTradingPostGreenPotion,
                ShopItemTradingPostFairy,
                ShopItemTradingPostShield,
                ShopItemTradingPostStick,
                ShopItemTradingPostNut10,
                ShopItemTradingPostArrow30,
                ShopItemTradingPostArrow50,
                ShopItemWitchBluePotion,
                ShopItemWitchGreenPotion,
                ShopItemWitchRedPotion,
                ShopItemGoronRedPotion,
                ShopItemGoronBomb10,
                ShopItemGoronArrow10,
                ShopItemBombsBomb10,
                ShopItemBombsBombchu10,
                ShopItemZoraArrow10,
                ShopItemZoraRedPotion,
                ShopItemZoraShield,
        });

        public static readonly ReadOnlyCollection<int> ITEM_ADDRS
            = new ReadOnlyCollection<int>(new int[] {
                0xC5CE41,
                0xC5CE25,
                0xC5CE26,
                0xC5CE27,
                0xC5CE28,
                0xC5CE2A,
                0xC5CE2E,
                0xC5CE30,
                0xC5CE31,
                0xC5CE32,
                0xC5CE33,
                0xC5CE34,
                0xC5CE36,
                0xC5CE37,
                0xC5CE38,
                0xC5CE39,
                0xC5CE3A,
                0xC5CE3B,
                0xC5CE71,
                0xC5CE21,
                0xC5CE21,
                0xC5CE21,
                0xC5CE25,
                0xC5CE25,
                0xC5CE2A,
                0xC5CE2A,
                0xC5CE6E,
                0xC5CE6E,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE70,
                0xC5CE3C,
                0xC5CE3D,
                0xC5CE3E,
                0xC5CE3F,
                0xC5CE40,
                0xC5CE42,
                0xC5CE43,
                0xC5CE44,
                0xC5CE45,
                0xC5CE46,
                0xC5CE48,
                0xC5CE49,
                0xC5CE4A,
                0xC5CE4B,
                0xC5CE4C,
                0xC5CE4E,
                0xC5CE4F,
                0xC5CE50,
                0xC5CE51,
                0xC5CE52,
                0xC5CE47,
                0xC5CE4D,
                0xC5CE72,
                0xC5CE72,
                0xC5CE71,
                0xC5CE73,
                0xC5CE73,
                0xC5CE72,
                0xC5CE72,
                0xC5CE72
        });

        public static readonly ReadOnlyCollection<byte> ITEM_VALUES
            = new ReadOnlyCollection<byte>(new byte[] {
                0x32,
                0x01,
                0x02,
                0x03,
                0x04,
                0x06,
                0x0A,
                0x0C,
                0x0D,
                0x0E,
                0x0F,
                0x10,
                0x12,
                0x12,
                0x12,
                0x12,
                0x12,
                0x12,
                0x04,
                0x12,
                0x13,
                0x21,
                0x01,
                0x01,
                0x06,
                0x06,
                0x10,
                0x20,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x10,
                0x3E,
                0x38,
                0x47,
                0x45,
                0x40,
                0x3A,
                0x46,
                0x39,
                0x42,
                0x48,
                0x3C,
                0x3D,
                0x37,
                0x3F,
                0x36,
                0x43,
                0x41,
                0x3B,
                0x44,
                0x49,
                0x33,
                0x34,
                0xB0,
                0x70,
                0x01,
                0x40,
                0x80,
                0x31,
                0x32,
                0x34
        });

        public static readonly ReadOnlyCollection<string> ITEM_NAMES
            = new ReadOnlyCollection<string>(new string[] {
                "Deku Mask",
                "Hero's Bow",
                "Fire Arrow",
                "Ice Arrow",
                "Light Arrow",
                "Bomb Bag",
                "Magic Bean",
                "Powder Keg",
                "Pictobox",
                "Lens of Truth",
                "Hookshot",
                "Great Fairy's Sword",
                "Witch Bottle",
                "Aliens Bottle",
                "Goron Race Bottle",
                "Beaver Race Bottle",
                "Dampe Bottle",
                "Chateau Bottle",
                "Bombers' Notebook",
                "Razor Sword",
                "Gilded Sword",
                "Mirror Shield",
                "Town Archery Quiver",
                "Swamp Archery Quiver",
                "Town Bomb Bag",
                "Mountain Bomb Bag",
                "Town Wallet",
                "Ocean Wallet",
                "Moon's Tear",
                "Land Title Deed",
                "Swamp Title Deed",
                "Mountain Title Deed",
                "Ocean Title Deed",
                "Room Key",
                "Letter to Kafei",
                "Pendant of Memories",
                "Letter to Mama",
                "Mayor Dotour HP",
                "Postman HP",
                "Rosa Sisters HP",
                "??? HP",
                "Grandma Short Story HP",
                "Grandma Long Story HP",
                "Keaton Quiz HP",
                "Deku Playground HP",
                "Town Archery HP",
                "Honey and Darling HP",
                "Swordsman's School HP",
                "Postbox HP",
                "Termina Field Gossips HP",
                "Termina Field Business Scrub HP",
                "Swamp Archery HP",
                "Pictograph Contest HP",
                "Boat Archery HP",
                "Frog Choir HP",
                "Beaver Race HP",
                "Seahorse HP",
                "Fisherman Game HP",
                "Evan HP",
                "Dog Race HP",
                "Poe Hut HP",
                "Treasure Chest Game HP",
                "Peahat Grotto HP",
                "Dodongo Grotto HP",
                "Woodfall Chest HP",
                "Twin Islands Chest HP",
                "Ocean Spider House HP",
                "Graveyard Iron Knuckle HP",
                "Postman's Hat",
                "All Night Mask",
                "Blast Mask",
                "Stone Mask",
                "Great Fairy's Mask",
                "Keaton Mask",
                "Bremen Mask",
                "Bunny Hood",
                "Don Gero's Mask",
                "Mask of Scents",
                "Romani Mask",
                "Circus Leader's Mask",
                "Kafei's Mask",
                "Couple's Mask",
                "Mask of Truth",
                "Kamaro's Mask",
                "Gibdo Mask",
                "Garo Mask",
                "Captain's Hat",
                "Giant's Mask",
                "Goron Mask",
                "Zora Mask",
                "Song of Soaring",
                "Epona's Song",
                "Song of Storms",
                "Sonata of Awakening",
                "Goron Lullaby",
                "New Wave Bossa Nova",
                "Elegy of Emptiness",
                "Oath to Order",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "Woodfall Map",
                "Woodfall Compass",
                "Woodfall Boss Key",
                "Woodfall Key 1",
                "Snowhead Map",
                "Snowhead Compass",
                "Snowhead Boss Key",
                "Snowhead Key 1",
                "Snowhead Key 2",
                "Snowhead Key 3",
                "Great Bay Map",
                "Great Bay Compass",
                "Great Bay Boss Key",
                "Great Bay Key 1",
                "Stone Tower Map",
                "Stone Tower Compass",
                "Stone Tower Boss Key",
                "Stone Tower Key 1",
                "Stone Tower Key 2",
                "Stone Tower Key 3",
                "Stone Tower Key 4",
                "Trading Post Red Potion",
                "Trading Post Green Potion",
                "Trading Post Shield",
                "Trading Post Fairy",
                "Trading Post Stick",
                "Trading Post Arrow 30",
                "Trading Post Nut 10",
                "Trading Post Arrow 50",
                "Witch Shop Blue Potion",
                "Witch Shop Red Potion",
                "Witch Shop Green Potion",
                "Bomb Shop Bomb 10",
                "Bomb Shop Chu 10",
                "Goron Shop Bomb 10",
                "Goron Shop Arrow 10",
                "Goron Shop Red Potion",
                "Zora Shop Shield",
                "Zora Shop Arrow 10",
                "Zora Shop Red Potion",
                "Bottle: Fairy",
                "Bottle: Deku Princess",
                "Bottle: Fish",
                "Bottle: Bug",
                "Bottle: Poe",
                "Bottle: Big Poe",
                "Bottle: Spring Water",
                "Bottle: Hot Spring Water",
                "Bottle: Zora Egg",
                "Bottle: Mushroom",
                "Lens Cave 20r",
                "Lens Cave 50r",
                "Bean Grotto 20r",
                "HSW Grotto 20r",
                "Graveyard Bad Bats",
                "Ikana Grotto",
                "PF 20r Lower",
                "PF 20r Upper",
                "PF Tank 20r",
                "PF Guard Room 100r",
                "PF HP Room 20r",
                "PF HP Room 5r",
                "PF Maze 20r",
                "PR 20r (1)",
                "PR 20r (2)",
                "Bombers' Hideout 100r",
                "Termina Bombchu Grotto",
                "Termina 20r Grotto",
                "Termina Underwater 20r",
                "Termina Grass 20r",
                "Termina Stump 20r",
                "Great Bay Coast Grotto",
                "Great Bay Cape Ledge (1)",
                "Great Bay Cape Ledge (2)",
                "Great Bay Cape Grotto",
                "Great Bay Cape Underwater",
                "PF Exterior 20r (1)",
                "PF Exterior 20r (2)",
                "PF Exterior 20r (3)",
                "Path to Swamp Grotto",
                "Doggy Racetrack 50r",
                "Graveyard Grotto",
                "Swamp Grotto",
                "Woodfall 5r",
                "Woodfall 20r",
                "Well Right Path 50r",
                "Well Left Path 50r",
                "Mountain Village Chest (Spring)",
                "Mountain Village Grotto (Spring)",
                "Path to Ikana 20r",
                "Path to Ikana Grotto",
                "Stone Tower 100r",
                "Stone Tower Bombchu 10",
                "Stone Tower Magic Bean",
                "Path to Snowhead Grotto",
                "Twin Islands 20r",
                "Secret Shrine HP",
                "Secret Shrine Dinolfos",
                "Secret Shrine Wizzrobe",
                "Secret Shrine Wart",
                "Secret Shrine Garo Master",
                "Inn Staff Room",
                "Inn Guest Room",
                "Mystery Woods Grotto",
                "East Clock Town 100r",
                "South Clock Town 20r",
                "South Clock Town 50r",
                "Bank HP",
                "South Clock Town HP",
                "North Clock Town HP",
                "Path to Swamp HP",
                "Swamp Scrub HP",
                "Deku Palace HP",
                "Goron Village Scrub HP",
                "Bio Baba Grotto HP",
                "Lab Fish HP",
                "Great Bay Like-Like HP",
                "Pirates' Fortress HP",
                "Zora Hall Scrub HP",
                "Path to Snowhead HP",
                "Great Bay Coast HP",
                "Ikana Scrub HP",
                "Ikana Castle HP",
                "Odolwa Heart Container",
                "Goht Heart Container",
                "Gyorg Heart Container",
                "Twinmold Heart Container",
                "Map: Clock Town",
                "Map: Woodfall",
                "Map: Snowhead",
                "Map: Romani Ranch",
                "Map: Great Bay",
                "Map: Stone Tower",
                "Goron Racetrack Grotto"
        });

        internal static readonly int TotalNumberOfItems = 255;
    }

}