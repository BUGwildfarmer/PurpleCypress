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
    public partial class Pic_Remark : Form
    {
        const int cntGrid = 3;
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        DataTable dt;
        string ConStr;
        int State = 0;
        int Maxvalue = 0;
        int picpid = 0;
        int userid = 0;

        public Pic_Remark()
        {
            InitializeComponent();
        }

        private void Pic_Remark_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“picShareDBDataSet.Remark”中。您可以根据需要移动或删除它。
            this.remarkTableAdapter.Fill(this.picShareDBDataSet.Remark);

            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

            dt = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select * from Remark where Pid=" + picpid.ToString() + ";");
            OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

            Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            strSQL.Clear();
            strSQL.Append("select count(*) from Remark where Pid=" + picpid.ToString() + ";");
            Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL.ToString(), Olecon).ExecuteScalar());
            Olecon.Close();

            // 0 ~ Maxvalue行
            OleDat.Fill(0, Maxvalue, dt);

            /*remark datagridview绑定新的datatable*/
            dataGridView1.DataSource = dt;
        }

        public void set_Pid(int pid)
        {
            picpid = pid;
        }

        public void set_uid(int uid)
        {
            userid = uid;
        }

        private void btn_addremark_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Remark ad = new Add_Remark();
            ad.set_pid(picpid);
            ad.set_uid(userid);
            ad.ShowDialog();
            this.Dispose();
        }
    }
}
