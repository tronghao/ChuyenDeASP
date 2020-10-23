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
        sms += @" <table class='table table-striped'>
                    <tbody> ";
        sms += @"<tr>
                        <td> Tên Tài khoản:</td>
                       ";
        sms += "<td>" + dt.Rows[0][1].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Email:</td>
                       ";
        sms += "<td>" + dt.Rows[0][3].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Giới tính:</td>
                       ";
        sms += "<td>" + dt.Rows[0][5].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Loại trình duyệt:</td>
                       ";
        sms += "<td>" + dt.Rows[0][6].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> ip:</td>
                       ";
        sms += "<td>" + dt.Rows[0][7].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Hostname:</td>
                       ";
        sms += "<td>" + dt.Rows[0][8].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Thời gian truy cập:</td>
                       ";
        sms += "<td>" + dt.Rows[0][9].ToString() + "</td></tr>";  

        sms += @"                      
                    </tbody>
                  </table>
        ";
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

        sms += @" <table class='table table-striped'>
                    <tbody> ";
        sms += @"<tr>
                        <td> Google id:</td>
                       ";
        sms += "<td>" + dt.Rows[0][10].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Email:</td>
                       ";
        sms += "<td>" + dt.Rows[0][3].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Giới tính:</td>
                       ";
        sms += "<td>" + dt.Rows[0][5].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Loại trình duyệt:</td>
                       ";
        sms += "<td>" + dt.Rows[0][6].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> ip:</td>
                       ";
        sms += "<td>" + dt.Rows[0][7].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Hostname:</td>
                       ";
        sms += "<td>" + dt.Rows[0][8].ToString() + "</td></tr>";

        sms += @"<tr>
                        <td> Thời gian truy cập:</td>
                       ";
        sms += "<td>" + dt.Rows[0][9].ToString() + "</td></tr>";

        sms += @"                      
                    </tbody>
                  </table>
        ";

        ltr.Text = sms;
    }

    public DataTable duLieuUserGoogle()
    {
        String id = Session["id"].ToString();
        String sql = "select * from tbl_nguoi_dung where id_google='" + id + "'";
        return connect.LayBang(sql);
    }
}