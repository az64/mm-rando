using static MMRando.Models.SoundEffects.SoundAttributes;
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

        [Replacable(0x24040800, 0x00EABA44, 0x00B8D038, 0x00EABC38, 0x00EACAC8), Tags(Long)]
        CuccoMorning = 0x2013,
        [Replacable(0x24050800, 0x00DFC774), Tags(Short, LowHpBeep), ReplacableByTags(Short)]
        DogBark = 0x20D8,
        [Tags(Long)]
        CowMoo = 0x20DF,
        [Replacable(0x24050800, 0x00DFC7B4), Tags(Short, LowHpBeep), ReplacableByTags(Short)]
        DogBarkAngry = 0x2110,

        // System

        [Replacable(0x24040600, 0x00B97E28), Tags(Short), ReplacableByTags(LowHpBeep)]
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
        [Tags(Short, LowHpBeep)]
        PostmanGreeting = 0x616F,
        [Tags(Short, LowHpBeep)]
        MikauBaybee = 0x6175,
        [Tags(Short, LowHpBeep)]
        MikauYay = 0x6176,
        [Tags(Long)]
        TingleChuckle = 0x617A,
    }
}
