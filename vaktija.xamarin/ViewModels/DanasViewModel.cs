using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using vaktija.xamarin.Models;

namespace vaktija.xamarin.ViewModels
{
    public class DanasViewModel : BaseViewModel
    {
        private Danas _danas;
        private Dan _dan;
        private ObservableCollection<Vakat> _vremenaZaDanas;
        private string _praznik;
        private bool _showPraznik;
        private DateTime _sat;

        public DanasViewModel()
        {
            Title = "Vaktija za danas";
            Takvim = new Takvim();
            Dan = Takvim.Danas;
            Task.Run(PokreniVaktijuAsync);
        }

        private Takvim Takvim { get; set; }

        public DateTime Sat
        {
            get => _sat;
            set => SetProperty(ref _sat, value);
        }

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

        public ObservableCollection<Vakat> VremenaZaDanas
        {
            get => _vremenaZaDanas;
            set => SetProperty(ref _vremenaZaDanas, value);
        }

        public string Praznik
        {
            get => _praznik;
            set =>SetProperty(ref _praznik, value);
        }

        public bool ShowPraznik
        {
            get => _showPraznik;
            set => SetProperty(ref _showPraznik , value);
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
                        Sat = DateTime.Now;
                        Dan.Sat = Sat;
                        Danas = new Danas();
                        VremenaZaDanas = Dan.GetVremenaZaDanas();

                        var vjerskiPraznik = Takvim.VjerskiPraznik;
                        var drzavniPraznik = Takvim.DrzavniPraznik;

                        Praznik= (vjerskiPraznik == null && drzavniPraznik == null)
                            ? null
                            : ((vjerskiPraznik != null && drzavniPraznik != null)
                                ? $"{vjerskiPraznik} - {drzavniPraznik}"
                                : $"{vjerskiPraznik}{drzavniPraznik}");

                        ShowPraznik = Praznik != null;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
        }

       
    }

    
}