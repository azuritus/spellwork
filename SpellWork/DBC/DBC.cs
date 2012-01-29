using System.Collections.Generic;

namespace SpellWork
{
    public static class DBC
    {
        public const string VERSION = "SpellWork 3.3.5a (12340)";
        public const string DBC_PATH = @"dbc";

        public const int MAX_DBC_LOCALE = 16;
        public const int MAX_EFFECT_INDEX = 3;
        public const int SPELL_ENTRY_FOR_DETECT_LOCALE = 1;

        public static IDictionary<uint, SpellEntry> Spell;
        public static IDictionary<uint, SpellRadiusEntry> SpellRadius;
        public static IDictionary<uint, SpellCastTimesEntry> SpellCastTimes;
        public static IDictionary<uint, SpellDifficultyEntry> SpellDifficulty;
        public static IDictionary<uint, SpellRangeEntry> SpellRange;
        public static IDictionary<uint, SpellDurationEntry> SpellDuration;
        public static IDictionary<uint, SkillLineAbilityEntry> SkillLineAbility;
        public static IDictionary<uint, SkillLineEntry> SkillLine;
        public static IDictionary<uint, ScreenEffectEntry> ScreenEffect;
        public static IDictionary<uint, OverrideSpellDataEntry> OverrideSpellData;
        public static IDictionary<uint, AreaGroupEntry> AreaGroup;
        public static IDictionary<uint, AreaTableEntry> AreaTable;
        public static IDictionary<uint, SpellRuneCostEntry> SpellRuneCost;

        public static IDictionary<uint, string> AreaTableStrings = new Dictionary<uint, string>();
        public static IDictionary<uint, string> SpellStrings = new Dictionary<uint, string>();
        public static IDictionary<uint, string> SkillLineStrings = new Dictionary<uint, string>();
        public static IDictionary<uint, string> SpellRangeStrings = new Dictionary<uint, string>();
        public static IDictionary<uint, string> ScreenEffectStrings = new Dictionary<uint, string>();

        // DB 
        public static IList<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
