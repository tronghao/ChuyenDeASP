using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hienThiDuLieu();
        }
    }

    public void hienThiDuLieu()
    {
        hienThiBoDe();
    }

    public void hienThiBoDe()
    {
        String sql = "SELECT * FROM tbl_bo_de_thi";
        DataTable dt_bo_de = new DataTable();
        dt_bo_de = connect.LayBang(sql);

        lb_de_thi.Text = "Bộ " + dt_bo_de.Rows.Count + " đề thi chuẩn Bộ Giao Thông Vận Tải";
        ltrDe.Text = "";
        for (int i = 0; i < dt_bo_de.Rows.Count; i++)
        {
            ltrDe.Text += "<a href='thi.aspx?bd=" + dt_bo_de.Rows[i][0] + "' runat='server'><button type='button' class='btn btn-success btn-thongtin'>" + dt_bo_de.Rows[i][1] + "</button></a>";
        }
        Repeater1.DataSource = dt_bo_de;
        Repeater1.DataBind();
    }

}