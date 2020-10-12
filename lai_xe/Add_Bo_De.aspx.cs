using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Bo_De : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        hienthidulieu();
    }
    public void hienthidulieu()
    {
        String sql = "SELECT ma_bo_de AS 'Mã bộ đề ', ten_bo_de AS 'Tên bộ đề' FROM tbl_bo_de_thi";
        DataTable bode = new DataTable();
        bode = connect.LayBang(sql);
        gv.DataSource = bode;
        gv.DataBind();
    }

    protected void btn_Them_Click(object sender, EventArgs e)
    {
        String maBD = txtMaBD.Text.Trim();
        String tenBD = txtTenBD.Text.Trim();
        String sql = "INSERT INTO tbl_bo_de_thi VALUES('" + maBD + "',N'" + tenBD + "')";

        if (connect.CapnhatCSDL(sql))
            Response.Write("<script>alert('Thêm thành công')</script>");
        else
            Response.Write("<script>alert('Thêm không thành công')</script>");
        hienthidulieu();
    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv.SelectedRow;
        txtMaBD.Text = row.Cells[2].Text;
        txtTenBD.Text = row.Cells[3].Text;
    }

    protected void btnSua_Click(object sender, EventArgs e)
    {
        String maBD = txtMaBD.Text.Trim();
        String tenBD = txtTenBD.Text.Trim();
        String sql = "UPDATE tbl_bo_de_thi SET ten_bo_de = N'" + tenBD + "' WHERE ma_bo_de = '" + maBD + "'";
        if (connect.CapnhatCSDL(sql))
            Response.Write("<script>alert('Sửa thành công')</script>");
        else
            Response.Write("<script>alert('Sửa không thành công')</script>");

        hienthidulieu();
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gv.Rows[e.RowIndex];
        String maBD = row.Cells[2].Text;
        String sql = "DELETE FROM tbl_bo_de_thi WHERE ma_bo_de = '" + maBD + "'";
        if (connect.CapnhatCSDL(sql))
            Response.Write("<script>alert('Xóa thành công')</script>");
        else
            Response.Write("<script>alert('Xóa không thành công')</script>");

        hienthidulieu();
    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        String sql = "SELECT ma_bo_de AS 'Mã bộ đề ', ten_bo_de AS 'Tên bộ đề' FROM tbl_bo_de_thi WHERE ten_bo_de LIKE'%" + txtTim.Text + "%'";
        DataTable bode = new DataTable();
        bode = connect.LayBang(sql);
        gv.DataSource = bode;
        gv.DataBind();
    }

    protected void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtMaBD.Text = "";
        txtTenBD.Text = "";
    }
}
