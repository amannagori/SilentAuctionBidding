using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro
{
    public partial class Geolocation : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {

            if (!Master.Page.ClientScript.IsStartupScriptRegistered("alert"))
            {
                Master.Page.ClientScript.RegisterStartupScript
                    (this.GetType(), "alert", "initialize();", true);
            }
        }
    }
}