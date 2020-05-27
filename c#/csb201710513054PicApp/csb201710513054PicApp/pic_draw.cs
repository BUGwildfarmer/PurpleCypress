using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csb201710513054PicApp
{
    public partial class pic_draw : Form
    {
        bool G_MouseFlag;
        Pen pen = new Pen(Color.Black,2);
        Point lastPoint;
        Graphics graphics;

        public pic_draw()
        {
            InitializeComponent();
        }

        private void pic_draw_Load(object sender, EventArgs e)
        {
             
        }

        public void setImage(Image i)
        {
            pb_draw.Image = i;
        }

        private void pb_draw_MouseUp(object sender, MouseEventArgs e)
        {
            G_MouseFlag = false;//开始绘图标识设置为false
        }

        private void pb_draw_MouseMove(object sender, MouseEventArgs e)
        {
            graphics = Graphics.FromImage(pb_draw.Image);
            if (lastPoint.Equals(Point.Empty))//判断绘图开始点是否为空
            {
                lastPoint = new Point(e.X, e.Y);//记录鼠标当前位置
            }
            if (G_MouseFlag)//开始绘图
            {
                Point currentPoint = new Point(e.X, e.Y);//获取鼠标当前位置
                graphics.DrawLine(pen, currentPoint, lastPoint);//绘图 
                pb_draw.Refresh();
            }
            lastPoint = new Point(e.X, e.Y);//记录鼠标当前位置
        }

        private void pb_draw_MouseDown(object sender, MouseEventArgs e)
        {
            G_MouseFlag = true;//开始绘图标识设置为true
        }

        private void btn_savenew_Click(object sender, EventArgs e)
        {
            // 从picturebox获取图片文件，无需从数据库读取二进制流文件再转换
            Image image = pb_draw.Image;
            // 文件类型
            saveFileDialog1.Filter = "Jpg 图片|*.jpg|Bmp 图片|*.bmp|Gif 图片|*.gif|Png 图片|*.png|Wmf  图片|*.wmf";
            saveFileDialog1.FilterIndex = 0;
            //保存对话框是否记忆上次打开的目录
            saveFileDialog1.RestoreDirectory = true;
            //检查目录
            saveFileDialog1.CheckPathExists = true;
            //设置默认文件名：“时间-”  / 用户可自定义
            saveFileDialog1.FileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "-"; ;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // image为要保存的图片
                image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show(this, "图片保存成功！", "信息提示");
            }
        }
    }
}
