﻿namespace SpellWork
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._rtSpellInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lvSpellList = new System.Windows.Forms.ListView();
            this.chSpellID = new System.Windows.Forms.ColumnHeader();
            this.chSpellName = new System.Windows.Forms.ColumnHeader();
            this._cbTarget2 = new System.Windows.Forms.ComboBox();
            this._cbTarget1 = new System.Windows.Forms.ComboBox();
            this._cbSpellEffect = new System.Windows.Forms.ComboBox();
            this._cbSpellAura = new System.Windows.Forms.ComboBox();
            this._cbSpellFamilyName = new System.Windows.Forms.ComboBox();
            this._bSearch = new System.Windows.Forms.Button();
            this._tbSearch = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this._clbProcFlags = new System.Windows.Forms.CheckedListBox();
            this._cbProcFlag = new System.Windows.Forms.CheckBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this._cbProcSpellFamilyTree = new System.Windows.Forms.ComboBox();
            this._tvFamilyTree = new System.Windows.Forms.TreeView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this._rtbProcSpellInfo = new System.Windows.Forms.RichTextBox();
            this._bProcSearch = new System.Windows.Forms.Button();
            this._tbProcSeach = new System.Windows.Forms.TextBox();
            this._cbProcTarget2 = new System.Windows.Forms.ComboBox();
            this._cbProcTarget1 = new System.Windows.Forms.ComboBox();
            this._cbProcSpellEffect = new System.Windows.Forms.ComboBox();
            this._cbProcSpellAura = new System.Windows.Forms.ComboBox();
            this._cbProcSpellFamilyName = new System.Windows.Forms.ComboBox();
            this._lvProcSpellList = new System.Windows.Forms.ListView();
            this._chProcID = new System.Windows.Forms.ColumnHeader();
            this._chProcName = new System.Windows.Forms.ColumnHeader();
            this._lvProcAdditionalInfo = new System.Windows.Forms.ListView();
            this._chID = new System.Windows.Forms.ColumnHeader();
            this._chName = new System.Windows.Forms.ColumnHeader();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this._lvDataList = new System.Windows.Forms.ListView();
            this._tbSqlLog = new System.Windows.Forms.TextBox();
            this._clbProcFlagEx = new System.Windows.Forms.CheckedListBox();
            this._cbProcFitstSpellFamily = new System.Windows.Forms.ComboBox();
            this._clbSchools = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbPPM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tbChance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._tbCooldown = new System.Windows.Forms.TextBox();
            this._ProcStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this._bWrite = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._status,
            this._ProcStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _status
            // 
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmFile,
            this._tsmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _tsmFile
            // 
            this._tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmSettings,
            this._tsmExit});
            this._tsmFile.Name = "_tsmFile";
            this._tsmFile.Size = new System.Drawing.Size(35, 20);
            this._tsmFile.Text = "File";
            // 
            // _tsmSettings
            // 
            this._tsmSettings.Name = "_tsmSettings";
            this._tsmSettings.Size = new System.Drawing.Size(119, 22);
            this._tsmSettings.Text = "Setting";
            this._tsmSettings.Click += new System.EventHandler(this._tsmSettings_Click);
            // 
            // _tsmExit
            // 
            this._tsmExit.Name = "_tsmExit";
            this._tsmExit.Size = new System.Drawing.Size(119, 22);
            this._tsmExit.Text = "Exit";
            this._tsmExit.Click += new System.EventHandler(this._tsmExit_Click);
            // 
            // _tsmHelp
            // 
            this._tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmAbout});
            this._tsmHelp.Name = "_tsmHelp";
            this._tsmHelp.Size = new System.Drawing.Size(40, 20);
            this._tsmHelp.Text = "Help";
            // 
            // _tsmAbout
            // 
            this._tsmAbout.Name = "_tsmAbout";
            this._tsmAbout.Size = new System.Drawing.Size(122, 22);
            this._tsmAbout.Text = "About..";
            this._tsmAbout.Click += new System.EventHandler(this._tsmAbout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 583);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Spell Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._rtSpellInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(858, 533);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 0;
            // 
            // _rtSpellInfo
            // 
            this._rtSpellInfo.BackColor = System.Drawing.Color.Gainsboro;
            this._rtSpellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtSpellInfo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rtSpellInfo.Location = new System.Drawing.Point(0, 0);
            this._rtSpellInfo.Name = "_rtSpellInfo";
            this._rtSpellInfo.ReadOnly = true;
            this._rtSpellInfo.Size = new System.Drawing.Size(580, 533);
            this._rtSpellInfo.TabIndex = 0;
            this._rtSpellInfo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lvSpellList);
            this.groupBox1.Controls.Add(this._cbTarget2);
            this.groupBox1.Controls.Add(this._cbTarget1);
            this.groupBox1.Controls.Add(this._cbSpellEffect);
            this.groupBox1.Controls.Add(this._cbSpellAura);
            this.groupBox1.Controls.Add(this._cbSpellFamilyName);
            this.groupBox1.Controls.Add(this._bSearch);
            this.groupBox1.Controls.Add(this._tbSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 533);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _lvSpellList
            // 
            this._lvSpellList.AllowColumnReorder = true;
            this._lvSpellList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lvSpellList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSpellID,
            this.chSpellName});
            this._lvSpellList.FullRowSelect = true;
            this._lvSpellList.GridLines = true;
            this._lvSpellList.HideSelection = false;
            this._lvSpellList.Location = new System.Drawing.Point(0, 129);
            this._lvSpellList.MultiSelect = false;
            this._lvSpellList.Name = "_lvSpellList";
            this._lvSpellList.Size = new System.Drawing.Size(277, 404);
            this._lvSpellList.TabIndex = 7;
            this._lvSpellList.UseCompatibleStateImageBehavior = false;
            this._lvSpellList.View = System.Windows.Forms.View.Details;
            this._lvSpellList.SelectedIndexChanged += new System.EventHandler(this._lvSpellList_SelectedIndexChanged);
            // 
            // chSpellID
            // 
            this.chSpellID.Text = "ID";
            this.chSpellID.Width = 48;
            // 
            // chSpellName
            // 
            this.chSpellName.Text = "Name";
            this.chSpellName.Width = 224;
            // 
            // _cbTarget2
            // 
            this._cbTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbTarget2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTarget2.FormattingEnabled = true;
            this._cbTarget2.Location = new System.Drawing.Point(139, 102);
            this._cbTarget2.Name = "_cbTarget2";
            this._cbTarget2.Size = new System.Drawing.Size(135, 21);
            this._cbTarget2.TabIndex = 5;
            this._cbTarget2.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbTarget1
            // 
            this._cbTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbTarget1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTarget1.FormattingEnabled = true;
            this._cbTarget1.Location = new System.Drawing.Point(1, 102);
            this._cbTarget1.Name = "_cbTarget1";
            this._cbTarget1.Size = new System.Drawing.Size(135, 21);
            this._cbTarget1.TabIndex = 5;
            this._cbTarget1.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbSpellEffect
            // 
            this._cbSpellEffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbSpellEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSpellEffect.FormattingEnabled = true;
            this._cbSpellEffect.Location = new System.Drawing.Point(1, 79);
            this._cbSpellEffect.Name = "_cbSpellEffect";
            this._cbSpellEffect.Size = new System.Drawing.Size(273, 21);
            this._cbSpellEffect.TabIndex = 4;
            this._cbSpellEffect.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbSpellAura
            // 
            this._cbSpellAura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbSpellAura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSpellAura.FormattingEnabled = true;
            this._cbSpellAura.Location = new System.Drawing.Point(1, 56);
            this._cbSpellAura.Name = "_cbSpellAura";
            this._cbSpellAura.Size = new System.Drawing.Size(273, 21);
            this._cbSpellAura.TabIndex = 3;
            this._cbSpellAura.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbSpellFamilyName
            // 
            this._cbSpellFamilyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbSpellFamilyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbSpellFamilyName.FormattingEnabled = true;
            this._cbSpellFamilyName.Location = new System.Drawing.Point(1, 32);
            this._cbSpellFamilyName.Name = "_cbSpellFamilyName";
            this._cbSpellFamilyName.Size = new System.Drawing.Size(273, 21);
            this._cbSpellFamilyName.TabIndex = 2;
            this._cbSpellFamilyName.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _bSearch
            // 
            this._bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bSearch.Location = new System.Drawing.Point(227, 8);
            this._bSearch.Name = "_bSearch";
            this._bSearch.Size = new System.Drawing.Size(47, 23);
            this._bSearch.TabIndex = 1;
            this._bSearch.Text = "Seach";
            this._bSearch.UseVisualStyleBackColor = true;
            this._bSearch.Click += new System.EventHandler(this._bSearch_Click);
            // 
            // _tbSearch
            // 
            this._tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbSearch.Location = new System.Drawing.Point(1, 10);
            this._tbSearch.Name = "_tbSearch";
            this._tbSearch.Size = new System.Drawing.Size(220, 20);
            this._tbSearch.TabIndex = 0;
            this._tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._tbSearch_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(864, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Spell Proc Event";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel2.Controls.Add(this._lvProcAdditionalInfo);
            this.splitContainer2.Size = new System.Drawing.Size(864, 557);
            this.splitContainer2.SplitterDistance = 489;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Panel1.Controls.Add(this._tbCooldown);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this._tbChance);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this._tbPPM);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this._clbSchools);
            this.splitContainer3.Panel1.Controls.Add(this._cbProcFitstSpellFamily);
            this.splitContainer3.Panel1.Controls.Add(this._clbProcFlags);
            this.splitContainer3.Panel1.Controls.Add(this._clbProcFlagEx);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(864, 489);
            this.splitContainer3.SplitterDistance = 214;
            this.splitContainer3.TabIndex = 0;
            // 
            // _clbProcFlags
            // 
            this._clbProcFlags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._clbProcFlags.CheckOnClick = true;
            this._clbProcFlags.ColumnWidth = 220;
            this._clbProcFlags.FormattingEnabled = true;
            this._clbProcFlags.Location = new System.Drawing.Point(1, 101);
            this._clbProcFlags.MultiColumn = true;
            this._clbProcFlags.Name = "_clbProcFlags";
            this._clbProcFlags.Size = new System.Drawing.Size(860, 109);
            this._clbProcFlags.TabIndex = 0;
            // 
            // _cbProcFlag
            // 
            this._cbProcFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcFlag.Appearance = System.Windows.Forms.Appearance.Button;
            this._cbProcFlag.AutoSize = true;
            this._cbProcFlag.Location = new System.Drawing.Point(809, 1);
            this._cbProcFlag.Name = "_cbProcFlag";
            this._cbProcFlag.Size = new System.Drawing.Size(59, 23);
            this._cbProcFlag.TabIndex = 2;
            this._cbProcFlag.Text = "ProcFlag";
            this._cbProcFlag.UseVisualStyleBackColor = true;
            this._cbProcFlag.Visible = false;
            this._cbProcFlag.CheckedChanged += new System.EventHandler(this._cbProcFlag_CheckedChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.White;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer4.Panel1.Controls.Add(this._cbProcSpellFamilyTree);
            this.splitContainer4.Panel1.Controls.Add(this._tvFamilyTree);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(864, 271);
            this.splitContainer4.SplitterDistance = 260;
            this.splitContainer4.TabIndex = 0;
            // 
            // _cbProcSpellFamilyTree
            // 
            this._cbProcSpellFamilyTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcSpellFamilyTree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcSpellFamilyTree.FormattingEnabled = true;
            this._cbProcSpellFamilyTree.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._cbProcSpellFamilyTree.Location = new System.Drawing.Point(1, 2);
            this._cbProcSpellFamilyTree.Name = "_cbProcSpellFamilyTree";
            this._cbProcSpellFamilyTree.Size = new System.Drawing.Size(258, 21);
            this._cbProcSpellFamilyTree.TabIndex = 1;
            this._cbProcSpellFamilyTree.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // _tvFamilyTree
            // 
            this._tvFamilyTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tvFamilyTree.Location = new System.Drawing.Point(1, 23);
            this._tvFamilyTree.Name = "_tvFamilyTree";
            this._tvFamilyTree.Size = new System.Drawing.Size(258, 246);
            this._tvFamilyTree.TabIndex = 0;
            this._tvFamilyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvFamilyTree_AfterSelect);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this._rtbProcSpellInfo);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer5.Panel2.Controls.Add(this._bProcSearch);
            this.splitContainer5.Panel2.Controls.Add(this._tbProcSeach);
            this.splitContainer5.Panel2.Controls.Add(this._cbProcTarget2);
            this.splitContainer5.Panel2.Controls.Add(this._cbProcTarget1);
            this.splitContainer5.Panel2.Controls.Add(this._cbProcSpellEffect);
            this.splitContainer5.Panel2.Controls.Add(this._cbProcSpellAura);
            this.splitContainer5.Panel2.Controls.Add(this._cbProcSpellFamilyName);
            this.splitContainer5.Panel2.Controls.Add(this._lvProcSpellList);
            this.splitContainer5.Size = new System.Drawing.Size(600, 271);
            this.splitContainer5.SplitterDistance = 330;
            this.splitContainer5.TabIndex = 0;
            // 
            // _rtbProcSpellInfo
            // 
            this._rtbProcSpellInfo.BackColor = System.Drawing.SystemColors.MenuBar;
            this._rtbProcSpellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbProcSpellInfo.Font = new System.Drawing.Font("Arial Unicode MS", 9F);
            this._rtbProcSpellInfo.Location = new System.Drawing.Point(0, 0);
            this._rtbProcSpellInfo.Name = "_rtbProcSpellInfo";
            this._rtbProcSpellInfo.Size = new System.Drawing.Size(330, 271);
            this._rtbProcSpellInfo.TabIndex = 0;
            this._rtbProcSpellInfo.Text = "";
            // 
            // _bProcSearch
            // 
            this._bProcSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bProcSearch.Location = new System.Drawing.Point(217, 3);
            this._bProcSearch.Name = "_bProcSearch";
            this._bProcSearch.Size = new System.Drawing.Size(46, 20);
            this._bProcSearch.TabIndex = 5;
            this._bProcSearch.Text = "Seach";
            this._bProcSearch.UseVisualStyleBackColor = true;
            this._bProcSearch.Click += new System.EventHandler(this._bSearch_Click);
            // 
            // _tbProcSeach
            // 
            this._tbProcSeach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbProcSeach.Location = new System.Drawing.Point(3, 3);
            this._tbProcSeach.Name = "_tbProcSeach";
            this._tbProcSeach.Size = new System.Drawing.Size(211, 20);
            this._tbProcSeach.TabIndex = 4;
            this._tbProcSeach.KeyDown += new System.Windows.Forms.KeyEventHandler(this._tbSearch_KeyDown);
            // 
            // _cbProcTarget2
            // 
            this._cbProcTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcTarget2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcTarget2.FormattingEnabled = true;
            this._cbProcTarget2.Location = new System.Drawing.Point(144, 90);
            this._cbProcTarget2.Name = "_cbProcTarget2";
            this._cbProcTarget2.Size = new System.Drawing.Size(119, 21);
            this._cbProcTarget2.TabIndex = 3;
            this._cbProcTarget2.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbProcTarget1
            // 
            this._cbProcTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcTarget1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcTarget1.FormattingEnabled = true;
            this._cbProcTarget1.Location = new System.Drawing.Point(3, 90);
            this._cbProcTarget1.Name = "_cbProcTarget1";
            this._cbProcTarget1.Size = new System.Drawing.Size(122, 21);
            this._cbProcTarget1.TabIndex = 3;
            this._cbProcTarget1.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbProcSpellEffect
            // 
            this._cbProcSpellEffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcSpellEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcSpellEffect.FormattingEnabled = true;
            this._cbProcSpellEffect.Location = new System.Drawing.Point(3, 68);
            this._cbProcSpellEffect.Name = "_cbProcSpellEffect";
            this._cbProcSpellEffect.Size = new System.Drawing.Size(260, 21);
            this._cbProcSpellEffect.TabIndex = 3;
            this._cbProcSpellEffect.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbProcSpellAura
            // 
            this._cbProcSpellAura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcSpellAura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcSpellAura.FormattingEnabled = true;
            this._cbProcSpellAura.Location = new System.Drawing.Point(3, 46);
            this._cbProcSpellAura.Name = "_cbProcSpellAura";
            this._cbProcSpellAura.Size = new System.Drawing.Size(260, 21);
            this._cbProcSpellAura.TabIndex = 2;
            this._cbProcSpellAura.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _cbProcSpellFamilyName
            // 
            this._cbProcSpellFamilyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cbProcSpellFamilyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcSpellFamilyName.FormattingEnabled = true;
            this._cbProcSpellFamilyName.Location = new System.Drawing.Point(3, 24);
            this._cbProcSpellFamilyName.Name = "_cbProcSpellFamilyName";
            this._cbProcSpellFamilyName.Size = new System.Drawing.Size(260, 21);
            this._cbProcSpellFamilyName.TabIndex = 1;
            this._cbProcSpellFamilyName.SelectedIndexChanged += new System.EventHandler(this._cbSpellFamilyNames_SelectedIndexChanged);
            // 
            // _lvProcSpellList
            // 
            this._lvProcSpellList.AllowColumnReorder = true;
            this._lvProcSpellList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lvProcSpellList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chProcID,
            this._chProcName});
            this._lvProcSpellList.FullRowSelect = true;
            this._lvProcSpellList.GridLines = true;
            this._lvProcSpellList.HideSelection = false;
            this._lvProcSpellList.Location = new System.Drawing.Point(3, 113);
            this._lvProcSpellList.MultiSelect = false;
            this._lvProcSpellList.Name = "_lvProcSpellList";
            this._lvProcSpellList.ShowItemToolTips = true;
            this._lvProcSpellList.Size = new System.Drawing.Size(260, 156);
            this._lvProcSpellList.TabIndex = 0;
            this._lvProcSpellList.UseCompatibleStateImageBehavior = false;
            this._lvProcSpellList.View = System.Windows.Forms.View.Details;
            this._lvProcSpellList.SelectedIndexChanged += new System.EventHandler(this._lvProcSpellList_SelectedIndexChanged);
            // 
            // _chProcID
            // 
            this._chProcID.Text = "ID";
            this._chProcID.Width = 45;
            // 
            // _chProcName
            // 
            this._chProcName.Text = "Name";
            this._chProcName.Width = 221;
            // 
            // _lvProcAdditionalInfo
            // 
            this._lvProcAdditionalInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chID,
            this._chName});
            this._lvProcAdditionalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvProcAdditionalInfo.Location = new System.Drawing.Point(0, 0);
            this._lvProcAdditionalInfo.Name = "_lvProcAdditionalInfo";
            this._lvProcAdditionalInfo.Size = new System.Drawing.Size(864, 64);
            this._lvProcAdditionalInfo.TabIndex = 0;
            this._lvProcAdditionalInfo.UseCompatibleStateImageBehavior = false;
            this._lvProcAdditionalInfo.View = System.Windows.Forms.View.Details;
            // 
            // _chID
            // 
            this._chID.Text = "Entry";
            this._chID.Width = 100;
            // 
            // _chName
            // 
            this._chName.Text = "Name";
            this._chName.Width = 685;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(864, 539);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sql Data";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 539);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Data";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 16);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this._lvDataList);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this._tbSqlLog);
            this.splitContainer6.Size = new System.Drawing.Size(858, 520);
            this.splitContainer6.SplitterDistance = 204;
            this.splitContainer6.TabIndex = 0;
            // 
            // _lvDataList
            // 
            this._lvDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lvDataList.Location = new System.Drawing.Point(0, 0);
            this._lvDataList.Name = "_lvDataList";
            this._lvDataList.Size = new System.Drawing.Size(858, 204);
            this._lvDataList.TabIndex = 0;
            this._lvDataList.UseCompatibleStateImageBehavior = false;
            this._lvDataList.View = System.Windows.Forms.View.Details;
            // 
            // _tbSqlLog
            // 
            this._tbSqlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbSqlLog.Location = new System.Drawing.Point(3, 53);
            this._tbSqlLog.Multiline = true;
            this._tbSqlLog.Name = "_tbSqlLog";
            this._tbSqlLog.Size = new System.Drawing.Size(852, 256);
            this._tbSqlLog.TabIndex = 0;
            // 
            // _clbProcFlagEx
            // 
            this._clbProcFlagEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._clbProcFlagEx.CheckOnClick = true;
            this._clbProcFlagEx.ColumnWidth = 120;
            this._clbProcFlagEx.FormattingEnabled = true;
            this._clbProcFlagEx.Location = new System.Drawing.Point(3, 48);
            this._clbProcFlagEx.MultiColumn = true;
            this._clbProcFlagEx.Name = "_clbProcFlagEx";
            this._clbProcFlagEx.Size = new System.Drawing.Size(858, 49);
            this._clbProcFlagEx.TabIndex = 3;
            // 
            // _cbProcFitstSpellFamily
            // 
            this._cbProcFitstSpellFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbProcFitstSpellFamily.FormattingEnabled = true;
            this._cbProcFitstSpellFamily.Location = new System.Drawing.Point(3, 3);
            this._cbProcFitstSpellFamily.Name = "_cbProcFitstSpellFamily";
            this._cbProcFitstSpellFamily.Size = new System.Drawing.Size(342, 21);
            this._cbProcFitstSpellFamily.TabIndex = 4;
            // 
            // _clbSchools
            // 
            this._clbSchools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._clbSchools.CheckOnClick = true;
            this._clbSchools.ColumnWidth = 100;
            this._clbSchools.FormattingEnabled = true;
            this._clbSchools.Location = new System.Drawing.Point(398, 9);
            this._clbSchools.MultiColumn = true;
            this._clbSchools.Name = "_clbSchools";
            this._clbSchools.Size = new System.Drawing.Size(463, 34);
            this._clbSchools.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "PPM";
            // 
            // _tbPPM
            // 
            this._tbPPM.Location = new System.Drawing.Point(39, 27);
            this._tbPPM.Name = "_tbPPM";
            this._tbPPM.Size = new System.Drawing.Size(60, 20);
            this._tbPPM.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chance";
            // 
            // _tbChance
            // 
            this._tbChance.Location = new System.Drawing.Point(155, 27);
            this._tbChance.Name = "_tbChance";
            this._tbChance.Size = new System.Drawing.Size(60, 20);
            this._tbChance.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cooldown";
            // 
            // _tbCooldown
            // 
            this._tbCooldown.Location = new System.Drawing.Point(285, 27);
            this._tbCooldown.Name = "_tbCooldown";
            this._tbCooldown.Size = new System.Drawing.Size(60, 20);
            this._tbCooldown.TabIndex = 7;
            // 
            // _ProcStatus
            // 
            this._ProcStatus.Name = "_ProcStatus";
            this._ProcStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // _bWrite
            // 
            this._bWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bWrite.Enabled = false;
            this._bWrite.Location = new System.Drawing.Point(728, 1);
            this._bWrite.Name = "_bWrite";
            this._bWrite.Size = new System.Drawing.Size(75, 23);
            this._bWrite.TabIndex = 3;
            this._bWrite.Text = "Write";
            this._bWrite.UseVisualStyleBackColor = true;
            this._bWrite.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 629);
            this.Controls.Add(this._bWrite);
            this.Controls.Add(this._cbProcFlag);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(880, 585);
            this.Name = "MainForm";
            this.Text = "Spell Work";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            this.splitContainer6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox _rtSpellInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _bSearch;
        private System.Windows.Forms.TextBox _tbSearch;
        private System.Windows.Forms.ComboBox _cbSpellFamilyName;
        private System.Windows.Forms.ListView _lvSpellList;
        private System.Windows.Forms.ColumnHeader chSpellID;
        private System.Windows.Forms.ColumnHeader chSpellName;
        private System.Windows.Forms.ComboBox _cbTarget1;
        private System.Windows.Forms.ComboBox _cbSpellEffect;
        private System.Windows.Forms.ComboBox _cbSpellAura;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ComboBox _cbProcSpellEffect;
        private System.Windows.Forms.ComboBox _cbProcSpellAura;
        private System.Windows.Forms.ComboBox _cbProcSpellFamilyName;
        private System.Windows.Forms.ListView _lvProcSpellList;
        private System.Windows.Forms.TextBox _tbProcSeach;
        private System.Windows.Forms.Button _bProcSearch;
        private System.Windows.Forms.ListView _lvProcAdditionalInfo;
        private System.Windows.Forms.TreeView _tvFamilyTree;
        private System.Windows.Forms.ComboBox _cbProcSpellFamilyTree;
        private System.Windows.Forms.RichTextBox _rtbProcSpellInfo;
        private System.Windows.Forms.ColumnHeader _chID;
        private System.Windows.Forms.ColumnHeader _chName;
        private System.Windows.Forms.ToolStripStatusLabel _status;
        private System.Windows.Forms.ComboBox _cbTarget2;
        private System.Windows.Forms.CheckBox _cbProcFlag;
        private System.Windows.Forms.CheckedListBox _clbProcFlags;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.ListView _lvDataList;
        private System.Windows.Forms.TextBox _tbSqlLog;
        private System.Windows.Forms.ToolStripMenuItem _tsmFile;
        private System.Windows.Forms.ToolStripMenuItem _tsmExit;
        private System.Windows.Forms.ToolStripMenuItem _tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem _tsmAbout;
        private System.Windows.Forms.ComboBox _cbProcTarget2;
        private System.Windows.Forms.ComboBox _cbProcTarget1;
        private System.Windows.Forms.ColumnHeader _chProcID;
        private System.Windows.Forms.ColumnHeader _chProcName;
        private System.Windows.Forms.ToolStripMenuItem _tsmSettings;
        private System.Windows.Forms.CheckedListBox _clbProcFlagEx;
        private System.Windows.Forms.CheckedListBox _clbSchools;
        private System.Windows.Forms.ComboBox _cbProcFitstSpellFamily;
        private System.Windows.Forms.ToolStripStatusLabel _ProcStatus;
        private System.Windows.Forms.TextBox _tbCooldown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _tbChance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _tbPPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bWrite;
    }
}