namespace MultiMC.WinGUI
{
    partial class InstanceOptions
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
            this.groupBoxMemory = new System.Windows.Forms.GroupBox();
            this.check_defaultMemMax = new System.Windows.Forms.CheckBox();
            this.check_defaultMemMin = new System.Windows.Forms.CheckBox();
            this.labelMaxMem = new System.Windows.Forms.Label();
            this.spinner_MemMax = new System.Windows.Forms.NumericUpDown();
            this.spinner_MemMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxConsole = new System.Windows.Forms.GroupBox();
            this.check_defaultAutoClose = new System.Windows.Forms.CheckBox();
            this.check_defaultShowConsole = new System.Windows.Forms.CheckBox();
            this.check_AutoClose = new System.Windows.Forms.CheckBox();
            this.check_ShowConsole = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBoxMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinner_MemMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinner_MemMin)).BeginInit();
            this.groupBoxConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMemory
            // 
            this.groupBoxMemory.Controls.Add(this.check_defaultMemMax);
            this.groupBoxMemory.Controls.Add(this.check_defaultMemMin);
            this.groupBoxMemory.Controls.Add(this.labelMaxMem);
            this.groupBoxMemory.Controls.Add(this.spinner_MemMax);
            this.groupBoxMemory.Controls.Add(this.spinner_MemMin);
            this.groupBoxMemory.Controls.Add(this.label1);
            this.groupBoxMemory.Location = new System.Drawing.Point(12, 36);
            this.groupBoxMemory.Name = "groupBoxMemory";
            this.groupBoxMemory.Size = new System.Drawing.Size(414, 71);
            this.groupBoxMemory.TabIndex = 2;
            this.groupBoxMemory.TabStop = false;
            this.groupBoxMemory.Text = "Memory";
            // 
            // check_defaultMemMax
            // 
            this.check_defaultMemMax.AutoSize = true;
            this.check_defaultMemMax.Checked = true;
            this.check_defaultMemMax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_defaultMemMax.Location = new System.Drawing.Point(202, 45);
            this.check_defaultMemMax.Name = "check_defaultMemMax";
            this.check_defaultMemMax.Size = new System.Drawing.Size(58, 17);
            this.check_defaultMemMax.TabIndex = 5;
            this.check_defaultMemMax.Text = "default";
            this.check_defaultMemMax.UseVisualStyleBackColor = true;
            this.check_defaultMemMax.CheckedChanged += new System.EventHandler(this.check_defaultMemMax_CheckedChanged);
            // 
            // check_defaultMemMin
            // 
            this.check_defaultMemMin.AutoSize = true;
            this.check_defaultMemMin.Checked = true;
            this.check_defaultMemMin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_defaultMemMin.Location = new System.Drawing.Point(202, 21);
            this.check_defaultMemMin.Name = "check_defaultMemMin";
            this.check_defaultMemMin.Size = new System.Drawing.Size(58, 17);
            this.check_defaultMemMin.TabIndex = 4;
            this.check_defaultMemMin.Text = "default";
            this.check_defaultMemMin.UseVisualStyleBackColor = true;
            this.check_defaultMemMin.CheckedChanged += new System.EventHandler(this.check_defaultMemMin_CheckedChanged);
            // 
            // labelMaxMem
            // 
            this.labelMaxMem.AutoSize = true;
            this.labelMaxMem.Location = new System.Drawing.Point(6, 47);
            this.labelMaxMem.Name = "labelMaxMem";
            this.labelMaxMem.Size = new System.Drawing.Size(138, 13);
            this.labelMaxMem.TabIndex = 3;
            this.labelMaxMem.Text = "Maximum memory allocation";
            // 
            // spinner_MemMax
            // 
            this.spinner_MemMax.Enabled = false;
            this.spinner_MemMax.Location = new System.Drawing.Point(287, 45);
            this.spinner_MemMax.Name = "spinner_MemMax";
            this.spinner_MemMax.Size = new System.Drawing.Size(120, 20);
            this.spinner_MemMax.TabIndex = 2;
            // 
            // spinner_MemMin
            // 
            this.spinner_MemMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinner_MemMin.Enabled = false;
            this.spinner_MemMin.Location = new System.Drawing.Point(288, 19);
            this.spinner_MemMin.Name = "spinner_MemMin";
            this.spinner_MemMin.Size = new System.Drawing.Size(120, 20);
            this.spinner_MemMin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum memory allocation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "You can override the Global Settings here.";
            // 
            // groupBoxConsole
            // 
            this.groupBoxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxConsole.Controls.Add(this.check_defaultAutoClose);
            this.groupBoxConsole.Controls.Add(this.check_defaultShowConsole);
            this.groupBoxConsole.Controls.Add(this.check_AutoClose);
            this.groupBoxConsole.Controls.Add(this.check_ShowConsole);
            this.groupBoxConsole.Location = new System.Drawing.Point(11, 107);
            this.groupBoxConsole.Name = "groupBoxConsole";
            this.groupBoxConsole.Size = new System.Drawing.Size(414, 65);
            this.groupBoxConsole.TabIndex = 4;
            this.groupBoxConsole.TabStop = false;
            this.groupBoxConsole.Text = "Console";
            // 
            // check_defaultAutoClose
            // 
            this.check_defaultAutoClose.AutoSize = true;
            this.check_defaultAutoClose.Checked = true;
            this.check_defaultAutoClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_defaultAutoClose.Location = new System.Drawing.Point(289, 42);
            this.check_defaultAutoClose.Name = "check_defaultAutoClose";
            this.check_defaultAutoClose.Size = new System.Drawing.Size(58, 17);
            this.check_defaultAutoClose.TabIndex = 3;
            this.check_defaultAutoClose.Text = "default";
            this.check_defaultAutoClose.UseVisualStyleBackColor = true;
            this.check_defaultAutoClose.CheckedChanged += new System.EventHandler(this.check_defaultAutoClose_CheckedChanged);
            // 
            // check_defaultShowConsole
            // 
            this.check_defaultShowConsole.AutoSize = true;
            this.check_defaultShowConsole.Checked = true;
            this.check_defaultShowConsole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_defaultShowConsole.Location = new System.Drawing.Point(288, 19);
            this.check_defaultShowConsole.Name = "check_defaultShowConsole";
            this.check_defaultShowConsole.Size = new System.Drawing.Size(58, 17);
            this.check_defaultShowConsole.TabIndex = 2;
            this.check_defaultShowConsole.Text = "default";
            this.check_defaultShowConsole.UseVisualStyleBackColor = true;
            this.check_defaultShowConsole.CheckedChanged += new System.EventHandler(this.check_defaultShowConsole_CheckedChanged);
            // 
            // check_AutoClose
            // 
            this.check_AutoClose.AutoSize = true;
            this.check_AutoClose.Enabled = false;
            this.check_AutoClose.Location = new System.Drawing.Point(6, 42);
            this.check_AutoClose.Name = "check_AutoClose";
            this.check_AutoClose.Size = new System.Drawing.Size(260, 17);
            this.check_AutoClose.TabIndex = 1;
            this.check_AutoClose.Text = "Automatically close console when the game quits.";
            this.check_AutoClose.UseVisualStyleBackColor = true;
            // 
            // check_ShowConsole
            // 
            this.check_ShowConsole.AutoSize = true;
            this.check_ShowConsole.Enabled = false;
            this.check_ShowConsole.Location = new System.Drawing.Point(6, 19);
            this.check_ShowConsole.Name = "check_ShowConsole";
            this.check_ShowConsole.Size = new System.Drawing.Size(218, 17);
            this.check_ShowConsole.TabIndex = 0;
            this.check_ShowConsole.Text = "Show console while the game is running.";
            this.check_ShowConsole.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(199, 244);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(299, 243);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // InstanceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 279);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBoxConsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxMemory);
            this.Name = "InstanceOptions";
            this.Text = "Instance Options";
            this.Title = "Instance Options";
            this.groupBoxMemory.ResumeLayout(false);
            this.groupBoxMemory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinner_MemMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinner_MemMin)).EndInit();
            this.groupBoxConsole.ResumeLayout(false);
            this.groupBoxConsole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMemory;
        private System.Windows.Forms.Label labelMaxMem;
        private System.Windows.Forms.NumericUpDown spinner_MemMax;
        private System.Windows.Forms.NumericUpDown spinner_MemMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check_defaultMemMax;
        private System.Windows.Forms.CheckBox check_defaultMemMin;
        private System.Windows.Forms.GroupBox groupBoxConsole;
        private System.Windows.Forms.CheckBox check_defaultAutoClose;
        private System.Windows.Forms.CheckBox check_defaultShowConsole;
        private System.Windows.Forms.CheckBox check_AutoClose;
        private System.Windows.Forms.CheckBox check_ShowConsole;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;

    }
}