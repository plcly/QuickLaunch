using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuickLaunch.Infrastructure
{
    public class Win32Helper
    {
        public static bool SwitchExeProcess(string filePath)
        {
            var extension = Path.GetExtension(filePath);
            if (extension.Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(filePath));
                if (processes.Length > 0)
                {
                    var handlePtr = processes[0].MainWindowHandle;
                    SwitchToThisWindow(handlePtr, true);

                    return true;
                }
            }
            return false;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
    }
}
