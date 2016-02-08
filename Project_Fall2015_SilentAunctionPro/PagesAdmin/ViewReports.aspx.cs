using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class view_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindValuesToCategoryDropdown();
                getItemSummary();
            }
        }

        protected void getItemSummary()
        {
            try
            {
                 SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
              dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                String q1 = "select count(*) as count from item";
                SqlCommand q1Command = new SqlCommand(q1, dbConnection);

                String q2 = "select count(*)  as count from item where itemstatus = 'SOLD' ";
                SqlCommand q2Command = new SqlCommand(q2, dbConnection);

                String q3 = "select count(*)  as count from item where itemstatus = 'UNSOLD' ";
                SqlCommand q3Command = new SqlCommand(q3, dbConnection);

                String q4 = "select count(*)  as count from item where paymentStatus = 'YES'";
                SqlCommand q4Command = new SqlCommand(q4, dbConnection);

                String q5 = "select count(*)  as count from item where paymentStatus = 'NO'";
                SqlCommand q5Command = new SqlCommand(q5, dbConnection);

                DataTable table = new DataTable();
                table.Columns.Add("Total Number of Items");
                table.Columns.Add("Sold");
                table.Columns.Add("UnSold");
                table.Columns.Add("Paid");
                table.Columns.Add("UnPaid");

                DataRow row = table.NewRow();

                SqlDataReader q1Reader = q1Command.ExecuteReader();
                q1Reader.Read();
                row["Total Number of Items"] = q1Reader["count"];
                q1Reader.Close();

                SqlDataReader q2Reader = q2Command.ExecuteReader();
                q2Reader.Read();
                row["Sold"] = q2Reader["count"];
                q2Reader.Close();

                SqlDataReader q3Reader = q3Command.ExecuteReader();
                q3Reader.Read();
                row["UnSold"] = q3Reader["count"];
                q3Reader.Close();

                SqlDataReader q4Reader = q4Command.ExecuteReader();
                q4Reader.Read();
                row["Paid"] = q4Reader["count"];
                q4Reader.Close();

                SqlDataReader q5Reader = q5Command.ExecuteReader();
                q5Reader.Read();
                row["UnPaid"] = q5Reader["count"];
                q5Reader.Close();

                table.Rows.Add(row);


                //bind datatable to gridview;
                GridView3.DataSource = table;
                GridView3.DataBind();

                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");

            }
        }

        protected void RadioList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioList1.SelectedValue.Equals("3"))
            {
                DropDownList1.Visible = true;
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
            else
            {
                DropDownList1.Visible = false;
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
        }
        protected void bindValuesToCategoryDropdown()
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                //select all valid items
                String searchString = "select categoryName from category";

                SqlCommand SQLString = new SqlCommand(searchString, dbConnection);
                SqlDataAdapter da = new SqlDataAdapter(SQLString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //bind to both dropdowns
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "categoryName";
                DropDownList1.DataTextField = "categoryName";
                DropDownList1.DataBind();

                //Adding "Please select" option in dropdownlist for validation
                DropDownList1.Items.Insert(0, new ListItem("Please select category", "Please select category"));
                dbConnection.Close();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");

            }
        }

        protected void getValuesInGrid(int reportType)
        {
            try
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String searchString1 = "";
                String searchString2 = "";

                switch (reportType)
                {
                    case 1:
                        searchString1 = "select itemID, itemName from item where paymentStatus = 'YES'";
                        searchString2 = "select itemID, itemName from item where paymentStatus = 'NO'";
                        break;
                    case 2:
                        searchString1 = "select itemID, itemName from item where itemStatus = 'SOLD'";
                        searchString2 = "select itemID, itemName from item where itemStatus = 'UNSOLD' and approvalStatus = 1 ";
                        break;
                    case 3:
                        searchString1 = "select i.itemid, i.itemname, ido.userid as designer, "
                           + " c.categoryname, i.buyerid ,"
                           + " i.itemstatus from item i, itemdonor ido, category c "
                           + " where (i.itemid = ido.itemid and i.categoryid = c.categoryid)  "
                           + " and c.categoryname = @categoryname ";
                        searchString2 = "";
                        break;
                }

                System.Diagnostics.Debug.WriteLine("searchstring1::" + searchString1);
                System.Diagnostics.Debug.WriteLine("searchstring2::" + searchString2);

                if (reportType != 3)
                {
                    SqlCommand SQLString1 = new SqlCommand(searchString1, dbConnection);
                    SqlDataAdapter da1 = new SqlDataAdapter(SQLString1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);


                    SqlCommand SQLString2 = new SqlCommand(searchString2, dbConnection);
                    SqlDataAdapter da2 = new SqlDataAdapter(SQLString2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    //bind to both gridviews
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();


                    GridView2.DataSource = dt2;
                    GridView2.DataBind();

                }
                else if (reportType == 3)
                {
                    SqlCommand SQLString1 = new SqlCommand(searchString1, dbConnection);
                    SQLString1.Parameters.AddWithValue("@categoryname", DropDownList1.SelectedValue);
                    SqlDataAdapter da1 = new SqlDataAdapter(SQLString1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    //bind to both gridviews
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }



                dbConnection.Close();

            }
            catch (SqlException exception)
            {
                System.Diagnostics.Debug.WriteLine("There was a sql exception");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (RadioList1.SelectedValue.Equals("1"))
            {
                Label2.Text = "";
                Label3.Text = "List of Paid Items";
                Label4.Text = "List of Unpaid Items";
                getValuesInGrid(1);
                getPieChartPaymentStatus();
                GridView1.Visible = true;
                GridView2.Visible = true;

            }
            else if (RadioList1.SelectedValue.Equals("2"))
            {
                Label2.Text = "";
                Label3.Text = "List of Sold Items";
                Label4.Text = "List of Unsold Items";
                getValuesInGrid(2);
                getPieChartItemStatus();
                GridView1.Visible = true;
                GridView2.Visible = true;
            }
            else if (RadioList1.SelectedValue.Equals("3"))
            {
                if (DropDownList1.SelectedValue == "Please select category")
                {
                    Label1.Text = "*";
                    Label2.Text = "";
                    Label3.Text = "";
                    Label4.Text = "";
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                }
                else
                {
                    Label1.Text = "";
                    Label2.Text = "";
                    Label3.Text = "List of Items by category - " + DropDownList1.SelectedValue;
                    Label4.Text = "";
                    getValuesInGrid(3);
                    getPieChartCategories();
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                }
            }
            else
            {
                Label2.Text = "Please select one of the report types";
                Label2.ForeColor = System.Drawing.Color.Red;
            }


        }
        protected void getPieChartPaymentStatus()
        {
            string query = string.Format("select paymentStatus, count(*) countItem from item group by paymentStatus");

            DataTable dt = GetData(query);

            //Loop and add each datatable row to the Pie Chart Values
            foreach (DataRow row in dt.Rows)
            {
                PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                {
                    Category = row["paymentStatus"].ToString(),
                    Data = Convert.ToDecimal(row["countItem"])
                });
            }
            PieChart1.Visible = true;
        }

        protected void getPieChartItemStatus()
        {
            string query = string.Format("select itemstatus, count(*) countItem from item group by itemStatus");

            DataTable dt = GetData(query);

            //Loop and add each datatable row to the Pie Chart Values
            foreach (DataRow row in dt.Rows)
            {
                PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                {
                    Category = row["itemstatus"].ToString(),
                    Data = Convert.ToDecimal(row["countItem"])
                });
            }
            PieChart1.Visible = true;
        }

        protected void getPieChartCategories()
        {
            string query = string.Format("select categoryPrefix, count(*) countItem from category c join item i ON c.categoryID=i.categoryID group by categoryPrefix");

            DataTable dt = GetData(query);

            //Loop and add each datatable row to the Pie Chart Values
            foreach (DataRow row in dt.Rows)
            {
                PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                {
                    Category = row["categoryPrefix"].ToString(),
                    Data = Convert.ToDecimal(row["countItem"])
                });
            }
            PieChart1.Visible = true;
        }


        private static DataTable GetData(string query)
        {
            //DataTable dt = new DataTable();

            //string constr = ConfigurationManager.ConnectionStrings["SilentProConnectionString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            sda.Fill(dt);
            //        }
            //    }
            //    return dt;
            //}

            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            
            dbConnection.Open();
            SqlCommand cmd = dbConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          
            da.Fill(dt);
            return dt;
        }
    }

}