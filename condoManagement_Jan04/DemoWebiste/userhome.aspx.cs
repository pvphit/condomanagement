using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class userhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
         
            if (IsPostBack == false)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE username = @username";
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());

                DataTable dt = new DataTable();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    Label1.Text = "Welcome, " + dt.Rows[0]["fullname"].ToString();

                }
            }

        }
      
       
    }
}