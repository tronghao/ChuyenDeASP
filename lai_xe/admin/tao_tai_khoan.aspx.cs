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
            if(Request.QueryString["id"] != null) {
                string id = Request.QueryString["id"];
                delete_items(id);
            }
            if (Request.QueryString["info"] != null)
            {
                string info = Request.QueryString["info"];
                if (info == "1")
                    Response.Write("<script> alert('Cập nhật thành công') </script>");
                else Response.Write("<script> alert('Cập nhật không thành công') </script>");
                
            }
            
            if (Request.QueryString["id_sua"] != null)
            {
                string id = Request.QueryString["id_sua"];
                capNhat();
                hienThiDuLieuCapNhat(id);
            }
            else
            {
                tao();
                hienThiDuLieu();
            }   
        }
        
    }

    public void delete_items(string id)
    {
        String sql = "delete from tbl_nguoi_dung where ten_tai_khoan=N'" + id + "'";
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Xóa thành công') </script>");
        }
        else
        {
            Response.Write("<script> alert('Xóa không thành công') </script>");
        }
    }

    public void hienThiDuLieu()
    {
        String sql = "select * from tbl_nguoi_dung";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
       

        ltr_table.Text = @"<table class='table table-striped table-bordered' id='example'>
                            <thead>
                                <tr>
                                    <th class='text-center'> STT </th>  
                                    <th class='text-center'> Tên tài khoản </th>  
                                    <th class='text-center'> Họ tên </th>  
                                    <th class='text-center'> Giới tính </th>  
                                    <th class='text-center'>  </th>  
                                </tr>
                            </thead>
                            <tbody>
                          ";
        for (int i = 0; i < nguoidung_table.Rows.Count; i++)
        {
            ltr_table.Text += @"<tr>
                                    <td class='text-center'> " + (i + 1).ToString() + @" </td>  
                                    <td> " + nguoidung_table.Rows[i][0] + @" </td>  
                                    <td> " + nguoidung_table.Rows[i][3] + @" </td>  
                                    <td class='text-center'> " + nguoidung_table.Rows[i][2] + @" </td>  
                                    <td> <a href='?id_sua=" + nguoidung_table.Rows[i][0] + @"'>Sửa</a> | <a href='?id=" + nguoidung_table.Rows[i][0] + @"'>Xóa</a> </td>  
                                </tr>
                          ";
        }
        ltr_table.Text += "</tbody></table>";
    }

    public void hienThiDuLieuCapNhat(String id)
    {
        String sql = "select * from tbl_nguoi_dung where ten_tai_khoan='" + id + "'";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);

        txtTenTaiKhoan.Text = nguoidung_table.Rows[0][0].ToString();
        txtHoTen.Text = nguoidung_table.Rows[0][3].ToString();
        ddlGioiTinh.SelectedValue = nguoidung_table.Rows[0][2].ToString();
        
    }

    public void tao()
    {
        txtMatKhau.Text = "";
        txtTenTaiKhoan.Text = "";
        txtTenTaiKhoan.ReadOnly = false;
        btnTao.Visible = true;
        btnCapNhat.Visible = false;
        btnHuy.Visible = false;
    }


    public void capNhat()
    {
        btnTao.Visible = false;
        btnCapNhat.Visible = true;
        btnHuy.Visible = true;
        txtTenTaiKhoan.ReadOnly = true;
    }

    public bool validateTao()
    {
        if (txtTenTaiKhoan.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập tên tài khoản') </script>");
            return false;
        }
        if (txtMatKhau.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập mật khẩu') </script>");
            return false;
        }
        if (txtHoTen.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập họ tên') </script>");
            return false;
        }

        return true;
    }

    protected void btnTao_Click(object sender, EventArgs e)
    {
        if (validateTao())
        {
            String tenTaiKhoan = txtTenTaiKhoan.Text;
            String matKhau = connect.mahoa(txtMatKhau.Text);
            String hoTen = txtHoTen.Text;
            String gioiTinh = ddlGioiTinh.SelectedValue;
            String sql = "insert into tbl_nguoi_dung(ten_tai_khoan, mat_khau, ho_ten, gioi_tinh) values(N'" + tenTaiKhoan + "', '" + matKhau + "', N'" + hoTen + "', N'" + gioiTinh + "')";
            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Write("<script> alert('Thêm thành công') </script>");
                txtTenTaiKhoan.Text = "";
                txtMatKhau.Text = "";
            }
            else Response.Write("<script> alert('Thêm không thành công') </script>");
            hienThiDuLieu();
        }
    }



    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("tao_tai_khoan.aspx");
    }

    public bool validateCapNhat()
    {
        if (txtHoTen.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập họ tên') </script>");
            return false;
        }

        return true;
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (validateCapNhat())
        {


            String tenTaiKhoan = txtTenTaiKhoan.Text;
            String hoTen = txtHoTen.Text;
            String gioiTinh = ddlGioiTinh.SelectedValue;
            String matKhau = txtMatKhau.Text;
            String sql = "";
            if (matKhau == "")
                sql = "update tbl_nguoi_dung set ho_ten=N'" + hoTen + "', gioi_tinh=N'" + gioiTinh + "' where ten_tai_khoan='" + tenTaiKhoan + "'";
            else
            {
                matKhau = connect.mahoa(matKhau);
                sql = "update tbl_nguoi_dung set ho_ten=N'" + hoTen + "', gioi_tinh=N'" + gioiTinh + "', mat_khau='" + matKhau + "' where ten_tai_khoan='" + tenTaiKhoan + "'";
            }
            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Redirect("tao_tai_khoan.aspx?info=1");
            }
            else Response.Redirect("tao_tai_khoan.aspx?info=0");
        }
        
    }

    // string a = GridView1.DataKeys[e.RowIndex].Values["username"].ToString();

}