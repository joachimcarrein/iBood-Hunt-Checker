using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Policy;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

                var url = "https://api.ibood.io/event/events/live";

                XmlDocument apiHeaders;
                using (var wc = new WebClient())
                {
                    apiHeaders = new XmlDocument();
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                    apiHeaders.LoadXml(wc.DownloadString("https://raw.githubusercontent.com/joachimcarrein/iBood-Hunt-Checker/refs/heads/master/iBood%20Hunt%20Checker%20JSONP/Settings/ApiSettings.xml"));
                }

                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = DecompressionMethods.GZip;

                using (var client = new HttpClient(handler))
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                    foreach (XmlNode node in apiHeaders.SelectSingleNode("/headers").ChildNodes)
                    {
                        request.Headers.Add(node.Name, node.InnerText);
                    }

                    var response = client.SendAsync(request).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                        CheckDownloadedDataFromApi(obj.data.items[0].currentItem);
                    }
                }
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

        private void CheckDownloadedDataFromApi(dynamic huntInfo)
        {
            var url = $"https://www.ibood.com/offers/nl/s-be/o/{huntInfo.slug}/{huntInfo.offerItemClassicId}";
            var imageBase64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"gs://ibood-go-production-gcs-storage/images/source/{huntInfo.image.id}.{huntInfo.image.extension}"));
            var imageUrl = $"https://image.ibood.io/image/w1920a4-3/{imageBase64}";

            iBoodOffer newOffer = new iBoodOffer();
            newOffer.ID = huntInfo.offerItemClassicId;
            newOffer.Description = huntInfo.title;
            newOffer.PermaLink = url;
            newOffer.ImageURL = imageUrl;            
            newOffer.OldPrice = huntInfo.referencePrice.value;
            newOffer.NewPrice = huntInfo.price.value;          

            if (!newOffer.Equals(CurrentOffer))
            {
                CurrentOffer = newOffer;
                Debug.WriteLine("New Offer found, showing offer");
                iBoodChanged(typeof(iBoodChecker), null);
            }
        }
    }
}
