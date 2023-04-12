using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunHavasi_WebApp.AdminPanel
{
    public partial class YorumOnayla : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele(false);
            lv_yorumlar.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "onayla")
            {
                dm.YorumOnayla(id);
            }
            else if(e.CommandName == "sil")
            {
                dm.YorumSil(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele(false);
            lv_yorumlar.DataBind();
        }
    }
}