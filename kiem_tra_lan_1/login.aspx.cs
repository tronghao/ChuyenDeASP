using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

public partial class login : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        String username = txtTenDangNhap.Text;
        String password = connect.mahoa(txtMatKhau.Text);
        
        String sql = "select * from tbl_nguoi_dung where ten_tai_khoan='" + username + "' and mat_khau='" + password + "'";
        DataTable duLieuDangNhap = connect.LayBang(sql);
        if (coDuLieu(duLieuDangNhap))
        {
            Session["user"] = username;
            Session["id"] = duLieuDangNhap.Rows[0][0].ToString();
            Session["quyen"] = true;
            Response.Redirect("thongtin.aspx");
        }
        else Response.Write("<script>alert('Tên đăng nhập hoặc mật khẩu không đúng')</script>");

    }

    bool coDuLieu(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            return true;
        else return false;
    }



    protected void btnDangNhapGoogle_Click(object sender, EventArgs e)
    {
        //your client id  
        string clientid = "431346109080-furu6dr21vahdc3m3m1vhp6v94537vc0.apps.googleusercontent.com";
        //your client secret  
        string clientsecret = "7kZNmPsGd5IoSVZLfqyMAtm8";
        //your redirection url  
        string redirection_url = "http://localhost:55433/google-callback.aspx";
        string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
        Response.Redirect(url);
    }

}