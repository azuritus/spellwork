﻿using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    public class ProcInfo
    {
        public static SpellEntry SpellProc { get; set; }
        public static bool Update = true;

        public ProcInfo(TreeView familyTree, SpellFamilyName spellfamily)
        {
            Contract.Requires(familyTree != null);

            familyTree.Nodes.Clear();

            var spells = from spell in Dbc.Spell
                         where spell.Value.SpellFamilyName == spellfamily
                         join skillLineAbility in Dbc.SkillLineAbility on spell.Key equals skillLineAbility.Value.SpellId into temp1
                         from skill in temp1.DefaultIfEmpty()
                         join skl in Dbc.SkillLine on skill.Value.SkillId equals skl.Key into temp2
                         from skillLine in temp2.DefaultIfEmpty()
                         select new
                         {
                             spell,
                             skill.Value.SkillId,
                             skillLine.Value
                         };

            for (var flag = 0; flag < 96; flag++)
            {
                var mask = new uint[3];

                if (flag < 32)
                    mask[0] = 1U << flag;
                else if (flag < 64)
                    mask[1] = 1U << (flag - 32);
                else
                    mask[2] = 1U << (flag - 64);

                var node = new TreeNode
                               {
                                   Text = String.Format("0x{0:X8} {1:X8} {2:X8}", mask[2], mask[1], mask[0]),
                                   ImageKey = "family.ico"
                               };
                familyTree.Nodes.Add(node);
            }

            foreach (var spellEntry in spells)
            {
                var spell = spellEntry.spell.Value;
                var isSkill = spellEntry.SkillId != 0;

                var name = new StringBuilder();
                var toolTip = new StringBuilder();

                name.AppendFormat("{0} - {1} ", spell.ID, spell.SpellNameRank);

                toolTip.AppendFormatLine("Spell Name: {0}", spell.SpellNameRank);
                toolTip.AppendFormatLine("Description: {0}", spell.Description);
                toolTip.AppendFormatLine("ToolTip: {0}", spell.ToolTip);

                if (isSkill)
                {
                    name.AppendFormat("(Skill: ({0}) {1}) ", spellEntry.SkillId, spellEntry.Value.Name);

                    toolTip.AppendLine();
                    toolTip.AppendFormatLine("Skill Name: {0}", spellEntry.Value.Name);
                    toolTip.AppendFormatLine("Description: {0}", spellEntry.Value.Description);
                }

                name.AppendFormat("({0})", spell.SchoolMask.ToString().NormalizeString("MASK_"));

                foreach (TreeNode node in familyTree.Nodes)
                {
                    var mask = new uint[3];

                    if (node.Index < 32)
                        mask[0] = 1U << node.Index;
                    else if (node.Index < 64)
                        mask[1] = 1U << (node.Index - 32);
                    else
                        mask[2] = 1U << (node.Index - 64);

                    if ((!spell.SpellFamilyFlags.HasAnyFlagOnSameIndex(mask)))
                        continue;

                    var child = node.Nodes.Add(name.ToString());
                    child.Name = spell.ID.ToString(CultureInfo.InvariantCulture);
                    child.ImageKey = isSkill ? "plus.ico" : "munus.ico";
                    child.ForeColor = isSkill ? Color.Blue : Color.Red;
                    child.ToolTipText = toolTip.ToString();
                }
            }
        }
    }
}
