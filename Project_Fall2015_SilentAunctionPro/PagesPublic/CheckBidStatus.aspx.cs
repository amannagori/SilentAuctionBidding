using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesPublic
{
    public partial class CheckBidStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                populateItems();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            bool itemSold = checkIfItemSoldToThisUser();
            if (itemSold == true)
            {
                populateItems();
                
                Panel1.Visible = false;
               
            }
            else
            {
                itemSoldMsg.Text = "You did not win any items as of yet.";
               
            }

        }
        protected bool checkIfItemSoldToThisUser()
        {
            bool itemSold = false;
            string userid = Session["user_id"].ToString();
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String searchString = "select * from item where buyerID = @userID";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SQLString.Parameters.AddWithValue("@userID", userid);

                SqlDataReader idRecords = SQLString.ExecuteReader();
                if (idRecords.Read())
                {
                    itemSold = true;
                }

                idRecords.Close();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }
            return itemSold;
        }

        void populateItems()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "SELECT * FROM ITEM WHERE buyerID='"+ Session["user_id"]+ "'";
                SqlCommand pendingList = new SqlCommand(query, dbConnection);

                DataTable table = new DataTable();
                SqlDataReader pendingListDisplay = pendingList.ExecuteReader();

                table.Columns.Add("Item Id");
                table.Columns.Add("Item Name");
                table.Columns.Add("Item Desc");
                table.Columns.Add("Price");

                while (pendingListDisplay.Read())
                {
                    DataRow row = table.NewRow();
                    row["Item Id"] = pendingListDisplay["itemID"];
                    row["Item Name"] = pendingListDisplay["itemName"];
                    row["Item Desc"] = pendingListDisplay["itemDesc"];
                    row["Price"] = pendingListDisplay["sellingPrice"];
                    table.Rows.Add(row);
                }
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            catch(SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                   + ": " + exception.Message + "</p>");
            }
        }
    }
}