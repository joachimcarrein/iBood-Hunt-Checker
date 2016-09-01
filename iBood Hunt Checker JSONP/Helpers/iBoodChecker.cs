using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace iBood_Hunt_Checker.Helpers
{
    public class iBoodChecker
    {
        private static iBoodChecker _iBoodChecker;
        public static iBoodChecker iBoodCheckerInstance { 
            get
            {
                if (_iBoodChecker == null)
                    _iBoodChecker = new iBoodChecker();
                return _iBoodChecker;
            }
            set
            {
                _iBoodChecker = value;
            }
        }

        public event EventHandler iBoodChanged;
        private BackgroundWorker bw = new BackgroundWorker();

        public iBoodChecker()
        {
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
        }

        public decimal IntervalCheck { get; set; }
        public string ShopText { get; set; }
        public DataSet CurrentSubSites { get; set; }

        public iBoodOffer CurrentOffer { get; set; }
        
        public void StartBackgroundWorker()
        {
            if (bw.IsBusy)
            {
                Debug.WriteLine("Already Running, exiting");
                return;
            }
            bw.RunWorkerAsync();
        }

        private void CheckIbood()
        {
            try
            {
                Debug.WriteLine("Running check");

                WebClient wc = new WebClient();

                string Offer = wc.DownloadString(String.Format(Properties.Settings.Default.OffersLocation, ShopText));
                string Stock = wc.DownloadString(String.Format(Properties.Settings.Default.StockLocation, ShopText));
                if (Stock.ToUpper().Contains("URL=HTTP"))
                    Stock = wc.DownloadString(InterpretValue(Stock, ";url=", @""">"));
                Dictionary<string, string> offerdict = (new JavaScriptSerializer()).Deserialize<Dictionary<string, string>>(Offer);

                CheckDownloadedData(offerdict, Stock);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Occurred: " + ex.Message);
                //bw.CancellationPending
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckIbood();
        }

        private void CheckDownloadedData(Dictionary<string, string> OfferJSON, string StockJSON)
        {
            iBoodOffer newOffer = new iBoodOffer();
            newOffer.ID = InterpretValue(OfferJSON[Properties.Settings.Default.IDKey], Properties.Settings.Default.IDStart, Properties.Settings.Default.IDEnd);
            newOffer.Description = InterpretValue(OfferJSON[Properties.Settings.Default.TitleKey], Properties.Settings.Default.TitleStart, Properties.Settings.Default.TitleEnd);
            newOffer.PermaLink = InterpretValue(OfferJSON[Properties.Settings.Default.PermalinkKey], Properties.Settings.Default.PermalinkStart, Properties.Settings.Default.PermalinkEnd);
            newOffer.ImageURL = InterpretValue(OfferJSON[Properties.Settings.Default.ImageKey], Properties.Settings.Default.ImageStart, Properties.Settings.Default.ImageEnd);
            newOffer.ImageURL = AddHttpTag(newOffer.ImageURL);
            newOffer.OldPrice = InterpretValue(OfferJSON[Properties.Settings.Default.OldPriceKey], Properties.Settings.Default.OldPriceStart, Properties.Settings.Default.OldPriceEnd);
            newOffer.NewPrice = InterpretValue(OfferJSON[Properties.Settings.Default.NewPriceKey], Properties.Settings.Default.NewPriceStart, Properties.Settings.Default.NewPriceEnd);
            try
            {
                newOffer.PercentRemaining = Convert.ToInt32(InterpretValue(StockJSON, String.Format(Properties.Settings.Default.StockStart, newOffer.ID, newOffer.ShopID), Properties.Settings.Default.StockEnd));
            }
            catch
            { }

            if (!newOffer.Equals(CurrentOffer))
            {
                CurrentOffer = newOffer;
                Debug.WriteLine("New Offer found, showing offer");
                iBoodChanged(typeof(iBoodChecker), null);
            }
        }

        private string AddHttpTag(string checkURL)
        {
            if (!checkURL.ToLower().Contains("http://"))
                return "http://" + checkURL;

            return checkURL;
        }

        private string InterpretValue(string Value, string StartTag, string EndTag)
        {
            if ((String.IsNullOrEmpty(StartTag)) & (String.IsNullOrEmpty(EndTag)))
                return WebUtility.HtmlDecode(Value);

            StartTag = ChangeEncoding(StartTag, Encoding.UTF8, Encoding.Default);
            EndTag = ChangeEncoding(EndTag, Encoding.UTF8, Encoding.Default);

            int startPos = 0;
            int endPos = Value.Length;

            if (!String.IsNullOrEmpty(StartTag))
                startPos = Value.IndexOf(StartTag, StringComparison.OrdinalIgnoreCase) + StartTag.Length;

            if (!String.IsNullOrEmpty(EndTag))
                endPos = Value.Substring(startPos).IndexOf(EndTag, StringComparison.OrdinalIgnoreCase);

            if (endPos == -1)
                return "";

            return WebUtility.HtmlDecode(Value.Substring(startPos, endPos));
        }

        private string ChangeEncoding(string source, Encoding sourceEncoding, Encoding targetEncoding)
        {
            var bytes = sourceEncoding.GetBytes(source);
            return targetEncoding.GetString(bytes);
        }
    }
}
