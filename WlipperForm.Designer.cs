namespace Wlipper
{
    partial class WlipperForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
        	// Unregister first, before disposing the rest
            UnregisterWindowFromChain();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WlipperForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.reregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxLimits = new System.Windows.Forms.GroupBox();
            this.numericUpDownTooltip = new System.Windows.Forms.NumericUpDown();
            this.labelTooltip = new System.Windows.Forms.Label();
            this.numericUpDownHistory = new System.Windows.Forms.NumericUpDown();
            this.labelEntry = new System.Windows.Forms.Label();
            this.numericUpDownEntry = new System.Windows.Forms.NumericUpDown();
            this.labelHistory = new System.Windows.Forms.Label();
            this.groupBoxBehavior = new System.Windows.Forms.GroupBox();
            this.checkBoxFormatted = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooltip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntry)).BeginInit();
            this.groupBoxBehavior.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseUp);
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClear,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.toolStripMenuItemPreferences,
            this.reregisterToolStripMenuItem,
            this.toolStripMenuItemUpdate,
            this.toolStripMenuItemHelp,
            this.toolStripSeparator1,
            this.toolStripMenuItemQuit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            // 
            // toolStripMenuItemClear
            // 
            resources.ApplyResources(this.toolStripMenuItemClear, "toolStripMenuItemClear");
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripMenuItemPreferences
            // 
            resources.ApplyResources(this.toolStripMenuItemPreferences, "toolStripMenuItemPreferences");
            this.toolStripMenuItemPreferences.Name = "toolStripMenuItemPreferences";
            this.toolStripMenuItemPreferences.Click += new System.EventHandler(this.toolStripMenuItemPreferences_Click);
            // 
            // reregisterToolStripMenuItem
            // 
            resources.ApplyResources(this.reregisterToolStripMenuItem, "reregisterToolStripMenuItem");
            this.reregisterToolStripMenuItem.Name = "reregisterToolStripMenuItem";
            this.reregisterToolStripMenuItem.Click += new System.EventHandler(this.ReregisterToolStripMenuItemClick);
            // 
            // toolStripMenuItemUpdate
            // 
            resources.ApplyResources(this.toolStripMenuItemUpdate, "toolStripMenuItemUpdate");
            this.toolStripMenuItemUpdate.Name = "toolStripMenuItemUpdate";
            this.toolStripMenuItemUpdate.Click += new System.EventHandler(this.toolStripMenuItemUpdate_Click);
            // 
            // toolStripMenuItemHelp
            // 
            resources.ApplyResources(this.toolStripMenuItemHelp, "toolStripMenuItemHelp");
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Click += new System.EventHandler(this.toolStripMenuItemHelp_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripMenuItemQuit
            // 
            resources.ApplyResources(this.toolStripMenuItemQuit, "toolStripMenuItemQuit");
            this.toolStripMenuItemQuit.Name = "toolStripMenuItemQuit";
            this.toolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItemQuit_Click);
            // 
            // groupBoxLimits
            // 
            resources.ApplyResources(this.groupBoxLimits, "groupBoxLimits");
            this.groupBoxLimits.Controls.Add(this.numericUpDownTooltip);
            this.groupBoxLimits.Controls.Add(this.labelTooltip);
            this.groupBoxLimits.Controls.Add(this.numericUpDownHistory);
            this.groupBoxLimits.Controls.Add(this.labelEntry);
            this.groupBoxLimits.Controls.Add(this.numericUpDownEntry);
            this.groupBoxLimits.Controls.Add(this.labelHistory);
            this.groupBoxLimits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxLimits.Name = "groupBoxLimits";
            this.groupBoxLimits.TabStop = false;
            // 
            // numericUpDownTooltip
            // 
            resources.ApplyResources(this.numericUpDownTooltip, "numericUpDownTooltip");
            this.numericUpDownTooltip.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTooltip.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTooltip.Name = "numericUpDownTooltip";
            this.numericUpDownTooltip.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownTooltip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // labelTooltip
            // 
            resources.ApplyResources(this.labelTooltip, "labelTooltip");
            this.labelTooltip.Name = "labelTooltip";
            // 
            // numericUpDownHistory
            // 
            resources.ApplyResources(this.numericUpDownHistory, "numericUpDownHistory");
            this.numericUpDownHistory.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHistory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHistory.Name = "numericUpDownHistory";
            this.numericUpDownHistory.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // labelEntry
            // 
            resources.ApplyResources(this.labelEntry, "labelEntry");
            this.labelEntry.Name = "labelEntry";
            // 
            // numericUpDownEntry
            // 
            resources.ApplyResources(this.numericUpDownEntry, "numericUpDownEntry");
            this.numericUpDownEntry.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEntry.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEntry.Name = "numericUpDownEntry";
            this.numericUpDownEntry.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.numericUpDownEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // labelHistory
            // 
            resources.ApplyResources(this.labelHistory, "labelHistory");
            this.labelHistory.Name = "labelHistory";
            // 
            // groupBoxBehavior
            // 
            resources.ApplyResources(this.groupBoxBehavior, "groupBoxBehavior");
            this.groupBoxBehavior.Controls.Add(this.checkBoxFormatted);
            this.groupBoxBehavior.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxBehavior.Name = "groupBoxBehavior";
            this.groupBoxBehavior.TabStop = false;
            // 
            // checkBoxFormatted
            // 
            resources.ApplyResources(this.checkBoxFormatted, "checkBoxFormatted");
            this.checkBoxFormatted.Checked = true;
            this.checkBoxFormatted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFormatted.Name = "checkBoxFormatted";
            this.checkBoxFormatted.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // WlipperForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxLimits);
            this.Controls.Add(this.groupBoxBehavior);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "WlipperForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WlipperForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxLimits.ResumeLayout(false);
            this.groupBoxLimits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTooltip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntry)).EndInit();
            this.groupBoxBehavior.ResumeLayout(false);
            this.groupBoxBehavior.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ToolStripMenuItem reregisterToolStripMenuItem;

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPreferences;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemQuit;
        private System.Windows.Forms.GroupBox groupBoxLimits;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelTooltip;
        private System.Windows.Forms.Label labelEntry;
        private System.Windows.Forms.Label labelHistory;
        private System.Windows.Forms.NumericUpDown numericUpDownHistory;
        private System.Windows.Forms.NumericUpDown numericUpDownEntry;
        private System.Windows.Forms.NumericUpDown numericUpDownTooltip;
        private System.Windows.Forms.GroupBox groupBoxBehavior;
        private System.Windows.Forms.CheckBox checkBoxFormatted;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdate;
    }
}

