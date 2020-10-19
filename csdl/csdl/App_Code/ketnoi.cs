using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ketnoi
/// </summary>
public class ketnoi
{
    public SqlConnection con = new SqlConnection("server= .;database = QLNHCH;Integrated security = true;");
    public ketnoi()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string mahoa(string pass)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
    }
}