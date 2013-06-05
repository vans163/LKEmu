using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Globalization;
using System.Diagnostics;

using System.Windows.Forms;

namespace devTool
{
    public class Program
    {
        public static GUI GUI;
        public static Stopwatch tickcount;
        public static Logger MainLogger;
        public static Logger ExceptLogger;
        public static Server _server;
        public static Thread ServerThread;

        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(App_ThreadException);
            AppDomain.CurrentDomain.ProcessExit += new System.EventHandler(domain_ProcessExit);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            tickcount = new Stopwatch();
            tickcount.Start();

            Console.WriteLine("  $$ Starting LKE DevTool..  ", ConsoleColor.Cyan);
            long StartTime = tickcount.ElapsedMilliseconds;

                string banner = @"

         888~-_                                 
         888   \   e88~~8e  Y88b    /           
         888    | d888  88b  Y88b  /  ____      
         888    | 8888__888   Y88b/             
         888   /  Y888    ,    Y8/              
         ~~~888~~~  88___/      Y    888        
            888     e88~-_   e88~-_  888  d88~\ 
            888    d888   i d888   i 888 C888   
            888    8888   | 8888   | 888  Y88b  
            888    Y888   ' Y888   ' 888   888D 
            888      88_-~    88_-~  888 \_88P                  
                       
                ";

            Console.WriteLine(banner, ConsoleColor.White);

            Console.WriteLine("  $$ Starting Loggers..  ", ConsoleColor.Cyan);
            MainLogger = new Logger("main.txt");
            ExceptLogger = new Logger("exception.txt");

            Console.WriteLine("  $$ Starting socket listener..  ", ConsoleColor.Cyan);
            _server = new Server();
            var ServerThread = new Thread(_server.run);
            ServerThread.Name = "ServerThread";
            ServerThread.Start();

            Console.WriteLine("  $$ Starting GUI..  ", ConsoleColor.Cyan);
            GUI = new GUI();
            var thread = new Thread(GUI.GUIThread); thread.Name = "GUI"; thread.Start();

            long stoptime = tickcount.ElapsedMilliseconds - StartTime;
            Console.WriteLine("  $$ Took : " + stoptime + "ms", ConsoleColor.Cyan);
        }

        static void domain_ProcessExit(object sender, EventArgs e)
        {
            //cleanup
        }

        public static void App_ThreadException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteFatal((e.ExceptionObject as Exception).StackTrace);
            System.Console.ReadLine(); //Keep from closing
        }
    }

    public class GUI
    {
        public Form1 GUIForm;

        public void GUIThread()
        {
            AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(Program.App_ThreadException);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUIForm = new Form1();
            Application.Run(GUIForm);
        }
    }
}
