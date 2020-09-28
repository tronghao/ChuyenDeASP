using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Them_Bo_De : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
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
    }
}