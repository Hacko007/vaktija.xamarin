using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using vaktija.xamarin.Models;
using Xamarin.Forms;

namespace vaktija.xamarin.ViewModels
{
    public class VaktijaViewModel : BaseViewModel
    {
        private DateTime _mjesec;
        private string _mjesecLabel;

        public VaktijaViewModel()
        {
            BihCultureInfo = new CultureInfo("bs-Latn-BA");
            Mjesec = DateTime.Today;
            UpdateMjesec();
            Takvim = new Takvim();
            ProsliMjesecCommand = new Command(() => PromjeniMjesec(false));
            SlijedeciMjesecCommand = new Command(() => PromjeniMjesec(true));
            Task.Run(GenerisiDaneZaMjesecAsync);
        }

        private CultureInfo BihCultureInfo { get; }

        public Takvim Takvim { get; set; }
        

        public DateTime Mjesec
        {
            get => _mjesec;
            set => SetProperty(ref _mjesec, value);
        }

        public string MjesecLabel
        {
            get => _mjesecLabel;
            set => SetProperty(ref _mjesecLabel, value);
        }

        public ObservableCollection<Dan> Dani { get; set; } = new ObservableCollection<Dan>();

        public ICommand ProsliMjesecCommand { get; }

        public ICommand SlijedeciMjesecCommand { get; }

        private void UpdateMjesec()
        {
            
            MjesecLabel = Mjesec.ToString("MMMM yyyy", BihCultureInfo);
        }

        private void PromjeniMjesec(bool povecaj)
        {

            Mjesec = Mjesec.AddMonths(povecaj ? 1 : -1);
            
            UpdateMjesec();
            GenerisiDaneZaMjesecAsync().ConfigureAwait(false);
        }

        private async Task GenerisiDaneZaMjesecAsync()
        {
            await Task.Run((() =>
            {
                try
                {
                    Dani.Clear();
                    foreach (var dan in Takvim.Vremena
                        .Where(x => x.Datum.Month == Mjesec.Month)
                        .OrderBy(d => d.Datum.Day))
                    {
                        Dani.Add(dan);
                    }

                    OnPropertyChanged(nameof(Dani));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }));

        }
    }
}