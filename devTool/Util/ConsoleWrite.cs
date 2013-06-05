using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devTool
{
    public static class Console
    {
        public static void WriteLine(string x, ConsoleColor color = ConsoleColor.White)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(" " + x);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteException(string x, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine("Exc: " + x);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteFatal(string x, ConsoleColor color = ConsoleColor.Red)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine("Fatal: " + x);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
