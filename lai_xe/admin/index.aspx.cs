using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_index : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
                Response.Redirect("../Default.aspx");
            else hienThiDuLieu();
        }
    }

    public void hienThiDuLieu()
    {
        String sql = "select * from tbl_nguoi_dung";
        DataTable dt = new DataTable();
        dt = connect.LayBang(sql);

        lb_SoLuongTaiKhoan.Text = dt.Rows.Count.ToString();

        sql = "select * from tbl_bo_de_thi";
        dt = connect.LayBang(sql);
        lb_SoLuongBoDe.Text = dt.Rows.Count.ToString();

        sql = "select * from tbl_cau_hoi";
        dt = connect.LayBang(sql);
        lb_SoLuongCauHoi.Text = dt.Rows.Count.ToString();
    }
}