using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
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

                var url = new Uri("https://api.ibood.io/search/hunt");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjE1YzJiNDBhYTJmMzIyNzk4NjY2YTZiMzMyYWFhMDNhNjc3MzAxOWIiLCJ0eXAiOiJKV1QifQ.eyJuYW1lIjoiSm9hY2hpbSBDYXJyZWluIiwiaWQiOiIwOTM0OWJmMy1jN2M4LTVmYjgtOGI3OC1mYzMzZDkxYzEyZjEiLCJ1c2VyIjoiam9hY2hpbS5jYXJyZWluQGdtYWlsLmNvbSIsInNjb3BlcyI6WyJiYXNpYyIsImN1c3RvbWVyIl0sInRlbmFudCI6eyJpZCI6ImVhZmIzZWYyLWUxYmEtNGYwMS1iNjdhLWIwNDQ3YmVhNzRlYiIsIm5hbWUiOiJpYm9vZCJ9LCJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vaWJleC1wcmQtaWRlbnRpdHktMjdjOCIsImF1ZCI6ImliZXgtcHJkLWlkZW50aXR5LTI3YzgiLCJhdX…OmZhbHNlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7ImVtYWlsIjpbImpvYWNoaW0uY2FycmVpbkBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJwYXNzd29yZCIsInRlbmFudCI6Imlib29kLTg1M3lwIn19.kHGlPKlpP9gOJSbGWCVhOKu4k_vdL5BrXmHNbdA6cTVBmCS61Ljoc276qe2NkRxuxO0uh-ZjKe5FIhacyGCX1S1DoZlLvoQgWwBuPC6qJkTogWY1q4yYBzVNxBqa66yYNLKSgYS7Eg7EZFlbKReoJWsAliy8m9Ziw33u0aSZPSrSnLqn38NvbuEvv-NCmGlnPX9p6ZXTkF4O5ds8qWOYv_nXw83o_CSQAZNoEQ1ATyIa6NzThfKgX1eSuhiy6f4xQbv66nPlWvoYFurui0e0SF5_nKMDc9eiioTLoKYsPxxj4WMwfVsW31ibublywVihNlEX1sJN9jtvZ6NGOC5HaA");
                client.DefaultRequestHeaders.Add("Ibex-Shop-Id", "52e47183-4a24-57fa-bef0-f82972e1f5ac");
                client.DefaultRequestHeaders.Add("Ibex-Tenant-Id", "eafb3ef2-e1ba-4f01-b67a-b0447bea74eb");

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    CheckDownloadedDataFromApi(obj.data.items[0].hunt);
                }

                //WebClient wc = new WebClient();

                //string Offer = wc.DownloadString(String.Format(Properties.Settings.Default.OffersLocation, ShopText));
                //string Stock = wc.DownloadString(String.Format(Properties.Settings.Default.StockLocation, ShopText));
                //if (Stock.ToUpper().Contains("URL=HTTP"))
                //    Stock = wc.DownloadString(InterpretValue(Stock, ";url=", @""">"));
                //Dictionary<string, string> offerdict = (new JavaScriptSerializer()).Deserialize<Dictionary<string, string>>(Offer);

                //CheckDownloadedData(offerdict, Stock);
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

        private void CheckDownloadedDataFromApi(dynamic huntInfo)
        {
            var url = $"https://www.ibood.com/offers/nl/s-be/o/{huntInfo.slug}/{huntInfo.classicOfferId}";

            iBoodOffer newOffer = new iBoodOffer();
            newOffer.ID = huntInfo.classicOfferId;
            newOffer.Description = huntInfo.title;
            newOffer.PermaLink = url;
            newOffer.ImageURL = huntInfo.image;            
            newOffer.OldPrice = huntInfo.referencePrice.value;
            newOffer.NewPrice = huntInfo.price.value;          

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

            Value = ChangeEncoding(Value, Encoding.Default, Encoding.UTF8);

            if ((String.IsNullOrEmpty(StartTag)) & (String.IsNullOrEmpty(EndTag)))
                return WebUtility.HtmlDecode(Value);

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
