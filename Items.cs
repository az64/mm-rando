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
        public const int ItemGoldDust = 14; // originally ItemBottleGoronRace
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
        public const int SongHealing = 90;
        public const int SongSoaring = 91;
        public const int SongEpona = 92;
        public const int SongStorms = 93;
        public const int SongSonata = 94;
        public const int SongLullaby = 95;
        public const int SongNewWaveBossaNova = 96;
        public const int SongElegy = 97;
        public const int SongOath = 98;

        //areas/other
        public const int AreaSouthAccess = 99;
        public const int AreaWoodFallTempleAccess = 100;
        public const int AreaWoodFallTempleClear = 101;
        public const int AreaNorthAccess = 102;
        public const int AreaSnowheadTempleAccess = 103;
        public const int AreaSnowheadTempleClear = 104;
        public const int OtherEpona = 105;
        public const int AreaWestAccess = 106;
        public const int AreaPiratesFortressAccess = 107;
        public const int AreaGreatBayTempleAccess = 108;
        public const int AreaGreatBayTempleClear = 109;
        public const int AreaEastAccess = 110;
        public const int AreaIkanaCanyonAccess = 111;
        public const int AreaStoneTowerTempleAccess = 112;
        public const int AreaInvertedStoneTowerTempleAccess = 113;
        public const int AreaStoneTowerClear = 114;
        public const int OtherExplosive = 115;
        public const int OtherArrow = 116;
        public const int AreaWoodfallNew = 117;
        public const int AreaSnowheadNew = 118;
        public const int AreaGreatBayNew = 119;
        public const int AreaLANew = 120; // ??
        public const int AreaInvertedStoneTowerNew = 121; // Seemingly not used

        //keysanity items
        public const int ItemWoodfallMap = 122;
        public const int ItemWoodfallCompass = 123;
        public const int ItemWoodfallBossKey = 124;
        public const int ItemWoodfallKey1 = 125;
        public const int ItemSnowheadMap = 126;
        public const int ItemSnowheadCompass = 127;
        public const int ItemSnowheadBossKey = 128;
        public const int ItemSnowheadKey1 = 129;
        public const int ItemSnowheadKey2 = 130;
        public const int ItemSnowheadKey3 = 131;
        public const int ItemGreatBayMap = 132;
        public const int ItemGreatBayCompass = 133;
        public const int ItemGreatBayBossKey = 134;
        public const int ItemGreatBayKey1 = 135;
        public const int ItemStoneTowerMap = 136;
        public const int ItemStoneTowerCompass = 137;
        public const int ItemStoneTowerBossKey = 138;
        public const int ItemStoneTowerKey1 = 139;
        public const int ItemStoneTowerKey2 = 140;
        public const int ItemStoneTowerKey3 = 141;
        public const int ItemStoneTowerKey4 = 142;

        //shop items
        public const int ShopItemTradingPostRedPotion = 143;
        public const int ShopItemTradingPostGreenPotion = 144;
        public const int ShopItemTradingPostShield = 145;
        public const int ShopItemTradingPostFairy = 146;
        public const int ShopItemTradingPostStick = 147;
        public const int ShopItemTradingPostArrow30 = 148;
        public const int ShopItemTradingPostNut10 = 149;
        public const int ShopItemTradingPostArrow50 = 150;
        public const int ShopItemWitchBluePotion = 151;
        public const int ShopItemWitchRedPotion = 152;
        public const int ShopItemWitchGreenPotion = 153;
        public const int ShopItemBombsBomb10 = 154;
        public const int ShopItemBombsBombchu10 = 155;
        public const int ShopItemGoronBomb10 = 156;
        public const int ShopItemGoronArrow10 = 157;
        public const int ShopItemGoronRedPotion = 158;
        public const int ShopItemZoraShield = 159;
        public const int ShopItemZoraArrow10 = 160;
        public const int ShopItemZoraRedPotion = 161;

        //bottle catch
        public const int BottleCatchFairy = 162;
        public const int BottleCatchPrincess = 163;
        public const int BottleCatchFish = 164;
        public const int BottleCatchBug = 165;
        public const int BottleCatchPoe = 166;
        public const int BottleCatchBigPoe = 167;
        public const int BottleCatchSpringWater = 168;
        public const int BottleCatchHotSpringWater = 169;
        public const int BottleCatchEgg = 170;
        public const int BottleCatchMushroom = 171;

        //other chests and grottos
        public const int ChestLensCaveRedRupee = 172;
        public const int ChestLensCavePurpleRupee = 173;
        public const int ChestBeanGrottoRedRupee = 174;
        public const int ChestHotSpringGrottoRedRupee = 175;
        public const int ChestBadBatsGrottoPurpleRupee = 176; 
        public const int ChestIkanaGrottoRecoveryHeart = 177; 
        public const int ChestPiratesFortressRedRupee1 = 178;
        public const int ChestPiratesFortressRedRupee2 = 179;
        public const int ChestInsidePiratesFortressTankRedRupee = 180;
        public const int ChestInsidePiratesFortressGuardSilverRupee = 181;
        public const int ChestInsidePiratesFortressHeartPieceRoomRedRupee = 182;
        public const int ChestInsidePiratesFortressHeartPieceRoomBlueRupee = 183;
        public const int ChestInsidePiratesFortressMazeRedRupee = 184;
        public const int ChestPinacleRockRedRupee1 = 185;
        public const int ChestPinacleRockRedRupee2 = 186;
        public const int ChestBomberHideoutSilverRupee = 187;
        public const int ChestTerminaGrottoBombchu = 188;
        public const int ChestTerminaGrottoRedRupee = 189;
        public const int ChestTerminaUnderwaterRedRupee = 190;
        public const int ChestTerminaGrassRedRupee = 191;
        public const int ChestTerminaStumpRedRupee = 192;
        public const int ChestGreatBayCoastGrotto = 193; //contents? 
        public const int ChestGreatBayCapeLedge1 = 194; //contents? 
        public const int ChestGreatBayCapeLedge2 = 195; //contents? 
        public const int ChestGreatBayCapeGrotto = 196; //contents? 
        public const int ChestGreatBayCapeUnderwater = 197; //contents? 
        public const int ChestPiratesFortressEntranceRedRupee1 = 198;
        public const int ChestPiratesFortressEntranceRedRupee2 = 199;
        public const int ChestPiratesFortressEntranceRedRupee3 = 200;
        public const int ChestToSwampGrotto = 201; //contents? 
        public const int ChestDogRacePurpleRupee = 202;
        public const int ChestGraveyardGrotto = 203; //contents? 
        public const int ChestSwampGrotto = 204;  //contents? 
        public const int ChestWoodfallBlueRupee = 205;
        public const int ChestWoodfallRedRupee = 206;
        public const int ChestWellRightPurpleRupee = 207;
        public const int ChestWellLeftPurpleRupee = 208;
        public const int ChestMountainVillage = 209; //contents? 
        public const int ChestMountainVillageGrottoBottle = 210; // originally RedRupee
        public const int ChestToIkanaRedRupee = 211;
        public const int ChestToIkanaGrotto = 212; //contents? 
        public const int ChestInvertedStoneTowerSilverRupee = 213;
        public const int ChestInvertedStoneTowerBombchu10 = 214;
        public const int ChestInvertedStoneTowerBean = 215;
        public const int ChestToSnowheadGrotto = 216; //contents? 
        public const int ChestToGoronVillageRedRupee = 217; 
        public const int ChestSecretShrineHeartPiece = 218; //Heart Piece
        public const int ChestSecretShrineDinoGrotto = 219; 
        public const int ChestSecretShrineWizzGrotto = 220; 
        public const int ChestSecretShrineWartGrotto = 221; 
        public const int ChestSecretShrineGaroGrotto = 222; 
        public const int ChestInnStaffRoom = 223; //contents? 
        public const int ChestInnGuestRoom = 224; //contents? 
        public const int ChestWoodsGrotto = 225; //contents? 
        public const int ChestEastClockTownSilverRupee = 226;
        public const int ChestSouthClockTownRedRupee = 227;
        public const int ChestSouthClockTownPurpleRupee = 228;
        public const int HeartPieceBank = 229; //Heart Piece

        //standing HPs
        public const int HeartPieceSouthClockTown = 230;
        public const int HeartPieceNorthClockTown = 231;
        public const int HeartPieceToSwamp = 232;
        public const int HeartPieceSwampScrub = 233;
        public const int HeartPieceDekuPalace = 234;
        public const int HeartPieceGoronVillageScrub = 235;
        public const int HeartPieceZoraGrotto = 236;
        public const int HeartPieceLabFish = 237;
        public const int HeartPieceGreatBayCapeLikeLike = 238;
        public const int HeartPiecePiratesFortress = 239;
        public const int HeartPieceZoraHallScrub = 240;
        public const int HeartPieceToSnowhead = 241;
        public const int HeartPieceGreatBayCoast = 242;
        public const int HeartPieceIkana = 243;
        public const int HeartPieceCastle = 244;
        public const int HeartContainerWoodfall = 245;
        public const int HeartContainerSnowhead = 246;
        public const int HeartContainerGreatBay = 247;
        public const int HeartContainerStoneTower = 248;

        //maps
        public const int ItemTingleMapTown = 249;
        public const int ItemTingleMapWoodfall = 250;
        public const int ItemTingleMapSnowhead = 251;
        public const int ItemTingleMapRanch = 252;
        public const int ItemTingleMapGreatBay = 253;
        public const int ItemTingleMapStoneTower = 254;

        //oops I forgot one
        public const int ChestToGoronRaceGrotto = 255; //contents?

        //moon items
        public const int OtherOneMask = 256;
        public const int OtherTwoMasks = 257;
        public const int OtherThreeMasks = 258;
        public const int OtherFourMasks = 259;
        public const int AreaMoonAccess = 260;
        public const int HeartPieceDekuTrial = 261;
        public const int HeartPieceGoronTrial = 262;
        public const int HeartPieceZoraTrial = 263;
        public const int HeartPieceLinkTrial = 264;
        public const int MaskFierceDeity = 265;

        public static readonly ReadOnlyCollection<int> REPEATABLE
            = new ReadOnlyCollection<int>(new int[] {
                ItemGoldDust,
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
                UpgradeBigBombBag,
                UpgradeBiggestBombBag,
                UpgradeGiantWallet,
                ChestLensCaveRedRupee,
                ChestLensCavePurpleRupee,
                ChestBeanGrottoRedRupee,
                ChestHotSpringGrottoRedRupee,
                ChestBadBatsGrottoPurpleRupee,
                ChestIkanaGrottoRecoveryHeart,
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
                ChestToIkanaRedRupee,
                ChestToIkanaGrotto,
                ChestInvertedStoneTowerSilverRupee,
                ChestInvertedStoneTowerBombchu10,
                ChestInvertedStoneTowerBean,
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

        public static readonly ReadOnlyCollection<int> JUNK
            = new ReadOnlyCollection<int>(new int[] {

                //TODO

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
                0x02,
                0x03,
                0x20,
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
                0x20,
                0x80,
                0x40,
                0x01,
                0x40,
                0x80,
                0x01,
                0x02,
                0x04
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
                "Gold Dust",
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
                "Song of Healing",
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
                "Mountain Village Grotto Bottle (Spring)",
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
                "Goron Racetrack Grotto",
                "One Mask",
                "Two Masks",
                "Three Masks",
                "Four Masks",
                "Moon Access",
                "Deku Trial HP",
                "Goron Trial HP",
                "Zora Trial HP",
                "Link Trial HP",
                "Fierce Deity's Mask",
        });

        internal static readonly int TotalNumberOfItems = 266;
    }

}