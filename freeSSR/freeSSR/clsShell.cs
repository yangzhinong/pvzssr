using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace freeSSR
{
    class clsShell
    {
        public static void ShellWaitExit(string sExe)
        {
            var pi = new ProcessStartInfo(sExe);
            var cmd = Process.Start(pi);
            cmd.WaitForExit();
        }
    }
}
