using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
public partial class login : System.Web.UI.Page
{
    ketnoi kn = new ketnoi();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        string passmahoa = kn.mahoa(txtPass.Text);

        SqlDataAdapter da = new SqlDataAdapter("select * from tbluser where username='" + txtUser.Text + "' and password='" + passmahoa + "'", kn.con);
        DataTable tb = new DataTable();
        da.Fill(tb);
        if (tb.Rows.Count > 0)
        {
            Session["name"] = txtUser.Text; // luu lại 
            Session["allow"] = true; //
            Response.Redirect("quanly.aspx");
        }
        else Response.Write("<script>alert('Username/Password chưa đúng')</script>");
    }
}