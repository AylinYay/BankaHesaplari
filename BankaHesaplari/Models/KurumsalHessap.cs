namespace BankaHesaplari.Models
{
    internal class KurumsalHessap : Hesap
    {
        public string Kurum{ get; }

        public KurumsalHessap(string sahibi, string kurum, decimal miktar = 0) : base(sahibi, miktar)
        {
            Kurum = kurum;
        }

        public override IslemSonucu ParaYatir(decimal yatirilacakMiktar, DateTime islemTarih, string islemAciklamasi)
        {           
            yatirilacakMiktar = yatirilacakMiktar - yatirilacakMiktar * 0.01m;
            return base.ParaYatir(yatirilacakMiktar, islemTarih, islemAciklamasi);
            
        }
    }
}
