using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chart : System.Web.UI.Page
{
    KN_CSDL connect = new KN_CSDL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hienThiDuLieu();
        }
    }

    public void hienThiDuLieu()
    {
        DataTable dt = new DataTable();
        String sql = "select gioi_tinh, count(*) as soLuong from tbl_nguoi_dung group by gioi_tinh";
        dt = connect.LayBang(sql);

        ltr.Text = @"<script>
                am4core.ready(function() {

                // Themes begin
                am4core.useTheme(am4themes_animated);
                // Themes end

                // Create chart instance
                var chart = am4core.create('div-chart', am4charts.PieChart);

                // Add data
                chart.data = [";
        for(int i=0; i<dt.Rows.Count; i++) {
            ltr.Text += @"{
                          'gioiTinh': '"+ dt.Rows[i][0] + @"',
                          'soLuong': " + dt.Rows[i][1] +  @"
                        },";
        }

        ltr.Text+= @"];

                // Add and configure Series
                var pieSeries = chart.series.push(new am4charts.PieSeries());
                pieSeries.dataFields.value = 'soLuong';
                pieSeries.dataFields.category = 'gioiTinh';
                pieSeries.slices.template.stroke = am4core.color('#fff');
                pieSeries.slices.template.strokeWidth = 2;
                pieSeries.slices.template.strokeOpacity = 1;

                // This creates initial animation
                pieSeries.hiddenState.properties.opacity = 1;
                pieSeries.hiddenState.properties.endAngle = -90;
                pieSeries.hiddenState.properties.startAngle = -90;

                }); // end am4core.ready()
                </script>";

    }
}