namespace Stu.Zzr.FinalHomework
{
    partial class ShowWeather
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowWeather));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.todayTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fivedaysTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FivedaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.Close = new System.Windows.Forms.Button();
            this.citypic_imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.ContextMenuStrip = this.contextMenuStrip;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1091, 50);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseDown);
            this.menuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseMove);
            this.menuStrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.contextMenuStrip.Font = new System.Drawing.Font("汉仪铸字超然体W", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayTSMenuItem,
            this.fivedaysTSMenuItem,
            this.toolStripSeparator2,
            this.exitTSMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 76);
            // 
            // todayTSMenuItem
            // 
            this.todayTSMenuItem.Name = "todayTSMenuItem";
            this.todayTSMenuItem.Size = new System.Drawing.Size(136, 22);
            this.todayTSMenuItem.Text = "今天天气";
            this.todayTSMenuItem.Click += new System.EventHandler(this.todayTSMenuItem_Click);
            // 
            // fivedaysTSMenuItem
            // 
            this.fivedaysTSMenuItem.Name = "fivedaysTSMenuItem";
            this.fivedaysTSMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fivedaysTSMenuItem.Text = "五天天气";
            this.fivedaysTSMenuItem.Click += new System.EventHandler(this.fivedaysTSMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // exitTSMenuItem
            // 
            this.exitTSMenuItem.Name = "exitTSMenuItem";
            this.exitTSMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitTSMenuItem.Text = "退出";
            this.exitTSMenuItem.Click += new System.EventHandler(this.exitTSMenuItem_Click);
            // 
            // SetToolStripMenuItem
            // 
            this.SetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TodayToolStripMenuItem,
            this.FivedaysToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.SetToolStripMenuItem.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetToolStripMenuItem.Name = "SetToolStripMenuItem";
            this.SetToolStripMenuItem.Size = new System.Drawing.Size(60, 46);
            this.SetToolStripMenuItem.Text = "设置";
            // 
            // TodayToolStripMenuItem
            // 
            this.TodayToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.TodayToolStripMenuItem.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TodayToolStripMenuItem.Name = "TodayToolStripMenuItem";
            this.TodayToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.TodayToolStripMenuItem.Text = "今天天气";
            this.TodayToolStripMenuItem.Click += new System.EventHandler(this.TodayToolStripMenuItem_Click);
            // 
            // FivedaysToolStripMenuItem
            // 
            this.FivedaysToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FivedaysToolStripMenuItem.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FivedaysToolStripMenuItem.Name = "FivedaysToolStripMenuItem";
            this.FivedaysToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.FivedaysToolStripMenuItem.Text = "五天天气";
            this.FivedaysToolStripMenuItem.Click += new System.EventHandler(this.FivedaysToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ExitToolStripMenuItem.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.Close_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(60, 46);
            this.HelpToolStripMenuItem.Text = "帮助";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.ContextMenuStrip = this.contextMenuStrip;
            this.panel.Location = new System.Drawing.Point(63, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(950, 780);
            this.panel.TabIndex = 1;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseUp);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Close.BackgroundImage")));
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(1052, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(39, 32);
            this.Close.TabIndex = 5;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // citypic_imageList
            // 
            this.citypic_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("citypic_imageList.ImageStream")));
            this.citypic_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.citypic_imageList.Images.SetKeyName(0, "北京.jpg");
            this.citypic_imageList.Images.SetKeyName(1, "天津.jpg");
            this.citypic_imageList.Images.SetKeyName(2, "上海.jpg");
            this.citypic_imageList.Images.SetKeyName(3, "重庆.jpg");
            this.citypic_imageList.Images.SetKeyName(4, "哈尔滨.jpg");
            this.citypic_imageList.Images.SetKeyName(5, "南京.jpg");
            this.citypic_imageList.Images.SetKeyName(6, "杭州.jpg");
            this.citypic_imageList.Images.SetKeyName(7, "武汉.jpg");
            this.citypic_imageList.Images.SetKeyName(8, "长沙.jpg");
            this.citypic_imageList.Images.SetKeyName(9, "成都.jpg");
            this.citypic_imageList.Images.SetKeyName(10, "桂林.jpg");
            this.citypic_imageList.Images.SetKeyName(11, "昆明.jpg");
            this.citypic_imageList.Images.SetKeyName(12, "西安.jpg");
            this.citypic_imageList.Images.SetKeyName(13, "广州.jpg");
            this.citypic_imageList.Images.SetKeyName(14, "香港.jpg");
            this.citypic_imageList.Images.SetKeyName(15, "background.png");
            this.citypic_imageList.Images.SetKeyName(16, "hongkong.jpg");
            // 
            // ShowWeather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1091, 782);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.Close);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowWeather";
            this.Text = "ShowWeather";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowWeather_MouseUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem SetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TodayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FivedaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.ImageList citypic_imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem todayTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fivedaysTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitTSMenuItem;
    }
}