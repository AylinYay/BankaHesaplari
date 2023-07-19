using BankaHesaplari.Models;

namespace BankaHesaplari.Config
{
    public static class BankaConfig    // tüm uygulama için paylaşılan bir alana ihtiyacımız olduğundan "static" tanımladık.
    {
        public static int BaslangicId { get; set; } = 1;
        public static string IlkHesapMesaji => "İlk hesap açımı";
        public static string IslemSonucuGetir(IslemSonucu islemSonucu)
        {
            return islemSonucu == IslemSonucu.IslemBasarili ? "İşlem başarılı" : islemSonucu == IslemSonucu.YetersizBakiye ? "Yetersiz bakiye!" : "Negatif Miktar!";
        }
    }
}
