using System;
using System.Drawing;
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
            familyTree.Nodes.Clear();

            var spells = from Spell in DBC.Spell
                         where Spell.Value.SpellFamilyName == (uint)spellfamily
                         join sk in DBC.SkillLineAbility on Spell.Key equals sk.Value.SpellId into temp1
                         from Skill in temp1.DefaultIfEmpty()
                         join skl in DBC.SkillLine on Skill.Value.SkillId equals skl.Key into temp2
                         from SkillLine in temp2.DefaultIfEmpty()
                         select new
                         {
                             Spell,
                             Skill.Value.SkillId,
                             SkillLine.Value
                         };

            for (var i = 0; i < 96; i++)
            {
                var mask = new uint[3];

                if (i < 32)
                    mask[0] = 1U << i;
                else if (i < 64)
                    mask[1] = 1U << (i - 32);
                else
                    mask[2] = 1U << (i - 64);

                var node = new TreeNode();
                node.Text = String.Format("0x{0:X8} {1:X8} {2:X8}", mask[2], mask[1], mask[0]);
                node.ImageKey = "family.ico";
                familyTree.Nodes.Add(node);
            }

            foreach (var elem in spells)
            {
                var spell = elem.Spell.Value;
                var IsSkill = elem.SkillId != 0;

                var name = new StringBuilder();
                var toolTip = new StringBuilder();

                name.AppendFormat("{0} - {1} ", spell.ID, spell.SpellNameRank);

                toolTip.AppendFormatLine("Spell Name: {0}", spell.SpellNameRank);
                toolTip.AppendFormatLine("Description: {0}", spell.Description);
                toolTip.AppendFormatLine("ToolTip: {0}", spell.ToolTip);

                if (IsSkill)
                {
                    name.AppendFormat("(Skill: ({0}) {1}) ", elem.SkillId, elem.Value.Name);

                    toolTip.AppendLine();
                    toolTip.AppendFormatLine("Skill Name: {0}", elem.Value.Name);
                    toolTip.AppendFormatLine("Description: {0}", elem.Value.Description);
                }

                name.AppendFormat("({0})", spell.School.ToString().NormalizeString("MASK_"));

                foreach (TreeNode node in familyTree.Nodes)
                {
                    var mask = new uint[3];

                    if (node.Index < 32)
                        mask[0] = 1U << node.Index;
                    else if (node.Index < 64)
                        mask[1] = 1U << (node.Index - 32);
                    else
                        mask[2] = 1U << (node.Index - 64);

                    if ((spell.SpellFamilyFlags.HasAnyFlagOnSameIndex(mask)))
                    {
                        var child = new TreeNode();
                        child = node.Nodes.Add(name.ToString());
                        child.Name = spell.ID.ToString();
                        child.ImageKey = IsSkill ? "plus.ico" : "munus.ico";
                        child.ForeColor = IsSkill ? Color.Blue : Color.Red;
                        child.ToolTipText = toolTip.ToString();
                    }
                }
            }
        }
    }
}
