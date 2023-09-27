using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

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
    }
}
