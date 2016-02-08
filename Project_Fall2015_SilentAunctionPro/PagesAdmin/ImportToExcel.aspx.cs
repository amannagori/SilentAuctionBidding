using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace importexcel_Nov29
{
    public partial class ImportToExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        public void BindGridView()
        {
            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (ext == ".xls" || ext == ".xlsx")
                {
                    string path = Server.MapPath("~/Uploads/");
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    
                    //string actualFilePath = "~/Uploads/" + FileUploadToServer.FileName;
                    //string path = Server.MapPath("~/CommonImages/");
                    //FileUploadToServer.SaveAs(path + FileUploadToServer.FileName);

                    string actualPath = "~/Uploads/" + FileUpload1.FileName;


                    string SheetName = "Products";
                    int FileSize = FileUpload1.PostedFile.ContentLength; // get filesize
                    if (FileSize <= 1048576) //1048576 byte = 1MB
                    {
                        DataTable dt = new DataTable();
                        FileInfo fi = new FileInfo(Server.MapPath(actualPath));

                        // Check if the file exists
                        if (!fi.Exists)
                            throw new Exception("File " + actualPath + " Does Not Exists");

                        using (ExcelPackage xlPackage = new ExcelPackage(fi))
                        {
                            // get the first worksheet in the workbook
                            ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[SheetName];

                            // Fetch the WorkSheet size
                            ExcelCellAddress startCell = worksheet.Dimension.Start;
                            ExcelCellAddress endCell = worksheet.Dimension.End;

                            // create all the needed DataColumn
                            for (int col = startCell.Column; col <= endCell.Column; col++)
                                dt.Columns.Add(col.ToString());

                            // place all the data into DataTable
                            for (int row = startCell.Row; row <= endCell.Row; row++)
                            {
                                DataRow dr = dt.NewRow();
                                int x = 0;
                                for (int col = startCell.Column; col <= endCell.Column; col++)
                                {
                                    dr[x++] = worksheet.Cells[row, col].Value;
                                }
                                dt.Rows.Add(dr);
                            }

                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                } // end of valid excel file 
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Style.Add("color", "red");
                    lblMsg.Text = "Please upload only Excel";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Style.Add("color", "red");
                lblMsg.Text = "Please upload an excel file";
            }
        }
    }
}
