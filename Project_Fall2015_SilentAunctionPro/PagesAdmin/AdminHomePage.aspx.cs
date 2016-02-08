using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGrid();
                populateItemGrid();               
            }
        }

        void populateGrid()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "SELECT * FROM USERS WHERE app_pending=1";
                SqlCommand pendingList = new SqlCommand(query, dbConnection);

                DataTable table = new DataTable();
                SqlDataReader pendingListDisplay = pendingList.ExecuteReader();

                table.Columns.Add("User Id");
                table.Columns.Add("Email");
                table.Columns.Add("Approval Status");
                table.Columns.Add("Approval Pending");

                while (pendingListDisplay.Read())
                {
                    DataRow row = table.NewRow();
                    row["User Id"] = pendingListDisplay["userId"];
                    row["Email"] = pendingListDisplay["email"];
                    row["Approval Status"] = pendingListDisplay["approvalStatus"];
                    row["Approval Pending"] = pendingListDisplay["app_Pending"];
                    table.Rows.Add(row);
                }

                //table.Load(pendingListDisplay);
                pendingGrid.DataSource = table;
                pendingGrid.DataBind();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }


        // For User
        protected void pendingGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View User")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = pendingGrid.Rows[index];
                String uidSelected = row.Cells[0].Text;
                // Label2.Text = "View: " + itemIdSelected;   


                displayUserInfo(uidSelected);
            }
        }


        // diplay Prepoulated user info
        void displayUserInfo(String userIdSelected)
        {
            Session["userid"] = userIdSelected;
            userview.ActiveViewIndex = 1;
            tabContents.ActiveViewIndex = -1;
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                string query = "Select * from users where userID = @userID";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.Parameters.AddWithValue("@userID", userIdSelected);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    userid.Text = dr["userID"].ToString();
                    fname.Text = dr["firstName"].ToString();
                    lname.Text = dr["lastName"].ToString();
                    address1.Text = dr["addressLine1"].ToString();
                    address2.Text = dr["addressLine2"].ToString();
                    city.Text = dr["city"].ToString();
                    state.Text = dr["stateName"].ToString();
                    zip.Text = dr["zip"].ToString();
                    country.Text = dr["country"].ToString();
                    phoneNumber.Text = dr["phoneHome"].ToString();
                    email.Text = dr["email"].ToString();


                    //imagedisplay.Text = "<img src=\"" + dr["filePath"] + "\"/>";

                }

                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }


        protected void Approve_User_Click(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "UPDATE Users SET approvalStatus = 1, app_pending = 0 WHERE userID = \'" + Session["userid"] + "\'";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateGrid();
            userview.ActiveViewIndex = 0;
        }

        // Deny user
        protected void Deny_User_Click(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "UPDATE Users SET approvalStatus = 0, app_pending = 0 WHERE userID = \'" + Session["userid"] + "\'";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateGrid();
            userview.ActiveViewIndex = 0;
        }



        //
        // Method for Item
        //

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String itemIdSelected = row.Cells[0].Text;
               // Label2.Text = "View/Edit: " + itemIdSelected;
                ViewEditItem(itemIdSelected);
            }
        }



        // displaying prepopulated item
        void ViewEditItem(String itemIdSelected)
        {
            Session["itemId"] = itemIdSelected;
            tabContents.ActiveViewIndex = 1;
            userview.ActiveViewIndex = -1;
            

            string img = "";

                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                string cat = null;
                string query = "Select * from item i join category c on i.categoryID = c.categoryID"
                    + " where itemID = @itemID";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.Parameters.AddWithValue("@itemID", itemIdSelected);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    cat = dr["categoryPrefix"].ToString();
                    item_name.Text = dr["itemName"].ToString();
                    item_desc.Text = dr["itemdesc"].ToString();
                    item_val.Text = dr["itemValue"].ToString();
                    category.Text = dr["categoryName"].ToString();
                    pur_val.Text = dr["purchasePrice"].ToString();

                    // Method calling for Minimum bid calculation
                    minBidCalculation(cat, itemIdSelected);

                    // Method calling for Angel bid calculation
                    angelCalculation(cat, itemIdSelected);

                    // image display
                    displayItems(itemIdSelected);
                    //imagedisplay.Text = "<img src=\"" + dr["filePath"] + "\"/>";

                }

                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();
        }


        // Method for Minimum bid calculation
        private void minBidCalculation(string cat, string itemid)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                string query = "Select * from item i join category c on i.categoryID = c.categoryID"
                    + " where itemID = @itemID";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.Parameters.AddWithValue("@itemID", itemid);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    if (cat == "G")
                    {
                        minbid_val.Text = dr["itemValue"].ToString();
                    }
                    else if (cat == "CT" || cat == "ON" || cat == "JBJ" || cat == "DI")
                    {
                        double d = Convert.ToDouble(dr["itemValue"]);
                        double res = (d) / 3;
                        minbid_val.Text = res.ToString();
                    }

                }

                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();
        }

        // Angel Calculation
        protected void angelCalculation(string cat, string itemIdSelected)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                string query = "Select * from item i join category c on i.categoryID = c.categoryID"
                    + " where itemID = @itemID";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.Parameters.AddWithValue("@itemID", itemIdSelected);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    if (cat == "G" || cat == "CT" || cat == "ON" || cat == "JBJ")
                    {
                        ang_val.Text = Convert.ToString(0);
                    }
                    else if (cat == "DI")
                    {
                        double d = Convert.ToDouble(dr["itemValue"]);
                        double res = (d) / 3;
                        ang_val.Text = res.ToString();
                    }

                }

                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();

        }



        // Method for image display
        private void displayItems(String id)
        {
            imagedisplay.Text = "<table width='20%' border='1'>";
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                string query = "select * from item where itemID = '" + id + "'";
                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    string img = dr["filePath"].ToString();
                    //imagedisplay.Text += "<tr>";
                    ////tableItems.Text += "<td>" + itemsListDisplay["FileName"] + "</td>";
                    //imagedisplay.Text += "<td><img src= \"" + img + "\"/ width='55%'></td>";
                    ////tableItems.Text += "<td><a href='ItemDetails.aspx?ItemId=" + itemsListDisplay["ItemID"] + "'>View Details</a></td>";
                    //imagedisplay.Text += "</tr>";

                    Image1.ImageUrl = img;
                }
               // imagedisplay.Text += "</table>";
                //imagedisplay1.Text = imagedisplay.Text;
                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();
        }

        // Approove Item by Admin
        protected void Approve_Click(object sender, EventArgs e)
        {

                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                // String query = "UPDATE Item SET approvalStatus = 1 WHERE itemID = \'" + Session["itemId"] + "\' "+
                double d = Convert.ToDouble(item_val.Text);

                String query = " Update item set approvalStatus = 1, itemName = '" + item_name.Text + "', itemdesc = '" + item_desc.Text + "', itemValue = " + d + ",purchasePrice = " + pur_val.Text + ", angelPrice = " + ang_val.Text + "  where itemID = \'" + Session["itemId"] + "\'";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateItemGrid();
            sendEmailToSubscribers(Session["itemId"].ToString());
            tabContents.ActiveViewIndex = 0;
            Label2.Text= "Item " + Session["itemId"] + " has been updated Succesfully. Email has been sent to the subscribers.";
            Label2.ForeColor = System.Drawing.Color.Green;
            //Label3.Text = "Item" + Session["itemId"] +" has been updated Succesfully";
        }


        // Updating the table dynamically
        void populateItemGrid()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                // chaged by me dated 04-feb-2016
                // String query = "SELECT * FROM ITEM WHERE itemStatus= "+"'NO'";

                String query = "SELECT * FROM ITEM WHERE approvalStatus= 0";

                SqlCommand pendingList = new SqlCommand(query, dbConnection);

                DataTable table = new DataTable();
                SqlDataReader pendingListDisplay = pendingList.ExecuteReader();

                table.Columns.Add("Item Id");
                table.Columns.Add("Item Name");
                table.Columns.Add("Item Desc");

                while (pendingListDisplay.Read())
                {
                    DataRow row = table.NewRow();
                    row["Item Id"] = pendingListDisplay["itemID"];
                    row["Item Name"] = pendingListDisplay["itemName"];
                    row["Item Desc"] = pendingListDisplay["itemdesc"];

                    table.Rows.Add(row);
                }

                //table.Load(pendingListDisplay);
                GridView1.DataSource = table;
                GridView1.DataBind();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }


        // Deny Item by Admin
        protected void Deny_Click(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "Delete FROM Item WHERE itemID = \'" + Session["itemId"] + "\'";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateItemGrid();
            tabContents.ActiveViewIndex = 0;
            Label2.Text = "Item " + Session["itemId"] + " has been denied";
            Label2.ForeColor = System.Drawing.Color.Red;
        }

        //// Updating Item by Admin
        //protected void UpdateItem_Click(object sender, EventArgs e)
        //{
        //    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
        //    try
        //    {
        //        dbConnection.Open();
        //       dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
        //        double d = Convert.ToDouble(item_val.Text);


        //        String query = "Update item set itemName = '" + item_name.Text + "', itemdesc = '" + item_desc.Text + "', itemValue = " + d + " where itemID = \'" + Session["itemId"] + "\'";

        //        SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
        //        sqlCommand.ExecuteNonQuery();


        //    }
        //    catch (SqlException exception)
        //    {
        //        Response.Write("<p>Error code " + exception.Number
        //            + ": " + exception.Message + "</p>");
        //    }

        //    tabContents.ActiveViewIndex = 0;
        //}

        //protected void sell_item_Click(object sender, EventArgs e)
        //{
        //    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

        //    try
        //    {
        //        dbConnection.Open();
        //       dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
        //        double d = Convert.ToDouble(sellingPrice.Text);

        //        String query = "Update item set itemStatus = 'SOLD'" + ", buyerID = '" + buyerIdList.Text + "', sellingPrice = " + d + ", paymentStatus='"+ status.Text + "' where itemID = \'" + Session["itemId"] + "\'";

        //        SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
        //        sqlCommand.ExecuteNonQuery();
        //    }
        //    catch (SqlException exception)
        //    {
        //        Response.Write("<p>Error code " + exception.Number
        //            + ": " + exception.Message + "</p>");
        //    }

        //}

        // Sending Email To Subscribers after adding an item

        protected ArrayList getSubscribersList(string itemID)
        {
            ArrayList list = new ArrayList();

            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String searchString = "select email "
                                        + " from subscriberCategory "
                                        + " where categoryId in  (select c.categoryID "
                                        + " from item i, category c "
                                        + " where i.categoryID = c.categoryID "
                                        + " and i.itemID = @itemID )";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@itemID", itemID);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                while (idRecords.Read())
                {
                    list.Add(idRecords["email"].ToString());
                }

                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                         + ": " + exception.Message + "</p>");

            }

            return list;
        }

        protected void sendEmailToSubscribers(string itemID)
        {
            string itemName = string.Empty;
            double minBidPrice = 0;
            string categoryName = string.Empty;

            //get item details
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String searchString = "select i.itemID, i.itemName, i.minBidPrice, c.categoryName "
                                        + " from item i, category c "
                                        + " where (i.categoryID = c.categoryID) "
                                        + " and i.itemID = @itemID";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@itemID", itemID);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                if (idRecords.Read())
                {
                    itemID = idRecords["itemID"].ToString();
                    itemName = idRecords["itemName"].ToString();
                    //minBidPrice = Convert.ToDouble(idRecords["minBidPrice"].ToString());
                    categoryName = idRecords["categoryName"].ToString();
                }

                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                         + ": " + exception.Message + "</p>");

            }

           // string senderEmail = "njain12@ilstu.edu";
           // string senderName = "Nishant Kumar Jain";

            //compose new email
            MailMessage emailMessage = new MailMessage();

            //set From address
           // MailAddress messageFrom = new MailAddress(senderEmail.ToLower(), senderName);
           // emailMessage.From = messageFrom;

            //get the list of email addresses for this added item
            ArrayList subList = getSubscribersList(itemID);

            //set each email address from the list to the 'To Address' list
            foreach (string toAdr in subList)
            {
                MailAddress messageTo = new MailAddress(toAdr);
                emailMessage.To.Add(messageTo.Address);
            }

            //set the subject
            string subject = "Festival Of Trees - Silent Auction - New Item Added";
            emailMessage.Subject = subject;

            emailMessage.IsBodyHtml = true;
            //set the message body
            string messageBody = "<br><p>You have recieved this email because you were subscribed to " + categoryName + " category.</p>"
                + "<div style=\"clear:both\"><br />A new item was added to category " + categoryName
                + "<br /><br /><b> Item Details </b>"
                + "<br />Item Name : " + itemName
                + "<br />Item ID : " + itemID
                //+ "<br />Minimum Bid Price : $" + minBidPrice
                + "<br /><br /><br /> Thank You!"
                + "<br /><br /> Admin"
                + "<br />Silent Auction "
                + "<br />Festival Of Trees </div>";

            string htmlBody = "<div style=\"float:left\"><img src=\"cid:Pic1\" height=\"100px\" width=\"100px\" ></div><div style=\"float:left\">Hello,<b>"
                + "</b></div> " + messageBody;
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
                (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(Server.MapPath("~/CommonImages/fotLogo.jpg"));
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            emailMessage.AlternateViews.Add(avHtml);

            //set the smtp client
            SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
            mailClient.UseDefaultCredentials = true;// false;

            //send the email
            mailClient.Send(emailMessage);

           // Label2.Text += " Email has been sent to the subscribers.";

        }

        // Approve All Users By Admin
        protected void ApproveAllUser_Click(object sender, EventArgs e)
        {


                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "UPDATE Users SET approvalStatus = 1, app_pending = 0 WHERE app_pending = 1";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateGrid();

        }

        //The following method Denies All the pending user
        protected void DenyAllUser_Click(object sender, EventArgs e)
        {


                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "UPDATE Users SET approvalStatus = 0, app_pending = 0 WHERE app_pending = 1";
                SqlCommand updateQuery = new SqlCommand(query, dbConnection);
                updateQuery.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            populateGrid();

        }

    }
}