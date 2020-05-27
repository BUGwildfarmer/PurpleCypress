namespace csb201710513054PicApp
{
    partial class Pic_Upload
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_picdate = new System.Windows.Forms.Label();
            this.label_picauthor = new System.Windows.Forms.Label();
            this.label_pictype = new System.Windows.Forms.Label();
            this.label_picname = new System.Windows.Forms.Label();
            this.label_picid = new System.Windows.Forms.Label();
            this.btn_comfirm = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label_picdate);
            this.groupBox1.Controls.Add(this.label_picauthor);
            this.groupBox1.Controls.Add(this.label_pictype);
            this.groupBox1.Controls.Add(this.label_picname);
            this.groupBox1.Controls.Add(this.label_picid);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 351);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "填写图片信息";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(300, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(128, 274);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(140, 30);
            this.textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(128, 221);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 30);
            this.textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(128, 167);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 30);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 30);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 30);
            this.textBox1.TabIndex = 5;
            // 
            // label_picdate
            // 
            this.label_picdate.AutoSize = true;
            this.label_picdate.Location = new System.Drawing.Point(16, 277);
            this.label_picdate.Name = "label_picdate";
            this.label_picdate.Size = new System.Drawing.Size(89, 20);
            this.label_picdate.TabIndex = 4;
            this.label_picdate.Text = "上传日期";
            // 
            // label_picauthor
            // 
            this.label_picauthor.AutoSize = true;
            this.label_picauthor.Location = new System.Drawing.Point(16, 224);
            this.label_picauthor.Name = "label_picauthor";
            this.label_picauthor.Size = new System.Drawing.Size(89, 20);
            this.label_picauthor.TabIndex = 3;
            this.label_picauthor.Text = "图片作者";
            // 
            // label_pictype
            // 
            this.label_pictype.AutoSize = true;
            this.label_pictype.Location = new System.Drawing.Point(16, 170);
            this.label_pictype.Name = "label_pictype";
            this.label_pictype.Size = new System.Drawing.Size(89, 20);
            this.label_pictype.TabIndex = 2;
            this.label_pictype.Text = "图片类型";
            // 
            // label_picname
            // 
            this.label_picname.AutoSize = true;
            this.label_picname.Location = new System.Drawing.Point(16, 118);
            this.label_picname.Name = "label_picname";
            this.label_picname.Size = new System.Drawing.Size(89, 20);
            this.label_picname.TabIndex = 1;
            this.label_picname.Text = "图片名称";
            // 
            // label_picid
            // 
            this.label_picid.AutoSize = true;
            this.label_picid.Location = new System.Drawing.Point(16, 65);
            this.label_picid.Name = "label_picid";
            this.label_picid.Size = new System.Drawing.Size(89, 20);
            this.label_picid.TabIndex = 0;
            this.label_picid.Text = "图片编号";
            // 
            // btn_comfirm
            // 
            this.btn_comfirm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_comfirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_comfirm.Location = new System.Drawing.Point(671, 201);
            this.btn_comfirm.Name = "btn_comfirm";
            this.btn_comfirm.Size = new System.Drawing.Size(111, 43);
            this.btn_comfirm.TabIndex = 2;
            this.btn_comfirm.Text = "确认";
            this.btn_comfirm.UseVisualStyleBackColor = true;
            this.btn_comfirm.Click += new System.EventHandler(this.btn_comfirm_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upload.Location = new System.Drawing.Point(671, 126);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(111, 43);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "上传图片";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Pic_Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_comfirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pic_Upload";
            this.Text = "csb_Pic_Upload";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.picupload_close);
            this.Load += new System.EventHandler(this.Pic_Upload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_picdate;
        private System.Windows.Forms.Label label_picauthor;
        private System.Windows.Forms.Label label_pictype;
        private System.Windows.Forms.Label label_picname;
        private System.Windows.Forms.Label label_picid;
        private System.Windows.Forms.Button btn_comfirm;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}