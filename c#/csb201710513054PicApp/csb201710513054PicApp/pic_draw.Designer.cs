namespace csb201710513054PicApp
{
    partial class pic_draw
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
            this.pb_draw = new System.Windows.Forms.PictureBox();
            this.btn_savenew = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_draw
            // 
            this.pb_draw.Location = new System.Drawing.Point(172, 0);
            this.pb_draw.Name = "pb_draw";
            this.pb_draw.Size = new System.Drawing.Size(432, 354);
            this.pb_draw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_draw.TabIndex = 0;
            this.pb_draw.TabStop = false;
            this.pb_draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_draw_MouseDown);
            this.pb_draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_draw_MouseMove);
            this.pb_draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_draw_MouseUp);
            // 
            // btn_savenew
            // 
            this.btn_savenew.Location = new System.Drawing.Point(12, 395);
            this.btn_savenew.Name = "btn_savenew";
            this.btn_savenew.Size = new System.Drawing.Size(137, 43);
            this.btn_savenew.TabIndex = 1;
            this.btn_savenew.Text = "完成并保存";
            this.btn_savenew.UseVisualStyleBackColor = true;
            this.btn_savenew.Click += new System.EventHandler(this.btn_savenew_Click);
            // 
            // pic_draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_savenew);
            this.Controls.Add(this.pb_draw);
            this.Name = "pic_draw";
            this.Text = "pic_draw";
            this.Load += new System.EventHandler(this.pic_draw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_draw;
        private System.Windows.Forms.Button btn_savenew;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}