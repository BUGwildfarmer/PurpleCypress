namespace csb201710513054PicApp
{
    partial class Pic_Remark
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
            this.components = new System.ComponentModel.Container();
            this.btn_addremark = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.picShareDBDataSet = new csb201710513054PicApp.PicShareDBDataSet();
            this.remarkTableAdapter = new csb201710513054PicApp.PicShareDBDataSetTableAdapters.RemarkTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remarkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_addremark
            // 
            this.btn_addremark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addremark.Location = new System.Drawing.Point(242, 38);
            this.btn_addremark.Name = "btn_addremark";
            this.btn_addremark.Size = new System.Drawing.Size(133, 43);
            this.btn_addremark.TabIndex = 0;
            this.btn_addremark.Text = "添加评价";
            this.btn_addremark.UseVisualStyleBackColor = true;
            this.btn_addremark.Click += new System.EventHandler(this.btn_addremark_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pidDataGridViewTextBoxColumn,
            this.uidDataGridViewTextBoxColumn,
            this.rnumDataGridViewTextBoxColumn,
            this.rtextDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.remarkBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(606, 331);
            this.dataGridView1.TabIndex = 1;
            // 
            // pidDataGridViewTextBoxColumn
            // 
            this.pidDataGridViewTextBoxColumn.DataPropertyName = "Pid";
            this.pidDataGridViewTextBoxColumn.HeaderText = "Pid";
            this.pidDataGridViewTextBoxColumn.Name = "pidDataGridViewTextBoxColumn";
            // 
            // uidDataGridViewTextBoxColumn
            // 
            this.uidDataGridViewTextBoxColumn.DataPropertyName = "Uid";
            this.uidDataGridViewTextBoxColumn.HeaderText = "Uid";
            this.uidDataGridViewTextBoxColumn.Name = "uidDataGridViewTextBoxColumn";
            // 
            // rnumDataGridViewTextBoxColumn
            // 
            this.rnumDataGridViewTextBoxColumn.DataPropertyName = "Rnum";
            this.rnumDataGridViewTextBoxColumn.HeaderText = "Rnum";
            this.rnumDataGridViewTextBoxColumn.Name = "rnumDataGridViewTextBoxColumn";
            // 
            // rtextDataGridViewTextBoxColumn
            // 
            this.rtextDataGridViewTextBoxColumn.DataPropertyName = "Rtext";
            this.rtextDataGridViewTextBoxColumn.HeaderText = "Rtext";
            this.rtextDataGridViewTextBoxColumn.Name = "rtextDataGridViewTextBoxColumn";
            // 
            // remarkBindingSource
            // 
            this.remarkBindingSource.DataMember = "Remark";
            this.remarkBindingSource.DataSource = this.picShareDBDataSet;
            // 
            // picShareDBDataSet
            // 
            this.picShareDBDataSet.DataSetName = "PicShareDBDataSet";
            this.picShareDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // remarkTableAdapter
            // 
            this.remarkTableAdapter.ClearBeforeFill = true;
            // 
            // Pic_Remark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 458);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_addremark);
            this.Name = "Pic_Remark";
            this.Text = "Pic_Remark";
            this.Load += new System.EventHandler(this.Pic_Remark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remarkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShareDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addremark;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PicShareDBDataSet picShareDBDataSet;
        private System.Windows.Forms.BindingSource remarkBindingSource;
        private PicShareDBDataSetTableAdapters.RemarkTableAdapter remarkTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rtextDataGridViewTextBoxColumn;
    }
}