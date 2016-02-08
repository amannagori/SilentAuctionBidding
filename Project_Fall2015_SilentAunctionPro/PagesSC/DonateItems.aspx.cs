using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesSC
{
    public partial class DonateItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Important: If didn't check this, the list will get re-populated (and the 1st item will be the selected one)!
            if (!IsPostBack) 
            {
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                string SQLString = "SELECT DISTINCT categoryName,categoryPrefix FROM category";

                SqlCommand cmd = new SqlCommand(SQLString, dbConnection);

               

                SqlDataReader ddlValues;
                ddlValues = cmd.ExecuteReader();

                DropDownList1.DataSource = ddlValues;
                DropDownList1.DataValueField = "categoryPrefix";
                DropDownList1.DataTextField = "categoryName";
                DropDownList1.DataBind();

                dbConnection.Close();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         SqlConnection con = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

           string prefix =  DropDownList1.SelectedValue;
           string item_id = null;
            string userid = (string)Session["user_id"];


            try
            {

                con.Open();
                con.ChangeDatabase("nasa_SilentAuction_v1");

                string strQuery = "Select * from item where itemID Like \'" + prefix + "%\' order by itemID desc";
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                // con.Open();
                

                if (dr.Read())
                {
                    int pos = 0;
                    string str = dr.GetString(0);

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] >= '0' && str[i] <= '9')
                        {
                            pos = i;
                            break;
                        }

                    }// end of for loop

                    int count = Convert.ToInt32(str.Substring(pos));
                    count++;

                    item_id = prefix + count;

                }
                else
                {
                    item_id = prefix + "1";
                }
                dr.Close();
            }// End of try 1

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            finally
            {
                
                con.Close();
                con.Dispose();
            }

            SqlConnection con1 = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                // method call for fecthing CategoryID
               string categoryID = getcategoryID(prefix);

                con1.Open();
                con1.ChangeDatabase("nasa_SilentAuction_v1");

                string query = "INSERT INTO item (itemID,itemName,itemdesc," +
                            "itemValue,itemStatus,paymentStatus,categoryID)" +
                     "VALUES(@itemID,@itemName,@itemdesc,@itemValue," +
                             "@itemStatus,@paymentStatus,@categoryID)";

                SqlCommand sqlCommandEmp = new SqlCommand(query, con1);

                sqlCommandEmp.Parameters.AddWithValue("@itemID", item_id);
                sqlCommandEmp.Parameters.AddWithValue("@itemName", item_name.Text);
                sqlCommandEmp.Parameters.AddWithValue("@itemdesc", item_desc.Text);
                sqlCommandEmp.Parameters.AddWithValue("@itemValue", Convert.ToDouble(item_val.Text));
                sqlCommandEmp.Parameters.AddWithValue("@itemStatus", false);
                sqlCommandEmp.Parameters.AddWithValue("@paymentStatus", false);
                sqlCommandEmp.Parameters.AddWithValue("@categoryID", categoryID);

                sqlCommandEmp.ExecuteNonQuery();
                // Image Upload
                ImageUpload(item_id);

                // Inserting into ItemDonor
                string query1 = "INSERT INTO itemDonor (itemID,userID)" +
                                 "VALUES(@itemID,@userID)";
                SqlCommand sqlCommandEmp1 = new SqlCommand(query1, con1);

                sqlCommandEmp1.Parameters.AddWithValue("@itemID", item_id);
                sqlCommandEmp1.Parameters.AddWithValue("@userID", userid);
                sqlCommandEmp1.ExecuteNonQuery();

                lblStatus.Text = "sucessfully Inserted";
            }// End of try 2
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            finally
            {
                con1.Close();
                con1.Dispose();
            }

        }

        protected string getcategoryID(string str)
        {
            SqlConnection con1 = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            string a = "";
            try
            {
               

                con1.Open();
                con1.ChangeDatabase("nasa_SilentAuction_v1");

                // string strQuery = "Select c.categoryID from category c join item i  on i.categoryID = c.categoryID where c.categoryPrefix = \'" + str+"\'";
                string strQuery = "Select categoryID from category where categoryPrefix = \'" + str + "\'";
                SqlCommand cmd = new SqlCommand(strQuery, con1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = (string)dr["categoryID"];
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            finally
            {

                con1.Close();
                con1.Dispose();
            }

            return a;
        }



        // for file upload
        protected void ImageUpload(string temp)
        {
            if (FileUpload1.PostedFile != null)
            {

                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                //Save files to disk
                FileUpload1.SaveAs(Server.MapPath("images/" + FileName));

                SqlConnection con = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

                try
                {

                    con.Open();
                    con.ChangeDatabase("nasa_SilentAuction_v1"); // change itk368XXXX to your ID here
                                                           //                        dbConnection.ChangeDatabase("368SQLDB");

                    string strQuery = "Update item SET filePath = @filePath where itemID = \'"+ temp + "\'";
                    SqlCommand cmd = new SqlCommand(strQuery, con);
                    // cmd.Parameters.AddWithValue("@ImageID", ImageID);
                   // cmd.Parameters.AddWithValue("@FileName", FileName);
                    cmd.Parameters.AddWithValue("@filePath", "images/" + FileName);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    // con.Open();
                    cmd.ExecuteNonQuery();

                    lblStatus.Text = "Image sucessfully uploaded";
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }

        }

       
    }
}