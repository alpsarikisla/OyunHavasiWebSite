using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Makale
    {
        public int ID { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public int Yazar_ID { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string KapakResim { get; set; }
        public int GoruntulemeSayi { get; set; }
        public int BegeniSayi { get; set; }
        public DateTime EklemeTarih { get; set; }
        public string EklemeTarihStr { get; set; }
        public bool YayinDurumu { get; set; }
        public string YayinDurumuStr { get; set; }
        public bool Silinmis { get; set; }
    }
}
