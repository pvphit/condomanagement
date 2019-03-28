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

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            /// If we are using SQLDataSource
            //DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            //bool AlreadyExists = false;
            //for (int i = 0; i < dv.Table.Rows.Count; i++)
            //{
            //    if(dv.Table.Rows[i]["username"].ToString() == tbusername.Text)
            //    {
            //        AlreadyExists = true;
            //        break;
            //    }
            //}
            //if(AlreadyExists)
            //{
            //    Label1.Text = "Username is already taken.";
            //}
            //else
            //{
            //    SqlDataSource1.Insert();
            //    Response.Redirect("signupsuccess.aspx");
            //}       

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DemoConnectionString"].ConnectionString;

            SqlCommand SelectCmd = new SqlCommand();
            SelectCmd.CommandText = "SELECT * FROM Users";
            SelectCmd.Connection = conn;

            DataTable dt = new DataTable();

            SqlDataAdapter SelectAdp = new SqlDataAdapter();
            SelectAdp.SelectCommand = SelectCmd;

            SelectAdp.Fill(dt);

            bool UsernameAlreadyExists = false;
            bool EmailAlreadyExists = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["username"].ToString() == tbusername.Text)
                {
                    UsernameAlreadyExists = true;
                    break;
                }
                if (dt.Rows[i]["emailid"].ToString() == tbemail.Text)
                {
                    EmailAlreadyExists = true;
                    break;
                }
            }

            if(UsernameAlreadyExists)
            {
                Label1.Text = "Username is already taken.";
            }
            else if(EmailAlreadyExists)
            {
                Label1.Text = "Email is already registered.";
            }
            else if(!UsernameAlreadyExists && !EmailAlreadyExists)
            {
                SqlCommand InsertCmd = new SqlCommand();
                InsertCmd.CommandText = "INSERT INTO [Users] ([username], [password], [fullname], [emailid], [phoneno], [address], [gender]) VALUES (@username, @password, @fullname, @emailid, @phoneno, @address, @gender)";
                InsertCmd.Connection = conn;

                InsertCmd.Parameters.AddWithValue("@username",tbusername.Text);
                InsertCmd.Parameters.AddWithValue("@password",tbpassword.Text);
                InsertCmd.Parameters.AddWithValue("@fullname",tbfullname.Text);
                InsertCmd.Parameters.AddWithValue("@emailid",tbemail.Text);
                InsertCmd.Parameters.AddWithValue("@phoneno",tbphoneno.Text);
                InsertCmd.Parameters.AddWithValue("@address",tbaddress.Text);
                InsertCmd.Parameters.AddWithValue("@gender",RadioButtonList1.SelectedValue);
                
                if(conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                try
                {
                    InsertCmd.ExecuteNonQuery();
                    conn.Close();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(new MailAddress(tbemail.Text));
                    mail.From = new MailAddress("vmm.students2010@gmail.com");
                    mail.Subject = "Thanks for Signing Up";
                    mail.Body = "Your username : " + tbusername.Text + " and password : " + tbpassword.Text;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("vmm.students2010@gmail.com", "helloworld06125");

                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                }

                Response.Redirect("signupsuccess.aspx");

            }

        }
        else
        {
            Label1.Text = "Please enable JavaScript on your browser.";
        }
    }
}