using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Fall2015_SilentAunctionPro.PagesAdmin
{
    public partial class ViewItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateCatagories();
                Session["prevAList"] = "";
                Session["prevBList"] = "";
                        SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                //string img= "../UserWebForms/";
                dbConnection.Open();
                dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                //string sqlQuery = "select * from item where approvalStatus=" +true;
                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from item where approvalStatus= 1";


                //string strQuery = "select * from item where approvalStatus=1";
                //SqlCommand cmd = new SqlCommand(strQuery, dbConnection);

                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = CommandText.te
                cmd.Connection = dbConnection;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // SqlDataReader pendingListDisplay = cmd.ExecuteReader();
                da.Fill(dt);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                dbConnection.Close();

            }
        }

        void populateCatagories()
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");

            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");
                String query = "SELECT * FROM category";
                SqlCommand catList1 = new SqlCommand(query, dbConnection);
                SqlDataReader catListDisplay = catList1.ExecuteReader();

                ListItem item1 = new ListItem();
                item1.Text = "All";
                item1.Value = "All";
                item1.Selected = true;

                CheckBoxList1.Items.Add(item1);

                while (catListDisplay.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = catListDisplay["categoryName"].ToString();
                    item.Value = catListDisplay["categoryPrefix"].ToString();
                    CheckBoxList1.Items.Add(item);
                }

                dbConnection.Close();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cat = "";
            //Label1.Text = "Categories changed";
            ArrayList prevAl = new ArrayList();
            string prevAList = Session["prevAList"].ToString();
            int t = 0;
            for (int i = 0; i < prevAList.Length; i++)
                if (prevAList[i] == ',')
                    t++;
            int tx = t;
            while (prevAList.Length > 0)
            {
                if (tx > 1)
                {
                    prevAl.Add(prevAList.Substring(0, prevAList.IndexOf(",")));
                    prevAList = prevAList.Substring(prevAList.IndexOf(",") + 1);
                }
                else
                {
                    prevAl.Add(prevAList.Substring(0, prevAList.IndexOf(",")));
                    prevAList = "";
                }
                tx--;
            }

            ArrayList al = new ArrayList();

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                    al.Add(item.Value);
            }

            string val = "";

            foreach (string item1 in al)
            {
                bool fflag = false;
                foreach (string item2 in prevAl)
                {
                    if (item1 == item2)
                        fflag = true;
                }
                if (!fflag)
                    val = item1;
            }

            switch (val)
            {
                case "All":
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        if (item.Value != "All")
                        {
                            item.Selected = false;
                        }
                    }
                    break;

                default:
                    CheckBoxList1.Items[0].Selected = false;
                    break;
            }

            prevAList = "";
            prevAl.Clear();
            al.Clear();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    prevAList += item.Value + ",";
                    if (item.Value != "All")
                    {
                        al.Add(item.Value);
                    }
                }
            }

            Session["prevAList"] = prevAList;
            if (al.Count == 0)
                cat = "1=1";
            else
            {
                int i = 0;
                foreach (String c in al)
                {
                    if (i == 0)
                        cat = "itemID LIKE \'" + c + "%\'";
                    else
                        cat += "OR itemID LIKE \'" + c + "%\'";
                    i++;
                }
            }
            String query1 = "Select * from item where " + cat + " and approvalStatus=1";
            Session["q1"] = query1;
            //Label1.Text += query1;
            executeQuery();
        }

        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cat = "";
            //Label1.Text = "Prices changed";
            ArrayList prevBl = new ArrayList();
            string prevBList = Session["prevBList"].ToString();
            int t = 0;
            for (int i = 0; i < prevBList.Length; i++)
                if (prevBList[i] == ',')
                    t++;
            int tx = t;
            while (prevBList.Length > 0)
            {
                if (tx > 1)
                {
                    prevBl.Add(prevBList.Substring(0, prevBList.IndexOf(",")));
                    prevBList = prevBList.Substring(prevBList.IndexOf(",") + 1);
                }
                else
                {
                    prevBl.Add(prevBList.Substring(0, prevBList.IndexOf(",")));
                    prevBList = "";
                }
                tx--;
            }

            ArrayList al = new ArrayList();

            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected)
                    al.Add(item.Value);
            }

            string val = "";

            foreach (string item1 in al)
            {
                bool fflag = false;
                foreach (string item2 in prevBl)
                {
                    if (item1 == item2)
                        fflag = true;
                }
                if (!fflag)
                    val = item1;
            }

            switch (val)
            {
                case "All":
                    foreach (ListItem item in CheckBoxList2.Items)
                    {
                        if (item.Value != "All")
                        {
                            item.Selected = false;
                        }
                    }
                    break;

                default:
                    CheckBoxList2.Items[0].Selected = false;
                    break;
            }

            prevBList = "";
            prevBl.Clear();
            al.Clear();
            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected)
                {
                    prevBList += item.Value + ",";
                    if (item.Value != "All")
                    {
                        al.Add(item.Value);
                    }
                }
            }

            Session["prevBList"] = prevBList;

            if (al.Count == 0)
                cat = "1=1";
            else
            {
                int i = 0;
                foreach (String c in al)
                {
                    switch (c)
                    {
                        case "p1":
                            cat += "itemValue<=100";
                            break;
                        case "p2":
                            cat += "itemValue>100 and itemValue<=200";
                            break;
                        case "p3":
                            cat += "itemValue>200 and itemValue<=300";
                            break;
                        case "p4":
                            cat += "itemValue>300 and itemValue<=400";
                            break;
                        case "p5":
                            cat += "itemValue>400";
                            break;
                    }
                    if (i != al.Count - 1)
                        cat += " OR ";
                    i++;
                }
            }
            String query1 = "Select * from item where " + cat + " and approvalStatus=1";
            Session["q2"] = query1;
            //Label1.Text += query1;
            executeQuery();
        }

        void executeQuery()
        {
            String mainQuery = "";
            ArrayList queryArr = new ArrayList();
            for (int i = 0; i <= 2; i++)
                queryArr.Add("");

            queryArr[0] = (String)(Session["q0"]);
            queryArr[1] = (String)(Session["q1"]);
            queryArr[2] = (String)(Session["q2"]);
            for (int i = 0; i < 3; i++)
            {
                String temp = (String)queryArr[i] + "";
                if ((temp.Length != 0))
                {
                    if (mainQuery.Length == 0)
                        mainQuery += queryArr[i];
                    else
                        mainQuery += " INTERSECT " + queryArr[i];
                }
            }
            //Label1.Text = mainQuery;
            displayNewGrid(mainQuery);
        }

        void displayNewGrid(String query)
        {
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            try
            {
                dbConnection.Open();
               dbConnection.ChangeDatabase("nasa_SilentAuction_v1");

                SqlCommand cmd = dbConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                cmd.Connection = dbConnection;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // SqlDataReader pendingListDisplay = cmd.ExecuteReader();
                da.Fill(dt);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                dbConnection.Close();
            }
            catch (SqlException exception)
            {
                Response.Write("Exception: " + exception.Message);
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            string temp = itemName.Text;
            string query1 = "SELECT * FROM item where itemName LIKE \'%" + temp + "%\'";
            Session["q0"] = query1;
            executeQuery();
        }
    }
}