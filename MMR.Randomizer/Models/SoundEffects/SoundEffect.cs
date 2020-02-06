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

        [Replacable(0x00DFC776)]
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

        [Replacable(0x00D01186, 0x00CFE0A6, 0x00CF969A, 0x00CFA602, 0x00CFA816, 0x00CFA482, 0x00CF91E2, 0x00CFC43A)]
        [Tags(Short, LowHpBeep)]
        [ReplacableByTags(Short)]
        EponaNeigh = 0x2044,

        #endregion

        #region Enemy SFX

        [Tags(Short)]
        DinolfosCry = 0x3029,

        [Tags(Short)]
        DinolfosAttack = 0x302A,

        [Tags(Short)]
        BombchuAim = 0x3055,

        [Tags(Short)]
        PoeAppear = 0x3073,

        [Tags(Short)]
        PoeDisappear = 0x3074,

        [Tags(Long)]
        MajoraGrowHead = 0x3088,

        [Tags(Long)]
        WallmasterAim = 0x3090,

        [Replacable(0xE0DBBE, 0x00E3C002, 0x01048266, 0x01048416, 0x0104852E)]
        [Tags(Short)]
        [ReplacableByTags(Short)]
        GuayCroak = 0x30B6,

        [Tags(Short)]
        FrogRibbit = 0x30D2,

        [Tags(Long)]
        RedeadMoan = 0x30E4,

        [Tags(Short)]
        RedeadAim = 0x30E5,

        [Replacable(0x00FB719E, 0x00FB72D6)]
        [Effect(0x000)]
        [Tags(Looping)]
        [ReplacableByTags(Long)]
        GoronKidCry = 0x30EA,

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

        [Replacable(0xC83C3E, 0xC83BEA, 0xC83FEA, 0xC8CD76, 0xC8CDE6, 0xC7E716, 0xC80886, 0xC7EE0A, 0xC7F80A, 0xC8120E, 0xC81982)]
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

        [Tags(Long)]
        GormanBrosLongYell = 0x6054,

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

        [Tags(Long)]
        GormanBrosLaugh = 0x607C,

        [Tags(Long)]
        DekuFrozen = 0x6086,

        [Tags(Long)]
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
