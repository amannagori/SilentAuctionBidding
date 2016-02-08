using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace forgot_password
{
    public partial class forgot_pass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmail(object sender, EventArgs e)
        {
            string userid = string.Empty;
            string password = string.Empty;
            string email_add = txtEmail.Text.Trim();

                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            dbConnection.Open();
            // // dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

            // using parameterized query
            string strQuery = "select userID,password,firstName,lastName from users where email = @email";


            SqlCommand sqlCommand = new SqlCommand(strQuery, dbConnection);
            sqlCommand.Parameters.AddWithValue("@email", email_add);
            SqlDataReader dr = sqlCommand.ExecuteReader();

            if (dr.Read())
                        {
                            userid = dr["userID"].ToString();
                            password = dr["password"].ToString();
                        }

           
                
            
            if (!string.IsNullOrEmpty(password))
            {
                // string username = dr["firstName"].ToString() +" " + dr["lastName"].ToString();
                string username = dr.GetString(2) + " " + dr.GetString(3);

                 MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email_add);
                mailMessage.From = new MailAddress("anagori@ilstu.edu");
                mailMessage.Subject = "Password Recovery Email";


                // MailMessage mm = new MailMessage("sender@gmail.com", txtEmail.Text.Trim());
                // mm.Subject = "Password Recovery";
                mailMessage.Body = "<html><body></body></html>" + "<br/>Hello " + username +
                                    ",<br/><br/> Your Password is: "+ password;

                //LinkedResource LinkedImage = new LinkedResource(@"H:\Assign4\SignupAndEmailApp\SignupAndEmailApp\Illinois_State_Redbirds_logo.png");
                //LinkedImage.ContentId = "MyPic";

                //LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                 mailMessage.Body, null, "text/html");

                //htmlView.LinkedResources.Add(LinkedImage);
                mailMessage.AlternateViews.Add(htmlView);


                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);

                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = " Password is sent to your Email. Please check the same!";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "This email address does not match our records.";
            }

            dbConnection.Close();
        }
    }
}