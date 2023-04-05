using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp.AdminPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataTextField = "Isim";
                ddl_kategoriler.DataValueField = "ID";
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_Ekle_Click(object sender, EventArgs e)
        {
            bool isvalid = true;
            Makale mak = new Makale();
            mak.Baslik = tb_baslik.Text;
            if (tb_ozet.Text.Length < 1000)
            {
                mak.Ozet = tb_ozet.Text;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Özet En fazla 1000 karakter uzunluğunda olmalıdır";
                isvalid = false;
            }
            mak.Icerik = tb_icerik.Text;
            mak.YayinDurumu = cb_yayin.Checked;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            mak.Yazar_ID = ((Yonetici)Session["yonetici"]).ID;
            mak.BegeniSayi = 0;
            mak.EklemeTarih = DateTime.Now;
            mak.GoruntulemeSayi = 0;
            if (fu_resim.HasFile)//File Upload kontrolünde dosya seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//File Upload kontrlüne eklenen dosyanın uzantısı
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string dosyaAdi = Guid.NewGuid().ToString() + uzanti;
                    mak.KapakResim = dosyaAdi;
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/"+dosyaAdi));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Dosya uzantısı PNG, JPG veya JPEG olmalıdır";
                    isvalid = false;
                }
            }
            else
            {
                mak.KapakResim = "none.png";
            }
            if (isvalid == true)
            {
                if (dm.MakaleEkle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Makale Eklenirken bir Hata Oluştu";
                }
            }
        }
    }
}