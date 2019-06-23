using MMRando.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MMRando
{
    public class Items
    {
        /// <summary>
        /// Item indices ranging from 98 and to (inclusive) 120 define 
        /// areas and other (epona, explosive, arrow). In total they make up 23 entries.
        /// </summary>
        public const int NumberOfAreasAndOther = 23;

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
        public const int IkanaScrubGoldRupee = 256;

        //moon items
        public const int OtherOneMask = 257;
        public const int OtherTwoMasks = 258;
        public const int OtherThreeMasks = 259;
        public const int OtherFourMasks = 260;
        public const int AreaMoonAccess = 261;
        public const int HeartPieceDekuTrial = 262;
        public const int HeartPieceGoronTrial = 263;
        public const int HeartPieceZoraTrial = 264;
        public const int HeartPieceLinkTrial = 265;
        public const int MaskFierceDeity = 266;

        public static readonly ReadOnlyCollection<int> DOWNGRADABLE_ITEMS
            = new ReadOnlyCollection<int>(new int[]
            {
                UpgradeMirrorShield,
                UpgradeGildedSword,
                UpgradeBiggestQuiver,
                UpgradeBigBombBag,
                UpgradeBiggestBombBag,
                UpgradeGiantWallet,
            });

        public static readonly ReadOnlyCollection<int> REPEATABLE
            = new ReadOnlyCollection<int>(new int[] {
                ItemMagicBean,
                ItemPowderKeg,
                UpgradeRazorSword,
                UpgradeGildedSword,
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
                IkanaScrubGoldRupee,
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
                "Bottle with Red Potion",
                "Bottle with Milk",
                "Gold Dust",
                "Empty Bottle",
                "Empty Bottle",
                "Bottle with Chateau Romani",
                "Bombers' Notebook",
                "Razor Sword",
                "Gilded Sword",
                "Mirror Shield",
                "Large Quiver",
                "Largest Quiver",
                "Big Bomb Bag",
                "Biggest Bomb Bag",
                "Adult Wallet",
                "Giant Wallet",
                "Moon's Tear",
                "Land Title Deed",
                "Swamp Title Deed",
                "Mountain Title Deed",
                "Ocean Title Deed",
                "Room Key",
                "Letter to Kafei",
                "Pendant of Memories",
                "Letter to Mama",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
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
                "Poison Swamp Access",
                "Woodfall Temple Access",
                "Woodfall Temple Clear",
                "North Access",
                "Snowhead Temple Access",
                "Snowhead Temple Clear",
                "Epona Access",
                "West Access",
                "Pirates' Fortress Access",
                "Great Bay Temple Access",
                "Great Bay Temple Clear",
                "East Access",
                "Ikana Canyon Access",
                "Stone Tower Temple Access",
                "Inverted Stone Tower Temple Access",
                "Stone Tower Temple Clear",
                "Explosives",
                "Arrows",
                "",
                "",
                "",
                "",
                "",
                "Woodfall Map",
                "Woodfall Compass",
                "Woodfall Boss Key",
                "Woodfall Small Key",
                "Snowhead Map",
                "Snowhead Compass",
                "Snowhead Boss Key",
                "Snowhead Small Key",
                "Snowhead Small Key",
                "Snowhead Small Key",
                "Great Bay Map",
                "Great Bay Compass",
                "Great Bay Boss Key",
                "Great Bay Small Key",
                "Stone Tower Map",
                "Stone Tower Compass",
                "Stone Tower Boss Key",
                "Stone Tower Small Key",
                "Stone Tower Small Key",
                "Stone Tower Small Key",
                "Stone Tower Small Key",
                "Red Potion",
                "Green Potion",
                "Hero's Shield",
                "Fairy",
                "Deku Stick",
                "30 Arrows",
                "10 Deku Nuts",
                "50 Arrows",
                "Blue Potion",
                "Red Potion",
                "Green Potion",
                "10 Bombs",
                "10 Bombchu",
                "10 Bombs",
                "10 Arrows",
                "Red Potion",
                "Hero's Shield",
                "10 Arrows",
                "Red Potion",
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
                "Red Rupee",
                "Purple Rupee",
                "Red Rupee",
                "Red Rupee",
                "Purple Rupee",
                "5 Bombchu",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Silver Rupee",
                "Red Rupee",
                "Blue Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Silver Rupee",
                "1 Bombchu",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "1 Bombchu",
                "Purple Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Red Rupee",
                "Purple Rupee",
                "5 Bombchu",
                "Red Rupee",
                "Blue Rupee",
                "Red Rupee",
                "Purple Rupee",
                "Purple Rupee",
                "Red Rupee",
                "Empty Bottle", // originally Red Rupee
                "Red Rupee",
                "1 Bombchu",
                "Silver Rupee",
                "10 Bombchu",
                "Magic Bean",
                "Red Rupee",
                "Red Rupee",
                "Heart Piece",
                "Silver Rupee",
                "Silver Rupee",
                "Silver Rupee",
                "Silver Rupee",
                "Silver Rupee",
                "Silver Rupee",
                "Purple Rupee",
                "Silver Rupee",
                "Red Rupee",
                "Purple Rupee",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Container",
                "Heart Container",
                "Heart Container",
                "Heart Container",
                "Map: Clock Town",
                "Map: Woodfall",
                "Map: Snowhead",
                "Map: Romani Ranch",
                "Map: Great Bay",
                "Map: Stone Tower",
                "1 Bombchu",
                "Gold Rupee",
                "One Mask",
                "Two Masks",
                "Three Masks",
                "Four Masks",
                "Moon Access",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Heart Piece",
                "Fierce Deity's Mask",
        });

        public static readonly ReadOnlyCollection<string> LOCATION_NAMES
            = new ReadOnlyCollection<string>(new string[] {
                "Starting Item #1",
                "Hero's Bow Chest",
                "Fire Arrow Chest",
                "Ice Arrow Chest",
                "Light Arrow Chest",
                "Bomb Bag Purchase",
                "Bean Man",
                "Powder Keg Challenge",
                "Koume",
                "Lens of Truth Chest",
                "Hookshot Chest",
                "Ikana Great Fairy",
                "Kotake",
                "Aliens Defense",
                "Goron Race",
                "Beaver Race #1",
                "Dampe Digging",
                "Madame Aroma in Bar",
                "Bombers' Hide and Seek",
                "Mountain Smithy Day 1",
                "Mountain Smithy Day 2",
                "Mirror Shield Chest",
                "Town Archery #1",
                "Swamp Archery #1",
                "Big Bomb Bag Purchase",
                "Biggest Bomb Bag Purchase",
                "Bank Reward #1",
                "Ocean Spider House Reward",
                "Moon's Tear", // todo
                "Clocktown Scrub Trade",
                "Swamp Scrub Trade",
                "Mountain Scrub Trade",
                "Ocean Scrub Trade",
                "Inn Reservation",
                "Midnight Meeting",
                "Kafei",
                "Curiosity Shop Man #2",
                "Mayor",
                "Postman's Game",
                "Rosa Sisters",
                "Toilet Hand",
                "Grandma Short Story",
                "Grandma Long Story",
                "Keaton Quiz",
                "Deku Playground",
                "Town Archery #2",
                "Honey and Darling",
                "Swordsman's School",
                "Postbox",
                "Gossips Stones",
                "Business Scrub Purchase",
                "Swamp Archery #2",
                "Pictograph Contest",
                "Boat Archery",
                "Frog Choir",
                "Beaver Race #2",
                "Seahorse",
                "Fisherman Game",
                "Evan",
                "Dog Race",
                "Poe Hut",
                "Treasure Chest Game",
                "Peahat Grotto",
                "Dodongo Grotto",
                "Woodfall Heart Piece Chest",
                "Twin Islands Heart Piece Chest",
                "Ocean Spider House Heart Piece Chest",
                "Iron Knuckle Chest",
                "Postman's Freedom Reward",
                "All Night Mask Purchase",
                "Old Lady",
                "Invisible Soldier",
                "Clocktown Great Fairy",
                "Curiosity Shop Man #1",
                "Guru Guru",
                "Grog",
                "Hungry Goron",
                "Butler",
                "Cremia",
                "Gorman",
                "Madame Aroma in Office",
                "Anju and Kafei",
                "Swamp Spider House Reward",
                "Kamaro",
                "Pamela's Father",
                "Gorman Bros Race",
                "Captain Keeta's Chest",
                "Giant's Mask Chest",
                "Darmani",
                "Mikau",
                "Starting Item #2",
                "Swamp Music Statue",
                "Romani's Game",
                "Day 1 Grave Tablet",
                "Imprisoned Monkey",
                "Baby Goron",
                "Baby Zoras",
                "Ikana King",
                "Four Giants",
                "Poison Swamp Access",
                "Woodfall Temple Access",
                "Woodfall Temple Clear",
                "North Access",
                "Snowhead Temple Access",
                "Snowhead Temple Clear",
                "Epona Access",
                "West Access",
                "Pirates' Fortress Access",
                "Great Bay Temple Access",
                "Great Bay Temple Clear",
                "East Access",
                "Ikana Canyon Access",
                "Stone Tower Temple Access",
                "Inverted Stone Tower Temple Access",
                "Stone Tower Temple Clear",
                "Explosives",
                "Arrows",
                "",
                "",
                "",
                "",
                "",
                "Woodfall Map Chest",
                "Woodfall Compass Chest",
                "Woodfall Boss Key Chest",
                "Woodfall Small Key Chest",
                "Snowhead Map Chest",
                "Snowhead Compass Chest",
                "Snowhead Boss Key Chest",
                "Snowhead Block Room Chest",
                "Snowhead Icicle Room Chest",
                "Snowhead Bridge Room Chest",
                "Great Bay Map Chest",
                "Great Bay Compass Chest",
                "Great Bay Boss Key Chest",
                "Great Bay Small Key Chest",
                "Stone Tower Map Chest",
                "Stone Tower Compass Chest",
                "Stone Tower Boss Key Chest",
                "Stone Tower Armos Room Chest",
                "Stone Tower Eyegore Room Chest",
                "Stone Tower Updraft Room Chest",
                "Stone Tower Death Armos Maze Chest",
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
                "Bomb Shop 10 Bombs",
                "Bomb Shop 10 Bombchu",
                "Goron Shop 10 Bombs",
                "Goron Shop 10 Arrows",
                "Goron Shop Red Potion",
                "Zora Shop Shield",
                "Zora Shop 10 Arrows",
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
                "Lens Cave Invisible Chest",
                "Lens Cave Rock Chest",
                "Bean Grotto",
                "Hot Spring Water Grotto",
                "Day 1 Grave Bats",
                "Secret Shrine Grotto",
                "Pirates' Fortress Interior Lower Chest",
                "Pirates' Fortress Interior Upper Chest",
                "Pirates' Fortress Interior Tank Chest",
                "Pirates' Fortress Interior Guard Room Chest",
                "Pirates' Fortress Heart Piece Room Shallow Chest",
                "Pirates' Fortress Heart Piece Room Deep Chest",
                "Pirates' Fortress Maze Chest",
                "Pinnacle Rock Lower Chest",
                "Pinnacle Rock Upper Chest",
                "Bombers' Hideout Chest",
                "Termina Field Pillar Grotto",
                "Termina Field Grass Grotto",
                "Termina Field Underwater Chest",
                "Termina Field Grass Chest",
                "Termina Field Stump Chest",
                "Great Bay Coast Grotto",
                "Great Bay Cape Ledge Without Tree Chest",
                "Great Bay Cape Ledge With Tree Chest",
                "Great Bay Cape Grotto",
                "Great Bay Cape Underwater Chest",
                "Pirates' Fortress Exterior Log Chest",
                "Pirates' Fortress Exterior Sand Chest",
                "Pirates' Fortress Exterior Corner Chest",
                "Path to Swamp Grotto",
                "Doggy Racetrack Roof Chest",
                "Ikana Graveyard Grotto",
                "Near Swamp Spider House Grotto",
                "Behind Woodfall Owl Chest",
                "Entrance to Woodfall Chest",
                "Well Right Path Chest",
                "Well Left Path Chest",
                "Mountain Waterfall Chest",
                "Mountain Spring Grotto",
                "Path to Ikana Pillar Chest",
                "Path to Ikana Grotto",
                "Inverted Stone Tower Right Chest",
                "Inverted Stone Tower Middle Chest",
                "Inverted Stone Tower Left Chest",
                "Path to Snowhead Grotto",
                "Twin Islands Cave Chest",
                "Secret Shrine Heart Piece Chest",
                "Secret Shrine Dinolfos Chest",
                "Secret Shrine Wizzrobe Chest",
                "Secret Shrine Wart Chest",
                "Secret Shrine Garo Master Chest",
                "Inn Staff Room Chest",
                "Inn Guest Room Chest",
                "Mystery Woods Grotto",
                "East Clock Town Chest",
                "South Clock Town Straw Roof Chest",
                "South Clock Town Final Day Chest",
                "Bank Reward #2",
                "South Clock Town Heart Piece",
                "North Clock Town Heart Piece",
                "Path to Swamp Heart Piece",
                "Swamp Scrub Heart Piece",
                "Deku Palace Heart Piece",
                "Goron Village Scrub Heart Piece",
                "Bio Baba Grotto Heart Piece",
                "Lab Fish Heart Piece",
                "Great Bay Like-Like Heart Piece",
                "Pirates' Fortress Heart Piece",
                "Zora Hall Scrub Heart Piece",
                "Path to Snowhead Heart Piece",
                "Great Bay Coast Heart Piece",
                "Ikana Scrub Heart Piece",
                "Ikana Castle Heart Piece",
                "Odolwa Heart Container",
                "Goht Heart Container",
                "Gyorg Heart Container",
                "Twinmold Heart Container",
                "Clock Town Map Purchase",
                "Woodfall Map Purchase",
                "Snowhead Map Purchase",
                "Romani Ranch Map Purchase",
                "Great Bay Map Purchase",
                "Stone Tower Map Purchase",
                "Goron Racetrack Grotto",
                "Canyon Scrub Trade",
                "One Mask",
                "Two Masks",
                "Three Masks",
                "Four Masks",
                "Moon Access",
                "Deku Trial Heart Piece",
                "Goron Trial Heart Piece",
                "Zora Trial Heart Piece",
                "Link Trial Heart Piece",
                "Majora Child",
        });

        public static readonly ReadOnlyCollection<string> HINT_REGIONS
            = new ReadOnlyCollection<string>(new string[] {
                "",//"Starting Item #1",
                "Woodfall Temple",//"Hero's Bow Chest",
                "Snowhead Temple",//"Fire Arrow Chest",
                "Great Bay Temple",//"Ice Arrow Chest",
                "Stone Tower Temple",//"Light Arrow Chest",
                "West Clock Town",//"Bomb Bag Purchase",
                "Deku Palace",//"Bean Man",
                "Goron Village",//"Powder Keg Challenge",
                "Southern Swamp",//"Koume",
                "Goron Village",//"Lens of Truth Chest",
                "Pirates' Fortress Interior",//"Hookshot Chest",
                "Ikana Canyon",//"Ikana Great Fairy",
                "Southern Swamp",//"Kotake",
                "Romani Ranch",//"Aliens Defense",
                "Twin Islands",//"Goron Race",
                "Great Bay Cape",//"Beaver Race #1",
                "Ikana Graveyard",//"Dampe Digging",
                "East Clock Town",//"Madame Aroma in Bar",
                "North Clock Town",//"Bombers' Hide and Seek",
                "Mountain Village",//"Mountain Smithy Day 1",
                "Mountain Village",//"Mountain Smithy Day 2",
                "Beneath the Well",//"Mirror Shield Chest",
                "East Clock Town",//"Town Archery #1",
                "Road to Southern Swamp",//"Swamp Archery #1",
                "West Clock Town",//"Big Bomb Bag Purchase",
                "Goron Village",//"Biggest Bomb Bag Purchase",
                "West Clock Town",//"Bank Reward #1",
                "Great Bay Coast",//"Ocean Spider House Reward",
                "Termina Field",//"Moon's Tear",
                "South Clock Town",//"Clocktown Scrub Trade",
                "Southern Swamp",//"Swamp Scrub Trade",
                "Goron Village",//"Mountain Scrub Trade",
                "Zora Hall",//"Ocean Scrub Trade",
                "East Clock Town",//"Inn Reservation",
                "East Clock Town",//"Midnight Meeting",
                "Laundry Pool",//"Kafei",
                "Laundry Pool",//"Curiosity Shop Man #2",
                "East Clock Town",//"Mayor",
                "West Clock Town",//"Postman's Game",
                "West Clock Town",//"Rosa Sisters",
                "East Clock Town",//"Toilet Hand",
                "East Clock Town",//"Grandma Short Story",
                "East Clock Town",//"Grandma Long Story",
                "North Clock Town",//"Keaton Quiz", // arguable
                "North Clock Town",//"Deku Playground",
                "East Clock Town",//"Town Archery #2",
                "East Clock Town",//"Honey and Darling",
                "West Clock Town",//"Swordsman's School",
                "South Clock Town",//"Postbox", // arguable
                "Termina Field",//"Gossips Stones",
                "Termina Field",//"Business Scrub Purchase",
                "Road to Southern Swamp",//"Swamp Archery #2",
                "Southern Swamp",//"Pictograph Contest",
                "Southern Swamp",//"Boat Archery",
                "Mountain Village",//"Frog Choir",
                "Great Bay Cape",//"Beaver Race #2",
                "Pinnacle Rock",//"Seahorse",
                "Great Bay Coast",//"Fisherman Game",
                "Zora Hall",//"Evan",
                "Romani Ranch",//"Dog Race",
                "Ikana Canyon",//"Poe Hut",
                "East Clock Town",//"Treasure Chest Game",
                "Termina Field",//"Peahat Grotto",
                "Termina Field",//"Dodongo Grotto",
                "Woodfall",//"Woodfall Heart Piece Chest",
                "Twin Islands",//"Twin Islands Heart Piece Chest",
                "Great Bay Coast",//"Ocean Spider House Heart Piece Chest",
                "Ikana Graveyard",//"Iron Knuckle Chest",
                "East Clock Town",//"Postman's Freedom Reward",
                "West Clock Town",//"All Night Mask Purchase",
                "North Clock Town",//"Old Lady",
                "Road to Ikana",//"Invisible Soldier",
                "North Clock Town",//"Clocktown Great Fairy",
                "Laundry Pool",//"Curiosity Shop Man #1",
                "Laundry Pool",//"Guru Guru",
                "Romani Ranch",//"Grog",
                "Mountain Village",//"Hungry Goron",
                "Deku Palace",//"Butler",
                "Romani Ranch",//"Cremia",
                "East Clock Town",//"Gorman",
                "East Clock Town",//"Madame Aroma in Office",
                "East Clock Town",//"Anju and Kafei",
                "Southern Swamp",//"Swamp Spider House Reward",
                "Termina Field",//"Kamaro",
                "Ikana Canyon",//"Pamela's Father",
                "Milk Road",//"Gorman Bros Race",
                "Ikana Graveyard",//"Captain Keeta's Chest",
                "Stone Tower Temple",//"Giant's Mask Chest",
                "Mountain Village",//"Darmani",
                "Great Bay Coast",//"Mikau",
                "",//"Starting Item #2",
                "Southern Swamp",//"Swamp Music Statue",
                "Romani Ranch",//"Romani's Game",
                "Ikana Graveyard",//"Day 1 Grave Tablet",
                "Deku Palace",//"Imprisoned Monkey",
                "Goron Village",//"Baby Goron",
                "Great Bay Coast",//"Baby Zoras",
                "Ikana Castle",//"Ikana King",
                "",//"Four Giants",
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
                "Woodfall Temple",//"Woodfall Map Chest",
                "Woodfall Temple",//"Woodfall Compass Chest",
                "Woodfall Temple",//"Woodfall Boss Key Chest",
                "Woodfall Temple",//"Woodfall Key 1 Chest",
                "Snowhead Temple",//"Snowhead Map Chest",
                "Snowhead Temple",//"Snowhead Compass Chest",
                "Snowhead Temple",//"Snowhead Boss Key Chest",
                "Snowhead Temple",//"Snowhead Key 1 Chest",
                "Snowhead Temple",//"Snowhead Key 2 Chest",
                "Snowhead Temple",//"Snowhead Key 3 Chest",
                "Great Bay Temple",//"Great Bay Map Chest",
                "Great Bay Temple",//"Great Bay Compass Chest",
                "Great Bay Temple",//"Great Bay Boss Key Chest",
                "Great Bay Temple",//"Great Bay Key 1 Chest",
                "Stone Tower Temple",//"Stone Tower Map Chest",
                "Stone Tower Temple",//"Stone Tower Compass Chest",
                "Stone Tower Temple",//"Stone Tower Boss Key Chest",
                "Stone Tower Temple",//"Stone Tower Key 1 Chest",
                "Stone Tower Temple",//"Stone Tower Key 2 Chest",
                "Stone Tower Temple",//"Stone Tower Key 3 Chest",
                "Stone Tower Temple",//"Stone Tower Key 4 Chest",
                "West Clock Town",//"Trading Post Red Potion",
                "West Clock Town",//"Trading Post Green Potion",
                "West Clock Town",//"Trading Post Shield",
                "West Clock Town",//"Trading Post Fairy",
                "West Clock Town",//"Trading Post Stick",
                "West Clock Town",//"Trading Post Arrow 30",
                "West Clock Town",//"Trading Post Nut 10",
                "West Clock Town",//"Trading Post Arrow 50",
                "Southern Swamp",//"Witch Shop Blue Potion",
                "Southern Swamp",//"Witch Shop Red Potion",
                "Southern Swamp",//"Witch Shop Green Potion",
                "West Clock Town",//"Bomb Shop 10 Bombs",
                "West Clock Town",//"Bomb Shop 10 Bombchu",
                "Goron Village",//"Goron Shop 10 Bombs",
                "Goron Village",//"Goron Shop 10 Arrows",
                "Goron Village",//"Goron Shop Red Potion",
                "Zora Hall",//"Zora Shop Shield",
                "Zora Hall",//"Zora Shop 10 Arrows",
                "Zora Hall",//"Zora Shop Red Potion",
                "",//"Bottle: Fairy",
                "",//"Bottle: Deku Princess",
                "",//"Bottle: Fish",
                "",//"Bottle: Bug",
                "",//"Bottle: Poe",
                "",//"Bottle: Big Poe",
                "",//"Bottle: Spring Water",
                "",//"Bottle: Hot Spring Water",
                "",//"Bottle: Zora Egg",
                "",//"Bottle: Mushroom",
                "Goron Village",//"Lens Cave Invisible Chest",
                "Goron Village",//"Lens Cave Rock Chest",
                "Deku Palace",//"Bean Grotto",
                "Twin Islands",//"Hot Spring Water Grotto",
                "Ikana Graveyard",//"Day 1 Grave Bats",
                "Ikana Canyon",//"Secret Shrine Grotto",
                "Pirates' Fortress Interior",//"Pirates' Fortress Interior Lower Chest",
                "Pirates' Fortress Interior",//"Pirates' Fortress Interior Upper Chest",
                "Pirates' Fortress Interior",//"Pirates' Fortress Interior Tank Chest",
                "Pirates' Fortress Interior",//"Pirates' Fortress Interior Guard Room Chest",
                "Pirates' Fortress Sewer",//"Pirates' Fortress Heart Piece Room Chest #1", // shallow?
                "Pirates' Fortress Sewer",//"Pirates' Fortress Heart Piece Room Chest #2", // deep?
                "Pirates' Fortress Sewer",//"Pirates' Fortress Maze Chest",
                "Pinnacle Rock",//"Pinnacle Rock Lower Chest",
                "Pinnacle Rock",//"Pinnacle Rock Upper Chest",
                "East Clock Town",//"Bombers' Hideout Chest", // arguable
                "Termina Field",//"Termina Field Pillar Grotto",
                "Termina Field",//"Termina Field Grass Grotto",
                "Termina Field",//"Termina Field Underwater Chest",
                "Termina Field",//"Termina Field Grass Chest",
                "Termina Field",//"Termina Field Stump Chest",
                "Great Bay Coast",//"Great Bay Coast Grotto",
                "Great Bay Cape",//"Great Bay Cape Upper Ledge Chest",
                "Great Bay Cape",//"Great Bay Cape Lower Ledge Chest",
                "Great Bay Cape",//"Great Bay Cape Grotto",
                "Great Bay Cape",//"Great Bay Cape Underwater Chest",
                "Pirates' Fortress Exterior",//"Pirates' Fortress Exterior Log Chest",
                "Pirates' Fortress Exterior",//"Pirates' Fortress Exterior Corner Chest",
                "Pirates' Fortress Exterior",//"Pirates' Fortress Exterior Sand Chest",
                "Road to Southern Swamp",//"Path to Swamp Grotto",
                "Romani Ranch",//"Doggy Racetrack Roof Chest",
                "Ikana Graveyard",//"Ikana Graveyard Grotto",
                "Southern Swamp",//"Near Swamp Spider House Grotto",
                "Woodfall",//"Behind Woodfall Owl Chest",
                "Woodfall",//"Entrance to Woodfall Chest",
                "Beneath the Well",//"Well Right Path Chest",
                "Beneath the Well",//"Well Left Path Chest",
                "Mountain Village",//"Mountain Waterfall Chest",
                "Mountain Village",//"Mountain Spring Grotto",
                "Road to Ikana",//"Path to Ikana Pillar Chest",
                "Road to Ikana",//"Path to Ikana Grotto",
                "Stone Tower",//"Inverted Stone Tower Chest #1",
                "Stone Tower",//"Inverted Stone Tower Chest #2",
                "Stone Tower",//"Inverted Stone Tower Chest #3",
                "Path to Snowhead",//"Path to Snowhead Grotto",
                "Twin Islands",//"Twin Islands Cave Chest",
                "Secret Shrine",//"Secret Shrine Heart Piece Chest",
                "Secret Shrine",//"Secret Shrine Dinolfos Chest",
                "Secret Shrine",//"Secret Shrine Wizzrobe Chest",
                "Secret Shrine",//"Secret Shrine Wart Chest",
                "Secret Shrine",//"Secret Shrine Garo Master Chest",
                "East Clock Town",//"Inn Staff Room Chest",
                "East Clock Town",//"Inn Guest Room Chest",
                "Southern Swamp",//"Mystery Woods Grotto",
                "East Clock Town",//"East Clock Town Chest",
                "South Clock Town",//"South Clock Town Straw Roof Chest",
                "South Clock Town",//"South Clock Town Final Day Chest",
                "West Clock Town",//"Bank Reward #2",
                "South Clock Town",//"South Clock Town Heart Piece",
                "North Clock Town",//"North Clock Town Heart Piece",
                "Road to Southern Swamp",//"Path to Swamp Heart Piece",
                "Southern Swamp",//"Swamp Scrub Heart Piece",
                "Deku Palace",//"Deku Palace Heart Piece",
                "Goron Village",//"Goron Village Scrub Heart Piece",
                "Termina Field",//"Bio Baba Grotto Heart Piece",
                "Great Bay Coast",//"Lab Fish Heart Piece",
                "Great Bay Cape",//"Great Bay Like-Like Heart Piece",
                "Pirates' Fortress Sewer",//"Pirates' Fortress Heart Piece",
                "Zora Hall",//"Zora Hall Scrub Heart Piece",
                "Path to Snowhead",//"Path to Snowhead Heart Piece",
                "Great Bay Coast",//"Great Bay Coast Heart Piece",
                "Ikana Canyon",//"Ikana Scrub Heart Piece",
                "Ikana Castle",//"Ikana Castle Heart Piece",
                "Woodfall Temple",//"Odolwa Heart Container",
                "Snowhead Temple",//"Goht Heart Container",
                "Great Bay Temple",//"Gyorg Heart Container",
                "Stone Tower Temple",//"Twinmold Heart Container",
                "North Clock Town",//"Clock Town Map Purchase",
                "Road to Southern Swamp",//"Woodfall Map Purchase",
                "Road to Southern Swamp",//"Snowhead Map Purchase",
                "Milk Road",//"Romani Ranch Map Purchase",
                "Milk Road",//"Great Bay Map Purchase",
                "Great Bay Coast",//"Stone Tower Map Purchase",
                "Twin Islands",//"Goron Racetrack Grotto",
                "Ikana Canyon",//"Canyon Scrub Trade",
                "",//"One Mask",
                "",//"Two Masks",
                "",//"Three Masks",
                "",//"Four Masks",
                "",//"Moon Access",
                "",//"Deku Trial Heart Piece",
                "",//"Goron Trial Heart Piece",
                "",//"Zora Trial Heart Piece",
                "",//"Link Trial Heart Piece",
                "",//"Majora Child",
        });

        internal static readonly int TotalNumberOfItems = 267;

    }
}