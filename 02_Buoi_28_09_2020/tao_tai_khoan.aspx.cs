using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tao_tai_khoan : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        String sql = "select * from tbl_nguoi_dung";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
        gvUser.DataSource = nguoidung_table;
        gvUser.DataBind();
    }

    protected void btnTao_Click(object sender, EventArgs e)
    {
        String tenTaiKhoan = txtTenTaiKhoan.Text;
        String matKhau = txtMatKhau.Text;
        String sql = "insert into tbl_nguoi_dung(ten_tai_khoan, mat_khau) values('" + tenTaiKhoan + "', '" + matKhau + "')";
        //Response.Write(sql);
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Thêm thành công') </script>");
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }
        else Response.Write("<script> alert('Thêm không thành công') </script>");
    }
}