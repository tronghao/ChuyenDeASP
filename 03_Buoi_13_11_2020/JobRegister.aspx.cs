using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //add dropdownlist Giới tính
            ddl_gioi_tinh.Items.Add("Nam");
            ddl_gioi_tinh.Items.Add("Nữ");

            //add dropdownlist Tình trạng hôn nhân:
            ddl_tinh_trang_hon_nhan.Items.Add("Độc thân");
            ddl_tinh_trang_hon_nhan.Items.Add("Đã kết hôn");

            //add dropdownlist Trình độ học vấn
            ddl_trinh_do_hoc_van.Items.Add("Chọn");
            ddl_trinh_do_hoc_van.Items.Add("9/12");
            ddl_trinh_do_hoc_van.Items.Add("10/12");
            ddl_trinh_do_hoc_van.Items.Add("11/12");
            ddl_trinh_do_hoc_van.Items.Add("12/12");
            ddl_trinh_do_hoc_van.Items.Add("Cao đẳng");
            ddl_trinh_do_hoc_van.Items.Add("Đại học");
        }
    }
}