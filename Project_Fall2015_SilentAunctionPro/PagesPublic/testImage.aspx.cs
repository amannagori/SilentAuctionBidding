using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesPublic
{
    public partial class testImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            string prefix = "G";
            string item_id = null;

            bool flag = true;
            try
            {

                con.Open();
                con.ChangeDatabase("nasa_SilentAuction_v1");

                string strQuery = "Select * from item where itemID Like \'" 
                                    + prefix + "%\' ";
                SqlCommand cmd = new SqlCommand(strQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                // con.Open();


                while (dr.Read())
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
                    flag = true;
                }
                if(!flag)
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
                Label1.Text += "<br/>final item id = "+ item_id;
                con.Close();
                con.Dispose();
            }
        }

            //protected void Button1_Click(object sender, EventArgs e)
            //{
            //    if (FileUpload1.HasFile)
            //    {
            //        string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
            //        if(ext== ".xls" || ext==".xlsx" || ext==".PNG" || ext==".jpg")
            //        {
            //            string path = Server.MapPath("~/CommonImages/");
            //            FileUpload1.SaveAs(path + FileUpload1.FileName);

            //            //Label1.Text = FileUpload1.PostedFile.ContentType;
            //            //Label2.Text = FileUpload1.PostedFile.ContentLength.ToString();
            //            //string fullpath = path + FileUpload1.FileName;
            //            //Label3.Text = path+"<br/>"+fullpath;
            //            Image1.ImageUrl = "~/CommonImages/"+FileUpload1.FileName;
            //        }
            //        else
            //        {
            //            Response.Write("select a excel file!!");
            //        }
            //    }
            //    else
            //    {
            //        Response.Write("select a file now!!");
            //    }

            //}
        }
}