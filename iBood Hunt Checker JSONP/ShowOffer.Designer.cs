namespace iBood_Hunt_Checker
{
    partial class ShowOffer
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
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblSoldOut = new System.Windows.Forms.Label();
            this.PrgRemaining = new System.Windows.Forms.ProgressBar();
            this.lblDescription = new System.Windows.Forms.LinkLabel();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.lblOldPrice = new System.Windows.Forms.Label();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemaining
            // 
            this.lblRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblRemaining.Location = new System.Drawing.Point(8, 425);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(41, 33);
            this.lblRemaining.TabIndex = 17;
            this.lblRemaining.Text = "0 %";
            this.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoldOut
            // 
            this.lblSoldOut.AutoSize = true;
            this.lblSoldOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldOut.Location = new System.Drawing.Point(4, 215);
            this.lblSoldOut.Name = "lblSoldOut";
            this.lblSoldOut.Size = new System.Drawing.Size(320, 76);
            this.lblSoldOut.TabIndex = 16;
            this.lblSoldOut.Text = "Sold Out!";
            this.lblSoldOut.Visible = false;
            // 
            // PrgRemaining
            // 
            this.PrgRemaining.Location = new System.Drawing.Point(55, 435);
            this.PrgRemaining.Name = "PrgRemaining";
            this.PrgRemaining.Size = new System.Drawing.Size(259, 21);
            this.PrgRemaining.Step = 1;
            this.PrgRemaining.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(14, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(300, 97);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.TabStop = true;
            this.lblDescription.Text = "DESCRIPTION";
            this.lblDescription.UseMnemonic = false;
            this.lblDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDescription_LinkClicked);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(153, 412);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(19, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "=>";
            // 
            // lblNewPrice
            // 
            this.lblNewPrice.AutoSize = true;
            this.lblNewPrice.Location = new System.Drawing.Point(246, 412);
            this.lblNewPrice.Name = "lblNewPrice";
            this.lblNewPrice.Size = new System.Drawing.Size(68, 13);
            this.lblNewPrice.TabIndex = 12;
            this.lblNewPrice.Text = "NEW PRICE";
            // 
            // lblOldPrice
            // 
            this.lblOldPrice.AutoSize = true;
            this.lblOldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPrice.Location = new System.Drawing.Point(18, 412);
            this.lblOldPrice.Name = "lblOldPrice";
            this.lblOldPrice.Size = new System.Drawing.Size(64, 13);
            this.lblOldPrice.TabIndex = 11;
            this.lblOldPrice.Text = "OLD PRICE";
            // 
            // pbxImage
            // 
            this.pbxImage.Location = new System.Drawing.Point(14, 109);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(300, 300);
            this.pbxImage.TabIndex = 10;
            this.pbxImage.TabStop = false;
            this.pbxImage.Click += new System.EventHandler(this.pbxImage_Click);
            // 
            // ShowOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 467);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblSoldOut);
            this.Controls.Add(this.PrgRemaining);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblNewPrice);
            this.Controls.Add(this.lblOldPrice);
            this.Controls.Add(this.pbxImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowOffer";
            this.Text = "Current Offer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShowOffer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblRemaining;
        internal System.Windows.Forms.Label lblSoldOut;
        internal System.Windows.Forms.ProgressBar PrgRemaining;
        internal System.Windows.Forms.LinkLabel lblDescription;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblNewPrice;
        internal System.Windows.Forms.Label lblOldPrice;
        internal System.Windows.Forms.PictureBox pbxImage;
    }
}