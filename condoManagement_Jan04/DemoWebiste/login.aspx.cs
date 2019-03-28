using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM Users WHERE username = @username AND password = @password";
        cmd.Connection = conn;

        cmd.Parameters.AddWithValue("@username", tbusername.Text);
        cmd.Parameters.AddWithValue("@password", tbpassword.Text);

        DataTable dt = new DataTable();

        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        adp.Fill(dt);

        if(dt.Rows.Count > 0)
        {
            Session["username"] = tbusername.Text;

            if (tbusername.Text == "employee")
            {
                Response.Redirect("employeeBooking.aspx");

            }
            else
            {
               
                Response.Redirect("userhome.aspx");
            }
            
        }
        else
        {
            Label1.Text = "Invalid Username/Password";
        }
    }
}