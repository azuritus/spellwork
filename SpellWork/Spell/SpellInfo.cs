using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpellWork
{
    class SpellInfo
    {
        private readonly RichTextBox _rtb;
        private SpellEntry _spell;

        private const string Line = "=================================================";

        public SpellInfo(RichTextBox rtb, SpellEntry spell)
        {
            _rtb = rtb;
            _spell = spell;

            ProcInfo.SpellProc = spell;

            ViewSpellInfo();
        }

        private void ViewSpellInfo()
        {
            _rtb.Clear();
            _rtb.SetBold();
            _rtb.AppendFormatLine("ID - {0} {1}", _spell.ID, _spell.SpellNameRank);
            _rtb.SetDefaultStyle();

            _rtb.AppendFormatLine(Line);
            _rtb.AppendFormatLineIfNotNullOrEmpty("Description: {0}", _spell.Description);
            _rtb.AppendFormatLineIfNotNullOrEmpty("ToolTip: {0}", _spell.ToolTip);
            _rtb.AppendFormatLineIfNotZero("Modal Next Spell: {0}", _spell.ModalNextSpell);
            if (!string.IsNullOrEmpty(_spell.Description) && string.IsNullOrEmpty(_spell.ToolTip) && _spell.ModalNextSpell != 0)
                _rtb.AppendFormatLine(Line);

            _rtb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                _spell.Category, _spell.SpellIconID, _spell.ActiveIconID, _spell.SpellVisual[0], _spell.SpellVisual[1]);

            _rtb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyName)_spell.SpellFamilyName, _spell.SpellFamilyFlags[2], _spell.SpellFamilyFlags[1], _spell.SpellFamilyFlags[0]);

            _rtb.AppendLine();

            _rtb.AppendFormatLine("SpellSchoolMask = {0} ({1})", _spell.SchoolMask, _spell.School);
            _rtb.AppendFormatLine("DamageClass = {0} ({1})", _spell.DmgClass, (SpellDmgClass)_spell.DmgClass);
            _rtb.AppendFormatLine("PreventionType = {0} ({1})", _spell.PreventionType, (SpellPreventionType)_spell.PreventionType);

            if (_spell.Attributes != 0 || _spell.AttributesEx != 0 || _spell.AttributesEx2 != 0 || _spell.AttributesEx3 != 0
                || _spell.AttributesEx4 != 0 || _spell.AttributesEx5 != 0 || _spell.AttributesEx6 != 0 || _spell.AttributesEx7 != 0)
                _rtb.AppendLine(Line);

            if (_spell.Attributes != 0)
                _rtb.AppendFormatLine("Attributes: 0x{0:X8} ({1})", _spell.Attributes, (SpellAtribute)_spell.Attributes);
            if (_spell.AttributesEx != 0)
                _rtb.AppendFormatLine("AttributesEx1: 0x{0:X8} ({1})", _spell.AttributesEx, (SpellAtributeEx)_spell.AttributesEx);
            if (_spell.AttributesEx2 != 0)
                _rtb.AppendFormatLine("AttributesEx2: 0x{0:X8} ({1})", _spell.AttributesEx2, (SpellAtributeEx2)_spell.AttributesEx2);
            if (_spell.AttributesEx3 != 0)
                _rtb.AppendFormatLine("AttributesEx3: 0x{0:X8} ({1})", _spell.AttributesEx3, (SpellAtributeEx3)_spell.AttributesEx3);
            if (_spell.AttributesEx4 != 0)
                _rtb.AppendFormatLine("AttributesEx4: 0x{0:X8} ({1})", _spell.AttributesEx4, (SpellAtributeEx4)_spell.AttributesEx4);
            if (_spell.AttributesEx5 != 0)
                _rtb.AppendFormatLine("AttributesEx5: 0x{0:X8} ({1})", _spell.AttributesEx5, (SpellAtributeEx5)_spell.AttributesEx5);
            if (_spell.AttributesEx6 != 0)
                _rtb.AppendFormatLine("AttributesEx6: 0x{0:X8} ({1})", _spell.AttributesEx6, (SpellAtributeEx6)_spell.AttributesEx6);
            if (_spell.AttributesEx7 != 0)
                _rtb.AppendFormatLine("AttributesEx7: 0x{0:X8} ({1})", _spell.AttributesEx7, (SpellAtributeEx7)_spell.AttributesEx7);

            _rtb.AppendLine(Line);

            if (_spell.Targets != 0)
                _rtb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", _spell.Targets, (SpellCastTargetFlag)_spell.Targets);

            if (_spell.TargetCreatureType != 0)
                _rtb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})",
                    _spell.TargetCreatureType, (CreatureTypeMask)_spell.TargetCreatureType);

            if (_spell.Stances != 0)
                _rtb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)_spell.Stances);

            if (_spell.StancesNot != 0)
                _rtb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)_spell.StancesNot);

            AppendSkillLine();

            // reagents
            var printedHeader = false;
            for (var i = 0; i < _spell.Reagent.Length; ++i)
            {
                if (_spell.Reagent[i] == 0)
                    continue;

                if (!printedHeader)
                {
                    _rtb.AppendLine();
                    _rtb.Append("Reagents:");
                    printedHeader = true;
                }

                _rtb.AppendFormat("  {0}x{1}", _spell.Reagent[i], _spell.ReagentCount[i]);
            }

            if (printedHeader)
                _rtb.AppendLine();

            _rtb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}",
                _spell.SpellLevel, _spell.BaseLevel, _spell.MaxLevel, _spell.MaxTargetLevel);

            if (_spell.EquippedItemClass != -1)
            {
                _rtb.AppendFormatLine("EquippedItemClass = {0} ({1})", _spell.EquippedItemClass, (ItemClass)_spell.EquippedItemClass);

                if (_spell.EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)_spell.EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            _rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                _spell.EquippedItemSubClassMask, (ItemSubClassWeaponMask)_spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            _rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                _spell.EquippedItemSubClassMask, (ItemSubClassArmorMask)_spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            _rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                _spell.EquippedItemSubClassMask, (ItemSubClassMiscMask)_spell.EquippedItemSubClassMask);
                            break;
                    }
                }

                if (_spell.EquippedItemInventoryTypeMask != 0)
                    _rtb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})",
                        _spell.EquippedItemInventoryTypeMask, (InventoryTypeMask)_spell.EquippedItemInventoryTypeMask);
            }

            _rtb.AppendLine();
            _rtb.AppendFormatLine("Category = {0}", _spell.Category);
            _rtb.AppendFormatLine("DispelType = {0} ({1})", _spell.Dispel, (DispelType)_spell.Dispel);
            _rtb.AppendFormatLine("Mechanic = {0} ({1})", _spell.Mechanic, (Mechanic)_spell.Mechanic);

            _rtb.AppendLine(_spell.Range);

            _rtb.AppendFormatLineIfNotZero("Speed {0:F}", _spell.Speed);
            _rtb.AppendFormatLineIfNotZero("Stackable up to {0}", _spell.StackAmount);

            _rtb.AppendLine(_spell.CastTime);

            _rtb.AppendLine(_spell.SpellDifficulty);

            if (_spell.RecoveryTime != 0 || _spell.CategoryRecoveryTime != 0 || _spell.StartRecoveryCategory != 0)
            {
                _rtb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", _spell.RecoveryTime, _spell.CategoryRecoveryTime);
                _rtb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", _spell.StartRecoveryCategory, _spell.StartRecoveryTime);
            }

            _rtb.AppendLine(_spell.Duration);

            if (_spell.ManaCost != 0 || _spell.ManaCostPercentage != 0)
            {
                _rtb.AppendFormat("Power {0}, Cost {1}",
                    (Power)_spell.PowerType, _spell.ManaCost == 0 ? _spell.ManaCostPercentage.ToString() + " %" : _spell.ManaCost.ToString());
                _rtb.AppendFormatIfNotZero(" + lvl * {0}", _spell.ManaCostPerlevel);
                _rtb.AppendFormatIfNotZero(" + {0} Per Second", _spell.ManaPerSecond);
                _rtb.AppendFormatIfNotZero(" + lvl * {0}", _spell.ManaPerSecondPerLevel);
                _rtb.AppendLine();
            }

            if (_spell.RuneCostID != 0 && Dbc.SpellRuneCost.ContainsKey(_spell.RuneCostID))
            {
                var R = Dbc.SpellRuneCost[_spell.RuneCostID];

                var append = true;
                for (var i = 0; i < R.RuneCost.Length; ++i)
                {
                    if (R.RuneCost[i] != 0)
                    {
                        if (append)
                        {
                            _rtb.AppendLine(Line);
                            _rtb.Append("Rune cost: ");
                        }
                        _rtb.AppendFormat("{0}x{1} ", (RuneType)i, R.RuneCost[i]);
                        append = false;
                    }
                }

                if (!append)
                    _rtb.AppendLine();

                _rtb.AppendFormatLineIfNotZero("Rune power gain ={0}", R.runePowerGain);
                if (!append)
                    _rtb.AppendLine(Line);
            }

            _rtb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}",
                _spell.InterruptFlags, _spell.AuraInterruptFlags, _spell.ChannelInterruptFlags);

            if (_spell.CasterAuraState != 0)
                _rtb.AppendFormatLine("CasterAuraState = {0} ({1})", _spell.CasterAuraState, (AuraState)_spell.CasterAuraState);

            if (_spell.TargetAuraState != 0)
                _rtb.AppendFormatLine("TargetAuraState = {0} ({1})", _spell.TargetAuraState, (AuraState)_spell.TargetAuraState);

            if (_spell.CasterAuraStateNot != 0)
                _rtb.AppendFormatLine("CasterAuraStateNot = {0} ({1})", _spell.CasterAuraStateNot, (AuraState)_spell.CasterAuraStateNot);

            if (_spell.TargetAuraStateNot != 0)
                _rtb.AppendFormatLine("TargetAuraStateNot = {0} ({1})", _spell.TargetAuraStateNot, (AuraState)_spell.TargetAuraStateNot);

            AppendSpellAura();

            AppendAreaInfo();

            _rtb.AppendFormatLineIfNotZero("Requires Spell Focus {0}", _spell.RequiresSpellFocus);

            if (_spell.ProcFlags != 0)
            {
                _rtb.SetBold();
                _rtb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                _spell.ProcFlags, _spell.ProcChance, _spell.ProcCharges);
                _rtb.SetDefaultStyle();
                _rtb.AppendFormatLine(Line);
                _rtb.AppendText(_spell.ProcInfo);
            }
            else
            {
                _rtb.AppendFormatLine("Chance = {0}, charges - {1}", _spell.ProcChance, _spell.ProcCharges);
            }

            AppendSpellEffectInfo();
            AppendItemInfo();
        }

        private void AppendAreaInfo()
        {
            if (_spell.AreaGroupId <= 0)
                return;

            var areaGroupId = (uint)_spell.AreaGroupId;
            if (!Dbc.AreaGroup.ContainsKey(areaGroupId))
            {
                _rtb.AppendFormatLine("Cannot find area group id {0} in AreaGroup.dbc!", _spell.AreaGroupId);
                return;
            }

            _rtb.AppendLine();
            _rtb.SetBold();
            _rtb.AppendLine("Allowed areas:");
            while (Dbc.AreaGroup.ContainsKey(areaGroupId))
            {
                var groupEntry = Dbc.AreaGroup[areaGroupId];
                for (var i = 0; i < 6; ++i)
                {
                    var areaId = groupEntry.AreaId[i];
                    if (Dbc.AreaTable.ContainsKey(areaId))
                    {
                        var areaEntry = Dbc.AreaTable[areaId];
                        _rtb.AppendFormatLine("{0} - {1} (Map: {2})", areaId, areaEntry.Name, areaEntry.MapId);
                    }
                }


                if (groupEntry.NextGroup == 0)
                    break;

                // Try search in next group
                areaGroupId = groupEntry.NextGroup;
            }

            _rtb.AppendLine();
        }

        private void AppendSkillLine()
        {
            var query = (from skillLineAbility in Dbc.SkillLineAbility
                        join skillLine in Dbc.SkillLine
                        on skillLineAbility.Value.SkillId equals skillLine.Key
                        where skillLineAbility.Value.SpellId == _spell.ID
                        select new
                        {
                            skillLineAbility,
                            skillLine
                        }).ToList();

            if (!query.Any())
                return;

            var skill = query.First().skillLineAbility.Value;
            var line = query.First().skillLine.Value;

            _rtb.AppendFormatLine("Skill (Id {0}) \"{1}\"", skill.SkillId, line.Name);
            _rtb.AppendFormat("    ReqSkillValue {0}", skill.Req_skill_value);

            _rtb.AppendFormat(", Forward Spell = {0}, MinMaxValue ({1}, {2})", skill.Forward_spellid, skill.Min_value, skill.Max_value);
            _rtb.AppendFormat(", CharacterPoints ({0}, {1})", skill.CharacterPoints[0], skill.CharacterPoints[1]);
        }

        private void AppendSpellEffectInfo()
        {
            _rtb.AppendLine(Line);

            for (var effectIndex = 0; effectIndex < Dbc.MaxEffectIndex; effectIndex++)
            {
                _rtb.SetBold();
                if ((SpellEffect)_spell.Effect[effectIndex] == SpellEffect.NO_SPELL_EFFECT)
                {
                    _rtb.AppendFormatLine("Effect {0}:  NO EFFECT", effectIndex);
                    _rtb.AppendLine();
                    continue;
                }

                _rtb.AppendFormatLine("Effect {0}: Id {1} ({2})", effectIndex, _spell.Effect[effectIndex], (SpellEffect)_spell.Effect[effectIndex]);
                _rtb.SetDefaultStyle();
                _rtb.AppendFormat("BasePoints = {0}", _spell.EffectBasePoints[effectIndex] + 1);

                if (_spell.EffectRealPointsPerLevel[effectIndex] != 0)
                    _rtb.AppendFormat(" + Level * {0:F}", _spell.EffectRealPointsPerLevel[effectIndex]);

                // WTF ? 1 = spell.EffectBaseDice[i]
                if (1 < _spell.EffectDieSides[effectIndex])
                {
                    if (_spell.EffectRealPointsPerLevel[effectIndex] != 0)
                        _rtb.AppendFormat(" to {0} + lvl * {1:F}",
                            _spell.EffectBasePoints[effectIndex] + 1 + _spell.EffectDieSides[effectIndex], _spell.EffectRealPointsPerLevel[effectIndex]);
                    else
                        _rtb.AppendFormat(" to {0}", _spell.EffectBasePoints[effectIndex] + 1 + _spell.EffectDieSides[effectIndex]);
                }

                _rtb.AppendFormatIfNotZero(" + combo * {0:F}", _spell.EffectPointsPerComboPoint[effectIndex]);

                if (_spell.DmgMultiplier[effectIndex] != 1.0f)
                    _rtb.AppendFormat(" x {0:F}", _spell.DmgMultiplier[effectIndex]);

                _rtb.AppendFormatIfNotZero("  Multiple = {0:F}", _spell.EffectMultipleValue[effectIndex]);
                _rtb.AppendLine();

                _rtb.AppendFormatLine("Targets ({0}, {1}) ({2}, {3})",
                    _spell.EffectImplicitTargetA[effectIndex], _spell.EffectImplicitTargetB[effectIndex],
                    (Target)_spell.EffectImplicitTargetA[effectIndex], (Target)_spell.EffectImplicitTargetB[effectIndex]);

                AuraModTypeName(effectIndex);

                var classMask = new uint[3];

                switch (effectIndex)
                {
                    case 0: classMask = _spell.EffectSpellClassMaskA; break;
                    case 1: classMask = _spell.EffectSpellClassMaskB; break;
                    case 2: classMask = _spell.EffectSpellClassMaskC; break;
                }

                if (classMask[0] != 0 || classMask[1] != 0 || classMask[2] != 0)
                {
                    _rtb.AppendFormatLine("SpellClassMask = {0:X8} {1:X8} {2:X8}", classMask[2], classMask[1], classMask[0]);

                    var query = from spell in Dbc.Spell.Values
                                where spell.SpellFamilyName == _spell.SpellFamilyName && spell.SpellFamilyFlags.HasAnyFlagOnSameIndex(classMask)
                                join sk in Dbc.SkillLineAbility on spell.ID equals sk.Value.SpellId into temp
                                from skill in temp.DefaultIfEmpty()
                                select new
                                {
                                    SpellID = spell.ID,
                                    SpellName = spell.SpellNameRank,
                                    skill.Value.SkillId
                                };

                    foreach (var row in query)
                    {
                        if (row.SkillId > 0)
                        {
                            _rtb.SelectionColor = Color.Blue;
                            _rtb.AppendFormatLine("\t+ {0} - {1}", row.SpellID, row.SpellName);
                        }
                        else
                        {
                            _rtb.SelectionColor = Color.Red;
                            _rtb.AppendFormatLine("\t- {0} - {1}", row.SpellID, row.SpellName);
                        }
                        _rtb.SelectionColor = Color.Black;
                    }
                }

                _rtb.AppendFormatLineIfNotNullOrEmpty("{0}", _spell.GetRadius(effectIndex));

                // append trigger spell
                var trigger = _spell.EffectTriggerSpell[effectIndex];
                if (trigger != 0)
                {
                    if (Dbc.Spell.ContainsKey(trigger))
                    {
                        var triggerSpell = Dbc.Spell[trigger];
                        _rtb.SetStyle(Color.Blue, FontStyle.Bold);
                        _rtb.AppendFormatLine("   Trigger spell ({0}) {1}. Chance = {2}", trigger, triggerSpell.SpellNameRank, _spell.ProcChance);
                        _rtb.AppendFormatLineIfNotNullOrEmpty("   Description: {0}", triggerSpell.Description);
                        _rtb.AppendFormatLineIfNotNullOrEmpty("   ToolTip: {0}", triggerSpell.ToolTip);
                        _rtb.SetDefaultStyle();
                        if (triggerSpell.ProcFlags != 0)
                        {
                            _rtb.AppendFormatLine("Charges - {0}", triggerSpell.ProcCharges);
                            _rtb.AppendLine(Line);
                            _rtb.AppendLine(triggerSpell.ProcInfo);
                            _rtb.AppendLine(Line);
                        }
                    }
                    else
                    {
                        _rtb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", trigger, _spell.ProcChance);
                    }
                }

                _rtb.AppendFormatLineIfNotZero("EffectChainTarget = {0}", _spell.EffectChainTarget[effectIndex]);
                _rtb.AppendFormatLineIfNotZero("EffectItemType = {0}", _spell.EffectItemType[effectIndex]);

                if ((Mechanic)_spell.EffectMechanic[effectIndex] != Mechanic.MECHANIC_NONE)
                    _rtb.AppendFormatLine("Effect Mechanic = {0} ({1})", _spell.EffectMechanic[effectIndex], (Mechanic)_spell.EffectMechanic[effectIndex]);

                _rtb.AppendLine();
            }
        }

        private void AppendSpellAura()
        {
            if (_spell.CasterAuraSpell != 0)
            {
                if (Dbc.Spell.ContainsKey(_spell.CasterAuraSpell))
                    _rtb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", _spell.CasterAuraSpell, Dbc.Spell[_spell.CasterAuraSpell].SpellName);
                else
                    _rtb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", _spell.CasterAuraSpell);
            }

            if (_spell.TargetAuraSpell != 0)
            {
                if (Dbc.Spell.ContainsKey(_spell.TargetAuraSpell))
                    _rtb.AppendFormatLine("  Target Aura Spell ({0}) {1}", _spell.TargetAuraSpell, Dbc.Spell[_spell.TargetAuraSpell].SpellName);
                else
                    _rtb.AppendFormatLine("  Target Aura Spell ({0}) ?????", _spell.TargetAuraSpell);
            }

            if (_spell.ExcludeCasterAuraSpell != 0)
            {
                if (Dbc.Spell.ContainsKey(_spell.ExcludeCasterAuraSpell))
                    _rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", _spell.ExcludeCasterAuraSpell, Dbc.Spell[_spell.ExcludeCasterAuraSpell].SpellName);
                else
                    _rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", _spell.ExcludeCasterAuraSpell);
            }

            if (_spell.ExcludeTargetAuraSpell != 0)
            {
                if (Dbc.Spell.ContainsKey(_spell.ExcludeTargetAuraSpell))
                    _rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", _spell.ExcludeTargetAuraSpell, Dbc.Spell[_spell.ExcludeTargetAuraSpell].SpellName);
                else
                    _rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", _spell.ExcludeTargetAuraSpell);
            }
        }

        private void AuraModTypeName(int index)
        {
            var aura = (AuraType)_spell.EffectApplyAuraName[index];
            var misc = _spell.EffectMiscValue[index];

            if (_spell.EffectApplyAuraName[index] == 0)
            {
                var effect = (SpellEffect)_spell.Effect[index];

                switch (effect)
                {
                    case SpellEffect.SPELL_EFFECT_ACTIVATE_RUNE:
                        _rtb.AppendFormatLine("EffectMiscValueA ={0} ({1})", misc, (RuneType)misc);
                        break;
                    case SpellEffect.SPELL_EFFECT_DISPEL_MECHANIC:
                        _rtb.AppendFormatLine("EffectMiscValueA ={0} ({1})", misc, (Mechanic)misc);
                        break;
                    case SpellEffect.SPELL_EFFECT_ENERGIZE:
                    case SpellEffect.SPELL_EFFECT_ENERGIZE_PCT:
                    case SpellEffect.SPELL_EFFECT_POWER_DRAIN:
                        _rtb.AppendFormatLine("EffectMiscValueA ={0} ({1})", misc, (Power)misc);
                        break;
                    case SpellEffect.SPELL_EFFECT_DISPEL:
                        _rtb.AppendFormatLine("EffectMiscValueA ={0} ({1})", misc, (DispelType)misc);
                        break;
                    case SpellEffect.SPELL_EFFECT_OPEN_LOCK:
                        _rtb.AppendFormatLine("EffectMiscValueA ={0} ({1})", misc, (LockType)misc);
                        break;
                    default:
                        _rtb.AppendFormatLineIfNotZero("EffectMiscValueA = {0}", _spell.EffectMiscValue[index]);
                        break;
                }

                _rtb.AppendFormatLineIfNotZero("EffectMiscValueB = {0}", _spell.EffectMiscValueB[index]);
                _rtb.AppendFormatLineIfNotZero("EffectAmplitude = {0}", _spell.EffectAmplitude[index]);
                return;
            }

            _rtb.AppendFormat("Aura Id {0:D} ({0})", aura);
            _rtb.AppendFormat(", value = {0}", _spell.EffectBasePoints[index] + 1);
            _rtb.AppendFormat(", misc = {0} (", misc);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_STAT:
                case AuraType.SPELL_AURA_MOD_PERCENT_STAT:
                case AuraType.SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE:
                case AuraType.SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_MANA_REGEN_FROM_STAT:
                case AuraType.SPELL_AURA_MOD_ATTACK_POWER_OF_STAT_PERCENT:
                    _rtb.Append((UnitMod)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_RATING:
                case AuraType.SPELL_AURA_MOD_RATING_FROM_STAT:
                    _rtb.Append((CombatRating)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE:
                case AuraType.SPELL_AURA_MOD_DAMAGE_TAKEN:
                case AuraType.SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
                case AuraType.SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_SHARE_DAMAGE_PCT:
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_ATTACK_POWER:
                case AuraType.SPELL_AURA_MOD_AOE_DAMAGE_AVOIDANCE:
                case AuraType.SPELL_AURA_SPLIT_DAMAGE_PCT:
                case AuraType.SPELL_AURA_DAMAGE_IMMUNITY:

                case AuraType.SPELL_AURA_MOD_CRIT_DAMAGE_BONUS:
                case AuraType.SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_DAMAGE:
                case AuraType.SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_DAMAGE:
                case AuraType.SPELL_AURA_MOD_SCHOOL_CRIT_DMG_TAKEN:

                case AuraType.SPELL_AURA_MOD_HEALING:
                case AuraType.SPELL_AURA_MOD_HEALING_PCT:
                case AuraType.SPELL_AURA_MOD_HEALING_DONE:
                case AuraType.SPELL_AURA_MOD_HEALING_DONE_PERCENT:
                case AuraType.SPELL_AURA_MOD_DAMAGE_FROM_CASTER:
                case AuraType.SPELL_AURA_MOD_HEALING_RECEIVED:
                case AuraType.SPELL_AURA_MOD_HOT_PCT:
                case AuraType.SPELL_AURA_MOD_SPELL_HEALING_OF_ATTACK_POWER:

                case AuraType.SPELL_AURA_MOD_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_BASE_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_PCT:
                case AuraType.SPELL_AURA_MOD_TARGET_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT:

                case AuraType.SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_CHANCE:
                case AuraType.SPELL_AURA_MOD_ATTACKER_SPELL_HIT_CHANCE:
                case AuraType.SPELL_AURA_MOD_INCREASES_SPELL_PCT_TO_HIT:

                case AuraType.SPELL_AURA_SCHOOL_IMMUNITY:
                case AuraType.SPELL_AURA_SCHOOL_ABSORB:
                case AuraType.SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL:
                case AuraType.SPELL_AURA_MOD_POWER_COST_SCHOOL_PCT:
                case AuraType.SPELL_AURA_MOD_POWER_COST_SCHOOL:
                case AuraType.SPELL_AURA_REFLECT_SPELLS_SCHOOL:
                case AuraType.SPELL_AURA_MOD_TARGET_ABSORB_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IMMUNE_AURA_APPLY_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IGNORE_TARGET_RESIST:
                case AuraType.SPELL_AURA_MOD_TARGET_ABILITY_ABSORB_SCHOOL:

                case AuraType.SPELL_AURA_MOD_THREAT:
                case AuraType.SPELL_AURA_MOD_CRITICAL_THREAT:

                case AuraType.SPELL_AURA_REDUCE_PUSHBACK:
                case AuraType.SPELL_AURA_MOD_CREATURE_AOE_DAMAGE_AVOIDANCE:
                case AuraType.SPELL_AURA_HASTE_SPELLS:
                case AuraType.SPELL_AURA_MANA_SHIELD:
                case AuraType.SPELL_AURA_MOD_CRITICAL_HEALING_AMOUNT:
                    _rtb.Append((SpellSchoolMask)misc);
                    break;

                case AuraType.SPELL_AURA_ADD_FLAT_MODIFIER:
                case AuraType.SPELL_AURA_ADD_PCT_MODIFIER:
                    _rtb.Append((SpellModOp)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_POWER_REGEN:
                case AuraType.SPELL_AURA_MOD_POWER_REGEN_PERCENT:
                case AuraType.SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT:
                case AuraType.SPELL_AURA_MOD_INCREASE_ENERGY:
                case AuraType.SPELL_AURA_PERIODIC_ENERGIZE:
                    _rtb.Append((Power)misc);
                    break;

                case AuraType.SPELL_AURA_MECHANIC_IMMUNITY:
                case AuraType.SPELL_AURA_MOD_MECHANIC_RESISTANCE:
                case AuraType.SPELL_AURA_MECHANIC_DURATION_MOD:
                case AuraType.SPELL_AURA_MECHANIC_DURATION_MOD_NOT_STACK:
                case AuraType.SPELL_AURA_MOD_MECHANIC_DAMAGE_TAKEN_PERCENT:
                    _rtb.Append((Mechanic)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_MELEE_ATTACK_POWER_VERSUS:
                case AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER_VERSUS:
                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE_VERSUS:
                case AuraType.SPELL_AURA_MOD_CRIT_PERCENT_VERSUS:
                case AuraType.SPELL_AURA_MOD_FLAT_SPELL_DAMAGE_VERSUS:
                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE_CREATURE:
                    _rtb.Append((CreatureTypeMask)misc);
                    break;

                case AuraType.SPELL_AURA_TRACK_CREATURES:
                    _rtb.Append((CreatureTypeMask)(1 << (misc - 1)));
                    break;

                case AuraType.SPELL_AURA_DISPEL_IMMUNITY:
                case AuraType.SPELL_AURA_MOD_DEBUFF_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_AURA_DURATION_BY_DISPEL:
                case AuraType.SPELL_AURA_MOD_AURA_DURATION_BY_DISPEL_NOT_STACK:
                    _rtb.Append((DispelType)misc);
                    break;

                case AuraType.SPELL_AURA_TRACK_RESOURCES:
                    _rtb.Append((LockType)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_SHAPESHIFT:
                    _rtb.Append((ShapeshiftFormMask)(1 << (misc - 1)));
                    break;

                case AuraType.SPELL_AURA_EFFECT_IMMUNITY:
                    _rtb.Append((SpellEffect)misc);
                    break;

                case AuraType.SPELL_AURA_CONVERT_RUNE:
                    _rtb.Append((RuneType)misc);
                    break;

                // TODO: more case
                default:
                    _rtb.Append(misc);
                    break;
            }

            var miscB = _spell.EffectMiscValueB[index];
            _rtb.AppendFormat("), miscB = {0}", miscB);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RATING_FROM_STAT:
                    _rtb.AppendFormat("({0})", (UnitMod)miscB);
                    break;
                case AuraType.SPELL_AURA_CONVERT_RUNE:
                    _rtb.AppendFormat("({0})", (RuneType)miscB);
                    break;
            }

            _rtb.AppendFormatLine(", periodic = {0}", _spell.EffectAmplitude[index]);

            switch (aura)
            {
                case AuraType.SPELL_AURA_OVERRIDE_SPELLS:
                    if (!Dbc.OverrideSpellData.ContainsKey((uint)misc))
                    {
                        _rtb.SetStyle(Color.Red, FontStyle.Bold);
                        _rtb.AppendFormatLine("Cannot find key {0} in OverrideSpellData.dbc", (uint)misc);
                    }
                    else
                    {
                        _rtb.AppendLine();
                        _rtb.SetStyle(Color.DarkRed, FontStyle.Bold);
                        _rtb.AppendLine("Overriding Spells:");
                        var Override = Dbc.OverrideSpellData[(uint)misc];
                        for (var i = 0; i < 10; ++i)
                        {
                            if (Override.Spells[i] == 0)
                                continue;

                            _rtb.SetStyle(Color.DarkBlue, FontStyle.Regular);
                            _rtb.AppendFormatLine("\t - #{0} ({1}) {2}", i + 1, Override.Spells[i],
                                Dbc.Spell.ContainsKey(Override.Spells[i]) ? Dbc.Spell[Override.Spells[i]].SpellName : "?????");
                        }
                        _rtb.AppendLine();
                    }
                    break;
                case AuraType.SPELL_AURA_SCREEN_EFFECT:
                    _rtb.SetStyle(Color.DarkBlue, FontStyle.Bold);
                    _rtb.AppendFormatLine("ScreenEffect: {0}",
                        Dbc.ScreenEffect.ContainsKey((uint)misc) ? Dbc.ScreenEffect[(uint)misc].Name : "?????");
                    break;
            }
        }

        private void AppendItemInfo()
        {
            if (!MySqlConnect.Connected)
                return;

            var items = (from item in Dbc.ItemTemplate
                         where item.SpellID.Contains(_spell.ID)
                         select item).ToList();

            if (!items.Any())
                return;

            _rtb.AppendLine(Line);
            _rtb.SetStyle(Color.Blue, FontStyle.Bold);
            _rtb.AppendLine("Items used this spell:");
            _rtb.SetDefaultStyle();

            foreach (var item in items)
            {
                var name = string.IsNullOrEmpty(item.LocalesName) ? item.Name : item.LocalesName;
                var desc = string.IsNullOrEmpty(item.LocalesDescription) ? item.Description : item.LocalesDescription;

                desc = string.IsNullOrEmpty(desc) ? string.Empty : string.Format("({0})", desc);

                _rtb.AppendFormatLine(@"   {0} - {1} {2} ", item.Entry, name, desc);
            }
        }
    }
}
