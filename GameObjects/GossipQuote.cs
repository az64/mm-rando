using MMRando.Attributes;

namespace MMRando.GameObjects
{
    public enum GossipQuote
    {
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.IkanaScrubGoldRupee)] // or random? or silver rupees?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongSonata)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongLullaby)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongNewWaveBossaNova)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongElegy)]
        TerminaSouth = 0x20B0,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPiecePictobox)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemPictobox)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceSwampArchery)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestWoodsGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskScents)]
        SwampPotionShop = 0x20B1,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceChoir)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeAdultWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemGoldDust)]
        MountainSpringPath = 0x20B2,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeAdultWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemGoldDust)]
        MountainPath = 0x20B3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceEvan)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleBeavers)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceBeaverRace)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskZora)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        OceanZoraGame = 0x20B4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskStone)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemLens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        CanyonRoad = 0x20B5,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemIceArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineHeartPiece)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineDinoGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineGaroGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineWartGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineWizzGrotto)]
        CanyonDock = 0x20B6,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongStorms)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongHealing)]
        CanyonSpiritHouse = 0x20B7,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestTerminaUnderwaterRedRupee)]
        TerminaMilk = 0x20B8,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceNotebookMayor)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskZora)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceTerminaGossipStones)]
        TerminaWest = 0x20B9,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.TradeItemRoomKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBigQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGoron)]
        TerminaNorth = 0x20BA,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskCouple)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        TerminaEast = 0x20BB,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)] // maybe make this something more useful?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDekuPlayground)]
        RanchTree = 0x20BC,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemKafeiLetter)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemPendant)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleAliens)]
        RanchBarn = 0x20BD,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskKamaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDekuPlayground)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        MilkRoad = 0x20BE,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleBeavers)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleWitch)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ChestMountainVillageGrottoBottle)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceLabFish)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.SongNewWaveBossaNova)]
        OceanFortress = 0x20BF,
        
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemRoomKey)] // maybe make this something more useful?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceSwampArchery)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBigQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskScents)]
        SwampRoad = 0x20C0,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskPostmanHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMamaLetter)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMoonTear)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemLandDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemSwampDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMountainDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemOceanDeed)]
        TerminaObservatory = 0x20C1,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskBunnyHood)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)]
        RanchCuccoShack = 0x20C2,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDogRace)]
        // todo add more
        RanchRacetrack = 0x20C3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceKeatonQuiz)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGiantWallet)]
        RanchEntrance = 0x20C4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskFierceDeity)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemIceArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemFairySword)]
        CanyonRavine = 0x20C5,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceChoir)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        MountainSpringFrog = 0x20C6,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDogRace)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGiantWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceOceanSpiderHouse)]
        SwampSpiderHouse = 0x20C7,


        // TerminaGossipGrotto
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceTerminaGossipStones)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongElegy)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemLightArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskGiant)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerMap)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerCompass)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerBossKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerKey1)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerKey2)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerKey3)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemStoneTowerKey4)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartContainerStoneTower)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceLinkTrial)]
        TerminaGossipLarge = 0x20F3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongNewWaveBossaNova)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskZora)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemIceArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGreatBayMap)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGreatBayCompass)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGreatBayBossKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGreatBayKey1)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartContainerGreatBay)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceZoraTrial)]
        TerminaGossipGuitar = 0x20F7,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongSonata)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDeku)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemWoodfallMap)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemWoodfallCompass)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemWoodfallBossKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemWoodfallKey1)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartContainerWoodfall)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDekuTrial)]
        TerminaGossipPipes = 0x20F8,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongLullaby)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGoron)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemFireArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadMap)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadCompass)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadBossKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadKey1)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadKey2)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemSnowheadKey3)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartContainerSnowhead)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceGoronTrial)]
        TerminaGossipDrums = 0x20F9,


        // Moon Gossip Stones
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth)]
        MoonMaskTruth = 0x20D4,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth, true)]
        MoonMaskTruthClear = 0x2103,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKafei)]
        MoonMaskKafei = 0x20D5,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKafei, true)]
        MoonMaskKafeiClear = 0x2104,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight)]
        MoonMaskAllNight = 0x20D6,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight, true)]
        MoonMaskAllNightClear = 0x2105,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood)]
        MoonMaskBunnyHood = 0x20D7,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood, true)]
        MoonMaskBunnyHoodClear = 0x2106,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton)]
        MoonMaskKeaton = 0x20D8,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton, true)]
        MoonMaskKeatonClear = 0x2107,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro)]
        MoonMaskGaro = 0x20D9,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro, true)]
        MoonMaskGaroClear = 0x2108,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani)]
        MoonMaskRomani = 0x20DA,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani, true)]
        MoonMaskRomaniClear = 0x2109,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCircusLeader)]
        MoonMaskCircusLeader = 0x20DB,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCircusLeader, true)]
        MoonMaskCircusLeaderClear = 0x210A,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskPostmanHat)]
        MoonMaskPostmanHat = 0x20DC,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskPostmanHat, true)]
        MoonMaskPostmanHatClear = 0x210B,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCouple)]
        MoonMaskCouple = 0x20DD,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCouple, true)]
        MoonMaskCoupleClear = 0x210C,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGreatFairy)]
        MoonMaskGreatFairy = 0x20DE,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGreatFairy, true)]
        MoonMaskGreatFairyClear = 0x210D,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        MoonMaskGibdo = 0x20DF,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo, true)]
        MoonMaskGibdoClear = 0x210E,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero)]
        MoonMaskDonGero = 0x20E0,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero, true)]
        MoonMaskDonGeroClear = 0x210F,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro)]
        MoonMaskKamaro = 0x20E1,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro, true)]
        MoonMaskKamaroClear = 0x2110,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        MoonMaskCaptainHat = 0x20E2,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat, true)]
        MoonMaskCaptainHatClear = 0x2111,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskStone)]
        MoonMaskStone = 0x20E3,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskStone, true)]
        MoonMaskStoneClear = 0x2112,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)]
        MoonMaskBremen = 0x20E4,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen, true)]
        MoonMaskBremenClear = 0x2113,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBlast)]
        MoonMaskBlast = 0x20E5,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBlast, true)]
        MoonMaskBlastClear = 0x2114,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskScents)]
        MoonMaskScents = 0x20E6,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskScents, true)]
        MoonMaskScentsClear = 0x2115,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant)]
        MoonMaskGiant = 0x20E7,
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant, true)]
        MoonMaskGiantClear = 0x2116,
    }
}
