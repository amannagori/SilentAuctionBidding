using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sub_test
{
    public partial class PrintBidNumber : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userID"] = "anagori";
            getBidderDetails();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true);
        }

        protected void getBidderDetails()
        {
            string userid = Session["user_id"].ToString();
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String searchString = "select * from users "
                                        + " where userId = @userID; ";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                if (idRecords.Read())
                {
                    bidderName.Text = idRecords["firstName"].ToString().ToUpper();
                    bidderNumber.Text = idRecords["bidder_no"].ToString();
                }

                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                         + ": " + exception.Message + "</p>");

            }

        }
    }
}