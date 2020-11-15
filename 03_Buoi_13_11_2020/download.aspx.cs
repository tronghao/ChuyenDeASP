using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            String path = Request.QueryString["file"];
            String[] fileNameArray = path.Split('/');
            string filename = fileNameArray[1];
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.TransmitFile(Server.MapPath(path));
            Response.End();
        }
    }
}