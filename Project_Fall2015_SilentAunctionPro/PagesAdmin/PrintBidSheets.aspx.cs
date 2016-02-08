using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sub_test
{
    public partial class printBidSheets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                populateItemDropdown();
                invalidMsg1.Text = "";
                invalidMsg2.Text = "";
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //populateItemDropdown();
        }

        protected void populateItemDropdown()
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

                dbConnection.Open();
                 dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                //select all valid items
                String searchString = "select distinct i.itemID "
                                       + " from item i, itemdonor id,users u "
                                       + "  where (i.itemid = id.itemid "
                                       + "  and id.userid = u.userid) ";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SqlDataAdapter da = new SqlDataAdapter(SQLString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //bind to both dropdowns
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "itemID";
                DropDownList1.DataTextField = "itemID";
                DropDownList1.DataBind();

                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "itemID";
                DropDownList2.DataTextField = "itemID";
                DropDownList2.DataBind();

                //Adding "Please select" option in dropdownlist for validation
                DropDownList1.Items.Insert(0, new ListItem("Please select", ""));
                DropDownList2.Items.Insert(0, new ListItem("Please select", ""));

                dbConnection.Close();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                         + ": " + exception.Message + "</p>");

            }
        }

        protected void print(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "window.print()", true);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                try
                {
                            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    dbConnection.Open();
                     dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                    bool flag = false;
                    string donors = "";

                    String searchString = "select i.itemid,i.itemName,i.itemValue,i.minBidPrice,(u.firstname+' '+u.lastname) as designer "
                                             + " from item i, itemdonor id, users u "
                                             + " where ( i.itemid = id.itemid "
                                             + " and id.userid = u.userid )"
                                             + " and i.itemid = @itemID";

                    SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                    SQLString.Parameters.AddWithValue("@itemID", TextBox1.Text);
                    SqlDataReader idRecords = SQLString.ExecuteReader();
                    while (idRecords.Read())
                    {
                        invalidMsg1.Text = "";
                        itemNo1.Text = idRecords["itemID"].ToString();
                        itemName1.Text = idRecords["itemName"].ToString();
                        value1.Text = idRecords["itemValue"].ToString();
                        minBid1.Text = idRecords["minBidPrice"].ToString();
                        //for multiple donors
                        donors += idRecords["designer"].ToString()+",";
                        flag = true;
                    }
                    if (flag)
                    {
                        donors = donors.Substring(0, (donors.Length - 2));
                        designer1.Text = donors;
                    }
                    else
                    {
                        invalidMsg1.Text = "Invalid Item ID";
                        invalidMsg1.ForeColor = System.Drawing.Color.Red;
                    }

                    idRecords.Close();
                    dbConnection.Close();
                }
                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                             + ": " + exception.Message + "</p>");

                }
            }
            else
            {
                invalidMsg1.Text = "Please enter an item ID or select one from the dropdown";
                invalidMsg1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox2.Text))
            {
                try
                {
                            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                    bool flag = false;
                    string donors = "";

                    String searchString = "select i.itemid,i.itemName,i.itemValue,i.minBidPrice,(u.firstname+' '+u.lastname) as designer "
                                             + " from item i, itemdonor id, users u "
                                             + " where ( i.itemid = id.itemid "
                                             + " and id.userid = u.userid )"
                                             + " and i.itemid = @itemID";

                    SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                    SQLString.Parameters.AddWithValue("@itemID", TextBox2.Text);
                    SqlDataReader idRecords = SQLString.ExecuteReader();
                    while (idRecords.Read())
                    {
                        invalidMsg2.Text = "";
                        itemNo2.Text = idRecords["itemID"].ToString();
                        itemName2.Text = idRecords["itemName"].ToString();
                        value2.Text = idRecords["itemValue"].ToString();
                        minBid2.Text = idRecords["minBidPrice"].ToString();
                        //for multiple donors
                        donors += idRecords["designer"].ToString() + ",";
                        flag = true;
                    }
                    if (flag)
                    {
                        donors = donors.Substring(0, (donors.Length - 2));
                        designer2.Text = donors;
                    }
                    else
                    {
                        invalidMsg2.Text = "Invalid Item ID";
                        invalidMsg2.ForeColor = System.Drawing.Color.Red;
                    }

                    idRecords.Close();
                    dbConnection.Close();
                }
                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                             + ": " + exception.Message + "</p>");

                }
            }
            else
            {
                invalidMsg2.Text = "Please enter an item ID or select one from the dropdown";
                invalidMsg2.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.SelectedValue;
            invalidMsg1.Text = "";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Text = DropDownList2.SelectedValue;
            invalidMsg2.Text = "";
        }
    }
}