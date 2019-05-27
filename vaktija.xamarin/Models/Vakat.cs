using System;

namespace vaktija.xamarin.Models
{
    public class Vakat
    {
        public string Naziv { get; set; }
        public TimeSpan Vrijeme { get; set; }
        public StilVremena StilVremena { get; set; }
    }
}