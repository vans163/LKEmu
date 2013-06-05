using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;

namespace FileReader
{
    public partial class FRForm : Form
    {
        static int offset = 76;
        /*Map Sizes
         * skel + weakly 64:64
         *erest.map 44:48
         */
        public void MapLoad()
        {
            //44:48
            string map = "weakly1";
            var input = File.ReadAllBytes(@"C:\EmuExample\Last Kingdom\Map\"+map+".map");
            List<byte[]> tiles = new List<byte[]>();

            int cnt = 4096;
            int itr = 0;
            byte[,] result = new byte[64, 64];
            int res1 = 0, res2 = 0;
            byte[] temp = new byte[4] { 0, 0, 0, 0 };
            while (itr != cnt)
            {
                Array.Copy(input, offset + (itr * 4), temp, 0, 4);
                if (temp[0] != 0x12)
                {
                    if (itr % 64 == 0 && itr != 0)
                    {
                        res2++;
                        res1 = 0;
                        Debug.WriteLine("");
                    }

                    if (temp[0] == 3)
                    {
                        result[res1++,res2] = 0;
                        Debug.Write("-");
                    }
                    else
                    {
                        result[res1++, res2] = 1;
                        Debug.Write("*");
                    }
                    
                }
                itr += 1;
            }

            using (StreamWriter outp = File.AppendText(map+".txt"))
            {
                outp.WriteLine("");
                outp.WriteLine("\tbyte[,] "+map +".map = new byte[64, 64]");
                outp.WriteLine("\t{");
                for (int x = 0; x < 64; x++)
                {
                    outp.Write("\n\t\t");
                    for (int y = 0; y < 64; y++)
                    {
                        outp.Write(+result[x,y]+", ");
                    }
                }
                outp.WriteLine("\t\t");
                outp.WriteLine("\t};");
            }
        }

    }
}