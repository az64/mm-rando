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
        // Environment

        [Replacable(0x00EABA46, 0x00EABC3A, 0x00EACACA), Tags(Long)]
        CuccoMorning = 0x2013,

        [Replacable(0x00EABC4A, 0x00EACABE), Tags(Long)]
        WolfHowlEvening = 0x20AE,

        [Replacable(0x00DFC776), Tags(Short, LowHpBeep), ReplacableByTags(Short)]
        DogBark = 0x20D8,

        [Tags(Long)]
        CowMoo = 0x20DF,

        [Replacable(0x00DFC7B6), Tags(Short, LowHpBeep), ReplacableByTags(Short)]
        DogBarkAngry = 0x2110,

        [Replacable(0x00D01186, 0x00CFE0A4, 0x00CF969A, 0x00CFA602, 0x00CFA816, 0x00CFA482, 0x00CF91E2, 0x00CFC43A), Tags(Short, LowHpBeep), ReplacableByTags(Short)]
        EponaNeigh = 0x2044,

        // System

        [Replacable(0x00B97E2A), Tags(Short, LowHpBeep), ReplacableByTags(LowHpBeep)]
        LowHealthBeep = 0x401B,

        // Voice

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

        [Replacable(0x00BABCF6), Tags(Short)]
        TatlEnemyAlert = 0x6043,

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
        ReceptionistMmHmm = 0x612A,

        [Tags(Short, LowHpBeep)]
        ReceptionistMmm = 0x612C,

        [Tags(Short, LowHpBeep)]
        MutohScoff = 0x614F,

        [ReplacableInMessage(0x696F, 10100, 10101, 10107, 10111, 10114, 10123, 10141, 10149, 10155, 10427, 10429, 10431, 10589), Tags(Short, LowHpBeep)]
        PostmanGreeting = 0x616F,

        [Tags(Short, LowHpBeep)]
        MikauBaybee = 0x6175,

        [Tags(Short, LowHpBeep)]
        MikauYay = 0x6176,

        [Tags(Long)]
        TingleChuckle = 0x617A,

        [ReplacableInMessage(0x6959, 10540, 10541, 10543, 10547, 10573, 10574), Tags(Long)]
        GuruGuruLalala = 0x6159,
    }
}
