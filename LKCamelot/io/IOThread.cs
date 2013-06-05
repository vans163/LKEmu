using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using LKCamelot.model;
using System.IO;

namespace LKCamelot.io
{
    public class IOThread
    {

    /*    static void App_ThreadException(object sender, UnhandledExceptionEventArgs e)
        {
//            World.DBConnect.Backup();
 //           LKCamelot.model.World.SaveAll();

            Console.WriteLine((e.ExceptionObject as Exception).StackTrace);
            System.Windows.Forms.MessageBox.Show((e.ExceptionObject as Exception).StackTrace); // Keep things from closing

            var trace = new System.Diagnostics.StackTrace();
            StreamWriter sw = new StreamWriter("lastexep.txt");
            foreach (var frame in trace.GetFrames())
            {
                var method = frame.GetMethod();
                if (method.Name.Equals("LogStack")) continue;
                sw.WriteLine(string.Format("{0}::{1}",
                    method.ReflectedType != null ? method.ReflectedType.Name : string.Empty,
                    method.Name));
            }
            sw.Close();

        } */

        ~IOThread()
        {
            Console.WriteLine(string.Format("IOThread destroyed at: {0}", DateTime.Now));
        }

        public void run()
        {
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(Server.App_ThreadException);
            int cycleTime = 50, waitFails = 0, cycle = 0;
            long lastTicks = 0, totalTimeSpentProcessing = 0;

            while (!Server.shutdownServer)
            {
                try
                {
                    Server.world.Tick();
                //    Server.playerHandler.processIOClients();
                }
                catch (Exception e)
                {
                    var st = new System.Diagnostics.StackTrace(e, true);
                    var frame = st.GetFrame(0);
                    var line = frame.GetFileLineNumber();
                    Console.WriteLine(line + "  " + e.Message + "  : " + e.InnerException +"   "+ e.StackTrace);
                }
                // taking into account the time spend in the processing code for more accurate timing
                long timeSpent = Server.CurrentTimeMillis() - lastTicks;
                totalTimeSpentProcessing += timeSpent;
                if (timeSpent >= cycleTime)
                {
                    timeSpent = cycleTime;
                    if (++waitFails > 100)
                    {
                        waitFails = 0;
                     //   Server.shutdownServer = true;
                        Console.Write("KERNEL");
                    }
                }

                try
                {
                 //   Thread.Sleep((int)(cycleTime - timeSpent));
                    Thread.Sleep(50);
                }
                catch { }

                lastTicks = Server.CurrentTimeMillis();
                cycle++;
                if (cycle % 100 == 0)
                {
                    float time = ((float)totalTimeSpentProcessing) / cycle;
                    // Console.WriteLine("[KERNEL]", (time*100/cycleTime) + "% processing time");
                }
            }
        }
    }
}
