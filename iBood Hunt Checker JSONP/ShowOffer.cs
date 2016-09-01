using iBood_Hunt_Checker.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iBood_Hunt_Checker
{
    public partial class ShowOffer : Form
    {

        private iBoodOffer CurrentOffer;

        public ShowOffer()
        {
            InitializeComponent();
        }

        private void ShowOffer_Load(object sender, EventArgs e)
        {
            if (iBoodChecker.iBoodCheckerInstance.CurrentOffer == null)
                return;

            lblSoldOut.Visible = iBoodChecker.iBoodCheckerInstance.CurrentOffer.SoldOut;
            PrgRemaining.Value = iBoodChecker.iBoodCheckerInstance.CurrentOffer.PercentRemaining;
            lblRemaining.Text = iBoodChecker.iBoodCheckerInstance.CurrentOffer.PercentRemaining.ToString() + " %";
            lblRemaining.BackColor = Color.Transparent;
            lblRemaining.ForeColor = Color.Black;
            lblDescription.Text = iBoodChecker.iBoodCheckerInstance.CurrentOffer.Description;
            lblNewPrice.Text = iBoodChecker.iBoodCheckerInstance.CurrentOffer.NewPrice;
            lblOldPrice.Text = iBoodChecker.iBoodCheckerInstance.CurrentOffer.OldPrice;
            CurrentOffer = iBoodChecker.iBoodCheckerInstance.CurrentOffer;
            LoadImage();
        }

        private void LoadImage()
        {
            Image im = iBoodChecker.iBoodCheckerInstance.CurrentOffer.OfferImage();
            if (im == null)
            {
                pbxImage.Visible = false;
            }
            else
            {
                pbxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbxImage.Image = im;
            }
        }

        private void lblDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentOffer != null)
                CurrentOffer.ExecutePermaLink();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pbxImage_Click(object sender, EventArgs e)
        {
            lblDescription_LinkClicked(lblDescription, new LinkLabelLinkClickedEventArgs(lblDescription.Links[0], MouseButtons.Left));
        }
    }
}
