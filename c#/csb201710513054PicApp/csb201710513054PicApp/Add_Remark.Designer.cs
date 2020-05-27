namespace csb201710513054PicApp
{
    partial class Add_Remark
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
            this.lb_score = new System.Windows.Forms.Label();
            this.lb_remark = new System.Windows.Forms.Label();
            this.lb_uid = new System.Windows.Forms.Label();
            this.tb_uid = new System.Windows.Forms.TextBox();
            this.tb_score = new System.Windows.Forms.TextBox();
            this.rtb_remark = new System.Windows.Forms.RichTextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_score
            // 
            this.lb_score.AutoSize = true;
            this.lb_score.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_score.Location = new System.Drawing.Point(31, 84);
            this.lb_score.Name = "lb_score";
            this.lb_score.Size = new System.Drawing.Size(69, 20);
            this.lb_score.TabIndex = 0;
            this.lb_score.Text = "评分：";
            // 
            // lb_remark
            // 
            this.lb_remark.AutoSize = true;
            this.lb_remark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_remark.Location = new System.Drawing.Point(31, 137);
            this.lb_remark.Name = "lb_remark";
            this.lb_remark.Size = new System.Drawing.Size(69, 20);
            this.lb_remark.TabIndex = 1;
            this.lb_remark.Text = "评价：";
            // 
            // lb_uid
            // 
            this.lb_uid.AutoSize = true;
            this.lb_uid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_uid.Location = new System.Drawing.Point(31, 35);
            this.lb_uid.Name = "lb_uid";
            this.lb_uid.Size = new System.Drawing.Size(109, 20);
            this.lb_uid.TabIndex = 2;
            this.lb_uid.Text = "用户账号：";
            // 
            // tb_uid
            // 
            this.tb_uid.Enabled = false;
            this.tb_uid.Location = new System.Drawing.Point(164, 30);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Size = new System.Drawing.Size(100, 25);
            this.tb_uid.TabIndex = 3;
            // 
            // tb_score
            // 
            this.tb_score.Location = new System.Drawing.Point(164, 79);
            this.tb_score.Name = "tb_score";
            this.tb_score.Size = new System.Drawing.Size(100, 25);
            this.tb_score.TabIndex = 4;
            // 
            // rtb_remark
            // 
            this.rtb_remark.Location = new System.Drawing.Point(25, 173);
            this.rtb_remark.Name = "rtb_remark";
            this.rtb_remark.Size = new System.Drawing.Size(301, 233);
            this.rtb_remark.TabIndex = 5;
            this.rtb_remark.Text = "";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_submit.Location = new System.Drawing.Point(117, 437);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(107, 45);
            this.btn_submit.TabIndex = 6;
            this.btn_submit.Text = "确认";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // Add_Remark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 494);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.rtb_remark);
            this.Controls.Add(this.tb_score);
            this.Controls.Add(this.tb_uid);
            this.Controls.Add(this.lb_uid);
            this.Controls.Add(this.lb_remark);
            this.Controls.Add(this.lb_score);
            this.Name = "Add_Remark";
            this.Text = "csb添加评价";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addremark_close);
            this.Load += new System.EventHandler(this.Add_Remark_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_score;
        private System.Windows.Forms.Label lb_remark;
        private System.Windows.Forms.Label lb_uid;
        private System.Windows.Forms.TextBox tb_uid;
        private System.Windows.Forms.TextBox tb_score;
        private System.Windows.Forms.RichTextBox rtb_remark;
        private System.Windows.Forms.Button btn_submit;
    }
}