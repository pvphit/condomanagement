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
            Boolean checkusertype = checkuser();
            if(checkusertype)
            {
                Response.Redirect("DefaultAdminHome.aspx");
            }
            else
            {

                Response.Redirect("userhome.aspx");
            }
            //if (tbusername.Text == "employee")
            //{
            //    Response.Redirect("employeeBooking.aspx");

            //}  
        }
        else
        {
            Label1.Text = "Invalid Username/Password";
        }
    }

    protected Boolean checkuser()
    {
        SqlConnection conn1 = new SqlConnection();
        conn1.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;
        conn1.Open();
        string query= "SELECT role FROM Users WHERE username = @username";
        SqlCommand cmd1 = new SqlCommand(query,conn1);
        cmd1.Parameters.AddWithValue("@username", tbusername.Text);
        string role = cmd1.ExecuteScalar().ToString();
        if(role=="admin")
        {
            conn1.Close();
            return true;
        }
        conn1.Close();
        return false;
    }
}