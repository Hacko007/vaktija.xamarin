using System;
using System.Threading;
using System.Threading.Tasks;
using vaktija.xamarin.Models;
using Xamarin.Forms.PlatformConfiguration;

namespace vaktija.xamarin.ViewModels
{
    public class DanasViewModel : BaseViewModel
    {
        private Danas _danas;
        private Dan _dan;

        public DanasViewModel()
        {
            Title = "Danas";
            Takvim = new Takvim();
            Dan = Takvim.Danas;
            Console.WriteLine(Dan.AksamS);
            Task.Run(PokreniVaktijuAsync);
        }

        private Takvim Takvim { get; set; }

        public Dan Dan
        {
            get => _dan;
            set => SetProperty(ref _dan , value);
        }

        public Danas Danas
        {
            get => _danas;
            set =>SetProperty(ref  _danas , value);
        }

        private async Task PokreniVaktijuAsync()
        {
            while (true)
            {
                await PostaviVrijeme();
                Thread.Sleep(1000);
            }
        }


        private async Task PostaviVrijeme()
        {


            await Task.Run(
                () =>
                {
                    try
                    {
                        Dan = Takvim.Danas;
                        Danas = new Danas();
                        Console.WriteLine(Dan.AksamS);
                        //var glavniSat = FindViewById<TextView>(Resource.Id.GlavniSat);
                        //glavniSat.Text = DateTime.Now.ToString("T");
                        //Console.WriteLine($"glavni sat:{glavniSat.Text}");
                        //var datum = FindViewById<TextView>(Resource.Id.Datum);
                        //datum.Text = Datum.Datum;

                        //var hidzretski = FindViewById<TextView>(Resource.Id.HidzretskiDatum);
                        //hidzretski.Text = DatumHidzretski.Datum;


                        //var praznik = FindViewById<TextView>(Resource.Id.Praznik);
                        //var vjerskiPraznik = Takvim.VjerskiPraznik;
                        //var drzavniPraznik = Takvim.DrzavniPraznik;

                        //praznik.Text = (vjerskiPraznik == null && drzavniPraznik == null)
                        //    ? ""
                        //    : ((vjerskiPraznik != null && drzavniPraznik != null)
                        //        ? $"{vjerskiPraznik} - {drzavniPraznik}"
                        //        : $"{vjerskiPraznik}{drzavniPraznik}");

                        //if (Danas == null) return;

                        //SetZora();
                        //SetStyle(FindViewById<TextView>(Resource.Id.Podne), Danas.Podne, Danas.Ikindija);
                        //SetStyle(FindViewById<TextView>(Resource.Id.Ikindija), Danas.Ikindija, Danas.Aksam);
                        //SetStyle(FindViewById<TextView>(Resource.Id.Aksam), Danas.Aksam, Danas.Jacija);
                        //SetJacija();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
        }

        //private static void SetTime(TextView view, TimeSpan time)
        //{
        //    view.Text = $"{time:hh\\:mm}"; ;
        //}

        //private static void SetStyle(TextView view, TimeSpan pocetak, TimeSpan kraj)
        //{
        //    var sad = DateTime.Now.TimeOfDay;
        //    SetTime(view, pocetak);
        //    if (pocetak > sad)
        //        view.SetTextColor(Android.Graphics.Color.Black);
        //    else if (pocetak <= sad && sad <= kraj)
        //        view.SetTextColor(Android.Graphics.Color.Green);
        //    else
        //        view.SetTextColor(Android.Graphics.Color.Gray);
        //}


        //private void SetZora()
        //{
        //    var zora = FindViewById<TextView>(Resource.Id.Zora);
        //    var izlazak = FindViewById<TextView>(Resource.Id.Izlazak);
        //    var sad = DateTime.Now.TimeOfDay;
        //    SetTime(zora, Danas.Zora);
        //    SetTime(izlazak, Danas.Sabah);
        //    if (Danas.Zora > sad)
        //    {
        //        zora.SetTextColor(Android.Graphics.Color.Black);
        //    }
        //    else if (Danas.Zora <= sad && sad <= Danas.Sabah)
        //    {
        //        zora.SetTextColor(Android.Graphics.Color.Black);
        //        izlazak.SetTextColor(Android.Graphics.Color.Green);
        //    }
        //    else
        //    {
        //        zora.SetTextColor(Android.Graphics.Color.Gray);
        //        izlazak.SetTextColor(Android.Graphics.Color.Gray);
        //    }

        //}

        //private void SetJacija()
        //{
        //    var jacija = FindViewById<TextView>(Resource.Id.Jacija);
        //    SetTime(jacija, Danas.Jacija);
        //    var sad = DateTime.Now.TimeOfDay;
        //    if (Danas.Jacija > sad)
        //        jacija.SetTextColor(Android.Graphics.Color.Black);
        //    else if (Danas.Jacija <= sad || sad < Danas.Zora)
        //        jacija.SetTextColor(Android.Graphics.Color.Green);
        //}
    }
}