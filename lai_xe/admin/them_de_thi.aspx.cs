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
            if (Session["user"] == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    hienThiDuLieu(id);
                }

                if (Request.QueryString["ids"] != null)
                {
                    string id = Request.QueryString["ids"];
                    addCSDL(id);
                }
            }
        }
    }

    public void hienThiDuLieu(String id)
    {
        String sql = @"select ch.ma_cau_hoi, ch.noi_dung 
                        from tbl_cau_hoi as ch 
                        where ch.ma_cau_hoi not in 
                        (select ma_cau_hoi from tbl_de_thi where ma_bo_de=" + Request.QueryString["id"] + ")";
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

    public void addCSDL(String id)
    {
        String[] arrSplitId = id.Split(',');
        String idBD = Request.QueryString["idBD"];
        
        //delete all item BD
        String sql_delete = "delete from tbl_de_thi where ma_bo_de = '" + idBD + "'";
        connect.CapnhatCSDL(sql_delete);
        String success = "true";
        //add list item;
        for (int i = 0; i < arrSplitId.Length - 1; i++)
        {
            String sql = "insert into tbl_de_thi(ma_bo_de, ma_cau_hoi) values('" + idBD + "', '" + arrSplitId[i] + "')";
            if (connect.CapnhatCSDL(sql))
            {
                success = "true";
            }
            else
            {
                success = "false";
            }
        }

        string json = "{\"success\": \"" + success + "\", \"idBD\": \"" + idBD + "\"}";
        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
        Response.End();
    }
}