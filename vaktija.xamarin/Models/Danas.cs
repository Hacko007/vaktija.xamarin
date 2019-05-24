using System;
using System.Globalization;

namespace vaktija.xamarin.Models
{
    public sealed class Danas
    {
        private CultureInfo ArabCultureInfo { get; set; }
        private CultureInfo BihCultureInfo { get; set; }

        public string Datum { get; set; }
        public string DatumHidzretski { get; set; }
        public string DrzavniPraznik { get; set; }
        public string HidzretskiPraznik { get; set; }

        public Danas()
        {
            Datum = "";
            DatumHidzretski = "";
            DrzavniPraznik = "";
            HidzretskiPraznik = "";
            ArabCultureInfo = new CultureInfo("ar-SA");
            BihCultureInfo = new CultureInfo("bs-Latn-BA");
            SetDatum();
            SetHidzretskiDatum();
        }

        public void SetDatum()
        {
            var danas = DateTime.Today.ToString("D", BihCultureInfo);
            try
            {
                Datum = BihCultureInfo.TextInfo.ToTitleCase(danas);
            }
            catch
            {
                Datum = danas;
            }
        }

        public void SetHidzretskiDatum()
        {
            DatumHidzretski = DateTime.Today.ToString("D", ArabCultureInfo);
        }

    }
}