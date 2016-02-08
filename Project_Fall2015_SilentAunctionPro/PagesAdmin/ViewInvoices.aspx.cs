using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web.UI;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class MyInvoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataToUserList();
                Panel2.Visible = false;
                Panel10.Visible = false;
                emailMsg.Text = "";
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (DropDownList1.SelectedValue == "")
                {
                    Panel2.Visible = false;
                    Panel10.Visible = false;
                    Label3.Text = "";
                    emailMsg.Text = "";
                }
            }
        }

        protected void BindDataToUserList()
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String searchString = "select distinct buyerid from item where buyerid is not null";
                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SqlDataAdapter da = new SqlDataAdapter(SQLString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "buyerid";
                DropDownList1.DataTextField = "buyerid";
                DropDownList1.DataBind();
                dbConnection.Close();

                //Adding "Please select" option in dropdownlist
                DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select a buyer", ""));
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {
               
                Panel2.Visible = false;
                Panel10.Visible = false;
                Label3.Text = "";
                emailMsg.Text = "";
            }
            else
            {
               
                Panel2.Visible = false;
                Panel10.Visible = false;
                emailMsg.Text = "";
            }
        }

        protected void getInvoice_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                Label3.Text = "Please select a buyer";
                Label3.ForeColor = System.Drawing.Color.Red;
                emailMsg.Text = "";
            }
            else
            {
                Label3.Text = "";
                string userid = DropDownList1.SelectedValue;
                printInvoiceForSelectedUser(userid);
                Panel2.Visible = true;
                Panel10.Visible = true;
                emailMsg.Text = "";
            }
        }

        //methods to print invoice
        protected void printInvoiceForSelectedUser(string userid)
        {
            getItemDetails(userid);
            getUserDetails(userid);
            getItemTotals(userid);
            currentDate.Text = DateTime.Now.ToString("d");
            Panel2.Visible = true;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true);
        }

        protected void getUserDetails(string userid)
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
             dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String searchString = "select * from users where userId = @userID";
                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                if (idRecords.Read())
                {
                    name.Text = idRecords["firstName"].ToString() + " " + idRecords["lastname"].ToString();
                    address.Text = idRecords["addressLine1"].ToString() + " " +
                        idRecords["addressLine2"].ToString() + ", " +
                        idRecords["city"].ToString() + ", " +
                        idRecords["statename"].ToString() + ", " +
                        idRecords["zip"].ToString() + ", " +
                        idRecords["country"].ToString();

                    mobilePhone.Text = idRecords["phonehome"].ToString();
                    cellPhone.Text = idRecords["cellphone"].ToString();
                }
                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
        }

        protected void getItemDetails(string userid)
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String searchString = "select * from item i, itemdonor ido , users u , category c "
                     + " where (i.itemid = ido.itemid and u.userid = ido.userid and c.categoryid = i.categoryid) and buyerid = @userID ";
                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);
                SqlDataReader idRecords = SQLString.ExecuteReader();
                Repeater1.DataSource = idRecords;
                Repeater1.DataBind();
                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
        }

        protected void getItemTotals(string userid)
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                //get total bid amount
                String searchString = "select sum(sellingPrice)as totalbidamt from item where buyerid = @userID";
                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);
                SqlDataReader idRecords = SQLString.ExecuteReader();
                decimal totalbidamt = 0; ;
                if (idRecords.Read())
                {
                    if (!string.IsNullOrEmpty(idRecords["totalbidamt"].ToString()))
                    {
                        totalbidamt = Convert.ToDecimal(idRecords["totalbidamt"].ToString());
                    }
                }
                totalBidAmt.Text = totalbidamt.ToString();
                idRecords.Close();

                //get total amount paid
                String searchString1 = "select * from item where buyerid = @userID";
                SqlCommand SQLString1 = new SqlCommand(searchString1, dbConnection);
                SQLString1.Parameters.AddWithValue("@userID", userid);
                SqlDataReader idRecords1 = SQLString1.ExecuteReader();
                decimal amtPaid = 0;
                decimal charityAmt = 0;

                while (idRecords1.Read())
                {
                    if (idRecords1["paymentStatus"].ToString().Equals("YES"))
                    {
                        amtPaid += Convert.ToDecimal(idRecords1["sellingPrice"].ToString());
                    }
                    decimal sp = Convert.ToDecimal(idRecords1["sellingPrice"].ToString());
                    decimal itemValue = Convert.ToDecimal(idRecords1["itemValue"].ToString());

                    if (sp > itemValue)
                    {
                        charityAmt += sp - itemValue;
                    }

                }
                idRecords1.Close();
                totalAmtPaid.Text = amtPaid.ToString();

                //calculate balance amount
                decimal totalamtdue = totalbidamt - amtPaid;
                totalAmtDue.Text = totalamtdue.ToString();

                //set charitable deduction
                charitableDeduction.Text = charityAmt.ToString();

                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
        }

        protected void emailInvoice(object sender, EventArgs e)
        {
            generatePDF(DropDownList1.SelectedValue);
            string userid = DropDownList1.SelectedValue;

            string email = getEmailFromUserID(userid);

            //email = "njain12@ilstu.edu";

            //compose new email
            MailMessage emailMessage = new MailMessage();

            //set To address
            MailAddress messageTo = new MailAddress(email);
            emailMessage.To.Add(messageTo.Address);

            //set the subject
            string subject = "Your Invoice - Silent Auction - Festival Of Trees";
            emailMessage.Subject = subject;

            emailMessage.IsBodyHtml = true;
            //set the message body
            string messageBody = "<div style=\"clear:both\"><br><p>Thank you for coming to the auction and showing interest in purchasing items!</p>"
                + "<br />Please find attached with this email your invoice of the items you purchased."

                + "<br /><br /><br /> Thank You!"
                + "<br /><br /> Admin"
                + "<br />Silent Auction "
                + "<br />Festival Of Trees </div>";

            string htmlBody = "<div style=\"float:left\"><img src=\"cid:Pic1\" height=\"100px\" width=\"100px\" ></div><div style=\"float:left\">Hello,<b>"
                + userid.ToUpper() + "</b></div> " + messageBody;
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
                (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(Server.MapPath("~/CommonImages/fotLogo.jpg"));
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            emailMessage.AlternateViews.Add(avHtml);

            //attach pdf as attachment
            emailMessage.Attachments.Add(new Attachment(Server.MapPath("~/invoices/invoice_" + userid + ".pdf")));

            //set the smtp client
            SmtpClient mailClient = new SmtpClient();
            mailClient.UseDefaultCredentials = true;// false;

            //send the email
            mailClient.Send(emailMessage);
            emailMsg.Text = "Invoice emailed to " + email;
        }  // End of Method


        protected string getEmailFromUserID(string userid)
        {
            string email = "";
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String searchString = "select email from users where userid = @userID ";
                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                if (idRecords.Read())
                {
                    email = idRecords["email"].ToString();
                }
                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
            return email;
        }

        protected void generatePDF(string userid)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ///This is the panel from the webform
            Panel2.RenderControl(hw);
            string htmlDisplayText = sb.ToString();
            string pdfFilename = "invoice_" + userid + ".pdf";
            string fullpath = "~/invoices/" + pdfFilename;

            converttopdf(htmlDisplayText, Server.MapPath(fullpath));
        }
        public void converttopdf(string HTMLString, string fileLocation)
        {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream(fileLocation, FileMode.Create));
            document.Open();

            List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(HTMLString), null);
            for (int k = 0; k < htmlarraylist.Count; k++)
            {
                document.Add((IElement)htmlarraylist[k]);
            }

            document.Close();
        }

    }
}