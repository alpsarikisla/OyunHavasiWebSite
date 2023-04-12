using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int Uye_ID { get; set; }
        public string Uye { get; set; }
        public int Makale_ID { get; set; }
        public string Makale { get; set; }
        public string Icerik { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string EklemeTarihiStr { get; set; }
        public int BegeniSayi { get; set; }
        public bool Durum { get; set; }
        public string DurumStr { get; set; }
    }
}
