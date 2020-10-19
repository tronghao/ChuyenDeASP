using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thongtin : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        if(!IsPostBack)
        {
            String id = Session["id"].ToString();
            String sql = "select * from tbl_nguoi_dung where id='" + id + "'";
            DataTable duLieuDangNhap = connect.LayBang(sql);
            lbTenTaiKhoan.Text = duLieuDangNhap.Rows[0][1].ToString();
            lbEmail.Text = duLieuDangNhap.Rows[0][3].ToString();
            lbHinhAnh.Text = duLieuDangNhap.Rows[0][4].ToString();
            lbGioiTinh.Text = duLieuDangNhap.Rows[0][5].ToString();
            lbTrinhDuyet.Text = duLieuDangNhap.Rows[0][6].ToString();
            lbHostname.Text = duLieuDangNhap.Rows[0][7].ToString();
            lbThoiGianTruyCap.Text = duLieuDangNhap.Rows[0][8].ToString();
        } 
    }
}