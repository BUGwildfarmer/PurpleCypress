using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace csb201710513054PicApp
{
    public partial class Pic_Upload : Form
    {
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        string ConStr;
        string file_str;
        int Maxvalue = 0;
        int userid = 0;

        public Pic_Upload()
        {
            InitializeComponent();
        }

        public void set_uid(int uid)
        {
            userid = uid;
        }

        private void Pic_Upload_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = true;

            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = userid.ToString();
            this.textBox5.Text = "";

        }

        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("输入的信息不完整，请重新输入！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + strPath;
            Olecon = new OleDbConnection(ConStr);
            StringBuilder strSQL = new StringBuilder();

            FileStream file = new FileStream(file_str, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] fByte = new byte[(int)file.Length];
            file.Read(fByte, 0, fByte.Length);

            strSQL.Append("insert into Photo(Pid,Pimg,Pname,Ptype,Pfrom,Pdate) ");
            strSQL.Append("values(" + textBox1.Text.Trim().ToString() + ",@Image,'");
            strSQL.Append(textBox2.Text.Trim().ToString() + "','");
            strSQL.Append(textBox3.Text.Trim().ToString() + "',");
            strSQL.Append(textBox4.Text.Trim().ToString() + ",#");
            strSQL.Append(textBox5.Text.Trim().ToString() + "#);");

            //strSQL.Append("UPDATE Photo SET Pimg=@Image WHERE Pid=" + textBox1.Text.Trim().ToString() + ";");

            using (OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), Olecon))
            {
                cmd.Parameters.Add("Image", SqlDbType.Binary).Value = fByte;
                Olecon.Open();
                cmd.ExecuteNonQuery();
                Maxvalue = Convert.ToInt32(new OleDbCommand("select count(*) from Photo", Olecon).ExecuteScalar());
                Olecon.Close();
                Olecon.Dispose();
            }

            MessageBox.Show("成功添加图片", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_str = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(file_str);
            }
        }

        private void picupload_close(object sender, FormClosedEventArgs e)
        {
            // close和dispose的区别
            //this.Close();
            this.Dispose();
            // 子窗体调用父窗体
            Form1 fm = new Form1();
            fm.set_uid(userid);
            fm.ShowDialog();
        }
    }
}
