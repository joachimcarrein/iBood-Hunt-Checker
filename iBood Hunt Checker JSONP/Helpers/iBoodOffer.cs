using System;
using System.Drawing;
using System.Net;

namespace iBood_Hunt_Checker.Helpers
{
    public class iBoodOffer : IEquatable<iBoodOffer>
    {

        public iBoodOffer()
        {
            PercentRemaining = 100;
            ShopID = 0;
            SoldOut = false;
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public string OldPrice { get; set; }
        public string NewPrice { get; set; }
        public string ImageURL { get; set; }
        public string PermaLink { get; set; }
        public bool SoldOut { get; set; }
        public Int32 PercentRemaining { get; set; }
        public Int32 ShopID { get; set; }

        public Image OfferImage()
        {
            if (String.IsNullOrWhiteSpace(ImageURL))
            {
                return null;
            }

            try
            {
                WebRequest req = WebRequest.Create(ImageURL);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Image im = Image.FromStream(resp.GetResponseStream());
                resp.Close();
                return im;
            }
            catch
            {
                return null;
            }
        }

        public void ExecutePermaLink()
        {
            if (!String.IsNullOrWhiteSpace(PermaLink))
                System.Diagnostics.Process.Start(PermaLink);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(iBoodOffer other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if ((ID == other.ID) & (Description.Equals(other.Description)))
            {
                return true;
            }

            return false;
        }
    }
}
