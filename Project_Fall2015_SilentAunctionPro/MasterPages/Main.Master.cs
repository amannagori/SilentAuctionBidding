using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage

    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (userid.Text == "")
            {
                loginResult.Text = "Name is Required";
                loginResult.ForeColor = System.Drawing.Color.Red;

            }// End of if statement

            else
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                string user_id = userid.Text.ToLower();
                string password = pass.Text;//.ToLower();



                try
                {
                    dbConnection.Open();
                   dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                    // using parameterized query
                    string strQuery = "select userID,password,role from users where userID = @user_id";

                    SqlCommand sqlCommand = new SqlCommand(strQuery, dbConnection);
                    sqlCommand.Parameters.AddWithValue("@user_id", user_id);
                    // sqlCommand.Parameters.AddWithValue("@user_id", user_id);
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        if (user_id.ToLower() == dr["userID"].ToString().ToLower() && password == (string)dr["password"])
                        {
                            Session["user_id"] = userid.Text;
                            Session["user_role"] = dr["role"].ToString();

                            string role = dr.GetString(2);
                            if (role == "Admin")
                            {

                                Response.Redirect("./PagesAdmin/AdminHomePage.aspx", false);
                                dr.Close();
                            }
                            else if (role == "Public")
                            {

                                Response.Redirect("./PagesPublic/PublicHomePage.aspx", false);
                                dr.Close();
                            }
                            else if (role == "SC")
                            {

                                Response.Redirect("./PagesSC/SCHomePage.aspx", false);
                                dr.Close();
                            }
                        }   // end of if statement
                        else
                        { loginResult.Text = "Invalid Credentials"; }
                        break;
                    }

                }
                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                        + ": " + exception.Message + "</p>");
                }
                dbConnection.Close();
            }// End of else statement
        }

        // Method for Ajax Calling UserId is valid or not
        protected void ajax_userid(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            string user_id = userid.Text;
            bool flag = true;

            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                // using parameterized query
                string strQuery = "select userID, approvalStatus from users where userID = @user_id";

                SqlCommand sqlCommand = new SqlCommand(strQuery, dbConnection);
                sqlCommand.Parameters.AddWithValue("@user_id", user_id);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    if ((bool)dr["approvalStatus"] == false)
                    {
                        Label1.Text = "Account Approval Pending";
                        flag = false;
                    }
                    else
                    {
                        Label1.Text = "Valid User ID";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    Label1.Text = "Invalid User ID";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    // flag = false;
                }

            } // End of try
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();

        } // End of Ajax Method for User ID

        // For forgot Password
        protected void ForgotPassword(object sender, EventArgs e)
        {
            Response.Redirect("./LoginBootstrptest.aspx");
        }


        // Sign Up
        protected void signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SignUpTestAman.aspx");
        }
    }
}