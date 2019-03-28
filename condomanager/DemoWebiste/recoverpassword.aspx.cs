using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recoverpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

        SqlCommand SelectCmd = new SqlCommand();
        SelectCmd.CommandText = "SELECT * FROM Users WHERE username = @username";
        SelectCmd.Connection = conn;
        SelectCmd.Parameters.AddWithValue("@username", TextBox1.Text);

        DataTable dt = new DataTable();

        SqlDataAdapter adp = new SqlDataAdapter(SelectCmd);
        adp.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            string status = "";

            Random rn = new Random();

            for (int i = 0; i < 20; i++)
            {
                status += (char)rn.Next(65, 65 + 26);
            }

            SqlCommand UpdateCmd = new SqlCommand();
            UpdateCmd.CommandText = "UPDATE users SET status = @status WHERE username = @username";
            UpdateCmd.Connection = conn;

            UpdateCmd.Parameters.AddWithValue("@username", TextBox1.Text);
            UpdateCmd.Parameters.AddWithValue("@status", status);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                UpdateCmd.ExecuteNonQuery();
                conn.Close();

                string URL = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/setnewpassword.aspx?q=" + status + "&em=" + HttpUtility.UrlEncode(dt.Rows[0]["emailid"].ToString());

                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(dt.Rows[0]["emailid"].ToString()));
                mail.From = new MailAddress("shahbaz.0092.ss@gmail.com");
                mail.Subject = "Recover Password";
                mail.Body = "Click <a href=\"" + URL + "\">here</a> to recover password ";
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("shahbaz.0092.ss@gmail.com", "Shah@0092ss");

                try
                {
                    client.Send(mail);
                }
                catch (Exception)
                {

                }

                Label1.Text = "A recovery email has been sent to your registered emailid";
            }
            catch (Exception)
            {
                conn.Close();
            }

        }
        else
        {
            Label1.Text = "Username is Incorrect.";
        }
    }
}