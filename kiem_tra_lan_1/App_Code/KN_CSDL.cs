﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KN_CSDL
/// </summary>
public class KN_CSDL
{
    SqlConnection sqlketnoi;
    SqlCommand sqllenh;
    public KN_CSDL()
    {
        sqlketnoi = new SqlConnection();
        string chuoiketnoi = @"Data Source=DG6GI3E1598CP8F\SQLEXPRESS;Initial Catalog=kt;Integrated Security=True";
        sqlketnoi.ConnectionString = chuoiketnoi;
        sqllenh = new SqlCommand();
    }
    public bool Moketnoi()
    {
        try
        {
            sqlketnoi.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void Dongketnoi()
    {
        sqlketnoi.Close();
    }
    public bool CapnhatCSDL(string str)
    {
        try
        {
            this.Moketnoi();
            sqllenh.Connection = sqlketnoi;
            sqllenh.CommandText = str;
            sqllenh.ExecuteNonQuery();
            this.Dongketnoi();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public DataTable LayBang(string str)
    {
        this.Moketnoi();
        SqlDataAdapter bodocghi = new SqlDataAdapter(str, sqlketnoi);
        DataTable bang = new DataTable();
        bodocghi.Fill(bang);
        this.Dongketnoi();
        return bang;
    }

    public string mahoa(string pass)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
    }
}