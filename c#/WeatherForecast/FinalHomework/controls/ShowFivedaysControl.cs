using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stu.Zzr.FinalHomework.controls
{
    public partial class ShowFivedaysControl : UserControl//显示连续五天的天气概况的控件
    {
        public ShowFivedaysControl()
        {
            InitializeComponent();
        }

        public void showfive(WebRequestWeatherInfo WeatherInfo)
        {
            this.title_label.Text = WeatherInfo.result.today.city + "连续五天天气";
            this.showInfo1.show(WeatherInfo, 0);
            this.showInfo2.show(WeatherInfo, 1);
            this.showInfo3.show(WeatherInfo, 2);
            this.showInfo4.show(WeatherInfo, 3);
            this.showInfo5.show(WeatherInfo, 4);

            //图表的数据绑定
            List<string> ylowData = new List<string>();
            List<string> yhighData = new List<string>();
            List<string> xData = new List<string>();

            //要对温度字符串进行处理
            int tmp = 0;
            for (;tmp<=6;tmp++)
            {
                string s = WeatherInfo.result.future[tmp].temperature;
                string[] ss = s.Split(new char[2] { '~', '℃' });
                ylowData.Add(ss[0]);
                yhighData.Add(ss[2]);
                xData.Add(WeatherInfo.result.future[tmp].date);

            }

            this.date_chart.Series[0].Points.DataBindXY(xData, ylowData);
            this.date_chart.Series[1].Points.DataBindXY(xData, yhighData);
        }
    }
}
