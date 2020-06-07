namespace Stu.Zzr.FinalHomework.controls
{
    partial class ShowInfo
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowInfo));
            this.day_label = new System.Windows.Forms.Label();
            this.week_label = new System.Windows.Forms.Label();
            this.weat_label = new System.Windows.Forms.Label();
            this.deg_label = new System.Windows.Forms.Label();
            this.wind_label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.weather_imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // day_label
            // 
            this.day_label.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.day_label.Location = new System.Drawing.Point(3, 60);
            this.day_label.Name = "day_label";
            this.day_label.Size = new System.Drawing.Size(106, 24);
            this.day_label.TabIndex = 0;
            this.day_label.Text = "日期";
            // 
            // week_label
            // 
            this.week_label.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.week_label.Location = new System.Drawing.Point(3, 95);
            this.week_label.Name = "week_label";
            this.week_label.Size = new System.Drawing.Size(106, 24);
            this.week_label.TabIndex = 1;
            this.week_label.Text = "星期";
            // 
            // weat_label
            // 
            this.weat_label.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.weat_label.Location = new System.Drawing.Point(3, 132);
            this.weat_label.Name = "weat_label";
            this.weat_label.Size = new System.Drawing.Size(106, 24);
            this.weat_label.TabIndex = 3;
            this.weat_label.Text = "天气";
            // 
            // deg_label
            // 
            this.deg_label.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deg_label.Location = new System.Drawing.Point(3, 169);
            this.deg_label.Name = "deg_label";
            this.deg_label.Size = new System.Drawing.Size(106, 24);
            this.deg_label.TabIndex = 4;
            this.deg_label.Text = "温度";
            // 
            // wind_label
            // 
            this.wind_label.Font = new System.Drawing.Font("汉仪铸字超然体W", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wind_label.Location = new System.Drawing.Point(3, 206);
            this.wind_label.Name = "wind_label";
            this.wind_label.Size = new System.Drawing.Size(106, 24);
            this.wind_label.TabIndex = 5;
            this.wind_label.Text = "风";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(7, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(72, 54);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // weather_imageList
            // 
            this.weather_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("weather_imageList.ImageStream")));
            this.weather_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.weather_imageList.Images.SetKeyName(0, "暴雪.png");
            this.weather_imageList.Images.SetKeyName(1, "暴雨.png");
            this.weather_imageList.Images.SetKeyName(2, "暴雨-大暴雨.png");
            this.weather_imageList.Images.SetKeyName(3, "冰雹.png");
            this.weather_imageList.Images.SetKeyName(4, "大暴雨.png");
            this.weather_imageList.Images.SetKeyName(5, "大暴雨-特大暴雨.png");
            this.weather_imageList.Images.SetKeyName(6, "大风.png");
            this.weather_imageList.Images.SetKeyName(7, "大雪.png");
            this.weather_imageList.Images.SetKeyName(8, "大雪-暴雪.png");
            this.weather_imageList.Images.SetKeyName(9, "大雨.png");
            this.weather_imageList.Images.SetKeyName(10, "大雨-暴雨.png");
            this.weather_imageList.Images.SetKeyName(11, "冻雨.png");
            this.weather_imageList.Images.SetKeyName(12, "多云.png");
            this.weather_imageList.Images.SetKeyName(13, "多云转晴.png");
            this.weather_imageList.Images.SetKeyName(14, "浮尘.png");
            this.weather_imageList.Images.SetKeyName(15, "雷阵雨.png");
            this.weather_imageList.Images.SetKeyName(16, "雷阵雨并伴有冰雹.png");
            this.weather_imageList.Images.SetKeyName(17, "霾.png");
            this.weather_imageList.Images.SetKeyName(18, "强沙尘暴.png");
            this.weather_imageList.Images.SetKeyName(19, "晴.png");
            this.weather_imageList.Images.SetKeyName(20, "沙尘暴.png");
            this.weather_imageList.Images.SetKeyName(21, "特大暴雨.png");
            this.weather_imageList.Images.SetKeyName(22, "雾.png");
            this.weather_imageList.Images.SetKeyName(23, "小雪.png");
            this.weather_imageList.Images.SetKeyName(24, "小雪-中雪.png");
            this.weather_imageList.Images.SetKeyName(25, "小雨.png");
            this.weather_imageList.Images.SetKeyName(26, "小雨-中雨.png");
            this.weather_imageList.Images.SetKeyName(27, "扬尘.png");
            this.weather_imageList.Images.SetKeyName(28, "阴.png");
            this.weather_imageList.Images.SetKeyName(29, "雨夹雪.png");
            this.weather_imageList.Images.SetKeyName(30, "暂无.png");
            this.weather_imageList.Images.SetKeyName(31, "阵雪.png");
            this.weather_imageList.Images.SetKeyName(32, "阵雨.png");
            this.weather_imageList.Images.SetKeyName(33, "中雪.png");
            this.weather_imageList.Images.SetKeyName(34, "中雪-大雪.png");
            this.weather_imageList.Images.SetKeyName(35, "中雨.png");
            this.weather_imageList.Images.SetKeyName(36, "中雨-大雨.png");
            this.weather_imageList.Images.SetKeyName(37, "阴转多云.png");
            this.weather_imageList.Images.SetKeyName(38, "小雨转多云.png");
            this.weather_imageList.Images.SetKeyName(39, "多云转小雨.png");
            this.weather_imageList.Images.SetKeyName(40, "多云转阴.png");
            this.weather_imageList.Images.SetKeyName(41, "霾转多云.png");
            this.weather_imageList.Images.SetKeyName(42, "晴转多云.png");
            this.weather_imageList.Images.SetKeyName(43, "阴转小雨.png");
            // 
            // ShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.wind_label);
            this.Controls.Add(this.deg_label);
            this.Controls.Add(this.weat_label);
            this.Controls.Add(this.week_label);
            this.Controls.Add(this.day_label);
            this.Name = "ShowInfo";
            this.Size = new System.Drawing.Size(129, 243);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label day_label;
        private System.Windows.Forms.Label week_label;
        private System.Windows.Forms.Label weat_label;
        private System.Windows.Forms.Label deg_label;
        private System.Windows.Forms.Label wind_label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ImageList weather_imageList;
    }
}
