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
    public partial class Form1 : Form
    {
        const int cntGrid = 5;
        OleDbConnection Olecon;
        OleDbDataAdapter OleDat;
        DataTable dt;
        string ConStr;
        //int State = 0;
        int Maxvalue = 0;
        public static PictureBox[,] pic = new PictureBox[cntGrid, cntGrid];
        int userid = 0;


        public Form1()
        {
            InitializeComponent();
        }

        public void set_uid(int uid)
        {
            userid = uid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*左上角显示用户账号*/
            textBox1.Text = userid.ToString();

            /*DataGridView的图片列不显示打红叉 原始：System.Drawing.Bitmap*/
            dataGridView1.Columns[1].DefaultCellStyle.NullValue = null;

            // TODO: 这行代码将数据加载到表“picShareDBDataSet.Photo”中。您可以根据需要移动或删除它。
            // 后续需要绑定Debug数据库，所以和picShareDBDataSet无关
            //this.photoTableAdapter.Fill(this.picShareDBDataSet.Photo);

            /*******************Photo datagridview显示*********************/
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

            dt = new DataTable();

            /**********************默认按照降序排列****************************/

            StringBuilder strSQL = new StringBuilder();
            StringBuilder strSQL1 = new StringBuilder();

            strSQL.Append("select * from Photo");
            strSQL1.Append("select count(*) from Photo");
            
            OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

            Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL1.ToString(), Olecon).ExecuteScalar());
            Olecon.Close();

            // 0 ~ Maxvalue 行
            OleDat.Fill(0, Maxvalue, dt);

            dataGridView1.DataSource = dt;



            /*****************picturebox动态加载***************/

            // MemoryStream buf;
            // Image image;

            //for (int i = 0; i < 1; i++)
            //{
            //    for (int j = 0; j < cntGrid; j++)
            //    {
            //        pic[i, j] = new PictureBox();
            //        pic[i, j].Location = new Point(j * 200+10, i * 200+10);
            //        pic[i, j].Size = new Size(150, 150);
            //        pic[i, j].BackColor = Color.Purple;
            //        pic[i, j].SizeMode = PictureBoxSizeMode.Zoom;
            //        buf= new MemoryStream((byte[])dt.Rows[i+j][1]);
            //        image = Image.FromStream(buf, true);
            //        pic[i, j].Image = image;
            //        pic[i, j].Click += F;
            //        this.pnl_display.Controls.Add(pic[i, j]);
            //        buf.Dispose();
            //    }
            //}

        }

        //private void F(object sender, EventArgs e)
        //{
        //    PictureBox p = sender as PictureBox;
        //    MessageBox.Show(p.Name);
        //}

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Pic_Detail fm = new Pic_Detail();
        //    fm.setState(e.RowIndex);
        //    fm.Show();
        //}

        private void btn_pic_upload_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pic_Upload fm = new Pic_Upload();
            fm.set_uid(userid);
            fm.ShowDialog();
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pic_Detail pd = new Pic_Detail();
            pd.setState(e.RowIndex);
            pd.set_uid(userid);
            pd.Show();
        }

        //private void rbtn_inscend_CheckedChanged(object sender, EventArgs e)
        //{
        //    /*******************Photo datagridview显示*********************/
        //    string strPath = Application.StartupPath + "\\PicShareDB.accdb";
        //    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

        //    dt = new DataTable();

        //    /**********************默认按照降序排列****************************/

        //    StringBuilder strSQL = new StringBuilder();
        //    StringBuilder strSQL1 = new StringBuilder();

        //    if (rbtn_descend.Checked == true)
        //    {
        //        // select Pid from Remark group by Pid
        //        // select Photo.Pid,Pimg,Pname,Ptype,Pfrom,Pdate from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );

        //        strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");
        //        strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");
        //    }
        //    else if (rbtn_inscend.Checked == true)
        //    {
        //        strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum));");
        //        strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum));");
        //    }
        //    else
        //    {
        //        strSQL.Append("select * from Photo");
        //        strSQL1.Append("select count(*) from Photo");
        //    }

        //    OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

        //    Olecon = new OleDbConnection(ConStr);
        //    Olecon.Open();
        //    Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL1.ToString(), Olecon).ExecuteScalar());
        //    Olecon.Close();

        //    // 0 ~ Maxvalue 行
        //    OleDat.Fill(0, Maxvalue, dt);

        //    dataGridView1.DataSource = dt;
        //}

        //private void rbtn_descend_CheckedChanged(object sender, EventArgs e)
        //{
        //    /*******************Photo datagridview显示*********************/
        //    string strPath = Application.StartupPath + "\\PicShareDB.accdb";
        //    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

        //    dt = new DataTable();

        //    /**********************默认按照原序排列****************************/

        //    StringBuilder strSQL = new StringBuilder();
        //    StringBuilder strSQL1 = new StringBuilder();

        //    strSQL.Append("select * from Photo");
        //    strSQL1.Append("select count(*) from Photo");

        //    //if (rbtn_descend.Checked == true)
        //    //{
        //    //    // select Pid from Remark group by Pid
        //    //    // select Photo.Pid,Pimg,Pname,Ptype,Pfrom,Pdate from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );

        //    //    strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");
        //    //    strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");
        //    //}
        //    //else if (rbtn_inscend.Checked == true)
        //    //{
        //    //    strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum));");
        //    //    strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum));");
        //    //}
        //    //else
        //    //{
                
        //    //}

        //    OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

        //    Olecon = new OleDbConnection(ConStr);
        //    Olecon.Open();
        //    Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL1.ToString(), Olecon).ExecuteScalar());
        //    Olecon.Close();

        //    // 0 ~ Maxvalue 行
        //    OleDat.Fill(0, Maxvalue, dt);

        //    dataGridView1.DataSource = dt;
        //}

        private void btn_ascend_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

            dt = new DataTable();


            StringBuilder strSQL = new StringBuilder();
            StringBuilder strSQL1 = new StringBuilder();

            
                // select Pid from Remark group by Pid
                // select Photo.Pid,Pimg,Pname,Ptype,Pfrom,Pdate from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );

             strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );");
             strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );");
            

            OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

            Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL1.ToString(), Olecon).ExecuteScalar());
            Olecon.Close();

            // 0 ~ Maxvalue 行
            OleDat.Fill(0, Maxvalue, dt);

            dataGridView1.DataSource = dt;
        }

        private void btn_descend_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\PicShareDB.accdb";
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + strPath;

            dt = new DataTable();


            StringBuilder strSQL = new StringBuilder();
            StringBuilder strSQL1 = new StringBuilder();


            // select Pid from Remark group by Pid
            // select Photo.Pid,Pimg,Pname,Ptype,Pfrom,Pdate from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) );

            strSQL.Append("select * from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");
            strSQL1.Append("select count(*) from Photo where Pid in (select Pid from Remark group by Pid order by avg(Rnum) DESC);");


            OleDat = new OleDbDataAdapter(strSQL.ToString(), ConStr);

            Olecon = new OleDbConnection(ConStr);
            Olecon.Open();
            Maxvalue = Convert.ToInt32(new OleDbCommand(strSQL1.ToString(), Olecon).ExecuteScalar());
            Olecon.Close();

            // 0 ~ Maxvalue 行
            OleDat.Fill(0, Maxvalue, dt);

            dataGridView1.DataSource = dt;
        }
    }
}
