using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["makid"]);
                Makale mak = dm.MakaleGetir(id);
                ltrl_baslik.Text = mak.Baslik;
                ltrl_icerik.Text = mak.Icerik;
                ltrl_kategori.Text = mak.Kategori;
                ltrl_yazar.Text = mak.Yazar;
                ltrl_goruntuleme.Text = mak.GoruntulemeSayi.ToString();
                img_resim.ImageUrl = "MakaleResimleri/" + mak.KapakResim;

                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();

                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisYok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = false;
                    pnl_girisYok.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_gonder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mesaj.Text))
            {
                Yorum y = new Yorum();
                y.BegeniSayi = 0;
                y.EklemeTarihi = DateTime.Now;
                y.Makale_ID = Convert.ToInt32(Request.QueryString["makid"]);
                y.Uye_ID = ((Uye)Session["uye"]).ID;
                y.Icerik = tb_mesaj.Text;
                y.Durum = false;
                if (dm.YorumEkle(y))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    lbl_mesaj.Text = "Yorum Eklerken bir hata ile karşılaşıldı. Lütfen daha sonra tekrar deneyiniz";
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                }
            }
            else
            {
                lbl_mesaj.Text = "Ne ekleyeyim mesela???";
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
            }
        }
    }
}