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
    public partial class ShowInfo : UserControl//显示一天的天气概况
    {
        public ShowInfo()
        {
            InitializeComponent();
        }

        //界面显示
        public void show(WebRequestWeatherInfo WeatherInfo,int a)
        {
             this.day_label.Text = WeatherInfo.result.future[a].date;
             this.weat_label.Text = WeatherInfo.result.future[a].weather;
             this.deg_label.Text = WeatherInfo.result.future[a].temperature;
             this.wind_label.Text = WeatherInfo.result.future[a].wind;
             this.week_label.Text = WeatherInfo.result.future[a].week;

            //字典查询判断当前天气是否在字典内，并取出对应的图片
            if (GlobalWeatherDict.weatherpict.ContainsKey(WeatherInfo.result.future[a].weather))
            {
                int tmp = GlobalWeatherDict.weatherpict[WeatherInfo.result.future[a].weather];
                this.pictureBox.Image = weather_imageList.Images[tmp];
            }
            else
            {
                this.pictureBox.Image = weather_imageList.Images[30];
            }
        }
    }
}
