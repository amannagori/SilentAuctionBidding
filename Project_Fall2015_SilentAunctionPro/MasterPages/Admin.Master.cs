using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.MasterPages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //if (Session["user_id"] ==  null)
            //{
            //    Response.Redirect("../UserWebForms/Login.aspx");
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Session["user_id"].ToString().ToUpper();
            if (Session["user_role"]!=null && !Session["user_role"].ToString().ToLower().Equals("admin"))
            {
                 Response.Redirect("~/Default.aspx");
            }
        }
    }
}