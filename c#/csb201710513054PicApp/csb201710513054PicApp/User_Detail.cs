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
    public partial class User_Detail : Form
    {
        int uid = 0;
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        DataTable dt;
        string ConStr;
        int State = 0;
        int Maxvalue = 0;

        public User_Detail()
        {
            InitializeComponent();
        }

        public void set_Uid(int usrid)
        {
            uid = usrid;
        }

        private void User_Detail_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

            dt = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            // 坑点：此处对于表名要加[] 为什么其他不要加
            strSQL.Append("select Uid,Uname,Ugrade,Uprofession from [User] where Uid=" + uid.ToString() + ";");
            //strSQL.Append("select * from [User] ;");
            OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);
            OleDat.Fill(0, 1, dt);
            this.textBox1.Text = dt.Rows[0][0].ToString();
            this.textBox2.Text = dt.Rows[0][1].ToString();
            this.textBox3.Text = dt.Rows[0][2].ToString();
            this.textBox4.Text = dt.Rows[0][3].ToString();
        }
    }
}
