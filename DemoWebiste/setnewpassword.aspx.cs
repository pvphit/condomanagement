using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class setnewpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack  == false)
        {
            if(Request.QueryString["q"] != null && Request.QueryString["em"] != null)
            {
                string status = Request.QueryString["q"];
                string email = HttpUtility.UrlDecode(Request.QueryString["em"]);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

                SqlCommand SelectCmd = new SqlCommand();
                SelectCmd.CommandText = "SELECT * FROM Users WHERE emailid = @emailid AND status = @status";
                SelectCmd.Connection = conn;
                SelectCmd.Parameters.AddWithValue("@emailid", email);
                SelectCmd.Parameters.AddWithValue("@status", status);

                DataTable dt = new DataTable();

                SqlDataAdapter adp = new SqlDataAdapter(SelectCmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["username"].ToString();
                    Panel1.Visible = true;
                    Label1.Text = "";
                }
                else
                {
                    Panel1.Visible = false;
                    Label1.Text = "Invalid Page.";
                }
            }
            else
            {
                Panel1.Visible = false;
                Label1.Text = "Invalid Page.";
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;


        SqlCommand UpdateCmd = new SqlCommand();
        UpdateCmd.CommandText = "UPDATE users SET password = @password WHERE username = @username";
        UpdateCmd.Connection = conn;

        UpdateCmd.Parameters.AddWithValue("@username", HiddenField1.Value);
        UpdateCmd.Parameters.AddWithValue("@password", tbnewpassword.Text);

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }

        try
        {
            UpdateCmd.ExecuteNonQuery();
            conn.Close();
            Label1.Text = "Password changed successfully";
        }
        catch (Exception)
        {
            conn.Close();
        }
    }
}