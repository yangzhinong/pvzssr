namespace Shadowsocks.View
{
    partial class FreeSSRForm
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
            this.btnRefreshPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.chkDeleteOld = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnRefreshPage
            // 
            this.btnRefreshPage.Location = new System.Drawing.Point(317, 38);
            this.btnRefreshPage.Name = "btnRefreshPage";
            this.btnRefreshPage.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshPage.TabIndex = 15;
            this.btnRefreshPage.Text = "Refresh Page";
            this.btnRefreshPage.UseVisualStyleBackColor = true;
            this.btnRefreshPage.Click += new System.EventHandler(this.btnRefreshPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "使用说明: 请等待页面加载完后, 复制表格中的一个IP到文本框中, 再按\"开始执行\"按钮";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(236, 38);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 13;
            this.btnExecute.Text = "开始执行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 21);
            this.textBox1.TabIndex = 12;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 68);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(691, 312);
            this.webBrowser1.TabIndex = 11;
            this.webBrowser1.Url = new System.Uri("https://free-ss.site/", System.UriKind.Absolute);
            // 
            // chkDeleteOld
            // 
            this.chkDeleteOld.AutoSize = true;
            this.chkDeleteOld.Location = new System.Drawing.Point(420, 42);
            this.chkDeleteOld.Name = "chkDeleteOld";
            this.chkDeleteOld.Size = new System.Drawing.Size(132, 16);
            this.chkDeleteOld.TabIndex = 16;
            this.chkDeleteOld.Text = "删除原有的配置文件";
            this.chkDeleteOld.UseVisualStyleBackColor = true;
            
            // 
            // FreeSSR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 392);
            this.Controls.Add(this.chkDeleteOld);
            this.Controls.Add(this.btnRefreshPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "FreeSSR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FreeSSR";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.CheckBox chkDeleteOld;
    }
}