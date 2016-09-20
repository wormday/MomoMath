using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CodeQty
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
            si.RedirectStandardError = true;
            si.RedirectStandardInput = true;
            si.RedirectStandardOutput = true;
            si.UseShellExecute = false;
            si.FileName = @"C:\Program Files (x86)\Git\bin\sh.exe";
            si.Arguments = "--login -i";
            si.CreateNoWindow = true;	//设置这个属性不创建新窗口。

            System.Diagnostics.Process p = Process.GetCurrentProcess();
            p.StartInfo = si;
            p.Start();

            StreamWriter sw = p.StandardInput;
            sw.WriteLine("git log --stat");
            sw.WriteLine("exit");
            StreamReader sr = p.StandardOutput;
            string str = sr.ReadToEnd();
            Console.Write(str);
            Console.ReadLine();
            p.WaitForExit();
        }
    }
}
