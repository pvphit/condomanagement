using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"] != null)
        {
            tbusername.Text = Session["username"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand SelectCmd = new SqlCommand();
        SelectCmd.CommandText = "SELECT * FROM Users WHERE username = @username AND password = @password";
        SelectCmd.Connection = conn;
        SelectCmd.Parameters.AddWithValue("@username", tbusername.Text);
        SelectCmd.Parameters.AddWithValue("@password", tboldpassword.Text);

        DataTable dt = new DataTable();

        SqlDataAdapter adp = new SqlDataAdapter(SelectCmd);
        adp.Fill(dt);

        if(dt.Rows.Count > 0)
        {
            SqlCommand UpdateCmd = new SqlCommand();
            UpdateCmd.CommandText = "UPDATE users SET password = @password WHERE username = @username";
            UpdateCmd.Connection = conn;

            UpdateCmd.Parameters.AddWithValue("@username", tbusername.Text);
            UpdateCmd.Parameters.AddWithValue("@password", tbnewpassword.Text);

            if(conn.State == ConnectionState.Closed)
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
        else
        {
            Label1.Text = "Old Password is Incorrect.";
        }
    }
}