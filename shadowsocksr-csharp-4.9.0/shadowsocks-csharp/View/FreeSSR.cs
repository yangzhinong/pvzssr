using Newtonsoft.Json;
using Shadowsocks.Controller;
using Shadowsocks.FreeSSR;
using Shadowsocks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Shadowsocks.View
{
    public partial class FreeSSRForm : Form
    {
        private const string SSR_EXE_PATH = @"E:\shadowsocksr-csharp-4.9.0\shadowsocks-csharp\bin\4.0\Debug";
        private ShadowsocksController controller;
        public FreeSSRForm(ShadowsocksController controller)
        {
           
            InitializeComponent();
            this.controller = controller;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://free-ss.site/");
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("请先在文本中输入一个IP!");
                return;
            }
            var s = webBrowser1.Document.Body.InnerHtml; ;
            var reg = new System.Text.RegularExpressions.Regex("<tbody>(.*)<\\/tbody>");
            foreach (Match m in reg.Matches(s))
            {
                var xx = m.ToString();
                if (xx.Contains(textBox1.Text))
                {
                    Console.WriteLine(m);
                    var sbOut = new System.Text.StringBuilder();
                    sbOut.AppendLine(@"<html>");
                    sbOut.AppendLine("<table>" + m.ToString() + "</table>");
                    sbOut.AppendLine("</html");
                    var sFileTemplate = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "1.html");
                    var sOut = System.IO.File.ReadAllText(sFileTemplate);
                    sOut = sOut.Replace("${SSTABLE}", "<table>" + m.ToString() + "</table>");
                    var sFileOut = getFilePath("2.html");
                    System.IO.File.WriteAllText(sFileOut, sOut);
                    ToSSRJson();

                    var _config= Configuration.Load();
                    Configuration.Save(_config);
                    controller.GetConfiguration();
                    



                }
            }
            Console.WriteLine(s);
        }
        private string getFilePath(string file)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
        }
        private void ToSSRJson()
        {
            var sFile = getFilePath("2.html");
            CsQuery.CQ dom = System.IO.File.ReadAllText(sFile);
            var oSSR = new SSR();
            oSSR.configs = new List<FreeSSR.Server>();
            foreach (var row in dom["tr"])
            {
                CsQuery.CQ rowDom = row.InnerHTML;
                var tds = rowDom["td"].ToList();
                var config = new FreeSSR.Server();
                if (tds.Count > 0)
                {
                    var vtm = tds[0].InnerText;
                    if (int.Parse(vtm.Split('/')[1]) > 8) //T是电信线路,值越大越好
                    {
                        config.server = tds[1].InnerText;
                        config.server_port = int.Parse(tds[2].InnerText);
                        var p1 = tds[3].InnerText;
                        var p2 = tds[4].InnerText;
                        if (p1 == "rc4-md5" || p1 == "chacha20" || p1.StartsWith("aes-"))
                        {
                            config.method = p1;
                            config.password = p2;
                        }
                        else
                        {
                            config.method = p2;
                            config.password = p1;
                        }
                        config.id = Guid.NewGuid().ToString("N");
                    }
                }
                if (!string.IsNullOrWhiteSpace(config.server))
                    oSSR.configs.Add(config);
            }
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(oSSR);
            System.IO.File.WriteAllText(getFilePath("ssr.json"), json);
            var sOutFile = $"{SSR_EXE_PATH}\\ssr.json";
            if (System.IO.File.Exists(sOutFile))
            {
                System.IO.File.Delete(sOutFile);
            }
            System.IO.File.Copy(getFilePath("ssr.json"), sOutFile);
            write_gui_config(sOutFile);
        }
        private void btnRefreshPage_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        /// <summary>
        /// 写到gui-config.json文件中
        /// </summary>
        private void write_gui_config(string srcFile)
        {
            var json = File.ReadAllText(srcFile);
            var sGuiFile = $"{SSR_EXE_PATH}\\gui-config.json";
            var srcConfig = JsonConvert.DeserializeObject<SSR>(json);
            var guiCofnig = JsonConvert.DeserializeObject<SSR>(File.ReadAllText(sGuiFile));
            if (chkDeleteOld.Checked)
                guiCofnig.configs.RemoveAll(x => x.group == "FreeSSR-public");
            guiCofnig.configs.RemoveAll(x =>
                                       srcConfig.configs.Select(y => y.server)
                                       .Contains(x.server));
            guiCofnig.configs.AddRange(srcConfig.configs);
            File.WriteAllText(sGuiFile, JsonConvert.SerializeObject(guiCofnig));
        }
    }
}
