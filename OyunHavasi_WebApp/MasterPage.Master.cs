using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uye u = (Uye)Session["uye"];
                ltrl_kullanici.Text = u.KullaniciAdi;
                pnl_girisVar.Visible = true;
                pnl_girisyok.Visible = false;
            }
            else
            {
                pnl_girisVar.Visible = false;
                pnl_girisyok.Visible = true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}