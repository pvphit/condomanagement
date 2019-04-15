using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class adminMaintance : System.Web.UI.Page
{
    private SqlConnection conn = new SqlConnection("Data Source=sql5041.site4now.net;User ID=DB_A46EAA_cm_admin;Password=condo123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvbind();
        }
    }

    protected void gvbind()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * from Maintenance", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete FROM Maintenance where id=" +id, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        gvbind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        gvbind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        TextBox username = (TextBox)row.Cells[0].Controls[0];
        TextBox apartmentNumber = (TextBox)row.Cells[1].Controls[0];
        TextBox userEmail = (TextBox)row.Cells[2].Controls[0];
        TextBox category = (TextBox)row.Cells[3].Controls[0];
        TextBox date = (TextBox)row.Cells[4].Controls[0];
        TextBox maintenanceDetail = (TextBox)row.Cells[5].Controls[0];
        conn.Open();
        SqlCommand cmd = new SqlCommand("update Maintenance set username='" + username.Text + "',apartmentNumber='" + apartmentNumber.Text + "', userEmail='" + userEmail.Text + "', category='" 
            + category.Text + "', date='" + date.Text + "', maintenanceDetail='" + maintenanceDetail.Text + "' where id='" + id+"'", conn);
       cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        gvbind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        gvbind();
    }

}