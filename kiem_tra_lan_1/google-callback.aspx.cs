using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class google_callback : System.Web.UI.Page
{
    //your client id  
    string clientid = "431346109080-furu6dr21vahdc3m3m1vhp6v94537vc0.apps.googleusercontent.com";
    //your client secret  
    string clientsecret = "7kZNmPsGd5IoSVZLfqyMAtm8";
    //your redirection url  
    string redirection_url = "http://localhost:1526/google-callback.aspx";
    string url = "https://accounts.google.com/o/oauth2/token";
    private object imgprofile;

    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["code"] != null)
            {
                GetToken(Request.QueryString["code"].ToString());
            }
        }
    }

    public void GetToken(string code)
    {
        string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + clientid + "&client_secret=" + clientsecret + "&redirect_uri=" + redirection_url + "";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        UTF8Encoding utfenc = new UTF8Encoding();
        byte[] bytes = utfenc.GetBytes(poststring);
        Stream outputstream = null;
        try
        {
            request.ContentLength = bytes.Length;
            outputstream = request.GetRequestStream();
            outputstream.Write(bytes, 0, bytes.Length);
        }
        catch { }
        var response = (HttpWebResponse)request.GetResponse();
        var streamReader = new StreamReader(response.GetResponseStream());
        string responseFromServer = streamReader.ReadToEnd();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
        GetuserProfile(obj.access_token);
    }
    public void GetuserProfile(string accesstoken)
    {
        string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accesstoken + "";
        WebRequest request = WebRequest.Create(url);
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        response.Close();
        JavaScriptSerializer js = new JavaScriptSerializer();
        Userclass userinfo = js.Deserialize < Userclass > (responseFromServer);
        //Response.Write(responseFromServer);
        Session["user"] = userinfo.name;
        Session["id"] = userinfo.id;
        Session["google"] = "true";
        updateThoiGianDangNhap(Session["id"].ToString());
        if (tonTaiUser(userinfo.id))
        {
            chuyenHuongDenTrangThongTin();
        }
        else
        {
            themDuLieuVaoCSDL(userinfo);
            chuyenHuongDenTrangThongTin();
        }
    }

    public void themDuLieuVaoCSDL(Userclass user)
    {
        String hostname = Environment.MachineName;
        String ip = getIpInternet();
        String browserName = GetWebBrowserName();
        String sql = "insert into tbl_nguoi_dung(id_google, email, hinh_anh, hostname, ip, loai_trinh_duyet, thoi_gian_truy_Cap) values('" + user.id + "', '" + user.email + "', '" + user.picture + "', '" + hostname + "', '" + ip + "', '" + browserName + "', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')";
        if (!connect.CapnhatCSDL(sql))
            Response.Write("<script>alert('khong xong roi')</script>");
    }

    public void chuyenHuongDenTrangThongTin()
    {
        Response.Redirect("thongtin.aspx");
    }

    public bool tonTaiUser(String id)
    {
        String sql = "select * from tbl_nguoi_dung where id_google='"+ id +"'";
        DataTable duLieuBangUser = new DataTable();
        duLieuBangUser = connect.LayBang(sql);
        if (coDuLieu(duLieuBangUser))
            return true;
        return false;
    }

    public bool coDuLieu(DataTable dt)
    {
        if (dt.Rows.Count > 0)
            return true;
        else return false;
    }

    public void updateThoiGianDangNhap(String id)
    {
        String hostname = Environment.MachineName;
        String ip = getIpInternet();
        String browserName = GetWebBrowserName();
        String sql = "update tbl_nguoi_dung set thoi_gian_truy_cap='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "', hostname='"+ hostname +"', ip='"+ ip +"', loai_trinh_duyet='"+ browserName +"' where id_google='" + id + "'";
        connect.CapnhatCSDL(sql);
    }

    public static string getIpInternet()
    {
        try
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                string ip = client.DownloadString("http://ipinfo.io/ip");
                ip = ip.Replace("\r", "").Replace("\n", "");
                return ip;
            }
        }
        catch
        {
            return "127.0.0.1";
        }
    }

    public string GetWebBrowserName()
    {
        string WebBrowserName = string.Empty;
        try
        {
            WebBrowserName = HttpContext.Current.Request.Browser.Browser;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return WebBrowserName;
    }
}



