using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thongtin : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        if(!IsPostBack)
        {
            DataTable duLieuDangNhap;
            if (Session["google"] == "true")
            {
                duLieuDangNhap = duLieuUserGoogle();
                showThongTinUserGoogle(duLieuDangNhap);
            }
            else
            {
                duLieuDangNhap = duLieuUser();
                showThongTinUserAccount(duLieuDangNhap);
            }
            
        } 
    }

    public void showThongTinUserAccount(DataTable dt)
    {
        String sms = "";
        if (dt.Rows[0][4].ToString() != "")
            sms += "<img src='" + dt.Rows[0][4].ToString() + "' width='150'> <br/>";
        else sms += "<img src='https://static.thenounproject.com/png/55393-200.png' width='150'> <br/>"; 
        sms += "Tên Tài khoản: ";
        sms += dt.Rows[0][1].ToString() + "<br/>"; 

        sms += "Email: ";
        sms += dt.Rows[0][3].ToString() + "<br/>"; 

        sms += "Giới tính: ";
        sms += dt.Rows[0][5].ToString() + "<br/>"; 

        sms += "Loại trình duyệt: ";
        sms += dt.Rows[0][6].ToString() + "<br/>"; 

        sms += "ip: ";
        sms += dt.Rows[0][7].ToString() + "<br/>"; 

        sms += "Hostname: ";
        sms += dt.Rows[0][8].ToString() + "<br/>"; 

        sms += "Thời gian truy cập: ";
        sms += dt.Rows[0][9].ToString() + "<br/>";

        ltr.Text = sms;

    }

    public DataTable duLieuUser()
    {
        String id = Session["id"].ToString();
        String sql = "select * from tbl_nguoi_dung where id='" + id + "'";
        return connect.LayBang(sql);
    }

    public void showThongTinUserGoogle(DataTable dt)
    {
        String sms = "";
        if (dt.Rows[0][4].ToString() != "")
            sms += "<img src='" + dt.Rows[0][4].ToString() + "' width='150'> <br/>";
        else sms += "<img src='https://static.thenounproject.com/png/55393-200.png' width='150'> <br/>";

        sms += "Google id: ";
        sms += dt.Rows[0][10].ToString() + "<br/>";

        sms += "Email: ";
        sms += dt.Rows[0][3].ToString() + "<br/>";

        sms += "Giới tính: ";
        sms += dt.Rows[0][5].ToString() + "<br/>";

        sms += "Loại trình duyệt: ";
        sms += dt.Rows[0][6].ToString() + "<br/>";

        sms += "ip: ";
        sms += dt.Rows[0][7].ToString() + "<br/>";

        sms += "Hostname: ";
        sms += dt.Rows[0][8].ToString() + "<br/>";

        sms += "Thời gian truy cập: ";
        sms += dt.Rows[0][9].ToString() + "<br/>";

        ltr.Text = sms;
    }

    public DataTable duLieuUserGoogle()
    {
        String id = Session["id"].ToString();
        String sql = "select * from tbl_nguoi_dung where id_google='" + id + "'";
        return connect.LayBang(sql);
    }
}