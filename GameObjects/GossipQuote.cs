using System;

namespace MMRando.GameObjects
{
    public enum GossipQuote
    {
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.IkanaScrubGoldRupee)] // or random? or silver rupees?
        TerminaSouth = 0x20B0,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPiecePictobox)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemPictobox)]
        SwampPotionShop = 0x20B1,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceChoir)]
        MountainSpringPath = 0x20B2,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemGoldDust)]
        MountainPath = 0x20B3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceEvan)] // maybe location of zora mask?
        OceanZoraGame = 0x20B4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskStone)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemLens)]
        CanyonRoad = 0x20B5,

        CanyonDock = 0x20B6, // maybe location of Captain's Hat

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        CanyonSpiritHouse = 0x20B7,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        TerminaMilk = 0x20B8,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceNotebookMayor)]
        TerminaWest = 0x20B9,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.TradeItemRoomKey)] // maybe guest room chest?
        TerminaNorth = 0x20BA,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskCouple)] // maybe hookshot, gibdo, or garo mask?
        TerminaEast = 0x20BB,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)] // maybe make this something more useful?
        RanchTree = 0x20BC,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemKafeiLetter)]
        RanchBarn = 0x20BD,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskKamaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro)]
        MilkRoad = 0x20BE,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleAliens)]
        OceanFortress = 0x20BF,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemRoomKey)]
        SwampRoad = 0x20C0,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskPostmanHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMamaLetter)]
        TerminaObservatory = 0x20C1,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskAllNight)] // or also location of All Night Mask?
        RanchCuccoShack = 0x20C2,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleMadameAroma)]
        RanchRacetrack = 0x20C3,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceKeatonQuiz)]
        RanchEntrance = 0x20C4,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskFierceDeity)] // maybe don't show this?
        CanyonRavine = 0x20C5,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        MountainSpringFrog = 0x20C6,

        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDogRace)]
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

    // todo move to new file
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class GossipRestrictAttribute : Attribute
    {
        public int Id { get; private set; }
        public RestrictionType Type { get; private set; }

        public GossipRestrictAttribute(RestrictionType type, int id)
        {
            Type = type;
            Id = id;
        }

        public enum RestrictionType
        {
            Item,
            Location
        }
    }

    // todo move to new file
    [AttributeUsage(AttributeTargets.Field)]
    public class GossipAlreadyAcquiredTextIdAttribute : Attribute
    {
        public ushort AlreadyAcquiredTextId { get; private set; }

        public GossipAlreadyAcquiredTextIdAttribute(ushort alreadyAcquiredTextId)
        {
            AlreadyAcquiredTextId = alreadyAcquiredTextId;
        }
    }
}
