using BankaHesaplari.Config;

namespace BankaHesaplari.Models
{
    public abstract class Hesap
    {
        public int Id { get; set; }
        public string Sahibi { get; set; }
        
        public decimal Miktar
        {
            get
            {
                decimal sonuc = 0;
                foreach (Islem islem in _islemler)
                {
                    sonuc += islem.Miktar;
                }
                return sonuc;
            }
        }
        private List<Islem> _islemler;

        public Hesap(string sahibi, decimal miktar = 0)
        {
            Id = BankaConfig.BaslangicId++;
            Sahibi = sahibi;
            _islemler = new List<Islem>();
            ParaYatir(miktar, DateTime.Now, BankaConfig.IlkHesapMesaji);
        }

        public virtual IslemSonucu ParaYatir(decimal yatirilacakMiktar, DateTime islemTarih, string islemAciklamasi)
        {
            if (yatirilacakMiktar < 0)
                return IslemSonucu.NegatifMiktar;
            Islem islem = new Islem(yatirilacakMiktar, islemTarih, islemAciklamasi);
            _islemler.Add(islem);
            return IslemSonucu.IslemBasarili;
        }

        public IslemSonucu ParaCek(decimal cekilecekMiktar, DateTime islemTarih, string islemAciklamasi)
        {
            IslemSonucu islemSonucu = IslemSonucu.IslemBasarili;

            if (cekilecekMiktar <= 0)
            {
                islemSonucu = IslemSonucu.NegatifMiktar;
            }
            else if (Miktar - cekilecekMiktar < 0)
            {
                islemSonucu = IslemSonucu.YetersizBakiye;
            }
            else
            {
                Islem islem = new Islem(-cekilecekMiktar, islemTarih, islemAciklamasi);
                _islemler.Add(islem);
                islemSonucu = IslemSonucu.IslemBasarili;
            }
            return islemSonucu;
        }
    }
}
