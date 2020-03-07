using static MMR.Randomizer.Models.SoundEffects.SoundEffectTag;

namespace MMR.Randomizer.Models.SoundEffects
{
    /// <summary>
    /// Sound effects used throughout the game. 
    /// The value of a sound effect corresponds to its Id
    /// 
    /// Extensive overview of sound ids can be found in this google spreadsheet:
    /// https://docs.google.com/spreadsheets/d/1YVJ7GdzNZUese6H8d40lzpxp8ZfWlt75c-lzBzKngmo/edit#gid=1343879920
    /// </summary>

    public enum SoundEffect
    {
        #region Environment SFX

        [Replacable(0x00EABA46, 0x00EABC3A, 0x00EACACA)]
        [Tags(Long)]
        [ReplacableByTags(Long)]
        CuccoMorning = 0x2013,

        [Replacable(0x00EABC4A, 0x00EACABE)]
        [Tags(Long)]
        [ReplacableByTags(Long)]
        WolfHowlEvening = 0x20AE,

        [Replacable(0x00DFC776, 0xDFCC3A, 0xDFDCF6)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        DogBark = 0x20D8,

        [Tags(Long)]
        CowMoo = 0x20DF,

        [Tags(Short)]
        [ReplacableByTags(Short)]
        [Replacable(0xDFC84A, 0xDFE0FA)]
        DogGroan = 0x210B,

        [Replacable(0x00DFC7B6)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        DogBarkAngry = 0x2110,

        [Replacable(0xDFC80A, 0xDFD5E6)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        DogWhine = 0x2113,

        [Replacable(0x00D01186, 0x00CFE0A6, 0x00CF969A, 0x00CFA602, 0x00CFA816, 0x00CFA482, 0x00CF91E2, 0x00CFC43A)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        EponaNeigh = 0x2044,

        #endregion

        #region Enemy SFX

        [Tags(Short)]
        GaroAppear = 0x3012,

        [Tags(Short)]
        DinolfosCry = 0x3029,

        [Tags(Short)]
        DinolfosAttack = 0x302A,

        [Replacable(0xE89EA6, 0xE8A336, 0xE03C66, 0xE03E36, 0xE060FE)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        WolfosAppear = 0x303C,

        [Replacable(0xE041A2, 0xE04496, 0xE046B2, 0xE04876, 0xE0511A, 0xE05AD6, 0xE060BA, 0xE0628E, 0xE064A2)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        WolfosCry = 0x303E,

        [Replacable(0xE04AD6)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        WolfosAttack = 0x303F,

        [Replacable(0xE0523E)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        WolfosTakeDamage = 0x3043,

        [Replacable(0xE8A426, 0xE05B26)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        WolfosDie = 0x304B,

        [Tags(Short)]
        BombchuAim = 0x3055,

        [Tags(Short)]
        PoeAppear = 0x3073,

        [Tags(Short)]
        PoeDisappear = 0x3074,

        [Replacable(0xE95C6E, 0xE960FA, 0xD3809E, 0xD38502)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        MadScrubTakeDamage = 0x3080,

        [Replacable(0xE96196, 0xD386A6)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        MadScrubDie = 0x3081,

        [Tags(Short)]
        MajoraGrowHead = 0x3088,

        [Replacable(0xCEEF0A)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        WallmasterAim = 0x3090,

        [Tags(Short)]
        GoronCold = 0x30B4,

        [Replacable(0xE0DBBE, 0xE3BD7A, 0x00E3C002, 0x01048266, 0x01048416, 0x0104852E)]
        [Tags(Short)]
        [ReplacableByTags(Short)]
        GuayCroak = 0x30B6,

        [Replacable(0xCE57CE, 0xCE5A22)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        FrogRibbit = 0x30D2,

        [Replacable(0xCE50F2, 0xCE603A, 0xCE6F7E)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        FrogTakeDamage = 0x30D3,

        [Replacable(0xCE6026)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        FrogDie = 0x30D6,

        [Replacable(0xD4E78E, 0xD4E996, 0xD4EB9E, 0xD4EBF6, 0xD4EE1A, 0xD4EEAE, 0xD4F0DA, 0xD4F57A, 0xD4F81A, 0xD4FA26)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        RedeadMoan = 0x30E4,

        [Replacable(0xD4F3E2, 0xD4FF36)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        RedeadAim = 0x30E5,

        [Replacable(0xD4FD26)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        RedeadAttack = 0x30E8,

        [Replacable(0x00FB719E, 0x00FB72D6)]
        [Effect(0x000)]
        [Tags(Looping)]
        [ReplacableByTags(Long)]
        GoronKidCry = 0x30EA,

        [Replacable(0xE3C096)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        GuayDie = 0x30EB,

        [Tags(Short)]
        GoronWake = 0x30FC,

        [Tags(Short)]
        GoronSitStand = 0x30FD,

        [Tags(Short)]
        IronKnuckleSwing = 0x3129,

        [Replacable(0xCE5E22, 0xCE717E)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        FrogGreet = 0x315C,

        [Replacable(0xCE5286)]
        [ReplacableByTags(Short)]
        [Tags(Short)]
        FrogVoice2 = 0x31A1,

        [Tags(Short)]
        GoronSleepy = 0x31AD,

        [Tags(Long)]
        SkullKidLaugh1 = 0x3275,

        [Tags(Long)]
        SkullKidLaugh2 = 0x3276,

        [Tags(Long)]
        SkullKidLaugh3 = 0x3277,

        #endregion

        #region System SFX

        [Replacable(0x00B3D5C6)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        GetRupee = 0x4003,

        [Replacable(0x00C9294E, 0x00C96A12)]
        [Tags(SystemSound)]
        [ReplacableByTags(SystemSound)]
        MenuSelect = 0x4008,

        [Replacable(0x00BABE6A)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        GetRecoveryHeart = 0x400B,

        [Replacable(0x00B97E2A)]
        [Tags(LowHpBeep)]
        [ReplacableByTags(Short, LowHpBeep)]
        LowHealthBeep = 0x401B,

        [Replacable(0x00DDE78E, 0x00DDF322)]
        [Tags(SystemSound)]
        [ReplacableByTags(Long)]
        TitleSelect = 0x4023,

        [Replacable(0x00B3D606)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        GetSmallItem = 0x4024,


        [Replacable(0x00C86DE2, 0x00C7E8EA, 0x00C7EFD2, 0x00C80A62, 0x00C841EE, 0x00C84242, 0xC843BA, 0x00C84456, 0x00C8453E, 0xC8458A, 0x00C846FE, 0x00C84ABE, 0x00C86DE2, 0xC844DE, 0xC84A3E, 0xC8CE2A, 0xC84B3E, 0xC81312, 0xC7F92E)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectCursor = 0x4039,

        [Replacable(0x00C83E1A)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectTypeCharacter = 0x403A,

        [Replacable(0x00C83ABE, 0xC7E8B2, 0xC7EEE2, 0xC7F91E, 0xC7FFEA, 0xC80A2A, 0xC86B26, 0xC86ACE, 0xC86C7E, 0xC8407A, 0xC8CD8E, 0xC7EF16, 0xC84B76, 0xC84996)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectDecideLong = 0x403B,

        [Replacable(0xC83C3E, 0xC83BEA, 0xC83FEA, 0xC8CD76, 0xC8CDE6, 0xC7E716, 0xC80886, 0xC7EE0A, 0xC7F80A, 0xC8120E, 0xC81982, 0xC83B4A)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectCancel = 0x403C,

        [Replacable(0xC84076, 0xC86D7E, 0xC80A3A, 0xC7E8C2)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectError = 0x403D,

        #endregion

        #region Voice SFX

        [Tags(Short)]
        FierceDeityLinkAttack = 0x6000,

        [Tags(Short)]
        FierceDeityLinkJumpAttack = 0x6001,

        [Tags(Short)]
        FierceDeityTakeDamage = 0x6005,

        [Tags(Short)]
        FierceDeityFrozen = 0x6006,

        [Tags(Short)]
        FierceDeityFallLong = 0x6008,

        [Tags(Short)]
        ChildLinkAttack = 0x6020,

        [Tags(Short)]
        ChildLinkJumpAttack = 0x6021,

        [Tags(Short)]
        ChildLinkGrabLedge = 0x6023,

        [Tags(Short)]
        ChildLinkMountLedge = 0x6024,

        [Tags(Short)]
        ChildLinkTakeDamage = 0x6025,

        [Tags(Short)]
        ChildLinkKnockedOffHorse = 0x603E,

        [Replacable(0x00BABCF6)]
        [Tags(Short)]
        [ReplacableByTags(Short)]
        TatlEnemyAlert = 0x6043,

        [ReplacableInMessage(0x6845, 4650, 5218, 6144, 6145, 6146, 6147, 6148, 6149, 6150, 6164, 6166, 6176, 6280, 6281, 6286, 8400, 10479, 10480, 10606, 10609, 10611)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        TatlMessage = 0x6045,

        [Replacable(0xD6DA1E)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        GormanBrosLongYell = 0x6054,

        [Replacable(0xD6DC72, 0xD6FF12)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        GormanBrosLost = 0x6055,

        [Tags(Short, LowHpBeep)]
        GormanBrosWhip1 = 0x6056,

        [Tags(Short, LowHpBeep)]
        GormanBrosWhip2 = 0x6057,

        [Tags(Long)]
        GreatFairyAppears = 0x6058,

        [Tags(Short)]
        GreatFairyLaugh = 0x6059,

        [Replacable(0xD6DC82, 0xD6FF36)]
        [ReplacableByTags(Long)]
        [Tags(Long)]
        GormanBrosLaugh = 0x607C,

        [Tags(Short)]
        DekuFrozen = 0x6086,

        [Tags(Short)]
        DekuFallShort = 0x6087,

        [Tags(Long)]
        DekuFallLong = 0x6088,

        [Tags(Short)]
        DekuHorror = 0x6096,

        [Tags(Short, LowHpBeep)]
        GoronPunch = 0x60C0,

        [Tags(Short)]
        GoronBonk = 0x60C4,

        [Tags(Short)]
        GoronFallShort = 0x60C7,

        [Tags(Long)]
        GoronFallLong = 0x60C8,

        [Tags(Short, LowHpBeep)]
        JimHeh = 0x6100,

        [Tags(Short, LowHpBeep)]
        BomberGiggle = 0x6101,

        [Tags(Short, LowHpBeep)]
        JimHuh = 0x6102,

        [Tags(Short, LowHpBeep)]
        BomberEhh = 0x6103,

        [Tags(Short, LowHpBeep)]
        MamamuYanCelebratory = 0x6112,

        [Tags(Short)]
        AveilFrustrated = 0x6115,

        [Tags(Short)]
        AveilLaugh = 0x6116,

        [Tags(Short)]
        PirateScream1 = 0x6118,

        [Tags(Short)]
        PirateScream2 = 0x6119,

        [Tags(Short)]
        RosaSigh1 = 0x611C,

        [Tags(Short)]
        RosaGiggle1 = 0x611D,

        [Tags(Short)]
        RosaSigh2 = 0x611E,

        [Tags(Short)]
        RosaGiggle2 = 0x611F,

        [Tags(Short)]
        RosaAnnoyed = 0x6120,

        [Tags(Short)]
        RosaLaugh = 0x6121,

        [Tags(Short)]
        AnjuSurprised = 0x6123,

        [Tags(Short, LowHpBeep)]
        CremiaInquisitive = 0x6126,

        [Tags(Short, LowHpBeep)]
        CremiaAnnoyed = 0x6127,

        [Tags(Short, LowHpBeep)]
        CremiaGiggle = 0x6128,

        [Tags(Short, LowHpBeep)]
        CremiaSurprised = 0x6129,

        [Tags(Long)]
        ReceptionistMmHmm = 0x612A,

        [Tags(Long)]
        ReceptionistMmm = 0x612C,

        [Tags(Short)]
        RomaniScream = 0x612D,

        [Tags(Short)]
        RomaniGiggle = 0x612E,

        [Tags(Short)]
        PamelaScream = 0x6130,

        [Tags(Long)]
        PamelaFather = 0x6131,

        [Tags(Short)]
        PamelaSniffle = 0x6132,

        [Tags(Long)]
        StrayFairyHelpMe = 0x6138,

        [Tags(Long)]
        DampeAfraid = 0x6143,

        [Tags(Long)]
        DampeUrgh = 0x6144,

        [Tags(Short)]
        ShikashiOh = 0x6146,

        [Tags(Long)]
        ShikashiLaugh = 0x6147,

        [Tags(Long)]
        MarineScientistDisgruntled = 0x6148,

        [Tags(Short)]
        MarineScientistHuh = 0x6149,

        [Tags(Short, LowHpBeep)]
        SwampTouristProprietorHehHeh = 0x614B,

        [Tags(Short, LowHpBeep)]
        MutohScoff = 0x614F,

        [Tags(Short, LowHpBeep)]
        CuriosityShopGuyHii = 0x6151,

        [Tags(Long)]
        CuriosityShopGuyLaugh = 0x6152,

        [ReplacableInMessage(0x6959, 10540, 10541, 10543, 10547, 10573, 10574)]
        [Tags(Long)]
        [ReplacableByTags(Long)]
        GuruGuruLalala = 0x6159,

        [Tags(Short)]
        ZuboraShaddup = 0x615D,

        [Tags(Short, LowHpBeep)]
        PamelaFatherGasp = 0x6161,

        [Tags(Short, LowHpBeep)]
        PamelaFatherPamela = 0x6162,

        [Tags(Short, LowHpBeep)]
        GaboraUgogh = 0x6165,

        [Tags(Short, LowHpBeep)]
        GaboraHurrgh = 0x6166,

        [ReplacableInMessage(0x696F, 10100, 10101, 10107, 10111, 10114, 10123, 10141, 10149, 10155, 10427, 10429, 10431, 10589)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        PostmanGreeting = 0x616F,

        [Tags(Short)]
        DarlingChuckle = 0x6170,

        [Tags(Short)]
        DarlingMmm = 0x6171,

        [Tags(Long)]
        MikauBaybee = 0x6175,

        [Tags(Long)]
        MikauYay = 0x6176,

        [Tags(Long)]
        TingleFall = 0x6177,

        [Tags(Long)]
        TingleChuckle = 0x617A,

        [Tags(Long)]
        TingleHappy = 0x617B,

        [Tags(Long)]
        TingleKoolooLimpah = 0x617C,

        #endregion
    }
}
