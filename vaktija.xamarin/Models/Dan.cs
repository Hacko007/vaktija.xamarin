using System;

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
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public DateTime Datum { get; set; }
        public TimeSpan Zora { get; set; }
        public TimeSpan Sabah { get; set; }
        public TimeSpan Podne { get; set; }
        public TimeSpan Ikindija { get; set; }
        public TimeSpan Aksam { get; set; }
        public string AksamS => Aksam.ToString("hh\\:mm");
        public TimeSpan Jacija { get; set; }
    }
}