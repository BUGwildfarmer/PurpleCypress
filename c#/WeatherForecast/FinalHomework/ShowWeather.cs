using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stu.Zzr.FinalHomework.controls;

namespace Stu.Zzr.FinalHomework
{
    public partial class ShowWeather : Form
    {
        Point downPoint = Point.Empty;
        WebRequestWeatherInfo WeatherInfo = new WebRequestWeatherInfo();

        ShowTodayControl showTodayControl = new ShowTodayControl();
        ShowFivedaysControl showFivedaysControl = new ShowFivedaysControl();
        public ShowWeather()
        {
            InitializeComponent();
            this.showTodayControl.Dock= System.Windows.Forms.DockStyle.Fill; 
            this.showFivedaysControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Controls.Add(showTodayControl);
        }

        internal void ShowDialog(string city)
        {
            this.panel.Controls.Clear();
            showTodayControl.Dock = DockStyle.Fill;
            this.panel.Controls.Add(showTodayControl);

            if (GlobalWeatherDict.Citypict.ContainsKey(city))
            {
                int tmp = GlobalWeatherDict.citypict[city];
                this.BackgroundImage = citypic_imageList.Images[tmp];
                ImageLayout layout = ImageLayout.Stretch;
                this.BackgroundImageLayout = layout;
            }
            else
            {
                int tmp = GlobalWeatherDict.citypict["暂无"];
                this.BackgroundImage = citypic_imageList.Images[tmp];
                ImageLayout layout = ImageLayout.Stretch;
                this.BackgroundImageLayout = layout;
            }

            //进行天气查询，并且存储在WeatherInfo类中
            WeatherInfo = WeatherInfo.GetWeatherInfo(city);

            //错误返回判断
            if (WeatherInfo.error_code == "0")
            {
                //显示当天天气
                showTodayControl.ShowWeatherInfo(WeatherInfo);
                //显示连续七天天气
                //showFivedaysControl.showfive(WeatherInfo);

                this.ShowDialog();//如果不支持要查询的城市就不显示
            }
            else if (WeatherInfo.error_code == "203902")
            {
                MessageBox.Show("查询不到该城市");
            }
            else
            {
                MessageBox.Show("查询出错，请重试");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowWeather_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            downPoint = new Point(e.X, e.Y);
        }

        private void ShowWeather_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint == Point.Empty)
                return;

            Point location = new Point(this.Left + e.X - downPoint.X, this.Top + e.Y - downPoint.Y);

            this.Location = location;
        }

        private void ShowWeather_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            downPoint = Point.Empty;
        }

        private void FivedaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            showFivedaysControl.Dock = DockStyle.Fill;
            this.panel.Controls.Add(showFivedaysControl);

            //显示连续五天天气
            if(WeatherInfo!=null)
                showFivedaysControl.showfive(WeatherInfo);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("菜单栏进行切换可以得到城市当前天气以及近五天的天气状况\n作者:赵紫如\n制作时间:大二学年.net课程", "帮助文档");
        }

        private void TodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            showTodayControl.Dock = DockStyle.Fill;
            this.panel.Controls.Add(showTodayControl);

            //显示天气
            if (WeatherInfo != null)
                showTodayControl.ShowWeatherInfo(WeatherInfo);
        }

        private void todayTSMenuItem_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            showTodayControl.Dock = DockStyle.Fill;
            this.panel.Controls.Add(showTodayControl);

            //显示天气
            if (WeatherInfo != null)
                showTodayControl.ShowWeatherInfo(WeatherInfo);
        }

        private void fivedaysTSMenuItem_Click(object sender, EventArgs e)
        {
            this.panel.Controls.Clear();
            showFivedaysControl.Dock = DockStyle.Fill;
            this.panel.Controls.Add(showFivedaysControl);

            //显示连续五天天气
            if (WeatherInfo != null)
                showFivedaysControl.showfive(WeatherInfo);
        }

        private void exitTSMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
