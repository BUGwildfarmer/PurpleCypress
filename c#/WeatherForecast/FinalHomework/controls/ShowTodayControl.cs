using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Stu.Zzr.FinalHomework.controls
{
    public partial class ShowTodayControl : UserControl//显示今天日期的控件
    {
        //初始化函数
        public ShowTodayControl()
        {
            InitializeComponent();
        }

        //显示当天天气的函数
        public void ShowWeatherInfo(WebRequestWeatherInfo WeatherInfo)
        {

            this.city_label.Text = "城市:"+ WeatherInfo.result.today.city;
            this.tmptemp_label.Text = "当前温度: " + WeatherInfo.result.sk.temp;
            this.date_label.Text = WeatherInfo.result.today.date_y;
            this.time_label.Text = WeatherInfo.result.sk.time;
            this.winddirection_label.Text = "当前风向: "+WeatherInfo.result.sk.wind_direction;
            this.windstrength_label.Text = "当前风力: "+WeatherInfo.result.sk.wind_strength;
            this.humidity_label.Text = "当前湿度: "+WeatherInfo.result.sk.humidity;

            this.weatherlabel.Text = "天气概况: " + WeatherInfo.result.today.weather;
            this.degree_label.Text = "温度范围: " + WeatherInfo.result.today.temperature;
            this.wind_label.Text = "风指数: " + WeatherInfo.result.today.wind;
            this.wet_label.Text = "湿度: " + WeatherInfo.result.sk.humidity;
            this.radio_label.Text = "紫外线指数: " + WeatherInfo.result.today.uv_index;

            if(WeatherInfo.result.today.comfort_index.Length!=0)
                this.comfort_label.Text =  "舒适度指数: " + WeatherInfo.result.today.comfort_index;
            else
                this.comfort_label.Text = "舒适度指数: 无";

            if(WeatherInfo.result.today.wash_index.Length!=0)
                this.wash_label.Text = "洗车指数: " + WeatherInfo.result.today.wash_index;
            else
                this.comfort_label.Text = "洗车指数: 无";

            if (WeatherInfo.result.today.travel_index.Length != 0)
                this.travel_label.Text = "旅游指数: " + WeatherInfo.result.today.travel_index;
            else
                this.travel_label.Text = "旅游指数: 无";

            if (WeatherInfo.result.today.exercise_index.Length != 0)
                this.exercise_label.Text = "晨练指数: " + WeatherInfo.result.today.exercise_index;
            else
                this.exercise_label.Text = "晨练指数: 无";

            if (WeatherInfo.result.today.drying_index.Length != 0)
                this.dry_label.Text = "干燥指数: " + WeatherInfo.result.today.drying_index;
            else
                this.dry_label.Text = "干燥指数: 无";

            this.tip_label.Text = "小提示:\n" + WeatherInfo.result.today.dressing_advice;
            
            //字典查询判断当前天气是否在字典内，并取出对应的图片
            if (GlobalWeatherDict.weatherpict.ContainsKey(WeatherInfo.result.today.weather))
            {
                int tmp = GlobalWeatherDict.weatherpict[WeatherInfo.result.today.weather];
                this.Weather_pictureBox.Image = weather_imageList.Images[tmp];
            }
            else
            {
                this.Weather_pictureBox.Image = weather_imageList.Images[30];
            }
        }
        
    }
}
