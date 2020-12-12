using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thi : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["bd"] != null)
            {
                string id = Request.QueryString["bd"];
                hienThiDuLieu(id);
            }
            else Response.Redirect("/");
            
        }
    }

    public void hienThiDuLieu(String id)
    {
        String sql = @"select *
                        from tbl_cau_hoi as ch, tbl_de_thi as dt
                        where ch.ma_cau_hoi = dt.ma_cau_hoi
                        and dt.ma_bo_de=" + id;
        DataTable dt = new DataTable();
        dt = connect.LayBang(sql);
        ltrNDCH.Text = "";
        ltrBtnCauHoi.Text = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i % 5 == 0)
            {
                ltrBtnCauHoi.Text += "<div class='block-button'>";
                ltrBtnCauHoi.Text += "<button onclick='JumpToSlide(" + (i + 1) + ")' type='button' id='btnCauHoi" + (i + 1).ToString() + "' class='btn btn-success btn-item-number'>" + (i + 1).ToString() + "</button>";
            }else if(i % 5 == 4) {
                ltrBtnCauHoi.Text += "<button onclick='JumpToSlide(" + (i + 1) + ")' type='button' id='btnCauHoi" + (i + 1).ToString() + "' class='btn btn-success btn-item-number'>" + (i + 1).ToString() + "</button>";
                ltrBtnCauHoi.Text += "</div>";
            }
            else
            {
                ltrBtnCauHoi.Text += "<button onclick='JumpToSlide(" + (i + 1) + ")' type='button' id='btnCauHoi" + (i + 1).ToString() + "' class='btn btn-success btn-item-number'>" + (i + 1).ToString() + "</button>";
            }

            if (i == dt.Rows.Count - 1 && i % 5 != 4)
            {
                ltrBtnCauHoi.Text += "</div>";
            }

            ltrNDCH.Text += @"
                    <div class='ch" + (i+1).ToString() + @"'>
                         <p class='title-cau-hoi'>Câu hỏi " + (i+1).ToString() + @":</p>
                         <p class='noi-dung-cau-hoi'>" + dt.Rows[i]["noi_dung"] + @"</p>";
            if(dt.Rows[i]["A"] != "")
                ltrNDCH.Text += "<p><input type='radio' value='A' name='ch" + (i + 1).ToString() + @"'> " + dt.Rows[i]["A"] + "</p>";
            if(dt.Rows[i]["B"] != "")
                ltrNDCH.Text += "<p><input type='radio' value='B' name='ch" + (i + 1).ToString() + @"'> " + dt.Rows[i]["B"] + "</p>";
            if(dt.Rows[i]["C"] != "")
                ltrNDCH.Text += "<p><input type='radio' value='C' name='ch" + (i + 1).ToString() + @"'> " + dt.Rows[i]["C"] + "</p>";
            if(dt.Rows[i]["D"] != "")
                ltrNDCH.Text += "<p><input type='radio' value='D' name='ch" + (i + 1).ToString() + @"'> " + dt.Rows[i]["D"] + "</p>";
            ltrNDCH.Text += "</div>";

            ltrScript.Text += "<script> var soCauHoi = " + dt.Rows.Count + ";</script>";
        }
    }
}