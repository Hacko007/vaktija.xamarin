using Xamarin.Forms;

namespace vaktija.xamarin.Models
{
    public class StilVremena
    {
        public Color TextColor { get; set; }
        public Color PozadinaColor { get; set; }
        public Color OutlineColor { get; set; }

        public static readonly StilVremena Standard = new StilVremena(){PozadinaColor = Color.Transparent, TextColor = Color.Black,OutlineColor = Color.DarkSeaGreen};
        public static readonly StilVremena VakatJe = new StilVremena(){PozadinaColor = Color.DarkSeaGreen, TextColor = Color.DarkGreen, OutlineColor = Color.DarkKhaki};
        public static readonly StilVremena ProsaoVakat = new StilVremena(){PozadinaColor = Color.Bisque, TextColor = Color.DarkGray,OutlineColor = Color.DimGray};
    }
}