using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class ExportToExcel_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = GetProducts();
                GridView1.DataBind();
            }
        }

        protected void ExportToExcel_Click(object sender, EventArgs e)
        {
            var products = GetProducts();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Products");
            var totalCols = products.Columns.Count;
            var totalRows = products.Rows.Count;

            for (var col = 1; col <= totalCols; col++)
            {
                workSheet.Cells[1, col].Value = products.Columns[col - 1].ColumnName;
            }
            for (var row = 1; row <= totalRows; row++)
            {
                for (var col = 0; col < totalCols; col++)
                {
                    workSheet.Cells[row + 1, col + 1].Value = products.Rows[row - 1][col];
                }
            }
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename= BuyerDetails.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        public DataTable GetProducts()
        {

            using (var conn = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true"))
            using (var cmd = new SqlCommand("select u.FIRSTNAME, u.LASTNAME, i.ITEMNAME, "
                                   + " c.CATEGORYID , c.CATEGORYNAME , i.SELLINGPRICE, "
                                   + " (u.ADDRESSLINE1 +', '+u.ADDRESSLINE2+', '+u.CITY+', '+', '+u.STATENAME+', '+u.COUNTRY) as ADDRESS,"
                                   + " u.PHONEHOME, u.CELLPHONE, "
                                   + " i.PAYMENTSTATUS "
                                   + " from users u, item i, category c "
                                   + " where (u.USERID = i.BUYERID "
                                   + " and i.CATEGORYID = c.CATEGORYID) "
                                   + " and i.BUYERID is not null", conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                var products = new DataTable();
                adapter.Fill(products);
                return products;
            }
        }
    }
}