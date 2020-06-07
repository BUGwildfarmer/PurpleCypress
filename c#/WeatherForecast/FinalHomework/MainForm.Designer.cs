namespace Stu.Zzr.FinalHomework
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Close = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.MiniSize = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Weatherlabel = new System.Windows.Forms.Label();
            this.city_comboBox = new System.Windows.Forms.ComboBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cMS_noti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMS_normal = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_noti.SuspendLayout();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Close.BackgroundImage")));
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(591, 12);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(39, 32);
            this.Close.TabIndex = 0;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.Transparent;
            this.Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Search.BackgroundImage")));
            this.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search.FlatAppearance.BorderSize = 0;
            this.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Search.Location = new System.Drawing.Point(447, 207);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(72, 58);
            this.Search.TabIndex = 1;
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // MiniSize
            // 
            this.MiniSize.BackColor = System.Drawing.Color.Transparent;
            this.MiniSize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MiniSize.BackgroundImage")));
            this.MiniSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MiniSize.FlatAppearance.BorderSize = 0;
            this.MiniSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiniSize.Location = new System.Drawing.Point(546, 12);
            this.MiniSize.Name = "MiniSize";
            this.MiniSize.Size = new System.Drawing.Size(39, 32);
            this.MiniSize.TabIndex = 3;
            this.MiniSize.UseVisualStyleBackColor = false;
            this.MiniSize.Click += new System.EventHandler(this.MiniSize_Click);
            // 
            // Help
            // 
            this.Help.BackColor = System.Drawing.Color.Transparent;
            this.Help.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Help.BackgroundImage")));
            this.Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Help.FlatAppearance.BorderSize = 0;
            this.Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help.Location = new System.Drawing.Point(501, 12);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(39, 32);
            this.Help.TabIndex = 4;
            this.Help.UseVisualStyleBackColor = false;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Weatherlabel
            // 
            this.Weatherlabel.AutoSize = true;
            this.Weatherlabel.BackColor = System.Drawing.Color.Transparent;
            this.Weatherlabel.Font = new System.Drawing.Font("汉仪铸字超然体W", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Weatherlabel.Location = new System.Drawing.Point(3, 17);
            this.Weatherlabel.Name = "Weatherlabel";
            this.Weatherlabel.Size = new System.Drawing.Size(204, 27);
            this.Weatherlabel.TabIndex = 5;
            this.Weatherlabel.Text = "天气预报查询系统";
            // 
            // city_comboBox
            // 
            this.city_comboBox.DropDownHeight = 200;
            this.city_comboBox.DropDownWidth = 200;
            this.city_comboBox.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.city_comboBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.city_comboBox.FormattingEnabled = true;
            this.city_comboBox.IntegralHeight = false;
            this.city_comboBox.Items.AddRange(new object[] {
            "北京",
            "上海",
            "广州",
            "香港",
            "重庆",
            "澳门",
            "石家庄",
            "太原",
            "沈阳",
            "长春",
            "哈尔滨",
            "南京",
            "杭州",
            "合肥",
            "福州",
            "台北",
            "南昌",
            "济南",
            "郑州",
            "武汉",
            "长沙",
            "海口",
            "天津",
            "南宁",
            "西安",
            "昆明",
            "贵阳",
            "成都",
            "西安",
            "兰州",
            "西宁",
            "呼和浩特",
            "拉萨",
            "银川",
            "乌鲁木齐"});
            this.city_comboBox.Location = new System.Drawing.Point(94, 216);
            this.city_comboBox.Name = "city_comboBox";
            this.city_comboBox.Size = new System.Drawing.Size(315, 35);
            this.city_comboBox.TabIndex = 6;
            this.city_comboBox.Enter += new System.EventHandler(this.city_comboBox_Enter);
            this.city_comboBox.Leave += new System.EventHandler(this.city_comboBox_Leave);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "WeatherForecast";
            this.notifyIcon.ContextMenuStrip = this.cMS_noti;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // cMS_noti
            // 
            this.cMS_noti.BackColor = System.Drawing.Color.Transparent;
            this.cMS_noti.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMS_noti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMS_normal,
            this.cMS_exit});
            this.cMS_noti.Name = "cMS_noti";
            this.cMS_noti.Size = new System.Drawing.Size(176, 80);
            // 
            // cMS_normal
            // 
            this.cMS_normal.Name = "cMS_normal";
            this.cMS_normal.Size = new System.Drawing.Size(175, 24);
            this.cMS_normal.Text = "还原";
            this.cMS_normal.Click += new System.EventHandler(this.cMS_normal_Click);
            // 
            // cMS_exit
            // 
            this.cMS_exit.Name = "cMS_exit";
            this.cMS_exit.Size = new System.Drawing.Size(175, 24);
            this.cMS_exit.Text = "退出";
            this.cMS_exit.Click += new System.EventHandler(this.cMS_exit_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(642, 488);
            this.Controls.Add(this.city_comboBox);
            this.Controls.Add(this.Weatherlabel);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.MiniSize);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Close);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.cMS_noti.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button MiniSize;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Label Weatherlabel;
        private System.Windows.Forms.ComboBox city_comboBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cMS_noti;
        private System.Windows.Forms.ToolStripMenuItem cMS_normal;
        private System.Windows.Forms.ToolStripMenuItem cMS_exit;
    }
}

