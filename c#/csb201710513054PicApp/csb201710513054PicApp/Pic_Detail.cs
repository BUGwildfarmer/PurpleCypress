using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace csb201710513054PicApp
{
    public partial class Pic_Detail : Form
    {
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        DataTable dt;
        string ConStr;
        int State = 0;
        int Maxvalue = 0;
        int userid = 0;

        public void set_uid(int uid)
        {
            userid = uid;
        }

        public Pic_Detail()
        {
            InitializeComponent();
        }

        private void Pic_Detail_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;
            Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            Maxvalue = Convert.ToInt32(new OleDbCommand("select Count(*) from Photo", Olecon).ExecuteScalar());
            Olecon.Close();

            ShowInfo(State, State + 1);
        }

        private void ShowInfo(int first, int next)
        {
            dt = new DataTable();
            OleDat = new OleDbDataAdapter("select * from Photo", ConStr);
            OleDat.Fill(first, next, dt);
            this.tb_Pid.Text = dt.Rows[0][0].ToString();
            this.textBox2.Text = dt.Rows[0][2].ToString();
            this.textBox3.Text = dt.Rows[0][3].ToString();
            this.tb_usrid.Text = dt.Rows[0][4].ToString();
            this.textBox5.Text = dt.Rows[0][5].ToString();
            // using namespace System.IO
            MemoryStream buf = new MemoryStream((byte[])dt.Rows[0][1]);
            Image image = Image.FromStream(buf, true);
            pictureBox1.Image = image;
        }

        public void setState(int curRow)
        {
            State = curRow;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            // 从picturebox获取图片文件，无需从数据库读取二进制流文件再转换
            Image image = pictureBox1.Image;
            // 文件类型
            sfd_picdownload.Filter = "Jpg 图片|*.jpg|Bmp 图片|*.bmp|Gif 图片|*.gif|Png 图片|*.png|Wmf  图片|*.wmf";
            sfd_picdownload.FilterIndex = 0;
            //保存对话框是否记忆上次打开的目录
            sfd_picdownload.RestoreDirectory = true;
            //检查目录
            sfd_picdownload.CheckPathExists = true;
            //设置默认文件名：“时间-”  / 用户可自定义
            sfd_picdownload.FileName = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "-"; ;
            if (sfd_picdownload.ShowDialog() == DialogResult.OK)
            {
                // image为要保存的图片
                image.Save(sfd_picdownload.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show(this, "图片保存成功！", "信息提示");
            }
        }

        private void btn_remark_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(tb_Pid.Text);
            Pic_Remark pr = new Pic_Remark();
            pr.set_Pid(pid);
            pr.set_uid(userid);
            pr.Show();
        }

        private void btn_userinfo_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(tb_usrid.Text);
            User_Detail ud = new User_Detail();
            ud.set_Uid(uid);
            ud.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pic_draw pd = new pic_draw();
            pd.setImage(pictureBox1.Image);
            pd.Show();
        }
    }
}
