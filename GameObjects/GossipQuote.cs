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
        // 0x20F3
        // 0x20F7
        // 0x20F8
        // 0x20F9


        // Moon Gossip Stones
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth), GossipAlreadyAcquiredTextId(0x2103)]
        MoonMaskTruth = 0x20D4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKafei), GossipAlreadyAcquiredTextId(0x2104)]
        MoonMaskKafei = 0x20D5,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight), GossipAlreadyAcquiredTextId(0x2105)]
        MoonMaskAllNight = 0x20D6,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood), GossipAlreadyAcquiredTextId(0x2106)]
        MoonMaskBunnyHood = 0x20D7,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton), GossipAlreadyAcquiredTextId(0x2107)]
        MoonMaskKeaton = 0x20D8,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro), GossipAlreadyAcquiredTextId(0x2108)]
        MoonMaskGaro = 0x20D9,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani), GossipAlreadyAcquiredTextId(0x2109)]
        MoonMaskRomani = 0x20DA,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCircusLeader), GossipAlreadyAcquiredTextId(0x210A)]
        MoonMaskCircusLeader = 0x20DB,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskPostmanHat), GossipAlreadyAcquiredTextId(0x210B)]
        MoonMaskPostmanHat = 0x20DC,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCouple), GossipAlreadyAcquiredTextId(0x210C)]
        MoonMaskCouple = 0x20DD,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGreatFairy), GossipAlreadyAcquiredTextId(0x210D)]
        MoonMaskGreatFairy = 0x20DE,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo), GossipAlreadyAcquiredTextId(0x210E)]
        MoonMaskGibdo = 0x20DF,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero), GossipAlreadyAcquiredTextId(0x210F)]
        MoonMaskDonGero = 0x20E0,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro), GossipAlreadyAcquiredTextId(0x2110)]
        MoonMaskKamaro = 0x20E1,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat), GossipAlreadyAcquiredTextId(0x2111)]
        MoonMaskCaptainHat = 0x20E2,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskStone), GossipAlreadyAcquiredTextId(0x2112)]
        MoonMaskStone = 0x20E3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen), GossipAlreadyAcquiredTextId(0x2113)]
        MoonMaskBremen = 0x20E4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBlast), GossipAlreadyAcquiredTextId(0x2114)]
        MoonMaskBlast = 0x20E5,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskScents), GossipAlreadyAcquiredTextId(0x2115)]
        MoonMaskScents = 0x20E6,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant), GossipAlreadyAcquiredTextId(0x2116)]
        MomonMaskGiant = 0x20E7,
    }
}
