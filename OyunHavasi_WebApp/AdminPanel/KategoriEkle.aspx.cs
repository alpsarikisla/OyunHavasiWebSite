using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp.AdminPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kategoriAdi.Text))//tb_kategoriAdi Boş Değilse
            {
                if (tb_kategoriAdi.Text.Length >= 3)
                {
                    Kategori k = new Kategori();
                    k.Isim = tb_kategoriAdi.Text;
                    if (dm.KategoriEkle(k))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kategori Eklerken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori Adı 3 karakterden büyük olmalıdır";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kategori Adı Boş Bırakılamaz";
            }
        }
    }
}