using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stu.Zzr.FinalHomework.WeatherServiceReference;
using Stu.Zzr.FinalHomework.Weatherweb;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using System.Media;

namespace Stu.Zzr.FinalHomework
{
    public partial class MainForm : Form
    {
        Point downPoint = Point.Empty;
        SoundPlayer play = null;
        ShowWeather showWeather = new ShowWeather();

        public MainForm()
        {
            InitializeComponent();
          
            this.city_comboBox.Text= "请输入城市名称";

            //加载音乐
            play = new SoundPlayer();
            play.SoundLocation = "../../song.wav";
            play.Load();
            play.Play();

        }

        //关闭窗体
        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("最小化?","确认",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result == DialogResult.OK)
                this.WindowState = FormWindowState.Minimized;
            else
                System.Environment.Exit(0);
        }

        //点击查询
        private void Search_Click(object sender, EventArgs e)
        {
            string city = city_comboBox.Text.Trim();
            //要如何把字符串传下去
            if (city.Length != 0)
                this.showWeather.ShowDialog(city);
        }
        
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            downPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            downPoint = Point.Empty;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
                return;

            Point location = new Point(this.Left + e.X - downPoint.X, this.Top + e.Y - downPoint.Y);

            this.Location = location;
        }

        
        //最小化
        private void MiniSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            //将天气状况和图片位置字符放在一个字典里
            GlobalWeatherDict.Weatherpict.Add("暴雪", 0);
            GlobalWeatherDict.Weatherpict.Add("暴雨", 1);
            GlobalWeatherDict.Weatherpict.Add("暴雨-大暴雨", 2);
            GlobalWeatherDict.weatherpict.Add("冰雹", 3);
            GlobalWeatherDict.Weatherpict.Add("大暴雨", 4);
            GlobalWeatherDict.Weatherpict.Add("大暴雨-特大暴雨", 5);
            GlobalWeatherDict.weatherpict.Add("大风", 6);
            GlobalWeatherDict.Weatherpict.Add("大雪", 7);
            GlobalWeatherDict.Weatherpict.Add("大雪-暴雪", 8);
            GlobalWeatherDict.Weatherpict.Add("大雨", 9);
            GlobalWeatherDict.Weatherpict.Add("大雨-暴雨", 10);
            GlobalWeatherDict.Weatherpict.Add("冻雨", 11);
            GlobalWeatherDict.Weatherpict.Add("多云", 12);
            GlobalWeatherDict.weatherpict.Add("多云转晴", 13);
            GlobalWeatherDict.Weatherpict.Add("浮尘", 14);
            GlobalWeatherDict.Weatherpict.Add("雷阵雨", 15);
            GlobalWeatherDict.Weatherpict.Add("雷阵雨并伴有冰雹", 16);
            GlobalWeatherDict.Weatherpict.Add("霾", 17);
            GlobalWeatherDict.Weatherpict.Add("强沙尘暴", 18);
            GlobalWeatherDict.Weatherpict.Add("晴", 19);
            GlobalWeatherDict.Weatherpict.Add("沙尘暴", 20);
            GlobalWeatherDict.Weatherpict.Add("特大暴雨", 21);
            GlobalWeatherDict.Weatherpict.Add("雾", 22);
            GlobalWeatherDict.Weatherpict.Add("小雪", 23);
            GlobalWeatherDict.Weatherpict.Add("小雪-中雪", 24);
            GlobalWeatherDict.Weatherpict.Add("小雨", 25);
            GlobalWeatherDict.Weatherpict.Add("小雨-中雨", 26);
            GlobalWeatherDict.Weatherpict.Add("扬尘", 27);
            GlobalWeatherDict.Weatherpict.Add("阴", 28);
            GlobalWeatherDict.Weatherpict.Add("雨夹雪", 29);
            GlobalWeatherDict.Weatherpict.Add("暂无", 30);
            GlobalWeatherDict.Weatherpict.Add("阵雪", 31);
            GlobalWeatherDict.Weatherpict.Add("阵雨", 32);
            GlobalWeatherDict.Weatherpict.Add("中雪", 33);
            GlobalWeatherDict.Weatherpict.Add("中雪-大雪", 34);
            GlobalWeatherDict.Weatherpict.Add("中雨", 35);
            GlobalWeatherDict.Weatherpict.Add("中雨-大雨", 36);
            GlobalWeatherDict.Weatherpict.Add("阴转多云", 37);
            GlobalWeatherDict.Weatherpict.Add("小雨转多云", 38);
            GlobalWeatherDict.Weatherpict.Add("多云转小雨", 39);
            GlobalWeatherDict.Weatherpict.Add("多云转阴", 40);
            GlobalWeatherDict.Weatherpict.Add("霾转多云", 41);
            GlobalWeatherDict.Weatherpict.Add("多云转霾", 41);
            GlobalWeatherDict.Weatherpict.Add("晴转多云", 42);
            GlobalWeatherDict.Weatherpict.Add("阴转小雨", 42);
            GlobalWeatherDict.Weatherpict.Add("小雨转阴", 43);

            //将省市字符和省市图片位置字符放在一个字典里，此处不一一列举每个省市的图片
            GlobalWeatherDict.Citypict.Add("北京",0);
            GlobalWeatherDict.Citypict.Add("天津",1);
            GlobalWeatherDict.Citypict.Add("上海",2);
            GlobalWeatherDict.Citypict.Add("重庆",3);
            GlobalWeatherDict.Citypict.Add("哈尔滨",4);
            GlobalWeatherDict.Citypict.Add("南京",5);
            GlobalWeatherDict.Citypict.Add("杭州",6);
            GlobalWeatherDict.Citypict.Add("武汉",7);
            GlobalWeatherDict.Citypict.Add("长沙",8);
            GlobalWeatherDict.Citypict.Add("成都",9);
            GlobalWeatherDict.Citypict.Add("桂林",10);
            GlobalWeatherDict.Citypict.Add("昆明",11);
            GlobalWeatherDict.Citypict.Add("西安",12);
            GlobalWeatherDict.Citypict.Add("广州",13);
            GlobalWeatherDict.Citypict.Add("香港",14);
            GlobalWeatherDict.Citypict.Add("暂无",15); 
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("在输入框里输入城市名称可以得到城市当前天气以及近五天的天气状况\n作者:赵紫如\n制作时间:大二学年.net课程","帮助文档");
        }

        private void city_comboBox_Leave(object sender, EventArgs e)
        {
            if (this.city_comboBox.Text.Length == 0)
            {
                this.city_comboBox.Text = "请输入城市名称";
            }
        }

        private void city_comboBox_Enter(object sender, EventArgs e)
        {
            if (this.city_comboBox.Text == "请输入城市名称")
            {
                this.city_comboBox.Text = "";
            }
        }

        //窗口最小化时
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.notifyIcon.Visible = true;
            }
        }

        //当窗体关闭时
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;//不关闭程序
            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.notifyIcon.Visible = false;
        }

        private void cMS_normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void cMS_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
