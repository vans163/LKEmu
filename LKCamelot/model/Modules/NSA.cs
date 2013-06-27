using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LKCamelot.model.Modules
{
    public class NSA
    {
        private string path = "nsa/";
        private string metadata;
        public Player target;

        public NSA(Player target)
        {
            this.target = target;
        }

        public static void Tap(string tarname)
        {
            try
            {
                if (tarname != "")
                {
                    var plr = LKCamelot.model.PlayerHandler.getSingleton().add.Where(xe => xe.Value != null && xe.Value.Name == tarname.ToUpper()).FirstOrDefault().Value;
                    plr.client.nsa = new NSA(plr);
                }
            }
            catch { }
        }

        public static void Untap(Player target)
        {
            //depreciated
        }

        public void AppendPacketOut(byte[] data)
        {
            //Hack :( lazy
            data = LKCamelot.net.Stream.Decrypt(data);
            if (PacketOP.PacketOPCodesOut.ContainsKey(data[0]))
            {
                var str = BitConverter.ToString(data, 0);
                string final = "";
                final += @"-  Out  ";
                final += PacketOP.PacketOPCodesOut[data[0]];
                final += " ";
                final += str;
                AppendFinalize(final);
            }
        }

        public void AppendPacketIn(byte[] data)
        {
            if (PacketOP.PacketOPCodesIn.ContainsKey(data[0]))
            {
                var str = BitConverter.ToString(data, 0);
                string final = "";
                final += "+  In  ";
                final += PacketOP.PacketOPCodesIn[data[0]];
                final += " ";
                final += str;
                AppendFinalize(final);
            }
        }

        private void AppendFinalize(string f)
        {
            f += "  [" + DateTime.Now.ToUniversalTime().ToString("MM/dd/yyyy hh:mm:ss.fff tt") + "]";
            f += Environment.NewLine;
            metadata += f;
            if (metadata.Length > 2000)
            {
                ArchiveMetaData(metadata);
                metadata = "";
            }
        }

        public void ArchiveMetaData(string data)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (StreamWriter sw = new StreamWriter(path+target.Name + ".diff", true))
            {
                sw.Write(data);
            }
        }

        public static void LoadTapList()
        {
            if (File.Exists("taplist.txt"))
            {
                using (StreamReader sr = new StreamReader("taplist.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            var line = sr.ReadLine();
                            NSA.Tap(line);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
