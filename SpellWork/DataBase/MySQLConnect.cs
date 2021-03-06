﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SpellWork.Properties;

namespace SpellWork
{
    public static class MySqlConnect
    {
        private static MySqlConnection _conn;
        private static MySqlCommand _command;

        public static bool Connected { get; private set; }
        public static List<string> Dropped = new List<string>();
        public static List<SpellProcEventEntry> SpellProcEvent = new List<SpellProcEventEntry>();

        private static string ConnectionString
        {
            get
            {
                return String.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};character set=utf8;Connection Timeout=10",
                    Settings.Default.Host,
                    Settings.Default.Port,
                    Settings.Default.User,
                    Settings.Default.Pass,
                    Settings.Default.Db_mangos);
            }
        }

        private static String GetSpellName(uint id)
        {
            if (Dbc.Spell.ContainsKey(id))
            {
                return Dbc.Spell[id].SpellNameRank;
            }
            else
            {
                Dropped.Add(string.Format("DELETE FROM `spell_proc_event` WHERE `entry` IN ({0});\r\n", id));
                return string.Empty;
            }
        }

        public static void SelectProc(string query)
        {
            using (_conn = new MySqlConnection(ConnectionString))
            {
                _command = new MySqlCommand(query, _conn);
                _conn.Open();
                SpellProcEvent.Clear();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SpellProcEventEntry str;

                        str.ID = reader[0].ToUInt32();
                        str.SpellName = GetSpellName(str.ID);
                        str.SchoolMask = reader[1].ToUInt32();
                        str.SpellFamilyName = reader[2].ToUInt32();
                        str.SpellFamilyMask = new[,] 
                        { 
                            {
                                (uint)reader[3 ], 
                                (uint)reader[4 ], 
                                (uint)reader[5 ]
                            },
                            {
                                (uint)reader[6 ], 
                                (uint)reader[7 ], 
                                (uint)reader[8 ]
                            },
                            {
                                (uint)reader[9 ], 
                                (uint)reader[10], 
                                (uint)reader[11]
                            }
                        };
                        str.ProcFlags = reader[12].ToUInt32();
                        str.ProcEx = reader[13].ToUInt32();
                        str.PpmRate = reader[14].ToUInt32();
                        str.CustomChance = reader[15].ToUInt32();
                        str.Cooldown = reader[16].ToUInt32();

                        SpellProcEvent.Add(str);
                    }
                }
            }
        }

        public static void Insert(string query)
        {
            _conn = new MySqlConnection(ConnectionString);
            _command = new MySqlCommand(query, _conn);
            _conn.Open();
            _command.ExecuteNonQuery();
            _command.Connection.Close();
        }

        public static IList<Item> SelectItems()
        {
            var items = Dbc.ItemTemplate;
            // In order to reduce the search time, we make the first selection of all items that have spellid
            var query = string.Format(
                @"SELECT    t.entry, 
                            t.name, 
                            t.description, 
                            l.name_loc{0}, 
                            l.description_loc{0}, 
                            t.spellid_1, 
                            t.spellid_2, 
                            t.spellid_3, 
                            t.spellid_4, 
                            t.spellid_5 
                FROM 
                    `item_template` t 
                LEFT JOIN 
                    `locales_item` l 
                ON 
                    t.entry = l.entry 
                WHERE 
                    t.spellid_1 <> 0 || 
                    t.spellid_2 <> 0 || 
                    t.spellid_3 <> 0 || 
                    t.spellid_4 <> 0 || 
                    t.spellid_5 <> 0;",
                (int)Dbc.Locale == 0 ? 1 : (int)Dbc.Locale /* it's hack TODO: replace this code*/);

            using (_conn = new MySqlConnection(ConnectionString))
            {
                _command = new MySqlCommand(query, _conn);
                _conn.Open();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Entry = reader[0].ToUInt32(),
                            Name = reader[1].ToString(),
                            Description = reader[2].ToString(),
                            LocalesName = reader[3].ToString(),
                            LocalesDescription = reader[4].ToString(),
                            SpellID = new[] 
                            { 
                                reader[5].ToUInt32(), 
                                reader[6].ToUInt32(), 
                                reader[7].ToUInt32(), 
                                reader[8].ToUInt32(), 
                                reader[9].ToUInt32() 
                            }
                        });
                    }
                }
            }
            return items;
        }

        public static void TestConnect()
        {
            if (!Settings.Default.UseDbConnect)
            {
                Connected = false;
                return;
            }

            try
            {
                _conn = new MySqlConnection(ConnectionString);
                _conn.Open();
                _conn.Close();
                Connected = true;
            }
            catch
            {
                Connected = false;
            }
        }
    }
}
