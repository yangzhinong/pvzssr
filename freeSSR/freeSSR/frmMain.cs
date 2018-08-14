using mshtml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace freeSSR
{
    public partial class frmMain : Form
    {
        private const string SSR_EXE_PATH = @"E:\shadowsocksr-csharp-4.9.0\shadowsocks-csharp\bin\4.0\Debug";

        private const string TEMP_PATH = @"E:\freeSSR\";
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //  webBrowser1.Navigate("https://free-ss.site/");
            try
            {
                var config = File.ReadAllText(@"e:\FreeSSR.sys.json");
                var oSysCfg = JsonConvert.DeserializeObject<freeSSR.frmMain.SysConfig>(config);
                txtAutoItExePath1.Text = oSysCfg.exe1;
                txtAutoItExePath2.Text = oSysCfg.exe2;
                txtLogFilePath.Text = oSysCfg.log;

                timer2.Enabled = false;
                timer2.Interval = 5 * 60 * 1000;
            } catch { }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            clsShell.ShellWaitExit(txtAutoItExePath1.Text);
            ToSSRJson();
        }
        private string getFilePath(string file)
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
        }
        private void ToSSRJson()
        {
            var oSSR = new SSR();
            oSSR.configs = new List<Server>();
            // ConfigFromHtml(oSSR);
            ConfigFromJsonTxt(oSSR);
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

        /// <summary>
        /// 配置从Html来
        /// </summary>
        /// <param name="oSSR"></param>
        private void ConfigFromHtml(SSR oSSR)
        {
            var sFile = getFilePath("2.html");
            CsQuery.CQ dom = System.IO.File.ReadAllText(sFile);

            foreach (var row in dom["tr"])
            {
                CsQuery.CQ rowDom = row.InnerHTML;
                var tds = rowDom["td"].ToList();
                var config = new Server();
                if (tds.Count > 0)
                {
                    var vtm = tds[0].InnerText;
                    try
                    {
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
                        if (!string.IsNullOrWhiteSpace(config.server))
                            oSSR.configs.Add(config);
                    }
                    catch { }
                }

            }
        }

        /// <summary>
        /// 配置从Html来
        /// </summary>
        /// <param name="oSSR"></param>
        private void ConfigFromJsonTxt(SSR oSSR)
        {
            var sFile = txtLogFilePath.Text;
            var txt = System.IO.File.ReadAllText(txtLogFilePath.Text);
            var data = JArray.Parse(txt);
            foreach (var item in data)
            {
                var config = new Server();
                var vtm = item[0].ToString();
                try
                {
                    if (int.Parse(vtm.Split('/')[1]) > 8) //T是电信线路,值越大越好
                    {
                        config.server = item[1].ToString();
                        config.server_port = int.Parse(item[2].ToString());
                        var p1 = item[3].ToString();
                        var p2 = item[4].ToString();
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
                    if (!string.IsNullOrWhiteSpace(config.server))
                        oSSR.configs.Add(config);
                }
                catch { }
                Console.WriteLine(item);

            }
        }

        private void btnRefreshPage_Click(object sender, EventArgs e)
        {
            //webBrowser1.Refresh();
        }
        /// <summary>
        /// 写到gui-config.json文件中
        /// </summary>
        private void write_gui_config(string srcFile)
        {
            var json = File.ReadAllText(srcFile);
            var sGuiFile = $"{SSR_EXE_PATH}\\gui-config.json";
            var srcConfig = JsonConvert.DeserializeObject<SSR>(json);
            var guiCofnig= JsonConvert.DeserializeObject<SSR>(File.ReadAllText(sGuiFile ));
            if (chkDeleteOld.Checked)
                guiCofnig.configs.RemoveAll(x => x.group == "FreeSSR-public");

            
            foreach(var s in srcConfig.configs)
            {
                var guiOldServer = guiCofnig.configs.FirstOrDefault(x => x.server == s.server);
                if (guiOldServer == null)
                {
                    guiCofnig.configs.Add(s);
                }
                else
                {
                    if (s.server == "45.77.95.5")
                    {
                        MessageBox.Show("怎么可能还有我自已！");
                    }
                    guiOldServer.server_port = s.server_port;
                    guiOldServer.method = s.method;
                    guiOldServer.password = s.password;
                }
            }
            File.WriteAllText(sGuiFile , JsonConvert.SerializeObject(guiCofnig));

            btnRebootSSR_Click(null, null);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 10)
            {
                numericUpDown1.Value = 10;
            }
            timer1.Interval = (int) numericUpDown1.Value * 1000;
        }

        private void btnRebootSSR_Click(object sender, EventArgs e)
        {
            var sFile = @"c:\reboot.ssr";
            File.WriteAllText(sFile,"");

            while (true)
            {
                System.Threading.Thread.Sleep(500);
                if (!File.Exists(sFile)) {
                    System.Threading.Thread.Sleep(500);
                    Process.Start($"{SSR_EXE_PATH}\\ShadowsocksR.exe");
                    break;
                }
            }
            
        }

        private void btnManualImport_Click(object sender, EventArgs e)
        {
            clsShell.ShellWaitExit(txtAutoItExePath2.Text);
            ToSSRJson();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(@"e:\FreeSSR.sys.json", JsonConvert.SerializeObject(new
            {
                exe1 = txtAutoItExePath1.Text,
                exe2 = txtAutoItExePath2.Text,
                log = txtLogFilePath.Text
            }));
        }

        private class SysConfig
        {
            public string exe1 { get; set; }

            public string exe2 { get; set; }
            public string log { get; set; }
        }
    }
}
