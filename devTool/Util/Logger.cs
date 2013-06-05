using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
namespace devTool
{
    public class Logger
    {
        string path;
        static readonly object WriteLock = new object();

        public Logger(string logname)
        {
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs");

            path = "logs/" + logname;
            LogLine(logname + " Logger Started");
        }

        public void LogLine(string line)
        {
            lock (WriteLock)
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("[ " + DateTime.Now.TimeOfDay.ToString().Remove(
                    DateTime.Now.TimeOfDay.ToString().IndexOf('.') + 3) + " ]  " + line);
                sw.Close(); sw.Dispose();
            }
        }
    }
}
