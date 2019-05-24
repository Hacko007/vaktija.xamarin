using System;
using System.Globalization;

namespace vaktija.xamarin.Models
{
    public class Praznik
    {
        public Praznik(Kalendar kalendar, int mjesec, int dan, string opis)
        {
            Kalendar = kalendar;
            Dan = dan;
            Mjesec = mjesec;
            Opis = opis;
        }

        public Kalendar Kalendar { get; set; }
        public int Dan { get; set; }
        public int Mjesec { get; set; }
        public string Opis { get; set; }

        public bool JeliOvoDanas(Kalendar kalendar)
        {
            try
            {
                if (kalendar == Kalendar.Georgianski)
                    return Kalendar == kalendar &&
                           DateTime.Today.Day == Dan &&
                           DateTime.Today.Month == Mjesec;


                if (int.TryParse(DateTime.Today.ToString("dd", new CultureInfo("ar-SA")), out int dan)
                    && int.TryParse(DateTime.Today.ToString("MM", new CultureInfo("ar-SA")), out int mjesc))
                {
                    return dan == Dan &&
                           mjesc == Mjesec;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
    public enum Kalendar
    {
        Georgianski,
        Hidzretski
    }
}