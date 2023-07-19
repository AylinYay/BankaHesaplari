using BankaHesaplari.Config;
using BankaHesaplari.Models;

namespace BankaHesaplari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IslemSonucu islemSonucu;
            KurumsalHessap hesap1 = new KurumsalHessap("Aylin", "iea", 1000);
            islemSonucu = hesap1.ParaYatir(100, DateTime.Now.AddDays(-1), "Dün için para yatırma.");
            islemSonucu = hesap1.ParaYatir(500, DateTime.Now, "Bugün için para yatırma.");

            islemSonucu = hesap1.ParaCek(1000, DateTime.Now, "Bugün için para çekme.");

            Console.WriteLine(BankaConfig.IslemSonucuGetir(islemSonucu) + "\nBakiye: " + hesap1.Miktar);
        }
    }
}