using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class SellItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateItemGrid();
                populateDropDown();
            }

        }


        void populateDropDown()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "SELECT * FROM USERS WHERE approvalStatus=1";
                SqlCommand cmd = new SqlCommand(query, dbConnection);

                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    ListItem u = new ListItem();
                    u.Text = (string)data["userID"];
                    u.Value = (string)data["userID"];
                    buyerIdList.Items.Add(u);
                }
            }
            catch (SqlException exception)
            {
                Response.Write("Error Code: " + exception.Message);
            }
        }

        void populateItemGrid()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "SELECT * FROM ITEM WHERE approvalStatus=1 AND (itemStatus='UNSOLD'OR itemStatus='0')";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sell")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String itemIdSelected = row.Cells[0].Text;                
                ViewEditItem(itemIdSelected);
            }
        }

        void ViewEditItem(string itemIdSelected)
        {
            Session["itemId1"] = itemIdSelected;
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
                    item_name1.Text = dr["itemName"].ToString();
                    item_desc1.Text = dr["itemdesc"].ToString();
                    item_val1.Text = dr["itemValue"].ToString();
                    category1.Text = dr["categoryName"].ToString();
                   
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

        void displayItems(string id)
        {
           // imagedisplay1.Text = "<table width='20%' border='1'>";
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
                   // imagedisplay1.Text += "<tr>";
                   //imagedisplay1.Text += "<td><img src= \"" + img + "\"/ width='55%'></td>";
                    //imagedisplay1.Text += "</tr>";
                }
               // imagedisplay1.Text += "</table>";                
                dr.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();
        }

        protected void sell_item_Click(object sender, EventArgs e)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                double d = Convert.ToDouble(sellingPrice.Text);

                String query = "Update item set itemStatus = 'SOLD'" + ", buyerID = '" + buyerIdList.Text + "', sellingPrice = " + d + ", paymentStatus='" + status.Text + "' where itemID = \'" + Session["itemId1"] + "\'";

                SqlCommand sqlCommand = new SqlCommand(query, dbConnection);
                sqlCommand.ExecuteNonQuery();
                sell_display.Text = "The Item has been sold.";
                sell_display.ForeColor = System.Drawing.Color.Green;
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }
    }
}