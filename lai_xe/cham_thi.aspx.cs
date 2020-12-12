using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chamThi : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["bd"] != null)
            {
                string id = Request.QueryString["bd"];
                kiemTra(id);
            }

        }
    }

    private void kiemTra(string id) {

        String sql = @"select ch.dap_an_dung
                        from tbl_cau_hoi as ch, tbl_de_thi as dt
                        where ch.ma_cau_hoi = dt.ma_cau_hoi
                        and dt.ma_bo_de=" + id;
        DataTable dt = new DataTable();
        dt = connect.LayBang(sql);

        Data[] arr = new Data[1000];
        
        for (int i = 0; i < Request.Form.Count; i++)
        {
            arr[i] = new Data();
            arr[i].key = Request.Form.AllKeys[i];
            arr[i].value = Request.Form[arr[i].key];
        }

        int soCauDung = 0;


        Data[] arrRes = new Data[1000];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][0].ToString() == arr[i].value)
            {
                arrRes[i] = new Data();
                arrRes[i].key = (i + 1).ToString();
                arrRes[i].value = "Y";
                soCauDung++;
            }
            else
            {
                arrRes[i] = new Data();
                arrRes[i].key = (i + 1).ToString();
                arrRes[i].value = "N";
            }
        }

        Data[] arrResValue = new Data[1000];
        int lengthArrResValue = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][0].ToString() != arr[i].value)
            {
                arrResValue[lengthArrResValue] = new Data();
                arrResValue[lengthArrResValue].key = (i + 1).ToString();
                arrResValue[lengthArrResValue].value = dt.Rows[i][0].ToString();
                lengthArrResValue++;
            }
        }


        string jsonData = Request.Form["data"];
        string json = "{\"data\": [";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if(i != dt.Rows.Count -1)
                json += "{ \"cauHoi\": \"" + arrRes[i].key + "\", \"correct\": \"" + arrRes[i].value + "\" },";
            else json += "{ \"cauHoi\": \"" + arrRes[i].key + "\", \"correct\": \"" + arrRes[i].value + "\" }";
        }
        json += "], \"kq\": [";
        for (int i = 0; i < lengthArrResValue; i++)
        {
            if(i != lengthArrResValue -1)
                json += "{ \"cauHoi\": \"" + arrResValue[i].key + "\", \"correct\": \"" + arrResValue[i].value + "\" },";
            else json += "{ \"cauHoi\": \"" + arrResValue[i].key + "\", \"correct\": \"" + arrResValue[i].value + "\" }";
        }
        json+="], \"soCauDung\": \"" + soCauDung + "\"}";

        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(json);
        Response.End();
    }
}

class Data
{
    public string key;
    public string value;
}