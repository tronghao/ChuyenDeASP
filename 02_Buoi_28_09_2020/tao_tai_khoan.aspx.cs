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
        if(!IsPostBack)
        {
            tao();
            hienThiDuLieu();
        }
        
    }

    public void hienThiDuLieu()
    {
        String sql = "select * from tbl_nguoi_dung";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
        gvUser.DataSource = nguoidung_table;
        gvUser.DataBind();
    }

    public void tao()
    {
        txtMatKhau.Text = "";
        txtTenTaiKhoan.Text = "";
        txtTenTaiKhoan.ReadOnly = false;
        btnTao.Visible = true;
        btnTim.Visible = true;
        btnCapNhat.Visible = false;
        btnHuy.Visible = false;

        lbKetQuaTim.Visible = false;
        gvTim.Visible = false;
    }


    public void tim()
    {
        txtMatKhau.Text = "";
        txtTenTaiKhoan.Text = "";
        btnTao.Visible = true;
        btnTim.Visible = true;
        btnCapNhat.Visible = false;
        btnHuy.Visible = false;

        lbKetQuaTim.Visible = true;
        gvTim.Visible = true;
    }

    public void capNhat()
    {
        btnTao.Visible = false;
        btnTim.Visible = false;
        btnCapNhat.Visible = true;
        btnHuy.Visible = true;
        txtTenTaiKhoan.ReadOnly = true;

        lbKetQuaTim.Visible = false;
        gvTim.Visible = false;

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




    protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gvUser.Rows[e.RowIndex];
        String tenTaiKhoan = row.Cells[2].Text;
        String sql = "delete from tbl_nguoi_dung where ten_tai_khoan='" + tenTaiKhoan + "'";
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Xóa thành công') </script>");
        }
        else Response.Write("<script> alert('Xóa không thành công') </script>");
        hienThiDuLieu();
    }


    protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvUser.SelectedRow;
        txtTenTaiKhoan.Text = row.Cells[2].Text;
        txtMatKhau.Text = row.Cells[3].Text;
        
        capNhat();
    }

    protected void btnHuy_Click(object sender, EventArgs e)
    {
        tao();
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        String tenTaiKhoan = txtTenTaiKhoan.Text;
        String matKhau = txtMatKhau.Text;
        String sql = "update tbl_nguoi_dung set ten_tai_khoan='" + tenTaiKhoan + "', mat_khau='" + matKhau + "' where ten_tai_khoan='" + tenTaiKhoan + "'";
        //Response.Write(sql);
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Cập nhật thành công') </script>");
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }
        else Response.Write("<script> alert('Cập nhật không thành công') </script>");
        hienThiDuLieu();
    }

    // string a = GridView1.DataKeys[e.RowIndex].Values["username"].ToString();

    protected void btnTim_Click(object sender, EventArgs e)
    {
        String tenTaiKhoan = txtTenTaiKhoan.Text;
        String sql = "select * from tbl_nguoi_dung where ten_tai_khoan like '%" + tenTaiKhoan + "%'";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
        gvTim.DataSource = nguoidung_table;
        gvTim.DataBind();
        tim();
    }
}