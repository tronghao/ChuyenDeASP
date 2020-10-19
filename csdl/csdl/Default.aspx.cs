using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class _Default : System.Web.UI.Page
{
    ketnoi kn = new ketnoi();
    //con = new SqlConnection("server= .;database = QLNHCH;Integrated security = true;");
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if(!IsPostBack)
        {
            hienthi();
        }
    }

    public void hienthi()
    {

        string sql = "select username,fullname,email,gender from tbluser"; // câu lệnh truy vấn
        SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
        DataSet ds = new DataSet();
        da.Fill(ds); //ds dang giu csdl
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
   
    protected void btThem_Click(object sender, EventArgs e)
    {
        try { 
        SqlCommand cmd = new SqlCommand("insert into tbluser(username,password,fullname) values('" + txtUser.Text + "','" + kn.mahoa(txtPass.Text) + "',N'" + txtFullname.Text + "')", kn.con);
        kn.con.Open();
        int co;
        co= cmd.ExecuteNonQuery();
        if(co==0)
            Response.Write("<script>alert('Lỗi dữ liệu')</script>");
        kn.con.Close();
            //Response.Write("<script>alert('Thanh cong')</script>");
        }
        catch (System.Exception excep)
        {
            Response.Write("<script>alert('Khong the them')</script>");
        }
        hienthi();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        this.txtUser.Text = row.Cells[2].Text;
        this.txtFullname.Text =HttpUtility.HtmlDecode((string)(row.Cells[3].Text.ToString()));
        
    }

    protected void btSua_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("update tbluser set fullname=N'"+txtFullname.Text+"'  where username='" + txtUser.Text + "'", kn.con);
        kn.con.Open();
        cmd.ExecuteNonQuery();
        kn.con.Close();
        //Response.Write("<script>alert('Thanh cong')</script>");
        hienthi();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string a = GridView1.DataKeys[e.RowIndex].Values["username"].ToString();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = kn.con;
        cmd.CommandText = "delete from tbluser where username='" + a + "'";
        cmd.CommandType = CommandType.Text;

        kn.con.Open(); // mo ket noi
        cmd.ExecuteNonQuery(); // thực thi 
        kn.con.Close(); // dong ket noi
        hienthi();
    }

    protected void bttim_Click(object sender, EventArgs e)
    {
        string sql = "select username,fullname from tbluser where fullname like '%"+TextBox1.Text+"%'"; // câu lệnh truy vấn
        SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
        DataSet ds = new DataSet();
        da.Fill(ds); //ds dang giu csdl
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}