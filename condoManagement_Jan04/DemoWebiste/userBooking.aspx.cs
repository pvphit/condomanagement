using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class userBooking : System.Web.UI.Page
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
                    lblUsername.Text = dt.Rows[0]["username"].ToString();
                    lblAddress.Text = dt.Rows[0]["address"].ToString();
                    lblEmail.Text = dt.Rows[0]["emailid"].ToString();

                }
            }

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString
            };

            SqlCommand SelectCmd = new SqlCommand
            {
                CommandText = "SELECT * FROM booking",
                Connection = conn
            };

            DataTable dt = new DataTable();

            SqlDataAdapter SelectAdp = new SqlDataAdapter
            {
                SelectCommand = SelectCmd
            };

            SelectAdp.Fill(dt);

            SqlCommand InsertCmd = new SqlCommand
            {
                CommandText = "INSERT INTO [booking] ([username], [apartmentNumber], [userEmail], [category], [date], [timeFrom], [timeTo], [bookingDetail]) VALUES (@fullname, @apartmentNumber, @emailid, @category, @date, @timeFrom, @timeTo, @bookingDetail)",
                Connection = conn
            };

            InsertCmd.Parameters.AddWithValue("@fullname", lblUsername.Text);
            InsertCmd.Parameters.AddWithValue("@apartmentNumber", lblAddress.Text);
            InsertCmd.Parameters.AddWithValue("@emailid", lblEmail.Text);
            InsertCmd.Parameters.AddWithValue("@category", CategoryList.SelectedItem.Value);
            InsertCmd.Parameters.AddWithValue("@date", date.Value);
            InsertCmd.Parameters.AddWithValue("@timeFrom", timeFrom.Value);
            InsertCmd.Parameters.AddWithValue("@timeTo", timeTo.Value);
            InsertCmd.Parameters.AddWithValue("@bookingDetail", bookingDetail.Value.ToString());
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

            Response.Redirect("userBooking.aspx");
            
        }
    }
}