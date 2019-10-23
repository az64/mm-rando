using static MMRando.Models.SoundEffects.SoundEffectTag;

namespace MMRando.Models.SoundEffects
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

        [Replacable(0x00E3C002, 0x01048266, 0x01048416, 0x0104852E)]
        [Tags(Short)]
        [ReplacableByTags(Short)]
        GuayCroak = 0x30B6,

        [Tags(Short)]
        FrogRibbit = 0x30D2,

        [Tags(Long)]
        RedeadMoan = 0x30E4,

        [Replacable(0x00FB719E, 0x00FB72D6)]
        [Effect(0x000)]
        [Tags(Looping)]
        [ReplacableByTags(Long)]
        GoronKidCry = 0x30EA,

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
        [Tags(Short, LowHpBeep)]
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


        [Replacable(0x00C86DE2, 0x00C7E8EA, 0x00C7EFD2, 0x00C80A62, 0x00C841EE, 0x00C84242, 0x00C84456, 0x00C8453E, 0x00C846FE, 0x00C84ABE, 0x00C86DE2)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectCursor = 0x4039,

        [Replacable(0x00C83E1A)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectTypeCharacter = 0x403A,

        [Replacable(0x00C83ABE)]
        [Tags(SystemSound)]
        [ReplacableByTags(Short)]
        FileSelectDecideLong = 0x403B,

        #endregion

        #region Voice SFX

        [Tags(Short)]
        FierceDeityLinkAttack = 0x6000,

        [Tags(Short)]
        FierceDeityLinkJumpAttack = 0x6001,

        [Tags(Short)]
        ChildLinkAttack = 0x6020,

        [Tags(Short)]
        ChildLinkJumpAttack = 0x6021,

        [Tags(Short)]
        ChildLinkGrabLedge = 0x6023,

        [Tags(Short)]
        ChildLinkMountLedge = 0x6024,

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

        [Tags(Short, LowHpBeep)]
        GormanBrosWhip1 = 0x6056,

        [Tags(Long)]
        GormanBrosLaugh = 0x607C,

        [Tags(Short, LowHpBeep)]
        GoronPunch = 0x60C0,

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

        [Tags(Long)]
        StrayFairyHelpMe = 0x6138,

        [Tags(Long)]
        DampeAfraid = 0x6143,

        [Tags(Long)]
        DampeUrgh = 0x6144,

        [Tags(Short, LowHpBeep)]
        SwampTouristProprietorHehHeh = 0x614B,

        [Tags(Short, LowHpBeep)]
        MutohScoff = 0x614F,

        [Tags(Short, LowHpBeep)]
        CuriosityShopGuyHii = 0x6151,

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

        [Tags(Long)]
        MikauBaybee = 0x6175,

        [Tags(Long)]
        MikauYay = 0x6176,

        [Tags(Long)]
        TingleChuckle = 0x617A,

        [ReplacableInMessage(0x6959, 10540, 10541, 10543, 10547, 10573, 10574)]
        [Tags(Long)]
        [ReplacableByTags(Long)]
        GuruGuruLalala = 0x6159,

        #endregion
    }
}
