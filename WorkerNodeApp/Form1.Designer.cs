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
            this.WorkersUserLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AdaptiveRadioButton = new System.Windows.Forms.RadioButton();
            this.LockedRadioButton = new System.Windows.Forms.RadioButton();
            this.FreeRadioButton = new System.Windows.Forms.RadioButton();
            this.LimitedRadioButton = new System.Windows.Forms.RadioButton();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ApplyButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LoadStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersUserLimitNumericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WorkersUserLimitNumericUpDown);
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
            // WorkersUserLimitNumericUpDown
            // 
            this.WorkersUserLimitNumericUpDown.Location = new System.Drawing.Point(109, 21);
            this.WorkersUserLimitNumericUpDown.Name = "WorkersUserLimitNumericUpDown";
            this.WorkersUserLimitNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.WorkersUserLimitNumericUpDown.TabIndex = 4;
            this.WorkersUserLimitNumericUpDown.ValueChanged += new System.EventHandler(this.WokersUserLimitNumericUpDown_ValueChanged);
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
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(12, 139);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(168, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply!";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ApplyButton_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 165);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(193, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LoadStatusLabel
            // 
            this.LoadStatusLabel.Name = "LoadStatusLabel";
            this.LoadStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 187);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "rCluster Load Settings";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersUserLimitNumericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AdaptiveRadioButton;
        private System.Windows.Forms.RadioButton LockedRadioButton;
        private System.Windows.Forms.RadioButton FreeRadioButton;
        private System.Windows.Forms.RadioButton LimitedRadioButton;
        private System.Windows.Forms.NumericUpDown WorkersUserLimitNumericUpDown;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LoadStatusLabel;

    }
}

