namespace BankaHesaplari.Models
{
    public class Islem
    {
        public decimal Miktar { get; }
        public DateTime Tarih { get; }
        public string Aciklama { get; }

        public Islem(decimal miktar, DateTime tarih, string aciklama)
        {
            Miktar = miktar;
            Tarih = tarih;
            Aciklama = aciklama;
        }
    }
}
