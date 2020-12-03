using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tao_cau_hoi : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["user"] == null)
                Response.Redirect("../Default.aspx");
            else
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    delete_items(id);
                }
                if (Request.QueryString["info"] != null)
                {
                    string info = Request.QueryString["info"];
                    if (info == "1")
                        Response.Write("<script> alert('Cập nhật thành công') </script>");
                    else Response.Write("<script> alert('Cập nhật không thành công') </script>");

                }

                if (Request.QueryString["id_sua"] != null)
                {
                    string id = Request.QueryString["id_sua"];
                    capNhat();
                    hienThiDuLieuCapNhat(id);
                }
                else
                {
                    tao();
                    hienThiDuLieu();
                }
            }  
        }
        
    }

    public void delete_items(string id)
    {
        String sql = "delete from tbl_cau_hoi where ma_cau_hoi=N'" + id + "'";
        if (connect.CapnhatCSDL(sql))
        {
            Response.Write("<script> alert('Xóa thành công') </script>");
        }
        else
        {
            Response.Write("<script> alert('Xóa không thành công') </script>");
        }
    }

    public void hienThiDuLieu()
    {
        String sql = "select * from tbl_cau_hoi";
        DataTable cauhoi_table = new DataTable();
        cauhoi_table = connect.LayBang(sql);
       

        ltr_table.Text = @"<table class='table table-striped table-bordered' id='example'>
                            <thead>
                                <tr>
                                    <th class='text-center'> STT </th>  
                                    <th class='text-center'> Mã câu hỏi </th>  
                                    <th class='text-center'> Nội dung </th>  
                                    <th class='text-center'> Đáp án A </th>  
                                    <th class='text-center'> Đáp án B </th>  
                                    <th class='text-center'> Đáp án C </th>  
                                    <th class='text-center'> Đáp án D </th>  
                                    <th class='text-center'> Đáp án đúng </th>  
                                    <th class='text-center'> </th> 
                                </tr>
                            </thead>
                            <tbody>
                          ";
        for (int i = 0; i < cauhoi_table.Rows.Count; i++)
        {
            ltr_table.Text += @"<tr>
                                    <td class='text-center'> " + (i + 1).ToString() + @" </td>  
                                    <td> " + cauhoi_table.Rows[i][0] + @" </td>  
                                    <td> " + cauhoi_table.Rows[i][1] + @" </td>  
                                    <td> " + cauhoi_table.Rows[i][2] + @" </td>  
                                    <td> " + cauhoi_table.Rows[i][3] + @" </td>
                                    <td> " + cauhoi_table.Rows[i][4] + @" </td>  
                                    <td> " + cauhoi_table.Rows[i][5] + @" </td> 
                                    <td> " + cauhoi_table.Rows[i][6] + @" </td> 
                                    <td> <a href='?id_sua=" + cauhoi_table.Rows[i][0] + @"'><i class='fa fa-pencil-square' style='color:blue' aria-hidden='true'></i></a> | <a href='?id=" + cauhoi_table.Rows[i][0] + @"'><i class='fa fa-trash' aria-hidden='true' style='color:red'></i></a> </td>  
                                </tr>
                          ";
        }
        ltr_table.Text += "</tbody></table>";
    }

    public void hienThiDuLieuCapNhat(String id)
    {
        String sql = "select * from tbl_cau_hoi where ma_cau_hoi='" + id + "'";
        DataTable cauhoi_table = new DataTable();
        cauhoi_table = connect.LayBang(sql);

        txtNoiDungCauHoi.Text = cauhoi_table.Rows[0][1].ToString();
        txtDapAnA.Text = cauhoi_table.Rows[0][2].ToString();
        txtDapAnB.Text = cauhoi_table.Rows[0][3].ToString();
        txtDapAnC.Text = cauhoi_table.Rows[0][4].ToString();
        txtDapAnD.Text = cauhoi_table.Rows[0][5].ToString();
        ddlDapAnDung.SelectedValue = cauhoi_table.Rows[0][6].ToString();
        
    }

    public void tao()
    {
        txtDapAnA.Text = "";
        txtDapAnB.Text = "";
        txtDapAnC.Text = "";
        txtDapAnD.Text = "";
        txtNoiDungCauHoi.Text = "";
        btnTao.Visible = true;
        btnCapNhat.Visible = false;
        btnHuy.Visible = false;
    }


    public void capNhat()
    {
        btnTao.Visible = false;
        btnCapNhat.Visible = true;
        btnHuy.Visible = true;
    }

    public bool validateTao()
    {
        if (txtNoiDungCauHoi.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập nội dung câu hỏi') </script>");
            return false;
        }
        if (txtDapAnA.Text == "")
        {
            Response.Write("<script> alert('Bạn cần ít nhất 2 đáp án') </script>");
            return false;
        }
        if (txtDapAnB.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập ít nhất 2 đáp án') </script>");
            return false;
        }

        if (ddlDapAnDung.SelectedValue == "C")
        {
            if (txtDapAnC.Text == "")
            {
                Response.Write("<script> alert('Bạn cần chọn đáp án đúng phù hợp') </script>");
                return false;
            }
        }

        if (ddlDapAnDung.SelectedValue == "D")
        {
            if (txtDapAnD.Text == "")
            {
                Response.Write("<script> alert('Bạn cần chọn đáp án đúng phù hợp') </script>");
                return false;
            }
        }
        return true;
    }

    protected void btnTao_Click(object sender, EventArgs e)
    {
        if (validateTao())
        {
            String noiDung = txtNoiDungCauHoi.Text;
            String A = txtDapAnA.Text;
            String B = txtDapAnB.Text;
            String C = txtDapAnC.Text;
            String D = txtDapAnD.Text;
            String dapAnDung = ddlDapAnDung.SelectedValue;
            String sql = "insert into tbl_cau_hoi(noi_dung, A, B, C, D, dap_an_dung) values(N'" + noiDung + "', N'" + A + "', N'" + B + "', N'" + C + "', N'" + D + "', '" + dapAnDung + "')";
            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Write("<script> alert('Thêm thành công') </script>");
                txtDapAnA.Text = "";
                txtDapAnB.Text = "";
                txtDapAnC.Text = "";
                txtDapAnD.Text = "";
                txtNoiDungCauHoi.Text = "";
            }
            else Response.Write("<script> alert('Thêm không thành công') </script>");
            hienThiDuLieu();
        }
    }



    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("tao_cau_hoi.aspx");
    }

    public bool validateCapNhat()
    {
        if (txtNoiDungCauHoi.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập nội dung câu hỏi') </script>");
            return false;
        }
        if (txtDapAnA.Text == "")
        {
            Response.Write("<script> alert('Bạn cần ít nhất 2 đáp án') </script>");
            return false;
        }
        if (txtDapAnB.Text == "")
        {
            Response.Write("<script> alert('Bạn cần nhập ít nhất 2 đáp án') </script>");
            return false;
        }

        if (ddlDapAnDung.SelectedValue == "C")
        {
            if (txtDapAnC.Text == "")
            {
                Response.Write("<script> alert('Bạn cần chọn đáp án đúng phù hợp') </script>");
                return false;
            }
        }

        if (ddlDapAnDung.SelectedValue == "D")
        {
            if (txtDapAnD.Text == "")
            {
                Response.Write("<script> alert('Bạn cần chọn đáp án đúng phù hợp') </script>");
                return false;
            }
        }
        return true;
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (validateCapNhat())
        {


            String noiDung = txtNoiDungCauHoi.Text;
            String A = txtDapAnA.Text;
            String B = txtDapAnB.Text;
            String C = txtDapAnC.Text;
            String D = txtDapAnD.Text;
            String dapAnDung = ddlDapAnDung.SelectedValue;

            String sql = "update tbl_cau_hoi set noi_dung=N'" + noiDung + "', A=N'" + A + "', B=N'" + B + "', C=N'" + C + "', D=N'" + D + "', dap_an_dung='" + dapAnDung + "' where ma_cau_hoi='" + Request.QueryString["id_sua"] + "'";

            //Response.Write(sql);
            if (connect.CapnhatCSDL(sql))
            {
                Response.Redirect("tao_cau_hoi.aspx?info=1");
            }
            else Response.Redirect("tao_cau_hoi.aspx?info=0");
        }
        
    }

    // string a = GridView1.DataKeys[e.RowIndex].Values["username"].ToString();

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        String sql = "select * from tbl_cau_hoi";
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

        for (int i = from; i < to; i++)
        {

            DataRow dr = dt.Rows[i];

            if (header == 0)
            {

                row = new TableRow();

                cell = new TableCell();

                //So thu tu

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 50;

                cell.Text = "<b>STT</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);


                //Ma cau hoi

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 100;

                cell.Text = "<b>Mã câu hỏi</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                //Nội dung câu hỏi

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 700;

                cell.Text = "<b>Nội dung câu hỏi</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);


                //A

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 400;

                cell.Text = "<b>Đáp án A</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                //B

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 400;

                cell.Text = "<b>B</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                //C

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 400;

                cell.Text = "<b>C</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                //D

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 400;

                cell.Text = "<b>D</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);

                //dap an dung

                cell = new TableCell();

                cell.Height = 50;

                cell.BackColor = System.Drawing.Color.FromName("orange");

                cell.Width = 50;

                cell.Text = "<b>Đáp án đúng</b>";

                cell.HorizontalAlign = HorizontalAlign.Center;

                cell.VerticalAlign = VerticalAlign.Middle;

                row.Cells.Add(cell);



                tb.Rows.Add(row);

            }

            header++;

            row = new TableRow();

            cell = new TableCell();


            //so thu tu

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = (i+1).ToString();

            cell.HorizontalAlign = HorizontalAlign.Center;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //Ma cau hoi

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[0].ToString();

            cell.HorizontalAlign = HorizontalAlign.Center;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //Noi dung cau hoi

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[1].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //A

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[2].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //B

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[3].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //C

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[4].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //D

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[5].ToString();

            cell.HorizontalAlign = HorizontalAlign.Left;

            row.Cells.Add(cell);

            row.Cells.Add(cell);

            //Dap an dung

            cell = new TableCell();

            cell.Height = 50;

            cell.Text = dr[6].ToString();

            cell.HorizontalAlign = HorizontalAlign.Center;

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
}