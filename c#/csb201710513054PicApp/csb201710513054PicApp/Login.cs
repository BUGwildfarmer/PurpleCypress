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

namespace csb201710513054PicApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("输入的信息不完整，请重新输入！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //创建路径及数据库名
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            string ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + strPath;
            OleDbConnection Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select * from [User] where Uid=" + textBox1.Text.Trim().ToString() + " and Upassword='" + textBox2.Text.Trim().ToString() + "';");
            OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), Olecon);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.Hide();
                Form1 form = new Form1();
                form.set_uid(Convert.ToInt32(textBox1.Text));
                form.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
