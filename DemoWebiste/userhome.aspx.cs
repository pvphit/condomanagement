using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Drawing;

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
                GridView1.DataSource = ParentCommentIDAcess.GetAllDepartmentsandEmployee();
                GridView1.DataBind();

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
            

    protected void btnCommentPublish_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        //SqlCommand cmd = new SqlCommand();
        SqlCommand cmd = new SqlCommand("spCommentInsert", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", Session["username"].ToString());
        cmd.Parameters.AddWithValue("@CommanetMessage", textComment.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.DataSource = ParentCommentIDAcess.GetAllDepartmentsandEmployee();
        GridView1.DataBind();
    }

    protected void btnReplyParent_Click(object sender1, EventArgs evr)
    {
        GridViewRow row = (sender1 as Button).NamingContainer as GridViewRow;
        Label lblchildCommentid = (Label)row.FindControl("lb1COmmenId");
        TextBox txtCommentParent = (TextBox)row.FindControl("textCommentReplyParent");
        SqlConnection conn = new SqlConnection();

        //SqlCommand cmd = new SqlCommand();
        SqlCommand cmd = new SqlCommand("spCommentReplyInsert", conn);
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", Session["username"].ToString());
        cmd.Parameters.AddWithValue("@CommentMessage", txtCommentParent.Text);
        cmd.Parameters.AddWithValue("@ParentCommentID", lblchildCommentid.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        GridView1.DataSource = ParentCommentIDAcess.GetAllDepartmentsandEmployee();
        GridView1.DataBind();


    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}



  

