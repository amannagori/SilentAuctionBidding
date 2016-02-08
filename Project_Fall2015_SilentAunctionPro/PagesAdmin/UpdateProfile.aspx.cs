using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
   
    public partial class UpdateProfile : System.Web.UI.Page
    {
       
        string str;
        private SMSService textMessage;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Session["user_id"] == null)
                {
                    Response.Redirect("../Default.aspx");
                }


                else
                {
                            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    try
                    {

                        dbConnection.Open();
                         dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                        string name = Session["user_id"].ToString();
                        userid1.Text = name.ToString();

                        string SQLString = "SELECT * FROM users WHERE userID='" + name + "'";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                       
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();
                        if (idRecords.Read())
                        {
                            do
                            {
                                
                                
                                fname.Text = idRecords["firstName"].ToString();
                                lname.Text = idRecords["lastName"].ToString();
                                addressLine1.Text = idRecords["addressLine1"].ToString();
                                addressLine2.Text = idRecords["addressLine2"].ToString();
                                city.Text = idRecords["city"].ToString();
                                state.Text = idRecords["stateName"].ToString();
                                phoneNumber.Text = idRecords["phoneHome"].ToString();
                                networkProvider.SelectedValue = idRecords["phncarrier"].ToString();
                                email.Text = idRecords["email"].ToString();
                                Password1.Text = idRecords["password"].ToString();
                            }
                            while (idRecords.Read());
                        }
                        idRecords.Close();

                    }

                    catch (SqlException exception)
                    {
                        Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                    }
                }
            }
        }
                    
                
        protected void updateUserProfile(object sender, EventArgs e)
        {

                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                string name = Session["user_id"] as string;
             str = "Update users set firstName='" + fname.Text + "', lastName='" + lname.Text + "', addressLine1='" + addressLine1.Text + "', addressLine2='" + addressLine2.Text + "', city='" + city.Text + "', stateName='" + state.Text + "', phoneHome='" + phoneNumber.Text + "', phncarrier='" + networkProvider.SelectedValue + "', email='" + email.Text + "', password='" + Password1.Text + "' WHERE userID='" + userid1.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(str, dbConnection);
              var x =   sqlCommand.ExecuteNonQuery();


                string message = "Bingo! your profile has been Updated. For confirmation we have sent you an email, Happy Bidding :)" ;
                textMessage = new SMSService(networkProvider.Text, phoneNumber.Text, message);
                textMessage.SendTextMessage(textMessage);


                UpdateReply.Text = "Data Updated Successfully, Please check your inbox :)";
               
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }


    }
}