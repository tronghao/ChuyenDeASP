using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class upload_file : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            hienThiDuLieu();
        }
    }

    public void hienThiDuLieu()
    {
        DataTable dt = new DataTable();
        String sql = "select file_name from file_upload";
        dt = connect.LayBang(sql);
        ltr.Text = @"<table class='table table-hover table-bordered' style='width: 100%'>
                            <tr>                        
                                <th>FileName</th>
                                 <th></th>
                            </tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltr.Text += @"<tr>
                            <td>" + dt.Rows[i][0] + @"</td>
                            <td><a target='blank' href='download.aspx?file="+ dt.Rows[i][0] +@"'>Download</a></td>
                          </tr>";
        }
        ltr.Text += "</table>";
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid  && CheckFileType(file.FileName))
        {
            string fileName = "file/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + file.FileName;
            string filePath = MapPath(fileName);
            file.SaveAs(filePath);
            //Image1.ImageUrl = fileName;
            string fileNameCSDL = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + file.FileName;
            String sql = "insert into file_upload(file_name) values('" + fileNameCSDL + "')";
            if(connect.CapnhatCSDL(sql))
                Response.Write("<script>alert('Thanh cong')</script>");
            else Response.Write("<script>alert('Cập nhật csdl không Thanh cong "+ sql+"')</script>");
        } else Response.Write("<script>alert('Upload file không Thanh cong')</script>");
        hienThiDuLieu();
    }

    bool CheckFileType(string fileName)
    {

        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;
            case ".pdf":
                return true;
            case ".docx":
                return true;
            default:
                return false;
        }
    }

    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        String sql = "select file_name from file_upload";
        dt = connect.LayBang(sql);
        string name_ = "du_lieu"; //Tên file excel mà bạn lưu về máy

        //Tạo mới bảng để chép vào file excel

        Table tb = new Table();

        //Định dạng bảng

        tb.BorderColor = System.Drawing.Color.FromName("red");

        tb.CellPadding = 4;

        tb.GridLines = GridLines.Both;

        tb.CellSpacing = 0;

        tb.Width = Unit.Percentage(100);

        TableCell cell;

        TableRow row;

        int from = 0;

        int to = dt.Rows.Count;

        int header = 0;

        for (int i = from; i < to ; i++)

        {

            DataRow dr = dt.Rows[i];

            if (header == 0)

            {

                row = new TableRow();

                cell = new TableCell();

                //so thu tu

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 200;

                cell.Text = "<b>FileName</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                

                tb.Rows.Add(row);

            }

            header++;

            row = new TableRow();

            cell = new TableCell();

            

            //TenSanPham

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[0].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);


            tb.Rows.Add(row);

        }


        Response.Clear();

        Response.Buffer = true;

        //excel

        string ex_ = "xls";

        Context.Response.AddHeader("Content-Disposition", "attachment; filename=" + name_ + "." + ex_);

        //    Context.Response.AddHeader("Content-Length", strpath.Length.ToString());

        Response.ContentType = "application/vnd.ms-excel";

        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

        this.EnableViewState = false;

        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

        tb.RenderControl(oHtmlTextWriter);

        Response.Write(oStringWriter.ToString());

        Response.End();
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        // CHECK IF A FILE HAS BEEN SELECTED.
        //if ((excelUpload.HasFile))
        //{
        //    if (!Convert.IsDBNull(excelUpload.PostedFile) &
        //    excelUpload.PostedFile.ContentLength > 0)
        //    {

        //        //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
        //        excelUpload.SaveAs(Server.MapPath(".") + "\\excel\\" + excelUpload.FileName);

        //        SqlBulkCopy oSqlBulk = null;

        //        // SET A CONNECTION WITH THE EXCEL FILE.
        //        string path = Server.MapPath(".") + "\\excel\\" + excelUpload.FileName;
        //        string connStr = "Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
        //        OleDbConnection myExcelConn = new OleDbConnection(connStr);
        //        try
        //        {
        //            myExcelConn.Open();
        //            string sql = "SELECT * FROM [Sheet1$]";
        //            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, myExcelConn))
        //            {
        //                DataTable ds = new DataTable();
        //                adaptor.Fill(ds);
        //                GridView1.DataSource = adaptor;
        //                GridView1.DataBind();
        //                for(int i=1; i<ds.Rows.Count; i++)
        //                {
        //                    String sql2 = "insert into file_upload(file_name) values('" + ds.Rows[i][0] + "')";
        //                    connect.CapnhatCSDL(sql2);
        //                }
        //            }

        //            Response.Write("<script>alert('DATA IMPORTED SUCCESSFULLY.')</script>");
        //        }
        //        catch (Exception ex)
        //        {

        //            Response.Write("<script>alert('"+ ex.Message + "')</script>");


        //        }
        //        finally
        //        {
        //            // CLEAR.
        //            //oSqlBulk.Close();
        //            oSqlBulk = null;
        //            //myExcelConn.Close();
        //            myExcelConn = null;
        //        }
        //    }
        //}
        if (excelUpload.HasFile)
        {
            if (excelUpload.FileContent.Length > 0)
            {
                string Foldername;
                string Extension = System.IO.Path.GetExtension(excelUpload.PostedFile.FileName);
                string filename = Path.GetFileName(excelUpload.PostedFile.FileName.ToString());


                if (Extension == ".XLS" || Extension == ".XLSX" || Extension == ".xls" || Extension == ".xlsx")
                {

                    Foldername = Server.MapPath("~/excel");

                    excelUpload.PostedFile.SaveAs(Foldername + "//" +  filename.ToString());

                    String conStr = "";
                    switch (Extension)
                    {
                        case ".xls": //Excel 97-03
                            conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Data Source=" + Foldername + "//" + filename + ";" +
                            "Extended Properties=Excel 8.0;";
                            break;

                        case ".xlsx": //Excel 07
                            conStr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                           "Data Source=" + Foldername + "//" + filename + ";" +
                           "Extended Properties=Excel 8.0;";
                            break;
                    }

                    OleDbConnection oconn = new OleDbConnection(conStr);
                    //------
                    OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                    oconn.Open();
                    OleDbDataReader odr = ocmd.ExecuteReader();
                    string Description1 = "";
                    string Quantity1 = "";
                    string OriginalPrice1 = "";
                    string Image1 = "";
                    string Shape; string Carat; string Certificate;
                    while (odr.Read())
                    {
                        Response.Write(odr);

                        // you will get row by value
                    }

                }
                else
                {
                    Response.Write( "Select only Excel File ....!!" );
                }
            }
        }
        else
        {
            Response.Write("Upload Excel File ......");

        }
    }

}