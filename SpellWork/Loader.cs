using System;

namespace SpellWork
{
    class Loader
    {
        public Loader()
        {
            Dbc.AreaGroup = DbcReader.ReadDbc<AreaGroupEntry>(null);
            Dbc.AreaTable = DbcReader.ReadDbc<AreaTableEntry>(Dbc.AreaTableStrings);
            Dbc.Spell = DbcReader.ReadDbc<SpellEntry>(Dbc.SpellStrings);
            Dbc.SkillLine = DbcReader.ReadDbc<SkillLineEntry>(Dbc.SkillLineStrings);
            Dbc.SpellRange = DbcReader.ReadDbc<SpellRangeEntry>(Dbc.SpellRangeStrings);
            Dbc.ScreenEffect = DbcReader.ReadDbc<ScreenEffectEntry>(Dbc.ScreenEffectStrings);

            Dbc.SpellDuration = DbcReader.ReadDbc<SpellDurationEntry>(null);
            Dbc.SkillLineAbility = DbcReader.ReadDbc<SkillLineAbilityEntry>(null);
            Dbc.SpellRadius = DbcReader.ReadDbc<SpellRadiusEntry>(null);
            Dbc.SpellCastTimes = DbcReader.ReadDbc<SpellCastTimesEntry>(null);
            Dbc.SpellDifficulty = DbcReader.ReadDbc<SpellDifficultyEntry>(null);

            Dbc.OverrideSpellData = DbcReader.ReadDbc<OverrideSpellDataEntry>(null);
            Dbc.SpellRuneCost = DbcReader.ReadDbc<SpellRuneCostEntry>(null);

            Dbc.Locale = DetectLocale();
        }

        private static LocalesDBC DetectLocale()
        {
            byte locale = 0;
            while (string.IsNullOrEmpty(Dbc.Spell[Dbc.SpellEntryForLocaleDetection].GetName(locale)))
            {
                ++locale;

                if (locale >= Dbc.MaxDbcLocale)
                    throw new Exception("Detected unknown locale index " + locale);
            }
            return (LocalesDBC)locale;
        }
    }
}
