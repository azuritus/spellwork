using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace SpellWork
{
    public struct DbcHeader
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;

        public bool IsDbc
        {
            get { return Signature == 0x43424457; }
        }

        public long DataSize
        {
            get { return RecordsCount * RecordSize; }
        }

        public long StartStringPosition
        {
            get { return DataSize + Marshal.SizeOf(typeof(DbcHeader)); }
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
    {
        public uint ID;                                           // 0        m_ID
        public uint Category;                                     // 1        m_category
        public DispelType Dispel;                                 // 2        m_dispelType
        public Mechanic Mechanic;                                 // 3        m_mechanic
        public SpellAtribute0 Attributes;                         // 4        m_attribute
        public SpellAtribute1 AttributesEx;                       // 5        m_attributesEx
        public SpellAtribute2 AttributesEx2;                      // 6        m_attributesExB
        public SpellAtribute3 AttributesEx3;                      // 7        m_attributesExC
        public SpellAtribute4 AttributesEx4;                      // 8        m_attributesExD
        public SpellAtribute5 AttributesEx5;                      // 9        m_attributesExE
        public SpellAtribute6 AttributesEx6;                      // 10       m_attributesExF
        public SpellAtribute7 AttributesEx7;                      // 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
        public ShapeshiftFormMask Stances;                        // 12-13    m_shapeshiftMask
        public ShapeshiftFormMask StancesNot;                     // 14-15    m_shapeshiftExclude
        public SpellCastTargetFlag Targets;                       // 16       m_targets
        public CreatureTypeMask TargetCreatureType;               // 17       m_targetCreatureType
        public uint RequiresSpellFocus;                           // 18       m_requiresSpellFocus
        public uint FacingCasterFlags;                            // 19       m_facingCasterFlags
        public AuraState CasterAuraState;                         // 20       m_casterAuraState
        public AuraState TargetAuraState;                         // 21       m_targetAuraState
        public AuraState CasterAuraStateNot;                      // 22       m_excludeCasterAuraState
        public AuraState TargetAuraStateNot;                      // 23       m_excludeTargetAuraState
        public uint CasterAuraSpell;                              // 24       m_casterAuraSpell
        public uint TargetAuraSpell;                              // 25       m_targetAuraSpell
        public uint ExcludeCasterAuraSpell;                       // 26       m_excludeCasterAuraSpell
        public uint ExcludeTargetAuraSpell;                       // 27       m_excludeTargetAuraSpell
        public uint CastingTimeIndex;                             // 28       m_castingTimeIndex
        public uint RecoveryTime;                                 // 29       m_recoveryTime
        public uint CategoryRecoveryTime;                         // 30       m_categoryRecoveryTime
        public uint InterruptFlags;                               // 31       m_interruptFlags
        public uint AuraInterruptFlags;                           // 32       m_auraInterruptFlags
        public uint ChannelInterruptFlags;                        // 33       m_channelInterruptFlags
        public uint ProcFlags;                                    // 34       m_procTypeMask
        public uint ProcChance;                                   // 35       m_procChance
        public uint ProcCharges;                                  // 36       m_procCharges
        public uint MaxLevel;                                     // 37       m_maxLevel
        public uint BaseLevel;                                    // 38       m_baseLevel
        public uint SpellLevel;                                   // 39       m_spellLevel
        public uint DurationIndex;                                // 40       m_durationIndex
        public Power PowerType;                                   // 41       m_powerType
        public uint ManaCost;                                     // 42       m_manaCost
        public uint ManaCostPerlevel;                             // 43       m_manaCostPerLevel
        public uint ManaPerSecond;                                // 44       m_manaPerSecond
        public uint ManaPerSecondPerLevel;                        // 45       m_manaPerSecondPerLevel
        public uint RangeIndex;                                   // 46       m_rangeIndex
        public float Speed;                                       // 47       m_speed
        public uint ModalNextSpell;                               // 48       m_modalNextSpell not used
        public uint StackAmount;                                  // 49       m_cumulativeAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Totem;                                      // 50-51    m_totem
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] Reagent;                                     // 52-59    m_reagent
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] ReagentCount;                               // 60-67    m_reagentCount
        public ItemClass EquippedItemClass;                       // 68       m_equippedItemClass (value)
        public int EquippedItemSubClassMask;                      // 69       m_equippedItemSubclass (mask)
        public InventoryTypeMask EquippedItemInventoryTypeMask;   // 70       m_equippedItemInvTypes (mask)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public SpellEffect[] Effect;                     		  // 71-73    m_effect
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public int[] EffectDieSides;                              // 74-76    m_effectDieSides
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public float[] EffectRealPointsPerLevel;                  // 77-79    m_effectRealPointsPerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public int[] EffectBasePoints;                            // 80-82    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public Mechanic[] EffectMechanic;                         // 83-85    m_effectMechanic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public Target[] EffectImplicitTargetA;                    // 86-88    m_implicitTargetA
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public Target[] EffectImplicitTargetB;                    // 89-91    m_implicitTargetB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectRadiusIndex;                          // 92-94    m_effectRadiusIndex - spellradius.dbc
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public AuraType[] EffectApplyAuraName;                    // 95-97    m_effectAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectAmplitude;                            // 98-100   m_effectAuraPeriod
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public float[] EffectMultipleValue;                       // 101-103  m_effectAmplitude
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectChainTarget;                          // 104-106  m_effectChainTargets
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectItemType;                             // 107-109  m_effectItemType
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public int[] EffectMiscValue;                             // 110-112  m_effectMiscValue
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public int[] EffectMiscValueB;                            // 113-115  m_effectMiscValueB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectTriggerSpell;                         // 116-118  m_effectTriggerSpell
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public float[] EffectPointsPerComboPoint;                 // 119-121  m_effectPointsPerCombo
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectSpellClassMaskA;                      // 122-124  m_effectSpellClassMaskA, effect 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectSpellClassMaskB;                      // 125-127  m_effectSpellClassMaskB, effect 1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] EffectSpellClassMaskC;                      // 128-130  m_effectSpellClassMaskC, effect 2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellVisual;                                // 131-132  m_spellVisualID
        public uint SpellIconID;                                  // 133      m_spellIconID
        public uint ActiveIconID;                                 // 134      m_activeIconID
        public uint SpellPriority;                                // 135      m_spellPriority not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        private uint[] _SpellName;                                // 136-151  m_name_lang
        public uint SpellNameFlag;                                // 152      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        private uint[] _Rank;                                     // 153-168  m_nameSubtext_lang
        public uint RankFlags;                                    // 169      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        private uint[] _Description;                              // 170-185  m_description_lang not used
        public uint DescriptionFlags;                             // 186      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        private uint[] _ToolTip;                                  // 187-202  m_auraDescription_lang not used
        public uint ToolTipFlags;                                 // 203      not used
        public uint ManaCostPercentage;                           // 204      m_manaCostPct
        public uint StartRecoveryCategory;                        // 205      m_startRecoveryCategory
        public uint StartRecoveryTime;                            // 206      m_startRecoveryTime
        public uint MaxTargetLevel;                               // 207      m_maxTargetLevel
        public SpellFamilyName SpellFamilyName;                   // 208      m_spellClassSet
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] SpellFamilyFlags;                           // 209-211  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint MaxAffectedTargets;                           // 212      m_maxTargets
        public SpellDmgClass DmgClass;                            // 213      m_defenseType
        public SpellPreventionType PreventionType;                // 214      m_preventionType
        public uint StanceBarOrder;                               // 215      m_stanceBarOrder not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public float[] DmgMultiplier;              				  // 216-218  m_effectChainAmplitude
        public uint MinFactionId;                                 // 219      m_minFactionID not used
        public uint MinReputation;                                // 220      m_minReputation not used
        public uint RequiredAuraVision;                           // 221      m_requiredAuraVision not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TotemCategory;                              // 222-223  m_requiredTotemCategoryID
        public int AreaGroupId;                                   // 224      m_requiredAreaGroupId
        public SpellSchoolMask SchoolMask;                        // 225      m_schoolMask
        public uint RuneCostID;                                   // 226      m_runeCostID
        public uint SpellMissileID;                               // 227      m_spellMissileID not used
        public uint PowerDisplayId;                               // 228      PowerDisplay.dbc, new in 3.1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public float[] EffectCoeffs;                              // 229-231  3.2.0
        public uint SpellDescriptionVariableID;                   // 232      3.2.0
        public uint SpellDifficultyId;                            // 233      3.3.0                           // 239      3.3.0

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get { return Dbc.SpellStrings[_SpellName[(uint)Dbc.Locale]]; }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get { return _Rank[(uint)Dbc.Locale] != 0 ? Dbc.SpellStrings[_Rank[(uint)Dbc.Locale]] : ""; }
        }

        public string SpellNameRank
        {
            get { return string.IsNullOrEmpty(Rank) ? SpellName : String.Format("{0} ({1})", SpellName, Rank); }
        }

        /// <summary>
        /// Return current Spell Description
        /// </summary>
        public string Description
        {
            get { return Dbc.SpellStrings[_Description[(uint)Dbc.Locale]]; }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return Dbc.SpellStrings[_ToolTip[(uint)Dbc.Locale]]; }
        }

        public string GetName(byte loc)
        {
            return Dbc.SpellStrings[_SpellName[loc]];
        }

        public string ProcInfo
        {
            get
            {
                var i = 0;
                var sb = new StringBuilder();
                var proc = ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        sb.AppendFormatLine("  {0}", SpellEnums.ProcFlagDesc[i]);
                    i++;
                    proc >>= 1;
                }
                return sb.ToString();
            }
        }

        public string Duration
        {
            get { return Dbc.SpellDuration.ContainsKey(DurationIndex) ? Dbc.SpellDuration[DurationIndex].ToString() : String.Empty; }
        }

        public string Range
        {
            get
            {
                if (RangeIndex == 0 || !Dbc.SpellRange.ContainsKey(RangeIndex))
                    return String.Empty;

                var range = Dbc.SpellRange[RangeIndex];
                var sb = new StringBuilder();
                sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", range.ID, range.Description1);
                sb.AppendFormatLine("    MinRange = {0}, MinRangeFriendly = {1}", range.MinRange, range.MinRangeFriendly);
                sb.AppendFormatLine("    MaxRange = {0}, MaxRangeFriendly = {1}", range.MaxRange, range.MaxRangeFriendly);

                return sb.ToString();
            }
        }

        [Pure]
        public string GetRadius(int effectIndex)
        {
            Contract.Requires(effectIndex >= 0 && effectIndex < Dbc.MaxEffectIndex);
            Contract.Ensures(Contract.Result<string>() != null);

            var radiusIndex = EffectRadiusIndex[effectIndex];
            if (radiusIndex != 0)
                return Dbc.SpellRadius.ContainsKey(radiusIndex) ?
                    string.Format("Radius (Id {0}) {1:F}", radiusIndex, Dbc.SpellRadius[radiusIndex].Radius) :
                    string.Format("Radius (Id {0}) Not found", radiusIndex);

            return string.Empty;
        }

        public string CastTime
        {
            get
            {
                if (CastingTimeIndex == 0)
                    return string.Empty;

                if (!Dbc.SpellCastTimes.ContainsKey(CastingTimeIndex))
                    return string.Format("CastingTime (Id {0}) = ????", CastingTimeIndex);
                else
                    return string.Format("CastingTime (Id {0}) = {1:F}",
                        CastingTimeIndex, Dbc.SpellCastTimes[CastingTimeIndex].CastTime / 1000.0f);
            }
        }

        public string SpellDifficulty
        {
            get
            {
                if (SpellDifficultyId == 0)
                    return string.Empty;

                var builder = new StringBuilder("Spell Difficulty Id: " + SpellDifficultyId);

                SpellDifficultyEntry entry;
                if (Dbc.SpellDifficulty.TryGetValue(SpellDifficultyId, out entry))
                {
                    builder.AppendLine();

                    for (var i = 0; i < entry.Spells.Length; ++i)
                    {
                        var spellId = entry.Spells[i];

                        builder.AppendFormat("    {0}) {1} - ", i, spellId);

                        SpellEntry spell;
                        builder.AppendLine(Dbc.Spell.TryGetValue((uint)spellId, out spell)
                                               ? spell.SpellNameRank
                                               : "(Not Found in Spell.dbc)");
                    }
                }
                else
                    builder.AppendLine(" (Not Found in SpellDifficulty.dbc)");

                return builder.ToString();
            }
        }
    };

    public struct SkillLineEntry
    {
        public uint ID;                                           // 0        m_ID
        public int CategoryId;                                    // 1        m_categoryID
        public uint SkillCostID;                                  // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] _Name;                                      // 3-18     m_displayName_lang
        public uint NameFlags;                                    // 19
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] _Description;                               // 20-35    m_description_lang
        public uint DescriptionFlags;                             // 36
        public uint SpellIcon;                                    // 37       m_spellIconID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] _AlternateVerb;                             // 38-53    m_alternateVerb_lang
        public uint AlternateVerbFlags;                           // 54
        public uint CanLink;                                      // 55       m_canLink (prof. with recipes

        public string Name
        {
            get { return Dbc.SkillLineStrings[_Name[(uint)Dbc.Locale]]; }
        }

        public string Description
        {
            get { return Dbc.SkillLineStrings[_Description[(uint)Dbc.Locale]]; }
        }

        public string AlternateVerb
        {
            get { return Dbc.SkillLineStrings[_AlternateVerb[(uint)Dbc.Locale]]; }
        }
    };

    public struct SkillLineAbilityEntry
    {
        public uint ID;                                             // 0        m_ID
        public uint SkillId;                                        // 1        m_skillLine
        public uint SpellId;                                        // 2        m_spell
        public uint Racemask;                                       // 3        m_raceMask
        public uint Classmask;                                      // 4        m_classMask
        public uint RacemaskNot;                                    // 5        m_excludeRace
        public uint ClassmaskNot;                                   // 6        m_excludeClass
        public uint Req_skill_value;                                // 7        m_minSkillLineRank
        public uint Forward_spellid;                                // 8        m_supercededBySpell
        public uint LearnOnGetSkill;                                // 9        m_acquireMethod
        public uint Max_value;                                      // 10       m_trivialSkillLineRankHigh
        public uint Min_value;                                      // 11       m_trivialSkillLineRankLow
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] CharacterPoints;                              // 12-13    m_characterPoints[2]
    };

    public struct SpellRadiusEntry
    {
        public uint ID;
        public float Radius;
        public int Zero;
        public float Radius2;
    };

    public struct SpellRangeEntry
    {
        public uint ID;
        public float MinRange;
        public float MinRangeFriendly;
        public float MaxRange;
        public float MaxRangeFriendly;
        public uint Field5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] _Desc1;
        public uint Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] _Desc2;
        public uint Desc2Flags;

        public string Description1
        {
            get { return Dbc.SpellRangeStrings[_Desc1[(uint)Dbc.Locale]]; }
        }

        public string Description2
        {
            get { return Dbc.SpellRangeStrings[_Desc2[(uint)Dbc.Locale]]; }
        }
    };

    public struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public int[] Duration;

        [Pure]
        public override string ToString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", ID, Duration[0], Duration[1], Duration[2]);
        }
    };

    public struct SpellCastTimesEntry
    {
        public uint ID;
        public int CastTime;
        public float CastTimePerLevel;
        public int MinCastTime;
    };

    public struct SpellDifficultyEntry
    {
        public uint Id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] Spells;
    };

    public struct ScreenEffectEntry
    {
        public uint Id;
        public uint _Name;
        public uint Unk0;
        public float Unk1;
        public uint Unk2;
        public uint Unk3;           // % of smth?
        public uint Unk4;           // all 0
        public int Unk5;
        public uint Unk6;
        public uint Unk7;

        public string Name
        {
            get { return Dbc.ScreenEffectStrings[_Name]; }
        }
    };

    public struct OverrideSpellDataEntry
    {
        public uint Id;
        // Value 10 also used in SpellInfo.AuraModTypeName
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Spells;
        public uint unk;
    };

    //=============== DateBase =================\\

    public struct SpellProcEventEntry
    {
        public uint ID;
        public string SpellName;
        public uint SchoolMask;
        public uint SpellFamilyName;
        public uint[,] SpellFamilyMask;
        public uint ProcFlags;
        public uint ProcEx;
        public float PpmRate;
        public float CustomChance;
        public uint Cooldown;

        [Pure]
        public string[] ToArray()
        {
            Contract.Ensures(Contract.Result<string[]>() != null);

            return new[]
            {
                ID.ToString(CultureInfo.InvariantCulture), 
                SpellName, 
                SchoolMask.ToString(CultureInfo.InvariantCulture), 
                SpellFamilyName.ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[0,0].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[0,1].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[0,2].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[1,0].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[1,1].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[1,2].ToString(CultureInfo.InvariantCulture),
                SpellFamilyMask[2,0].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[2,1].ToString(CultureInfo.InvariantCulture), 
                SpellFamilyMask[2,2].ToString(CultureInfo.InvariantCulture),
                ProcFlags.ToString(CultureInfo.InvariantCulture), 
                ProcEx.ToString(CultureInfo.InvariantCulture), 
                PpmRate.ToString(CultureInfo.InvariantCulture), 
                CustomChance.ToString(CultureInfo.InvariantCulture), 
                Cooldown.ToString(CultureInfo.InvariantCulture)
            };
        }
    };

    public struct SpellChain
    {
        public int ID;
        public int PrevSpell;
        public int FirstSpell;
        public int Rank;
        public int ReqSpell;
    };

    public struct Item
    {
        public uint Entry;
        public string Name;
        public string Description;
        public string LocalesName;
        public string LocalesDescription;
        public uint[] SpellID;
    };

    public struct AreaGroupEntry
    {
        public uint AreaGroupId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public uint[] AreaId;
        public uint NextGroup;
    };

    public struct AreaTableEntry
    {
        public uint Id;
        public uint MapId;
        public uint ZoneId;
        public uint ExploreFlag;
        public uint Flags;
        public uint SoundPreferences;
        public uint SoundPreferencesUnderwater;
        public uint SoundAmbience;
        public uint ZoneMusic;
        public uint ZoneIntroMusicTable;
        public int Level;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxDbcLocale)]
        public uint[] NamePtr;
        public uint StringFlags;
        public uint FactionFlags;
        public uint LiquidType1;
        public uint LiquidType2;
        public uint LiquidType3;
        public uint LiquidType4;
        public float MinElevation;
        public float AmbientMultiplier;
        public uint Light;

        public string Name
        {
            get { return Dbc.AreaTableStrings[NamePtr[(uint)Dbc.Locale]]; }
        }
    };

    public struct SpellRuneCostEntry
    {
        public uint ID;                                           // 0        m_ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Dbc.MaxEffectIndex)]
        public uint[] RuneCost;                                   // 1-3      0=blood, 1=unholy, 2=frost ,3=death
        public uint runePowerGain;                                // 4        m_runicPower
    };
}
