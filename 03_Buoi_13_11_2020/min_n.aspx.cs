using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class min_n : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTinh_Click(object sender, EventArgs e)
    {
        try
        {
            int soN = Convert.ToInt32(txtN.Text);
            int kq = 0;
            for (int i = 2; i < soN; i++)
            {
                if (i % 2 == 0)
                    kq += i;
            }

            lbKQ.Text = kq.ToString();
        } catch(Exception ex) {
            lbKQ.Text = "Lỗi nhập liệu";
        }
        
    }
}