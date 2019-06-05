using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace vaktija.xamarin.Models
{
    public class Dan
    {
        public Dan(int mjesec, int dan, int zorah, int zoram, int sabahh, int sabahm, int podneh, int podnem,
            int ikindijah, int ikindijam, int aksamh, int aksamm, int jacijah, int jacijam)
        {
            try
            {
                Datum = new DateTime(DateTime.Today.Year, mjesec, dan);
                Zora = new TimeSpan(zorah, zoram, 0);
                Sabah = new TimeSpan(sabahh, sabahm, 0);
                Podne = new TimeSpan(podneh, podnem, 0);
                Ikindija = new TimeSpan(ikindijah, ikindijam, 0);
                Aksam = new TimeSpan(aksamh, aksamm, 0);
                Jacija = new TimeSpan(jacijah, jacijam, 0);
                Sat = DateTime.Now;
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public DateTime Sat { get; set; }
        public DateTime Datum { get; set; }
        public string NazivDana => Datum.ToString("ddd", new CultureInfo("bs-Latn-BA"));
        public string DatumHidzretski => Datum.ToString("dd", new CultureInfo("ar-SA"));
        public TimeSpan Zora { get; set; }
        public TimeSpan Sabah { get; set; }
        public TimeSpan Podne { get; set; }
        public TimeSpan Ikindija { get; set; }
        public TimeSpan Aksam { get; set; }
        public TimeSpan Jacija { get; set; }
        private TimeSpan Ponoc => new TimeSpan(23,59,59);

        public FontAttributes IsDzuma =>
            Datum.DayOfWeek == DayOfWeek.Friday ? FontAttributes.Bold : FontAttributes.None;

        public Color DzumaBackground => Datum.DayOfWeek == DayOfWeek.Friday ? Color.DarkKhaki : Color.Transparent;

        public ObservableCollection<Vakat> GetVremenaZaDanas()
        {
            var result=new List<Vakat>()
            {
                new Vakat(){Naziv = "Zora", Vrijeme = Zora, StilVremena = GetStil(Zora,Sabah)},
                new Vakat(){Naziv = "Sabah", Vrijeme = Sabah, StilVremena = GetStil(Sabah,Podne)},
                new Vakat(){Naziv = "Podne", Vrijeme = Podne, StilVremena = GetStil(Podne,Ikindija)},
                new Vakat(){Naziv = "Ikindija", Vrijeme = Ikindija, StilVremena = GetStil(Ikindija,Aksam)},
                new Vakat(){Naziv = "Akšam", Vrijeme = Aksam, StilVremena = GetStil(Aksam,Jacija)},
                new Vakat(){Naziv = "Jacija", Vrijeme = Jacija, StilVremena = GetStil(Jacija, Ponoc)}
            };

            return new ObservableCollection<Vakat>(result);
        }

        private StilVremena GetStil(TimeSpan pocetak,TimeSpan kraj)
        {
            if(pocetak > Sat.TimeOfDay )
                return StilVremena.Standard;

            if (pocetak <= Sat.TimeOfDay && Sat.TimeOfDay < kraj)
                return StilVremena.VakatJe;

            return StilVremena.ProsaoVakat;
        }
    }
}