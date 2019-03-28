using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchusers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SearchUsers();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SearchUsers();
    }

    void SearchUsers()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand SelectCmd = new SqlCommand();
        SelectCmd.CommandText = "SELECT * FROM Users WHERE (username LIKE @search + '%') OR (emailid = @search)";
        SelectCmd.Connection = conn;

        SelectCmd.Parameters.AddWithValue("@search", tbsearch.Text);

        DataTable dt = new DataTable();

        SqlDataAdapter SelectAdp = new SqlDataAdapter();
        SelectAdp.SelectCommand = SelectCmd;

        SelectAdp.Fill(dt);

        if(dt.Rows.Count > 0)
        {
            Label4.Text = "";
            if(RadioButtonList1.SelectedIndex == 0)
            {
                GridView1.Visible = true;
                DataList1.Visible = false;
                Label4.Visible = false;

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if(RadioButtonList1.SelectedIndex == 1)
            {
                GridView1.Visible = false;
                DataList1.Visible = true;
                Label4.Visible = false;

                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
        else
        {
            GridView1.Visible = false;
            DataList1.Visible = false;
            Label4.Visible = true;

            Label4.Text = "No users found";
        }
    }

    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        Session["chatuser"] = e.CommandArgument.ToString();
        Response.Redirect("chat.aspx");
    }

    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        Session["chatuser"] = e.CommandArgument.ToString();
        Response.Redirect("chat.aspx");
    }
}