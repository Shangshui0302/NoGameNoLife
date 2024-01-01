namespace NoGameNoLife
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GameStart = new System.Windows.Forms.Button();
            this.GameStop = new System.Windows.Forms.Button();
            this.CLR = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.random = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.EditStart = new System.Windows.Forms.Button();
            this.EditEnd = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.probability = new System.Windows.Forms.ComboBox();
            this.text_probability = new System.Windows.Forms.Label();
            this.text_size = new System.Windows.Forms.Label();
            this.cellsize = new System.Windows.Forms.ComboBox();
            this.Rules = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TrackBar();
            this.text_speed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // GameStart
            // 
            this.GameStart.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.GameStart.Location = new System.Drawing.Point(622, 33);
            this.GameStart.Name = "GameStart";
            this.GameStart.Size = new System.Drawing.Size(75, 23);
            this.GameStart.TabIndex = 0;
            this.GameStart.Text = "推演";
            this.GameStart.UseVisualStyleBackColor = true;
            this.GameStart.Click += new System.EventHandler(this.GameStart_Click);
            // 
            // GameStop
            // 
            this.GameStop.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.GameStop.Location = new System.Drawing.Point(703, 33);
            this.GameStop.Name = "GameStop";
            this.GameStop.Size = new System.Drawing.Size(75, 23);
            this.GameStop.TabIndex = 1;
            this.GameStop.Text = "停止";
            this.GameStop.UseVisualStyleBackColor = true;
            this.GameStop.Click += new System.EventHandler(this.GameStop_Click);
            // 
            // CLR
            // 
            this.CLR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CLR.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.CLR.Location = new System.Drawing.Point(622, 62);
            this.CLR.Name = "CLR";
            this.CLR.Size = new System.Drawing.Size(75, 23);
            this.CLR.TabIndex = 2;
            this.CLR.Text = "初始化";
            this.CLR.UseVisualStyleBackColor = true;
            this.CLR.Click += new System.EventHandler(this.CLR_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(34, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(558, 377);
            this.panel.TabIndex = 3;
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // random
            // 
            this.random.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.random.Location = new System.Drawing.Point(703, 62);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(75, 23);
            this.random.TabIndex = 4;
            this.random.Text = "随机生成";
            this.random.UseVisualStyleBackColor = true;
            this.random.Click += new System.EventHandler(this.random_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // EditStart
            // 
            this.EditStart.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EditStart.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.EditStart.Location = new System.Drawing.Point(622, 143);
            this.EditStart.Name = "EditStart";
            this.EditStart.Size = new System.Drawing.Size(75, 23);
            this.EditStart.TabIndex = 5;
            this.EditStart.Text = "开始编辑";
            this.EditStart.UseVisualStyleBackColor = true;
            this.EditStart.Click += new System.EventHandler(this.EditStart_Click);
            // 
            // EditEnd
            // 
            this.EditEnd.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.EditEnd.Location = new System.Drawing.Point(703, 143);
            this.EditEnd.Name = "EditEnd";
            this.EditEnd.Size = new System.Drawing.Size(75, 23);
            this.EditEnd.TabIndex = 6;
            this.EditEnd.Text = "结束编辑";
            this.EditEnd.UseVisualStyleBackColor = true;
            this.EditEnd.Click += new System.EventHandler(this.EditEnd_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.label.Location = new System.Drawing.Point(32, 414);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(73, 18);
            this.label.TabIndex = 7;
            this.label.Text = "存活细胞数";
            // 
            // probability
            // 
            this.probability.FormattingEnabled = true;
            this.probability.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.probability.Location = new System.Drawing.Point(703, 91);
            this.probability.Name = "probability";
            this.probability.Size = new System.Drawing.Size(75, 20);
            this.probability.TabIndex = 8;
            this.probability.SelectedIndexChanged += new System.EventHandler(this.probability_SelectedIndexChanged);
            // 
            // text_probability
            // 
            this.text_probability.AutoSize = true;
            this.text_probability.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_probability.Location = new System.Drawing.Point(628, 91);
            this.text_probability.Name = "text_probability";
            this.text_probability.Size = new System.Drawing.Size(60, 18);
            this.text_probability.TabIndex = 9;
            this.text_probability.Text = "生成概率";
            // 
            // text_size
            // 
            this.text_size.AutoSize = true;
            this.text_size.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_size.Location = new System.Drawing.Point(628, 117);
            this.text_size.Name = "text_size";
            this.text_size.Size = new System.Drawing.Size(60, 18);
            this.text_size.TabIndex = 11;
            this.text_size.Text = "细胞尺寸";
            // 
            // cellsize
            // 
            this.cellsize.FormattingEnabled = true;
            this.cellsize.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cellsize.Location = new System.Drawing.Point(703, 117);
            this.cellsize.Name = "cellsize";
            this.cellsize.Size = new System.Drawing.Size(75, 20);
            this.cellsize.TabIndex = 10;
            this.cellsize.SelectedIndexChanged += new System.EventHandler(this.cellsize_SelectedIndexChanged);
            // 
            // Rules
            // 
            this.Rules.Font = new System.Drawing.Font("HarmonyOS Sans SC", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rules.Location = new System.Drawing.Point(610, 169);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(178, 257);
            this.Rules.TabIndex = 12;
            this.Rules.Text = resources.GetString("Rules.Text");
            // 
            // speed
            // 
            this.speed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.speed.Location = new System.Drawing.Point(358, 414);
            this.speed.Maximum = 1000;
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(234, 45);
            this.speed.SmallChange = 10;
            this.speed.TabIndex = 13;
            this.speed.Value = 500;
            this.speed.Scroll += new System.EventHandler(this.speed_Scroll);
            // 
            // text_speed
            // 
            this.text_speed.AutoSize = true;
            this.text_speed.Font = new System.Drawing.Font("HarmonyOS Sans SC", 9.75F, System.Drawing.FontStyle.Bold);
            this.text_speed.Location = new System.Drawing.Point(292, 423);
            this.text_speed.Name = "text_speed";
            this.text_speed.Size = new System.Drawing.Size(60, 18);
            this.text_speed.TabIndex = 14;
            this.text_speed.Text = "推演速度";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text_speed);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.Rules);
            this.Controls.Add(this.text_size);
            this.Controls.Add(this.cellsize);
            this.Controls.Add(this.text_probability);
            this.Controls.Add(this.probability);
            this.Controls.Add(this.label);
            this.Controls.Add(this.EditEnd);
            this.Controls.Add(this.EditStart);
            this.Controls.Add(this.random);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.CLR);
            this.Controls.Add(this.GameStop);
            this.Controls.Add(this.GameStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "NoGameNoLife【康威生命游戏】";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GameStart;
        private System.Windows.Forms.Button GameStop;
        private System.Windows.Forms.Button CLR;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button EditStart;
        private System.Windows.Forms.Button EditEnd;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox probability;
        private System.Windows.Forms.Label text_probability;
        private System.Windows.Forms.Label text_size;
        private System.Windows.Forms.ComboBox cellsize;
        private System.Windows.Forms.Label Rules;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Label text_speed;
    }
}

