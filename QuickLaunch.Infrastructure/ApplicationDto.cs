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
    public class ApplicationDto
    {
        public string Name { get; set; }
        public string IconPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Icons\\default.png");
        public string FilePath { get; set; }
        public string CMD { get; set; }
        public string CMDPara { get; set; }
        public string Category { get; set; }
        public string CategoryIcon { get; set; }


        public void Run()
        {
            ProcessStartInfo p = new ProcessStartInfo();
            Process pro = new Process();
            p.UseShellExecute = true;
            if (string.IsNullOrEmpty(CMD))
            {
                if (Win32Helper.SwitchExeProcess(FilePath))
                {
                    return;
                }
                p.FileName = FilePath;
            }
            else
            {
                p.FileName = CMD;
                p.Arguments = " " + CMDPara + " " + FilePath;
            }

            pro.StartInfo = p;
            pro.Start();
            pro.Close();
        }

        
    }
}
