namespace freeSSR
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshPage = new System.Windows.Forms.Button();
            this.chkDeleteOld = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.btnManualImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutoItExePath1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAutoItExePath2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(9, 182);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(764, 122);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 21);
            this.textBox1.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(248, 32);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "开始执行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "使用说明: 请等待页面加载完后, 复制表格中的一个IP到文本框中, 再按\"开始执行\"按钮";
            // 
            // btnRefreshPage
            // 
            this.btnRefreshPage.Location = new System.Drawing.Point(502, 5);
            this.btnRefreshPage.Name = "btnRefreshPage";
            this.btnRefreshPage.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshPage.TabIndex = 10;
            this.btnRefreshPage.Text = "Refresh Page";
            this.btnRefreshPage.UseVisualStyleBackColor = true;
            this.btnRefreshPage.Click += new System.EventHandler(this.btnRefreshPage_Click);
            // 
            // chkDeleteOld
            // 
            this.chkDeleteOld.AutoSize = true;
            this.chkDeleteOld.Location = new System.Drawing.Point(432, 36);
            this.chkDeleteOld.Name = "chkDeleteOld";
            this.chkDeleteOld.Size = new System.Drawing.Size(132, 16);
            this.chkDeleteOld.TabIndex = 11;
            this.chkDeleteOld.Text = "删除原有的配置文件";
            this.chkDeleteOld.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(605, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "自动断开所有连接";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(559, 32);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "重启";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRebootSSR_Click);
            // 
            // btnManualImport
            // 
            this.btnManualImport.Location = new System.Drawing.Point(329, 32);
            this.btnManualImport.Name = "btnManualImport";
            this.btnManualImport.Size = new System.Drawing.Size(97, 23);
            this.btnManualImport.TabIndex = 15;
            this.btnManualImport.Text = "手动log导入";
            this.btnManualImport.UseVisualStyleBackColor = true;
            this.btnManualImport.Click += new System.EventHandler(this.btnManualImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "AutoItExePath1";
            // 
            // txtAutoItExePath1
            // 
            this.txtAutoItExePath1.Location = new System.Drawing.Point(101, 66);
            this.txtAutoItExePath1.Name = "txtAutoItExePath1";
            this.txtAutoItExePath1.Size = new System.Drawing.Size(325, 21);
            this.txtAutoItExePath1.TabIndex = 17;
            this.txtAutoItExePath1.Text = "D:\\pvz\\ssr\\FreeSSR.exe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "AutoItExePath2";
            // 
            // txtAutoItExePath2
            // 
            this.txtAutoItExePath2.Location = new System.Drawing.Point(101, 98);
            this.txtAutoItExePath2.Name = "txtAutoItExePath2";
            this.txtAutoItExePath2.Size = new System.Drawing.Size(325, 21);
            this.txtAutoItExePath2.TabIndex = 19;
            this.txtAutoItExePath2.Text = "D:\\pvz\\ssr\\FreeSSRFromIP.exe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "LogFile";
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Location = new System.Drawing.Point(101, 132);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(100, 21);
            this.txtLogFilePath.TabIndex = 21;
            this.txtLogFilePath.Text = "f:\\1.log";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 316);
            this.Controls.Add(this.txtLogFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAutoItExePath2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAutoItExePath1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnManualImport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkDeleteOld);
            this.Controls.Add(this.btnRefreshPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "free-ss.site 抓取工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshPage;
        private System.Windows.Forms.CheckBox chkDeleteOld;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnManualImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutoItExePath1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAutoItExePath2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.Timer timer2;
    }
}

