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
    public partial class Add_Remark : Form
    {
        int uid = 0;
        int pid = 0;
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        DataTable dt;
        string ConStr;
        int userid = 0;

        public Add_Remark()
        {
            InitializeComponent();
        }

        private void Add_Remark_Load(object sender, EventArgs e)
        {
            tb_uid.Text = userid.ToString();
        }

        public void set_uid(int uid)
        {
            userid = uid;
        }

        public void set_pid(int picid)
        {
            pid = picid;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (tb_score.Text == "" || rtb_remark.Text == "")
            {
                MessageBox.Show("输入的信息不完整，请重新输入！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + strPath;
            Olecon = new OleDbConnection(ConStr);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("insert into Remark values(" + pid.ToString() + "," + tb_uid.Text.Trim().ToString() + ",");
            // 数字部分无需加引号 短文本字段需要用''或者""括起来
            strSQL.Append(tb_score.Text.Trim().ToString() + ",'" + rtb_remark.Text.Trim().ToString() + "');");
            /*坑点：重复添加相同内容会出错，要写一个错误处理，提示表示该数据已经被插入过*/
            using (OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), Olecon))
            {
                Olecon.Open();
                cmd.ExecuteNonQuery();
                Olecon.Close();
                Olecon.Dispose();
            }
            MessageBox.Show("成功评分", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            this.Dispose();
        }

        private void addremark_close(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose();
            // 子窗体调用父窗体
            Pic_Remark pr = new Pic_Remark();
            pr.set_Pid(pid);
            pr.set_uid(userid);
            pr.ShowDialog();
        }
    }
}
