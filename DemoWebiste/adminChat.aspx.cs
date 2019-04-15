using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class adminChat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["chatuser"] == null)
        {
            Response.Redirect("searchusers.aspx");
        }
        {
            Label1.Text = Session["chatuser"].ToString();
            if (!IsPostBack)
            {
                ShowChat();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand InsertCmd = new SqlCommand();
        InsertCmd.CommandText = "INSERT INTO [Messages] ([message], [sentby], [sento], [datetimeofmsg]) VALUES (@message, @sentby, @sento, @datetimeofmsg)";
        InsertCmd.Connection = conn;

        InsertCmd.Parameters.AddWithValue("@message", TextBox1.Text);
        InsertCmd.Parameters.AddWithValue("@sentby", Session["username"].ToString());
        InsertCmd.Parameters.AddWithValue("@sento", Session["chatuser"].ToString());
        InsertCmd.Parameters.AddWithValue("@datetimeofmsg", DateTime.Now);

        DataTable dt = new DataTable();

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }

        try
        {
            InsertCmd.ExecuteNonQuery();
            TextBox1.Text = "";
            conn.Close();
        }
        catch (Exception ex)
        {
            conn.Close();
            Label1.Text = ex.Message;
        }
        ShowChat();
    }

    void ShowChat()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand SelectCmd = new SqlCommand();
        SelectCmd.CommandText = "SELECT * FROM Messages WHERE (sentby = @sentby AND sento = @sento) OR (sentby = @sento AND sento = @sentby)";
        SelectCmd.Connection = conn;

        SelectCmd.Parameters.AddWithValue("@sentby", Session["username"].ToString());
        SelectCmd.Parameters.AddWithValue("@sento", Session["chatuser"].ToString());

        DataTable dt = new DataTable();

        SqlDataAdapter SelectAdp = new SqlDataAdapter();
        SelectAdp.SelectCommand = SelectCmd;

        SelectAdp.Fill(dt);

        DataList1.DataSource = dt;
        DataList1.DataBind();

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ShowChat();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label lblsender = e.Item.FindControl("Label2") as Label;

        if (lblsender.Text == Session["username"].ToString())
        {
            e.Item.CssClass = "alert-success";
        }
        else if (lblsender.Text == Session["chatuser"].ToString())
        {
            e.Item.CssClass = "alert-info";
        }
    }
}