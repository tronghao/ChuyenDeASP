using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tao_bo_de : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            if (Session["user"] == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (Request.QueryString["id"] != null)
                {
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
        
    }

    public void delete_items(string id)
    {
        String sql = "delete from tbl_bo_de_thi where ma_bo_de=N'" + id + "'";
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
        String sql = "select * from tbl_bo_de_thi";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
       

        ltr_table.Text = @"<table class='table table-striped table-bordered' id='example'>
                            <thead>
                                <tr>
                                    <th class='text-center'> STT </th>  
                                    <th class='text-center'> Tên bộ đề </th>  
                                    <th class='text-center'>  </th>  
                                </tr>
                            </thead>
                            <tbody>
                          ";
        for (int i = 0; i < nguoidung_table.Rows.Count; i++)
        {
            ltr_table.Text += @"<tr>
                                    <td class='text-center'> " + (i + 1).ToString() + @" </td>  
                                    <td> " + nguoidung_table.Rows[i][1] + @" </td>  
                                    <td> <a href='?id_sua=" + nguoidung_table.Rows[i][0] + @"'><i class='fa fa-pencil-square' style='color:blue' aria-hidden='true'></i></a> | <a href='?id=" + nguoidung_table.Rows[i][0] + @"'><i class='fa fa-trash' aria-hidden='true' style='color:red'></i></a> | <a href='them_de_thi.aspx?id=" + nguoidung_table.Rows[i][0] + @"' style='color:blue'>Quản lý câu hỏi</a> </td>  
                                </tr>
                          ";
        }
        ltr_table.Text += "</tbody></table>";
    }

    public void hienThiDuLieuCapNhat(String id)
    {
        String sql = "select * from tbl_bo_de_thi where ma_bo_de='" + id + "'";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);

        txtTenTaiKhoan.Text = nguoidung_table.Rows[0][1].ToString();

        
    }

    public void tao()
    {
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
    }

    public bool validateTao()
    {
        if (txtTenTaiKhoan.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập tên bộ đề') </script>");
            return false;
        }
        
        return true;
    }

    protected void btnTao_Click(object sender, EventArgs e)
    {
        if (validateTao())
        {
            String tenTaiKhoan = txtTenTaiKhoan.Text;

            String sql = "insert into tbl_bo_de_thi(ten_bo_de) values(N'" + tenTaiKhoan + "')";
            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Write("<script> alert('Thêm thành công') </script>");
                txtTenTaiKhoan.Text = "";
            }
            else Response.Write("<script> alert('Thêm không thành công') </script>");
            hienThiDuLieu();
        }
    }



    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("tao_bo_de.aspx");
    }

    public bool validateCapNhat()
    {
        if (txtTenTaiKhoan.Text == "")
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
            String sql = "update tbl_bo_de_thi set ten_bo_de=N'" + tenTaiKhoan + "' where ma_bo_de='" + Request.QueryString["id_sua"] + "'";

            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Redirect("tao_bo_de.aspx?info=1");
            }
            else Response.Redirect("tao_bo_de.aspx?info=0");
        }     
        
    }

    // string a = GridView1.DataKeys[e.RowIndex].Values["username"].ToString();

}