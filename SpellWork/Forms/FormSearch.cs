using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            // load items to control's
            _cbSpellFamily.SetEnumValues<SpellFamilyName>("SpellFamilyName");
            _cbSpellAura.SetEnumValues<AuraType>("Aura");
            _cbSpellEffect.SetEnumValues<SpellEffect>("Effect");
            _cbTarget1.SetEnumValues<Target>("Target A");
            _cbTarget2.SetEnumValues<Target>("Target B");
        }

        public SpellEntry Spell { get; private set; }

        private List<SpellEntry> _spellList = new List<SpellEntry>();

        private void IdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            var name = _tbIdName.Text;
            var id = name.ToUInt32();
            var icon = _tbIcon.Text.ToUInt32();
            var attributes = _tbAttribute.Text.ToUInt32();

            _spellList = (from spell in Dbc.Spell.Values

                          where ((id == 0 || spell.ID == id)

                                 && (icon == 0 || spell.SpellIconID == icon)

                                 && (attributes == 0
                                     || (spell.Attributes & (SpellAtribute0)attributes) != 0
                                     || (spell.AttributesEx & (SpellAtribute1)attributes) != 0
                                     || (spell.AttributesEx2 & (SpellAtribute2)attributes) != 0
                                     || (spell.AttributesEx3 & (SpellAtribute3)attributes) != 0
                                     || (spell.AttributesEx4 & (SpellAtribute4)attributes) != 0
                                     || (spell.AttributesEx5 & (SpellAtribute5)attributes) != 0
                                     || (spell.AttributesEx6 & (SpellAtribute6)attributes) != 0
                                     || (spell.AttributesEx7 & (SpellAtribute7)attributes) != 0))

                                && (id != 0 || icon != 0 && attributes != 0) || spell.SpellName.ContainsText(name)

                          select spell).ToList();

            _lvSpellList.VirtualListSize = _spellList.Count();
            groupBox1.Text = "Spell Search count: " + _spellList.Count();

            if (_lvSpellList.SelectedIndices.Count > 0)
                _lvSpellList.Items[_lvSpellList.SelectedIndices[0]].Selected = false;
        }

        private void SpellFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract.Assert(sender is ComboBox);

            if (((ComboBox) sender).SelectedIndex == 0)
                return;

            var bFamilyNames = _cbSpellFamily.SelectedIndex != 0;
            var fFamilyNames = (SpellFamilyName)_cbSpellFamily.SelectedValue.ToUInt32();

            var bSpellAura = _cbSpellAura.SelectedIndex != 0;
            var fSpellAura = (AuraType)_cbSpellAura.SelectedValue.ToUInt32();

            var bSpellEffect = _cbSpellEffect.SelectedIndex != 0;
            var fSpellEffect = (SpellEffect)_cbSpellEffect.SelectedValue.ToUInt32();

            var bTarget1 = _cbTarget1.SelectedIndex != 0;
            var fTarget1 = (Target)_cbTarget1.SelectedValue.ToUInt32();

            var bTarget2 = _cbTarget2.SelectedIndex != 0;
            var fTarget2 = (Target)_cbTarget2.SelectedValue.ToUInt32();

            _spellList = (from spell in Dbc.Spell.Values
                          where (!bFamilyNames || spell.SpellFamilyName == fFamilyNames)
                                && (!bSpellEffect || spell.Effect.Contains(fSpellEffect))
                                && (!bSpellAura || spell.EffectApplyAuraName.Contains(fSpellAura))
                                && (!bTarget1 || spell.EffectImplicitTargetA.Contains(fTarget1))
                                && (!bTarget2 || spell.EffectImplicitTargetB.Contains(fTarget2))
                          select spell).ToList();

            _lvSpellList.VirtualListSize = _spellList.Count();
            groupBox2.Text = "Spell Filter " + "count: " + _spellList.Count();

            if (_lvSpellList.SelectedIndices.Count > 0)
                _lvSpellList.Items[_lvSpellList.SelectedIndices[0]].Selected = false;
        }

        private void SpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedIndices.Count > 0)
                new SpellInfo(_rtbSpellInfo, _spellList[_lvSpellList.SelectedIndices[0]]);
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedIndices.Count > 0)
            {
                Spell = _spellList[_lvSpellList.SelectedIndices[0]];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void Cencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpellList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(new[] { _spellList[e.ItemIndex].ID.ToString(), _spellList[e.ItemIndex].SpellNameRank });
        }
    }
}
