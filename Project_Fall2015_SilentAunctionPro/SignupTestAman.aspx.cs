using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro
{
    public partial class SignupTestAman : System.Web.UI.Page
    {
        private SMSService textMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void signUp_Click1(object sender, EventArgs e)
        {
            string userId = (userid.Text).Trim();
            string FName = (fname.Text).Trim();
            string LName = (lname.Text).Trim();
            string Address1 = (address1.Text).Trim();
            string Address2 = (address2.Text).Trim();
            string City = (city.Text).Trim();
            string State = (state.Text).Trim();
            string Zip = (zip.Text).Trim();
            string Country = (country.Text).Trim();
            string PhoneNum = (phoneNumber.Text).Trim();
            string Carrier = networkProvider.SelectedValue;

            string Workphone = (workphone.Text).Trim();
            string Email = (email.Text).Trim();
            string Password = (signUpPassword.Text).Trim();
            string Role = role.SelectedValue;
            string selectRole = "";
            switch (Role)
            {
                case "P":
                    selectRole = "Public";
                    break;
                case "SC":
                    selectRole = "SC";
                    break;
                case "A":
                    selectRole = "Admin";
                    break;

            }

            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

                    try
                    {
                        dbConnection.Open();
                       dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                        // string SQLString = "SELECT * FROM users WHERE userID='" + userId + "'";
                        string SQLString = "SELECT userID FROM users WHERE userID= @user_id";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                        checkIDTable.Parameters.AddWithValue("@user_id", userId);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();

                        if (idRecords.Read())
                        {
                            //   form1.Visible = false;
                            SignUpReply.Text = "User ID already exist. Use another user ID";
                            SignUpReply.ForeColor = System.Drawing.Color.Red;
                            idRecords.Close();

                        }

                        else
                        {
                            idRecords.Close();
                            string UserInfo =
                     "INSERT INTO users (userID,firstName,lastName," +
                            "addressLine1,addressLine2,city,stateName,zip,country," +
                            "phoneHome,cellPhone,phncarrier,email,role,approvalStatus," +
                            "password,app_pending)" +
                     "VALUES(@userId,@FName,@LName,@Address1,@Address2,@City,@State," +
                             "@Zip,@Country,@PhoneNum,@Workphone,@Carrier,@Email," +
                             "@selectRole,@app_status,@Password,@app_pending)";

                            SqlCommand sqlCommandEmp = new SqlCommand(UserInfo, dbConnection);

                            sqlCommandEmp.Parameters.AddWithValue("@userId", userId);
                            sqlCommandEmp.Parameters.AddWithValue("@FName", FName);
                            sqlCommandEmp.Parameters.AddWithValue("@LName", LName);
                            sqlCommandEmp.Parameters.AddWithValue("@Address1", Address1);
                            sqlCommandEmp.Parameters.AddWithValue("@Address2", Address2);
                            sqlCommandEmp.Parameters.AddWithValue("@City", City);
                            sqlCommandEmp.Parameters.AddWithValue("@State", State);
                            sqlCommandEmp.Parameters.AddWithValue("@Zip", Zip);
                            sqlCommandEmp.Parameters.AddWithValue("@Country", Country);
                            sqlCommandEmp.Parameters.AddWithValue("@PhoneNum", PhoneNum);
                            sqlCommandEmp.Parameters.AddWithValue("@Workphone", Workphone);
                            sqlCommandEmp.Parameters.AddWithValue("@Carrier", Carrier);
                            sqlCommandEmp.Parameters.AddWithValue("@Email", Email);
                            sqlCommandEmp.Parameters.AddWithValue("@selectRole", selectRole);
                            sqlCommandEmp.Parameters.AddWithValue("@app_status", false);
                            sqlCommandEmp.Parameters.AddWithValue("@Password", Password);
                            sqlCommandEmp.Parameters.AddWithValue("@app_pending", true);


                            int rowcount = sqlCommandEmp.ExecuteNonQuery();
                            //if (rowcount == 1) {
                            //    SignUpReply.Text = "SignUp Succesfull";
                            //}
                            //else

                           
                            //form1.Visible = false;

                            string message = "Thank you for siging up with us. You will receive an email shortly. Please Check your inbox. Happy Bidding :)";
                            textMessage = new SMSService(Carrier, PhoneNum, message);
                            textMessage.SendTextMessage(textMessage);

                            // commented because no mail account setup

                            MailAddress messageTo = new MailAddress(Email);
                            MailMessage emailMessage = new MailMessage();
                            emailMessage.To.Add(messageTo.Address);

                            string messageSubject = ("Thank you For SignUp");
                            string messageBody = ("You Successfuly Signed Up, please wait for the Approval :) " +
                            Environment.NewLine + " First Name: " + FName + Environment.NewLine + " Last Name: " + LName +
                            Environment.NewLine + " User ID: " + userId +
                            Environment.NewLine + " Email: " + Email);

                            emailMessage.Subject = messageSubject;
                            emailMessage.Body = messageBody;
                            SmtpClient mailClient = new SmtpClient();
                            mailClient.UseDefaultCredentials = true;
                            mailClient.Send(emailMessage);

                            SignUpReply.Text += " Thank you for the SignUp, Please wait for the account approval. Thank you for your patience";
                            SignUpReply.ForeColor = Color.Green;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Signup.  Please wait for the account approval')", true);
                        }
                    }
                    catch (SqlException exception)
                    {
                        Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                    }
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}