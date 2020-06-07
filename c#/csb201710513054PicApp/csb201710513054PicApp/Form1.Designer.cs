namespace csb201710513054PicApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pimgDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pfromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.picShareDBDataSet = new csb201710513054PicApp.PicShareDBDataSet();
            this.pnl_display = new System.Windows.Forms.Panel();
            this.btn_pic_upload = new System.Windows.Forms.Button();
            this.photoTableAdapter = new csb201710513054PicApp.PicShareDBDataSetTableAdapters.PhotoTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_descend = new System.Windows.Forms.Button();
            this.btn_ascend = new System.Windows.Forms.Button();
            this.btn_origin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareDBDataSet)).BeginInit();
            this.pnl_display.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户账号：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pidDataGridViewTextBoxColumn,
            this.pimgDataGridViewImageColumn,
            this.pnameDataGridViewTextBoxColumn,
            this.ptypeDataGridViewTextBoxColumn,
            this.pfromDataGridViewTextBoxColumn,
            this.pdateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.photoBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(63, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(836, 304);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pidDataGridViewTextBoxColumn
            // 
            this.pidDataGridViewTextBoxColumn.DataPropertyName = "Pid";
            this.pidDataGridViewTextBoxColumn.HeaderText = "Pid";
            this.pidDataGridViewTextBoxColumn.Name = "pidDataGridViewTextBoxColumn";
            // 
            // pimgDataGridViewImageColumn
            // 
            this.pimgDataGridViewImageColumn.DataPropertyName = "Pimg";
            this.pimgDataGridViewImageColumn.HeaderText = "Pimg";
            this.pimgDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.pimgDataGridViewImageColumn.Name = "pimgDataGridViewImageColumn";
            // 
            // pnameDataGridViewTextBoxColumn
            // 
            this.pnameDataGridViewTextBoxColumn.DataPropertyName = "Pname";
            this.pnameDataGridViewTextBoxColumn.HeaderText = "Pname";
            this.pnameDataGridViewTextBoxColumn.Name = "pnameDataGridViewTextBoxColumn";
            // 
            // ptypeDataGridViewTextBoxColumn
            // 
            this.ptypeDataGridViewTextBoxColumn.DataPropertyName = "Ptype";
            this.ptypeDataGridViewTextBoxColumn.HeaderText = "Ptype";
            this.ptypeDataGridViewTextBoxColumn.Name = "ptypeDataGridViewTextBoxColumn";
            // 
            // pfromDataGridViewTextBoxColumn
            // 
            this.pfromDataGridViewTextBoxColumn.DataPropertyName = "Pfrom";
            this.pfromDataGridViewTextBoxColumn.HeaderText = "Pfrom";
            this.pfromDataGridViewTextBoxColumn.Name = "pfromDataGridViewTextBoxColumn";
            // 
            // pdateDataGridViewTextBoxColumn
            // 
            this.pdateDataGridViewTextBoxColumn.DataPropertyName = "Pdate";
            this.pdateDataGridViewTextBoxColumn.HeaderText = "Pdate";
            this.pdateDataGridViewTextBoxColumn.Name = "pdateDataGridViewTextBoxColumn";
            // 
            // photoBindingSource1
            // 
            this.photoBindingSource1.DataMember = "Photo";
            this.photoBindingSource1.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.picShareDBDataSet;
            this.bindingSource1.Position = 0;
            // 
            // picShareDBDataSet
            // 
            this.picShareDBDataSet.DataSetName = "PicShareDBDataSet";
            this.picShareDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnl_display
            // 
            this.pnl_display.Controls.Add(this.dataGridView1);
            this.pnl_display.Location = new System.Drawing.Point(12, 77);
            this.pnl_display.Name = "pnl_display";
            this.pnl_display.Size = new System.Drawing.Size(953, 344);
            this.pnl_display.TabIndex = 3;
            // 
            // btn_pic_upload
            // 
            this.btn_pic_upload.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pic_upload.Location = new System.Drawing.Point(246, 12);
            this.btn_pic_upload.Name = "btn_pic_upload";
            this.btn_pic_upload.Size = new System.Drawing.Size(109, 44);
            this.btn_pic_upload.TabIndex = 0;
            this.btn_pic_upload.Text = "上传图片";
            this.btn_pic_upload.UseVisualStyleBackColor = true;
            this.btn_pic_upload.Click += new System.EventHandler(this.btn_pic_upload_Click);
            // 
            // photoTableAdapter
            // 
            this.photoTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(127, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 30);
            this.textBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_origin);
            this.groupBox1.Controls.Add(this.btn_descend);
            this.groupBox1.Controls.Add(this.btn_ascend);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(395, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 69);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片排序";
            // 
            // btn_descend
            // 
            this.btn_descend.Location = new System.Drawing.Point(121, 22);
            this.btn_descend.Name = "btn_descend";
            this.btn_descend.Size = new System.Drawing.Size(68, 40);
            this.btn_descend.TabIndex = 0;
            this.btn_descend.Text = "降序";
            this.btn_descend.UseVisualStyleBackColor = true;
            this.btn_descend.Click += new System.EventHandler(this.btn_descend_Click);
            // 
            // btn_ascend
            // 
            this.btn_ascend.Location = new System.Drawing.Point(18, 23);
            this.btn_ascend.Name = "btn_ascend";
            this.btn_ascend.Size = new System.Drawing.Size(70, 40);
            this.btn_ascend.TabIndex = 0;
            this.btn_ascend.Text = "升序";
            this.btn_ascend.UseVisualStyleBackColor = true;
            this.btn_ascend.Click += new System.EventHandler(this.btn_ascend_Click);
            // 
            // btn_origin
            // 
            this.btn_origin.Location = new System.Drawing.Point(222, 22);
            this.btn_origin.Name = "btn_origin";
            this.btn_origin.Size = new System.Drawing.Size(68, 40);
            this.btn_origin.TabIndex = 1;
            this.btn_origin.Text = "还原";
            this.btn_origin.UseVisualStyleBackColor = true;
            this.btn_origin.Click += new System.EventHandler(this.btn_origin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 433);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_pic_upload);
            this.Controls.Add(this.pnl_display);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "csb图片共享系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareDBDataSet)).EndInit();
            this.pnl_display.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnl_display;
        private System.Windows.Forms.Button btn_pic_upload;
        private PicShareDBDataSetTableAdapters.PhotoTableAdapter photoTableAdapter;
        private PicShareDBDataSet picShareDBDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource photoBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pimgDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pfromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_descend;
        private System.Windows.Forms.Button btn_ascend;
        private System.Windows.Forms.Button btn_origin;
    }
}

