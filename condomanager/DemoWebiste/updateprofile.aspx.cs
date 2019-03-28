using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class updateprofile : System.Web.UI.Page
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
                    tbusername.Text = dt.Rows[0]["username"].ToString();
                    tbfullname.Text = dt.Rows[0]["fullname"].ToString();
                    tbemail.Text = dt.Rows[0]["emailid"].ToString();
                    tbphoneno.Text = dt.Rows[0]["phoneno"].ToString(); ;
                    tbaddress.Text = dt.Rows[0]["address"].ToString();
                    RadioButtonList1.SelectedValue = dt.Rows[0]["gender"].ToString();
                }
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "UPDATE [Users] SET [fullname] = @fullname, [emailid] = @emailid, [phoneno] = @phoneno, [address] = @address, [gender] = @gender WHERE [username] = @username";
        cmd.Connection = conn;

        cmd.Parameters.AddWithValue("@fullname",tbfullname.Text);
        cmd.Parameters.AddWithValue("@emailid",tbemail.Text);
        cmd.Parameters.AddWithValue("@phoneno",tbphoneno.Text);
        cmd.Parameters.AddWithValue("@address",tbaddress.Text);
        cmd.Parameters.AddWithValue("@gender",RadioButtonList1.SelectedValue);
        cmd.Parameters.AddWithValue("@username",tbusername.Text);

        if(conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }

        try
        {
            cmd.ExecuteNonQuery();
            conn.Close();
            Label1.Text = "Profile Updated";
        }
        catch (Exception)
        {
            conn.Close();
        }
       
    }
}