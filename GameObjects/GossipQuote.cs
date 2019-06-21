using MMRando.Attributes;

namespace MMRando.GameObjects
{
    public enum GossipQuote
    {
        //It seems the crows that fly near the town walls are fond of musical instruments...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.IkanaScrubGoldRupee)] // or random? or silver rupees?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongSonata)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongLullaby)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongNewWaveBossaNova)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongElegy)]
        TerminaSouth = 0x20B0,

        //The Swamp Tourist Center will not accept pictographs taken outside the swamp.
        //But if you bring a pictograph of the guide's son, he'll give you something nice...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPiecePictobox)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemPictobox)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceSwampArchery)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestWoodsGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskScents)]
        SwampPotionShop = 0x20B1,

        //The frogs that are supposed to gather in the mountain when spring arrives are elsewhere.
        //You need Don Gero's Mask to bring them together.
        //The frogs in Clock Town, the swamp, Woodfall Temple, and Great Bay Temple make four...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceChoir)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeAdultWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemGoldDust)]
        MountainSpringPath = 0x20B2,

        //The gold dust won as the prize in the Goron Races in spring can be used by the smithy to forge a sword.
        //Or it can be sold to the smithy for 40 Rupees, but the Curiosity Shop will buy it for 200 Rupees...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeAdultWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemGoldDust)]
        MountainPath = 0x20B3,

        //To get Evan to listen to Mikau and Japas's song from their music session, you should not try demonstrating it as Mikau.
        //It seems if you pose as someone unrelated to the band and begin playing it, you just might get him to lend an ear.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceEvan)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleBeavers)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceBeaverRace)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskZora)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        OceanZoraGame = 0x20B4,

        //If you use the Lens of Truth near here and speak to the man you find...
        //you may earn a mask that can enable you to blend into backgrounds and move about without being noticed.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskStone)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemLens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        CanyonRoad = 0x20B5,

        //It seems the ReDeads that appear in Ikana Castle start dancing when the Captain's Hat, Gibdo Mask or Garo's Mask are worn.
        //But that does not change things much...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemIceArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineHeartPiece)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineDinoGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineGaroGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineWartGrotto)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestSecretShrineWizzGrotto)]
        CanyonDock = 0x20B6,

        //Pamela, who lives in the music box house, comes out every two minutes when the music box is playing.
        //But it seems she will also come out if she hears a bomb explode...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongStorms)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongHealing)]
        CanyonSpiritHouse = 0x20B7,

        //It seems that you can become a Milk Bar member if you do a good deed at the ranch.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ChestTerminaUnderwaterRedRupee)]
        TerminaMilk = 0x20B8,

        //The symbol of marriage, the Couple's Mask seems to have the power to calm and silence arguments.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceNotebookMayor)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskZora)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceTerminaGossipStones)]
        TerminaWest = 0x20B9,

        //Anju, the woman at the inn, is known for being careless and frequently mixes up guests.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.TradeItemRoomKey)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBigQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGoron)]
        TerminaNorth = 0x20BA,

        //It seems that the hideout of Sakon, the thief, is tucked away at the edge of Ikana Canyon.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskCouple)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleDampe)]
        TerminaEast = 0x20BB,

        //The animal bandleader's mask seems to have the strange power of making young animals mature.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)] // maybe make this something more useful?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDekuPlayground)]
        RanchTree = 0x20BC,

        //It seems that Kafei, whose whereabouts are unknown, is awaiting a letter from Anju...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemKafeiLetter)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemPendant)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleAliens)]
        RanchBarn = 0x20BD,

        //The spirit of a charismatic dancer who died in Termina Field dances there night after night.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskKamaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDekuPlayground)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskRomani)]
        MilkRoad = 0x20BE,

        //The reward for Romani's nighttime assistant seems to be something that holds milk...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleAliens)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleBeavers)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleDampe)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleWitch)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ChestMountainVillageGrottoBottle)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceLabFish)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.SongNewWaveBossaNova)]
        OceanFortress = 0x20BF,
        
        //It seems the veranda door of the town's Stock Pot Inn has carelessly been left unlocked...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemRoomKey)] // maybe make this something more useful?
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceSwampArchery)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBigQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.UpgradeBiggestQuiver)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskScents)]
        SwampRoad = 0x20C0,

        //The postman puts his delivery schedule before everything else, but Priority Mail is of even greater importance.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskPostmanHat)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMamaLetter)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMoonTear)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemLandDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemSwampDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemMountainDeed)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.TradeItemOceanDeed)]
        TerminaObservatory = 0x20C1,

        //A torture device of insomnia called the All-Night Mask seems to be available at the Curiosity Shop...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskAllNight)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskBunnyHood)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)]
        RanchCuccoShack = 0x20C2,

        //It seems that drinking Chateau Romani makes your magic power last for three days...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemBottleMadameAroma)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDogRace)]
        // todo add more
        RanchRacetrack = 0x20C3,

        //It seems Keaton, the ghost fox, plays tricks in the grass...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceKeatonQuiz)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGiantWallet)]
        RanchEntrance = 0x20C4,

        //The Fierce Deity Mask, a mask that contains the merits of all masks seems to be...
        //somewhere in this world...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskFierceDeity)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemIceArrow)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.ItemHookshot)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemFairySword)]
        CanyonRavine = 0x20C5,

        //A small, lost horse seems to have been taken in by Romani Ranch, south of town.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.SongEpona)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceChoir)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeRazorSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGildedSword)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.ItemGoldDust)]
        MountainSpringFrog = 0x20C6,

        //The mask that can see into people's hearts and minds also seems to work on animals as well...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceDogRace)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.UpgradeGiantWallet)]
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Location, Items.HeartPieceOceanSpiderHouse)]
        SwampSpiderHouse = 0x20C7,


        // TerminaGossipGrotto
        //It seems all the strange stones that are arranged in a row wish to be the same color.
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

        //It seems the face of the slightly larger, strange stone changes when the guitar of waves is played.
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

        //It seems the face of the slightly larger, strange stone changes when the pipes of awakening are played.
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

        //It seems the face of the slightly larger, strange stone changes when the drums of sleep are played.
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
        //The mask that sees into people's hearts seems to be near the strange, shining, gold spiders...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth)]
        MoonMaskTruth = 0x20D4,
        //It seems the one cursed by the strange, sparkling gold spiders had the Mask of Truth...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskTruth, true)]
        MoonMaskTruthClear = 0x2103,

        //The cute boy's mask seems to have been made by an important man's wife...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKafei)]
        MoonMaskKafei = 0x20D5,
        //It seems his mother, Madame Aroma, had Kafei's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKafei, true)]
        MoonMaskKafeiClear = 0x2104,

        //The weird mask that disrupts sleeping habits seems to be found in a suspicious shop that opens only at night...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight)]
        MoonMaskAllNight = 0x20D6,
        //It seems the All-Night Mask was being sold at the Curiosity Shop...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskAllNight, true)]
        MoonMaskAllNightClear = 0x2105,

        //It seems the animal-loving young man with the scary face but kind heart has the wild ears that hear well...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood)]
        MoonMaskBunnyHood = 0x20D7,
        //It seems Grog of the Cucco Shack had the Bunny Hood...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBunnyHood, true)]
        MoonMaskBunnyHoodClear = 0x2106,

        //It seems an animal mask that was popular with children long ago is being cherished by the owner of the suspicious shop...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton)]
        MoonMaskKeaton = 0x20D8,
        //It seems the owner of the Curiosity Shop was keeping the Keaton Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKeaton, true)]
        MoonMaskKeatonClear = 0x2107,

        //The suspicious brothers seem to have a mask once used for spying activities...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro)]
        MoonMaskGaro = 0x20D9,
        //It seems the Gorman Brothers were using Garo's Mask for ill...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGaro, true)]
        MoonMaskGaroClear = 0x2108,

        //It seems the girl who smells of the ranch has a mask that only adults have...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani)]
        MoonMaskRomani = 0x20DA,
        //It seems Cremia, the owner of Romani Ranch, had Romani's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskRomani, true)]
        MoonMaskRomaniClear = 0x2109,

        //The mask that trickles out troubles from its face seems to be held by the greatest of traveling men...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCircusLeader)]
        MoonMaskCircusLeader = 0x20DB,
        //It seems the leader of the Gorman Troupe had the Circus Leader's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCircusLeader, true)]
        MoonMaskCircusLeaderClear = 0x210A,

        //It seems the person who is conscientious about being on time...
        //can see into the boxes that enable people to keep in touch with other people's feelings.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskPostmanHat)]
        MoonMaskPostmanHat = 0x20DC,
        //It seems the postman had the Postman's Hat...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskPostmanHat, true)]
        MoonMaskPostmanHatClear = 0x210B,

        //It seems the two who have most reason to have it are indeed the ones who have the mask that is full of a man and woman's love...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCouple)]
        MoonMaskCouple = 0x20DD,
        //It seems Kafei and Anju had the Couple's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCouple, true)]
        MoonMaskCoupleClear = 0x210C,

        //A large and colorful being seems to have a mask that calms those scattered in temples...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGreatFairy)]
        MoonMaskGreatFairy = 0x20DE,
        //It seems the Great Fairy in town had the Great Fairy's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGreatFairy, true)]
        MoonMaskGreatFairyClear = 0x210D,

        //It seems the father of the girl who's devoted to her parent is being forced to wear a frightening mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo)]
        MoonMaskGibdo = 0x20DF,
        //It seems the Gibdo Mask could fall from Pamela's father's cursed face...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGibdo, true)]
        MoonMaskGibdoClear = 0x210E,

        //He who is troubled by cold and hunger seems to have a mask that gathers voices to sing...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero)]
        MoonMaskDonGero = 0x20E0,
        //It seems the hungry Goron was wearing Don Gero's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskDonGero, true)]
        MoonMaskDonGeroClear = 0x210F,

        //The dancer's spirit that appears night after night in the great field seems to have a mask which causes one to dance.
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro)]
        MoonMaskKamaro = 0x20E1,
        //It seems Kamaro, the spirit dancer, had Kamaro's Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskKamaro, true)]
        MoonMaskKamaroClear = 0x2110,

        //It seems the mystical item that the skulls obey is in the fiercely burning flame in the graveyard of an accursed land...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat)]
        MoonMaskCaptainHat = 0x20E2,
        //It seems Skull Keeta, Captain of the Skull Knights, had the Captain's Hat...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskCaptainHat, true)]
        MoonMaskCaptainHatClear = 0x2111,

        //It seems a man so inconspicuous he can be seen only through the Lens of Truth has a mask which also is completely inconspicuous...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskStone)]
        MoonMaskStone = 0x20E3,
        //It seems Shiro, the unseen stone soldier, had the Stone Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskStone, true)]
        MoonMaskStoneClear = 0x2112,

        //He who plays music as he travels about seems to have a mask that animals follow obediently...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen)]
        MoonMaskBremen = 0x20E4,
        //It seems Guru-Guru, the traveling musician, had the Bremen Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBremen, true)]
        MoonMaskBremenClear = 0x2113,

        //The old woman with knowledge of explosives has a dangerous mask filled with gunpowder...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBlast)]
        MoonMaskBlast = 0x20E5,
        //It seems the old woman with the Bomb Bag had the Blast Mask...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskBlast, true)]
        MoonMaskBlastClear = 0x2114,

        //He of high class and manners who lives in the swamp has a useful mask that distinguishes scents...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskScents)]
        MoonMaskScents = 0x20E6,
        //It seems the Deku Scrub butler had the Mask of Scents...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskScents, true)]
        MoonMaskScentsClear = 0x2115,

        //A mask that contains gigantic power seems to be resting in the temple of the accursed land...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant)]
        MoonMaskGiant = 0x20E7,
        //It seems the Giant's Mask was dormant in Stone Tower Temple...
        [GossipRestrict(GossipRestrictAttribute.RestrictionType.Item, Items.MaskGiant, true)]
        MoonMaskGiantClear = 0x2116,
    }
}
