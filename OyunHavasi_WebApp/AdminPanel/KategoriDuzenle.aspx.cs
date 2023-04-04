using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp.AdminPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
               if(!IsPostBack)//Eğer Sayfa ilkkez açılıyorsa. bir buton vs. aracılığı ile tetiklenmediyse
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                    Kategori k = dm.KategoriGetir(id);
                    tb_kategoriAdi.Text = k.Isim;
                }
            }
            else
            {
                Response.Redirect("KategoriListeleListView.aspx");
            }
        }

        protected void lbtn_Duzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kategoriAdi.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                Kategori k = new Kategori();
                k.ID = id;
                k.Isim = tb_kategoriAdi.Text;
                if (dm.KategoriDuzenle(k))
                {
                    //pnl_basarili.Visible = true;
                    //pnl_basarisiz.Visible = false;
                    Response.Redirect("KategoriListeleListView.aspx");
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori Güncellenirken Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "kategori Adı Boş Bırakılamaz";
            }
        }
    }
}