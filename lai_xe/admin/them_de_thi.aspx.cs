using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_them_de_thi : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                hienThiDuLieu(id);
            }
           
        }
    }

    public void hienThiDuLieu(String id)
    {
        String sql = "select ch.ma_cau_hoi, ch.noi_dung from tbl_cau_hoi as ch left join (select * from tbl_de_thi where ma_bo_de=" + Request.QueryString["id"] + ") as dt on ch.ma_cau_hoi != dt.ma_cau_hoi ";
        DataTable dt = new DataTable();
        dt = connect.LayBang(sql);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrCauHoi.Text += "<div class='item'>" + dt.Rows[i][0].ToString() + ") " + dt.Rows[i][1].ToString() + "</div>";
        }

        sql = "select ch.ma_cau_hoi, ch.noi_dung from tbl_cau_hoi as ch, tbl_de_thi as dt where ch.ma_cau_hoi = dt.ma_cau_hoi and dt.ma_bo_de=" + Request.QueryString["id"] + "";
        dt = connect.LayBang(sql);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltr_bode.Text += "<div class='item'>" + dt.Rows[i][0].ToString() + ") " + dt.Rows[i][1].ToString() + "</div>";
        }
    }
}