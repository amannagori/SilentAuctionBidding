using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesSC
{
    public partial class SCHomePage : System.Web.UI.Page
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
                Label2.Text = "View/Edit: " + itemIdSelected;
                ViewEditItem(itemIdSelected);
            }
        }



        // displaying prepopulated item
        void ViewEditItem(String itemIdSelected)
        {
            Session["itemId"] = itemIdSelected;
            userview.ActiveViewIndex = -1;
            tabContents.ActiveViewIndex = 1;

            string img = "";

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
                    item_name.Text = dr["itemName"].ToString();
                    item_desc.Text = dr["itemdesc"].ToString();
                    item_val.Text = dr["itemValue"].ToString();
                    category.Text = dr["categoryName"].ToString();


                    //img = dr["filePath"].ToString();
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
                    string img = "../UserWebForms/" + dr["filePath"].ToString();
                    imagedisplay.Text += "<tr>";
                    //tableItems.Text += "<td>" + itemsListDisplay["FileName"] + "</td>";
                    imagedisplay.Text += "<td><img src= \"" + img + "\"/ width='55%'></td>";
                    //tableItems.Text += "<td><a href='ItemDetails.aspx?ItemId=" + itemsListDisplay["ItemID"] + "'>View Details</a></td>";
                    imagedisplay.Text += "</tr>";
                }
                imagedisplay.Text += "</table>";
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
                String query = "UPDATE Item SET approvalStatus = 1 WHERE itemID = \'" + Session["itemId"] + "\'";
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
                String query = "SELECT * FROM ITEM WHERE approvalStatus=0";
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
                    row["Item Desc"] = pendingListDisplay["approvalStatus"];

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
        }

        // Updating Item by Admin
        protected void UpdateItem_Click(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                double d = Convert.ToDouble(item_val.Text);


                String query = "Update item set itemName = '" + item_name.Text + "', itemdesc = '" + item_desc.Text + "', itemValue = " + d + " where itemID = \'" + Session["itemId"] + "\'";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.ExecuteNonQuery();


            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }

            tabContents.ActiveViewIndex = 0;
        }


    }
}