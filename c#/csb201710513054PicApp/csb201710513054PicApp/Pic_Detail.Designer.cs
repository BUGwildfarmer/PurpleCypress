namespace csb201710513054PicApp
{
    partial class Pic_Detail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_picinfo = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tb_usrid = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tb_Pid = new System.Windows.Forms.TextBox();
            this.label_picdate = new System.Windows.Forms.Label();
            this.label_picauthor = new System.Windows.Forms.Label();
            this.label_pictype = new System.Windows.Forms.Label();
            this.label_picname = new System.Windows.Forms.Label();
            this.label_picid = new System.Windows.Forms.Label();
            this.gb_picoperation = new System.Windows.Forms.GroupBox();
            this.btn_userinfo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_remark = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.sfd_picdownload = new System.Windows.Forms.SaveFileDialog();
            this.gb_picinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_picoperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_picinfo
            // 
            this.gb_picinfo.Controls.Add(this.pictureBox1);
            this.gb_picinfo.Controls.Add(this.textBox5);
            this.gb_picinfo.Controls.Add(this.tb_usrid);
            this.gb_picinfo.Controls.Add(this.textBox3);
            this.gb_picinfo.Controls.Add(this.textBox2);
            this.gb_picinfo.Controls.Add(this.tb_Pid);
            this.gb_picinfo.Controls.Add(this.label_picdate);
            this.gb_picinfo.Controls.Add(this.label_picauthor);
            this.gb_picinfo.Controls.Add(this.label_pictype);
            this.gb_picinfo.Controls.Add(this.label_picname);
            this.gb_picinfo.Controls.Add(this.label_picid);
            this.gb_picinfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_picinfo.Location = new System.Drawing.Point(12, 12);
            this.gb_picinfo.Name = "gb_picinfo";
            this.gb_picinfo.Size = new System.Drawing.Size(676, 367);
            this.gb_picinfo.TabIndex = 0;
            this.gb_picinfo.TabStop = false;
            this.gb_picinfo.Text = "图片信息";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(291, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 311);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(139, 279);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 30);
            this.textBox5.TabIndex = 9;
            // 
            // tb_usrid
            // 
            this.tb_usrid.Enabled = false;
            this.tb_usrid.Location = new System.Drawing.Point(139, 222);
            this.tb_usrid.Name = "tb_usrid";
            this.tb_usrid.Size = new System.Drawing.Size(114, 30);
            this.tb_usrid.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(139, 167);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 30);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(139, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 30);
            this.textBox2.TabIndex = 6;
            // 
            // tb_Pid
            // 
            this.tb_Pid.Enabled = false;
            this.tb_Pid.Location = new System.Drawing.Point(139, 56);
            this.tb_Pid.Name = "tb_Pid";
            this.tb_Pid.Size = new System.Drawing.Size(114, 30);
            this.tb_Pid.TabIndex = 5;
            // 
            // label_picdate
            // 
            this.label_picdate.AutoSize = true;
            this.label_picdate.Location = new System.Drawing.Point(27, 282);
            this.label_picdate.Name = "label_picdate";
            this.label_picdate.Size = new System.Drawing.Size(89, 20);
            this.label_picdate.TabIndex = 4;
            this.label_picdate.Text = "上传日期";
            // 
            // label_picauthor
            // 
            this.label_picauthor.AutoSize = true;
            this.label_picauthor.Location = new System.Drawing.Point(27, 226);
            this.label_picauthor.Name = "label_picauthor";
            this.label_picauthor.Size = new System.Drawing.Size(89, 20);
            this.label_picauthor.TabIndex = 3;
            this.label_picauthor.Text = "作者帐号";
            // 
            // label_pictype
            // 
            this.label_pictype.AutoSize = true;
            this.label_pictype.Location = new System.Drawing.Point(27, 170);
            this.label_pictype.Name = "label_pictype";
            this.label_pictype.Size = new System.Drawing.Size(89, 20);
            this.label_pictype.TabIndex = 2;
            this.label_pictype.Text = "图片类型";
            // 
            // label_picname
            // 
            this.label_picname.AutoSize = true;
            this.label_picname.Location = new System.Drawing.Point(27, 112);
            this.label_picname.Name = "label_picname";
            this.label_picname.Size = new System.Drawing.Size(89, 20);
            this.label_picname.TabIndex = 1;
            this.label_picname.Text = "图片名称";
            // 
            // label_picid
            // 
            this.label_picid.AutoSize = true;
            this.label_picid.Location = new System.Drawing.Point(27, 56);
            this.label_picid.Name = "label_picid";
            this.label_picid.Size = new System.Drawing.Size(89, 20);
            this.label_picid.TabIndex = 0;
            this.label_picid.Text = "图片编号";
            // 
            // gb_picoperation
            // 
            this.gb_picoperation.Controls.Add(this.btn_userinfo);
            this.gb_picoperation.Controls.Add(this.button3);
            this.gb_picoperation.Controls.Add(this.btn_remark);
            this.gb_picoperation.Controls.Add(this.btn_download);
            this.gb_picoperation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_picoperation.Location = new System.Drawing.Point(694, 12);
            this.gb_picoperation.Name = "gb_picoperation";
            this.gb_picoperation.Size = new System.Drawing.Size(195, 367);
            this.gb_picoperation.TabIndex = 1;
            this.gb_picoperation.TabStop = false;
            this.gb_picoperation.Text = "图片操作";
            // 
            // btn_userinfo
            // 
            this.btn_userinfo.Location = new System.Drawing.Point(33, 209);
            this.btn_userinfo.Name = "btn_userinfo";
            this.btn_userinfo.Size = new System.Drawing.Size(135, 38);
            this.btn_userinfo.TabIndex = 3;
            this.btn_userinfo.Text = "作者信息";
            this.btn_userinfo.UseVisualStyleBackColor = true;
            this.btn_userinfo.Click += new System.EventHandler(this.btn_userinfo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "联合创作";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_remark
            // 
            this.btn_remark.Location = new System.Drawing.Point(33, 131);
            this.btn_remark.Name = "btn_remark";
            this.btn_remark.Size = new System.Drawing.Size(135, 38);
            this.btn_remark.TabIndex = 1;
            this.btn_remark.Text = "评价";
            this.btn_remark.UseVisualStyleBackColor = true;
            this.btn_remark.Click += new System.EventHandler(this.btn_remark_Click);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(33, 53);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(135, 38);
            this.btn_download.TabIndex = 0;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // Pic_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 392);
            this.Controls.Add(this.gb_picoperation);
            this.Controls.Add(this.gb_picinfo);
            this.Name = "Pic_Detail";
            this.Text = "csb_Pic_Detail";
            this.Load += new System.EventHandler(this.Pic_Detail_Load);
            this.gb_picinfo.ResumeLayout(false);
            this.gb_picinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_picoperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_picinfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox tb_usrid;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tb_Pid;
        private System.Windows.Forms.Label label_picdate;
        private System.Windows.Forms.Label label_picauthor;
        private System.Windows.Forms.Label label_pictype;
        private System.Windows.Forms.Label label_picname;
        private System.Windows.Forms.Label label_picid;
        private System.Windows.Forms.GroupBox gb_picoperation;
        private System.Windows.Forms.Button btn_userinfo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_remark;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.SaveFileDialog sfd_picdownload;
    }
}