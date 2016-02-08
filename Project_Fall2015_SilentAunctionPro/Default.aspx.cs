using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro
{
    public partial class Default : Page
    {
       
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        #region Login Method
        protected void Login(object sender, EventArgs e)
        {
            //_user.Username = (loginUserName.Text).Trim();
            //_user.Password = (loginPassword.Text).Trim();

            //User user = _dataAccess.LoginResult(_user);
            //if (_user.LoginStatus)
            //{
            //    if (CheckBox1.Checked)
            //    {
            //        var httpCookie = Response.Cookies["User"];
            //        if (httpCookie != null)
            //            httpCookie["email"] = loginUserName.Text;
            //        var cookie = Response.Cookies["User"];
            //        if (cookie != null) cookie["Password"] = _user.Password;
            //        var httpCookie1 = Response.Cookies["User"];
            //        if (httpCookie1 != null)
            //            httpCookie1.Expires = DateTime.Now.AddDays(15);
            //    }

            //    if (user.AdminApprovalStatus == "N")
            //    {
            //        loginResult.Text =
            //            "Admin has not approved your account yet. Please try after sometime. Sorry for the inconvinience.";
            //        loginResult.ForeColor = Color.Red;
            //    }
            //    else if (!string.IsNullOrWhiteSpace(user.EmailValidatingString)
            //             || !string.IsNullOrEmpty(user.EmailValidatingString))
            //    {
            //        loginResult.Text = "Email not verified. Please verify the account.";
            //        loginResult.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        if (user.TwoFactorAuthenticationStatus == "Y")
            //        {
            //            Session["username"] = (loginUserName.Text).ToLower();
            //            Session["userId"] = user.UserId;
            //            Session["UserAccountType"] = user.AccountType;
            //            Response.Redirect("CommonWebforms/TfaCode.aspx", false);
            //        }
            //        else
            //        {
            //            Session["username"] = (loginUserName.Text).ToLower();
            //            Session["userId"] = user.UserId;
            //            if (user.AccountType.Equals("D"))
            //            {
            //                Response.Redirect("../Dean/HomePage.aspx", false);
            //            }
            //            else if (user.AccountType.Equals("P"))
            //            {
            //                Response.Redirect("../Professor/HomePage.aspx", false);
            //            }
            //            else if (user.AccountType.Equals("S"))
            //            {
            //                Response.Redirect("../Student/HomePage.aspx", false);
            //            }
            //            else if (user.AccountType.Equals("C"))
            //            {
            //                Response.Redirect("../Coordinator/HomePage.aspx", false);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    loginResult.Text = "Invalid Username or Password!!";
            //    loginResult.ForeColor = Color.Red;
            //}
        }
        #endregion

        //#region SignUp Method
       protected void SignUp(object sender, EventArgs e)
        {
        //    _user.RandomString = Path.GetRandomFileName();
        //    _user.RandomString = _user.RandomString.Replace(".", "");
        //    _user.RandomString = EncryptDecrypt.Encrypt(_user.RandomString);
        //    _user.Username = ((signUpUsername.Text).ToLower()).Trim();
        //    _user.Password = (signUpPassword.Text).Trim();
        //    _user.Password = EncryptDecrypt.Encrypt(_user.Password);
        //    _user.AccountType = accType.SelectedValue;
        //    _user.AccountPrivilegeForReview = _user.AccountType.Equals("D") ? "Y" : "N";
        //    _user.AdminApproval = "N";
        //    _user.TwoWayAuthenticationStatus = "N";
        //    _user.FirstName = (fname.Text).Trim();
        //    _user.LastName = (lname.Text).Trim();
        //    _user.PhnNumber = (phoneNumber.Text).Trim();
        //    _user.Carrier = networkProvider.SelectedValue;
        //    _user.UnitName = "";
        //    switch (_user.AccountType)
        //    {
        //        case "D":
        //            _user.UnitName = userUnit.SelectedValue;
        //            break;
        //        case "O":
        //            _user.UnitName = (OtherUnitName.Text).Trim();
        //            break;
        //    }

        //    var result = _databaseMethods.SignUp(_user);

        //    if (result == 1)
        //    {
        //        _email.Subject = "Thank you for siging up with us!!";
        //        SendSms(_user.Carrier, _user.PhnNumber, "Thank you for siging up with us!! Please check your email inbox to verify your account.");
        //        _email = new Email(_user.Username, _email.Subject, _email.EmailBodyForSignUp(_user.RandomString));
        //        var emailResult = _email.SendEmail(_email);
        //        if (emailResult)
        //        {
        //            SignUpReply.Text =
        //                "Thank you for sigining up. You will receive an email shortly. Please Check your ilstu inbox.";
        //            SignUpReply.ForeColor = Color.Green;
        //        }
        //        else
        //        {
        //            SignUpReply.Text =
        //                "Thank you for sigining up. We are not able to send the verification link. Please try to get the verification link from the login page. Sorry for the inconvinience!!";
        //            SignUpReply.ForeColor = Color.Red;
        //        }
        //    }
        //    else
        //    {
        //        SignUpReply.Text = "Something went wrong while signing you up!!";
        //        SignUpReply.ForeColor = Color.Red;
        //    }
        }

        //#endregion

        //#region Method to Change the View for Forgot Password
        protected void ForgotPassword(object sender, EventArgs e)
        {
        //    Response.Redirect("CommonWebforms/RetrieveForgotPassword.aspx", false);
        }
        //#endregion

        //#region Check UserName Availablity For Sign Up
       protected void CheckUserNameAvailability(object sender, EventArgs e)
        {
        //    const string query = "SELECT * FROM LOGININFO WHERE email = @username";

        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@username", signUpUsername.Text);
        //        try
        //        {
        //            connection.Open();
        //            var reader = command.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                usernameerror.Text = "Username already taken.";
        //                usernameerror.ForeColor = Color.Red;
        //            }
        //            else
        //            {
        //                usernameerror.Text = "Username available";
        //                usernameerror.ForeColor = Color.Green;
        //            }
        //            reader.Close();
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //        }
        //    }
        }
        //#endregion

        //#region Method to Get the Verification Link Page if Email Fails
        protected void GetVerificationLink(object sender, EventArgs e)
        {
        //    Response.Redirect("CommonWebforms/GetVerificationLinkAgain.aspx", false);
        }
        //#endregion

        protected void SignUpPage(object sender, EventArgs e)
        {
            ////var selection = accType.SelectedValue;
            //if (selection == "P")
            //{
            //    Response.Redirect("UserWebForms/SignUp.aspx?at=" + selection, false);
            //}
            //else if (selection == "A")
            //{
            //    Response.Redirect("UserWebForms/SignUp.aspx", false);
            //}
            //else if (selection == "S")
            //{
            //    Response.Redirect("UserWebForms/SignUp.aspx", false);
            //}
        }
    }
}