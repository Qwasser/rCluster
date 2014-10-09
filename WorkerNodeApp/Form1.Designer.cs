namespace WorkerNodeApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WokersUserLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AdaptiveRadioButton = new System.Windows.Forms.RadioButton();
            this.LockedRadioButton = new System.Windows.Forms.RadioButton();
            this.FreeRadioButton = new System.Windows.Forms.RadioButton();
            this.LimitedRadioButton = new System.Windows.Forms.RadioButton();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WokersUserLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WokersUserLimitNumericUpDown);
            this.groupBox1.Controls.Add(this.AdaptiveRadioButton);
            this.groupBox1.Controls.Add(this.LockedRadioButton);
            this.groupBox1.Controls.Add(this.FreeRadioButton);
            this.groupBox1.Controls.Add(this.LimitedRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // WokersUserLimitNumericUpDown
            // 
            this.WokersUserLimitNumericUpDown.Location = new System.Drawing.Point(109, 21);
            this.WokersUserLimitNumericUpDown.Name = "WokersUserLimitNumericUpDown";
            this.WokersUserLimitNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.WokersUserLimitNumericUpDown.TabIndex = 4;
            this.WokersUserLimitNumericUpDown.ValueChanged += new System.EventHandler(this.WokersUserLimitNumericUpDown_ValueChanged);
            // 
            // AdaptiveRadioButton
            // 
            this.AdaptiveRadioButton.AutoSize = true;
            this.AdaptiveRadioButton.Enabled = false;
            this.AdaptiveRadioButton.Location = new System.Drawing.Point(24, 93);
            this.AdaptiveRadioButton.Name = "AdaptiveRadioButton";
            this.AdaptiveRadioButton.Size = new System.Drawing.Size(67, 17);
            this.AdaptiveRadioButton.TabIndex = 3;
            this.AdaptiveRadioButton.TabStop = true;
            this.AdaptiveRadioButton.Text = "Adaptive";
            this.AdaptiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // LockedRadioButton
            // 
            this.LockedRadioButton.AutoSize = true;
            this.LockedRadioButton.Location = new System.Drawing.Point(24, 70);
            this.LockedRadioButton.Name = "LockedRadioButton";
            this.LockedRadioButton.Size = new System.Drawing.Size(61, 17);
            this.LockedRadioButton.TabIndex = 2;
            this.LockedRadioButton.TabStop = true;
            this.LockedRadioButton.Text = "Locked";
            this.LockedRadioButton.UseVisualStyleBackColor = true;
            this.LockedRadioButton.CheckedChanged += new System.EventHandler(this.LockedRadioButton_CheckedChanged);
            // 
            // FreeRadioButton
            // 
            this.FreeRadioButton.AutoSize = true;
            this.FreeRadioButton.Location = new System.Drawing.Point(24, 47);
            this.FreeRadioButton.Name = "FreeRadioButton";
            this.FreeRadioButton.Size = new System.Drawing.Size(46, 17);
            this.FreeRadioButton.TabIndex = 1;
            this.FreeRadioButton.TabStop = true;
            this.FreeRadioButton.Text = "Free";
            this.FreeRadioButton.UseVisualStyleBackColor = true;
            this.FreeRadioButton.CheckedChanged += new System.EventHandler(this.FreeRadioButton_CheckedChanged);
            // 
            // LimitedRadioButton
            // 
            this.LimitedRadioButton.AutoSize = true;
            this.LimitedRadioButton.Location = new System.Drawing.Point(24, 24);
            this.LimitedRadioButton.Name = "LimitedRadioButton";
            this.LimitedRadioButton.Size = new System.Drawing.Size(58, 17);
            this.LimitedRadioButton.TabIndex = 0;
            this.LimitedRadioButton.TabStop = true;
            this.LimitedRadioButton.Text = "Limited";
            this.LimitedRadioButton.UseVisualStyleBackColor = true;
            this.LimitedRadioButton.CheckedChanged += new System.EventHandler(this.LimitedRadioButton_CheckedChanged);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "rClusterTray";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 145);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "rCluster Load Settings";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WokersUserLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AdaptiveRadioButton;
        private System.Windows.Forms.RadioButton LockedRadioButton;
        private System.Windows.Forms.RadioButton FreeRadioButton;
        private System.Windows.Forms.RadioButton LimitedRadioButton;
        private System.Windows.Forms.NumericUpDown WokersUserLimitNumericUpDown;
        private System.Windows.Forms.NotifyIcon TrayIcon;

    }
}

