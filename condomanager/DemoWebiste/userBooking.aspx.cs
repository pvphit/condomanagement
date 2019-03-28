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

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

            SqlCommand SelectCmd = new SqlCommand();
            SelectCmd.CommandText = "SELECT * FROM booking";
            SelectCmd.Connection = conn;

            DataTable dt = new DataTable();

            SqlDataAdapter SelectAdp = new SqlDataAdapter();
            SelectAdp.SelectCommand = SelectCmd;

            SelectAdp.Fill(dt);

            SqlCommand InsertCmd = new SqlCommand();

            InsertCmd.CommandText = "INSERT INTO [booking] ([category], [date], [timeFrom], [timeTo], [bookingDetail]) VALUES (@category, @date, @timeFrom, @timeTo, @bookingDetail)";
            InsertCmd.Connection = conn;

            InsertCmd.Parameters.AddWithValue("@category", CategoryList.SelectedItem.Value);
            InsertCmd.Parameters.AddWithValue("@date", date.Text);
            InsertCmd.Parameters.AddWithValue("@timeFrom", timeFrom.Text);
            InsertCmd.Parameters.AddWithValue("@timeTo", timeTo.Text);
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

            Response.Redirect("signupsuccess.aspx");
            
        }
    }
}