using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login2 : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        String username = txtUserName.Text;
        String password = connect.mahoa(txtPassword.Text);

        String sql = "select * from tbl_nguoi_dung where ten_tai_khoan='" + username + "' and mat_khau='" + password + "'";
        DataTable duLieuDangNhap = connect.LayBang(sql);
        if (coDuLieu(duLieuDangNhap))
        {
            Session["user"] = username;
            Session["quyen"] = true;
            //Response.Redirect("Default.aspx");
        }
        else Response.Write("<script>alert('Tên đăng nhập hoặc mật khẩu không đúng')</script>");

    }

    bool coDuLieu(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            return true;
        else return false;
    }
}