using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp.AdminPanel
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Nabünüz Len";
            tb_kullaniciAdi.Text = "Murtazaaa";
        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            string kadi = tb_kullaniciAdi.Text;
            string sifre = tb_sifre.Text;

            if (kadi == "Admin" && sifre == "1234")
            {
                this.Title = "Giriş Başarılı";
            }
            else
            {
                this.Title = "Kullanıcı Adı Veya Şİfre Hatalı";
            }
        }
    }
}