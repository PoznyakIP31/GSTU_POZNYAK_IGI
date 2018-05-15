using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_7.Views
{
    public partial class Groups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];
            if (login != null && sign != null)
            {
                if (sign.Value == SignGenerator.GetSign(login.Value + "bytepp"))
                {
                    
                    return;
                }
            }
            Response.Redirect("../Login.aspx");
        }
    }
}