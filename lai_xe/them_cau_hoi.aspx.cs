using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class them_cau_hoi : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        hienThiDuLieu();
    }

    public void hienThiDuLieu()
    {
        String sql = "select * from tbl_cau_hoi";
        DataTable nguoidung_table = new DataTable();
        nguoidung_table = connect.LayBang(sql);
        gvData.DataSource = nguoidung_table;
        gvData.DataBind();

        rpt.DataSource = nguoidung_table;
        rpt.DataBind();
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        String noi_dung = txtND.Text;
        String A = txtA.Text;
        String B = txtB.Text;
        String C = txtC.Text;
        String D = txtD.Text;
        String dap_an_dung = txtDapAnDung.Text;

        String sql = "insert into tbl_cau_hoi(noi_dung, A, B, C, D, dap_an_dung) values(N'" + noi_dung + "', N'" + A + "',  N'" + B + "',  N'" + C + "',  N'" + D + "',  N'" + dap_an_dung + "')";
        //Response.Write(sql);
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Thêm thành công') </script>");
            txtND.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtDapAnDung.Text = "";
            hienThiDuLieu();
        }
        else Response.Write("<script> alert('Thêm không thành công') </script>");
    }

    public string mahoa(string pass)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
    }
}