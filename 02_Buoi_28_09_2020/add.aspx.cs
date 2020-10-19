using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected String tinh(String thao_tac)
    {

        int soA = Convert.ToInt32(txtA.Text);
        int soB = Convert.ToInt32(txtB.Text);
 
        switch (thao_tac)
        {
            case "Cộng": return (soA + soB).ToString();

            case "Trừ":  return (soA - soB).ToString();

            case "Nhân": return (soA * soB).ToString();

            case "Chia":
                if (soB != 0)
                    return ((float)soA / soB).ToString();
                else return "không thể tính - mẫu bằng 0";

        }

        return "Không thể tính";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lbKQ.Text = tinh("Cộng"); ;
    }
    protected void btnTru_Click(object sender, EventArgs e)
    {
        lbKQ.Text = tinh("Trừ");
    }
    protected void btnNhan_Click(object sender, EventArgs e)
    {
        lbKQ.Text = tinh("Nhân");
    }
    protected void btnChia_Click(object sender, EventArgs e)
    {
        lbKQ.Text = tinh("Chia");
    }
}