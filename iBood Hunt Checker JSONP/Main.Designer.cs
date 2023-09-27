namespace iBood_Hunt_Checker
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckForNewOfferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCurrentofferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblTimeSinceLastCheck = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnShowAgain = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.NotifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "iBood Hunt Checker";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFormToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.CheckForNewOfferToolStripMenuItem,
            this.ShowCurrentofferToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.ExitToolStripMenuItem});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.Size = new System.Drawing.Size(179, 104);
            // 
            // ShowFormToolStripMenuItem
            // 
            this.ShowFormToolStripMenuItem.Name = "ShowFormToolStripMenuItem";
            this.ShowFormToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ShowFormToolStripMenuItem.Text = "&Show form";
            this.ShowFormToolStripMenuItem.Click += new System.EventHandler(this.ShowFormToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // CheckForNewOfferToolStripMenuItem
            // 
            this.CheckForNewOfferToolStripMenuItem.Name = "CheckForNewOfferToolStripMenuItem";
            this.CheckForNewOfferToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.CheckForNewOfferToolStripMenuItem.Text = "&Check for new offer";
            this.CheckForNewOfferToolStripMenuItem.Click += new System.EventHandler(this.CheckForNewOfferToolStripMenuItem_Click);
            // 
            // ShowCurrentofferToolStripMenuItem
            // 
            this.ShowCurrentofferToolStripMenuItem.Name = "ShowCurrentofferToolStripMenuItem";
            this.ShowCurrentofferToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ShowCurrentofferToolStripMenuItem.Text = "Show current &offer";
            this.ShowCurrentofferToolStripMenuItem.Click += new System.EventHandler(this.ShowCurrentofferToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F4";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ExitToolStripMenuItem.Text = "&Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // nudInterval
            // 
            this.nudInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::iBood_Hunt_Checker.Properties.Settings.Default, "CheckInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudInterval.Location = new System.Drawing.Point(134, 7);
            this.nudInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(71, 20);
            this.nudInterval.TabIndex = 11;
            this.nudInterval.Value = global::iBood_Hunt_Checker.Properties.Settings.Default.CheckInterval;
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(105, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Check Interval (sec):";
            // 
            // lblTimeSinceLastCheck
            // 
            this.lblTimeSinceLastCheck.AutoSize = true;
            this.lblTimeSinceLastCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTimeSinceLastCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeSinceLastCheck.Location = new System.Drawing.Point(135, 39);
            this.lblTimeSinceLastCheck.Name = "lblTimeSinceLastCheck";
            this.lblTimeSinceLastCheck.Size = new System.Drawing.Size(14, 13);
            this.lblTimeSinceLastCheck.TabIndex = 15;
            this.lblTimeSinceLastCheck.Text = "0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label2.Location = new System.Drawing.Point(16, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(111, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Time until next check:";
            // 
            // btnShowAgain
            // 
            this.btnShowAgain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAgain.Location = new System.Drawing.Point(15, 94);
            this.btnShowAgain.MaximumSize = new System.Drawing.Size(194, 23);
            this.btnShowAgain.MinimumSize = new System.Drawing.Size(194, 23);
            this.btnShowAgain.Name = "btnShowAgain";
            this.btnShowAgain.Size = new System.Drawing.Size(194, 23);
            this.btnShowAgain.TabIndex = 13;
            this.btnShowAgain.Text = "Show current offer again";
            this.btnShowAgain.UseVisualStyleBackColor = true;
            this.btnShowAgain.Click += new System.EventHandler(this.btnShowAgain_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Location = new System.Drawing.Point(15, 65);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(194, 23);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "Check for new offer now";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 131);
            this.ContextMenuStrip = this.NotifyMenu;
            this.Controls.Add(this.lblTimeSinceLastCheck);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnShowAgain);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(231, 170);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iBood Hunt Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.NotifyMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        internal System.Windows.Forms.ContextMenuStrip NotifyMenu;
        internal System.Windows.Forms.ToolStripMenuItem ShowFormToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem CheckForNewOfferToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ShowCurrentofferToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.NumericUpDown nudInterval;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblTimeSinceLastCheck;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnShowAgain;
        internal System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Timer Timer;
    }
}

