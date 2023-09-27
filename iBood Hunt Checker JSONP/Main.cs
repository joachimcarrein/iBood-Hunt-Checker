using iBood_Hunt_Checker.Helpers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace iBood_Hunt_Checker
{
    public partial class Main : Form
    {
        private bool doExitForm = false;

        #region Form Initializing
        public Main()
        {
            InitializeComponent();
            LoadOldSettings();
        }
        #endregion

        #region Events
        private void Main_Load(object sender, EventArgs e)
        {
            CheckiBood();
            iBoodChecker.iBoodCheckerInstance.iBoodChanged += iBoodChecker_iBoodChanged;
            Timer.Start();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!doExitForm)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                e.Cancel = true;
                return;
            }
            else
            {
                Properties.Settings.Default.Save();
                NotifyIcon.Visible = false;
                GeneralFunctions.ExitApplication();
            }
        }
        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            iBoodChecker.iBoodCheckerInstance.IntervalCheck = nudInterval.Value;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckiBood();
        }
        private void btnShowAgain_Click(object sender, EventArgs e)
        {
            ShowAgain();
        }
        void iBoodChecker_iBoodChanged(object sender, EventArgs e)
        {
            ShowAgain();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTimeSinceLastCheck.Text = (Convert.ToInt32(lblTimeSinceLastCheck.Text) - 1).ToString();
            if (Convert.ToInt32(lblTimeSinceLastCheck.Text) <= 0)
            {
                CheckiBood();
                GC.Collect();
            }
        }
        #endregion

        #region Loaders

        private void LoadOldSettings()
        {
            if (Properties.Settings.Default.ReloadOldSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.ReloadOldSettings = false;
                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.Reload();
        }
        #endregion

        #region ContextMenu Events
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doExit();
        }
        private void ShowFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
        private void CheckForNewOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckiBood();
        }
        private void ShowCurrentofferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAgain();
        }
        #endregion

        #region Functions
        private void ShowForm()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        private void doExit()
        {
            doExitForm = true;
            this.Close();
        }
        private void ShowAgain()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(ShowAgain));
            }
            else
            {
                ShowOffer so = new ShowOffer();
                so.Show();
            }
        }
        private void CheckiBood()
        {
            lblTimeSinceLastCheck.Text = nudInterval.Value.ToString();
            iBoodChecker.iBoodCheckerInstance.StartBackgroundWorker();
        }
        #endregion

    }
}
