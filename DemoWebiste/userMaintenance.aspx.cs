using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userMaintenance : System.Web.UI.Page
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
                    lblUsername.Text =  dt.Rows[0]["username"].ToString();
                    lblAddress.Text =  dt.Rows[0]["address"].ToString();
                    lblEmail.Text = dt.Rows[0]["emailid"].ToString();

                }
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

            SqlCommand SelectCmd = new SqlCommand();
            SelectCmd.CommandText = "SELECT * FROM Maintenance";
            SelectCmd.Connection = conn;

            DataTable dt = new DataTable();

            SqlDataAdapter SelectAdp = new SqlDataAdapter();
            SelectAdp.SelectCommand = SelectCmd;

            SelectAdp.Fill(dt);

            SqlCommand InsertCmd = new SqlCommand();

            InsertCmd.CommandText = "INSERT INTO [Maintenance] ([username], [apartmentNumber], [userEmail], [category], [date], [maintenanceDetail]) VALUES (@fullname, @apartmentNumber, @emailid, @category, @date, @maintenanceDetail)";
            InsertCmd.Connection = conn;

            InsertCmd.Parameters.AddWithValue("@fullname", lblUsername.Text);
            InsertCmd.Parameters.AddWithValue("@apartmentNumber", lblAddress.Text);
            InsertCmd.Parameters.AddWithValue("@emailid", lblEmail.Text);
            InsertCmd.Parameters.AddWithValue("@category", CategoryList.SelectedItem.Value);
            InsertCmd.Parameters.AddWithValue("@date", date.Value);
            InsertCmd.Parameters.AddWithValue("@maintenanceDetail", bookingDetail.Value.ToString());
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                InsertCmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
            }

            Response.Redirect("userMaintenance.aspx");

        }
    }
}