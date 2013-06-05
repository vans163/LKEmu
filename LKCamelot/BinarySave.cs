using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LKCamelot
{
    public static class BinaryIO
    {
        public static void SavePlayers(List<LKCamelot.model.Player> players)
        {
            lock (readPlayerlock)
            {
                using (StreamWriter sw = new StreamWriter("worldsavePl.txt"))
                {
                    foreach (var play in players)
                    {
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}", Convert.ToInt32(play.Serial), play.Name, play.Pass, (int)play.Class,
                            play.Stage, play.LightRad, play.Transparancy, play.Map, play.Loc.X, play.Loc.Y, play.Face,
                            play.m_Str, play.m_Men, play.m_Dex, play.m_Vit, play.Extra, play.HP, play.HPCur, play.MP, play.MPCur, play.Level,
                            play.XP, play.Gold, play.MagicLearnedString()));
                    }
                }
            }
        }

        public static List<LKCamelot.model.Player> LoadPlayers()
        {
            lock (readPlayerlock)
            {
                List<LKCamelot.model.Player> temp = new List<LKCamelot.model.Player>();
                using (StreamReader sr = new StreamReader("worldsavePl.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');

                        var ret = new LKCamelot.model.Player();

                        ret.Serial = Convert.ToInt32(line[0]);
                        ret.Name = line[1];
                        ret.Pass = line[2];
                        ret.m_Class = (LKCamelot.library.Class)Convert.ToInt32(line[3]);
                        ret.Stage = (byte)Convert.ToInt32(line[4]);
                        ret.LightRad = (byte)Convert.ToInt32(line[5]);
                        ret.Transparancy = (byte)Convert.ToInt32(line[6]);
                        ret.m_Map = line[7];
                        ret.m_Loc = new model.Point2D(Convert.ToInt32(line[8]), Convert.ToInt32(line[9]));
                        ret.Face = (byte)Convert.ToInt32(line[10]);
                        ret.m_Str = (ushort)Convert.ToInt32(line[11]);
                        ret.m_Men = (ushort)Convert.ToInt32(line[12]);
                        ret.m_Dex = (ushort)Convert.ToInt32(line[13]);
                        ret.m_Vit = (ushort)Convert.ToInt32(line[14]);
                        ret.m_Extra = Convert.ToUInt32(line[15]);
                        ret.m_HP = (ushort)Convert.ToInt32(line[16]);
                        ret.m_HPCur = (ushort)Convert.ToInt32(line[17]);
                        ret.m_MP = (ushort)Convert.ToInt32(line[18]);
                        ret.m_MPCur = Convert.ToInt32(line[19]);
                        ret.m_Level = (short)Convert.ToInt32(line[20]);
                        ret.m_XP = Convert.ToInt32(line[21]);
                        ret.m_Gold = Convert.ToUInt64(line[22]);
                        ret.LoadMagic(line[23]);
                        ret.client = null;
                        temp.Add(ret);
                    }
                }
                return temp;
            }
        }

        public static void SavePlayer(LKCamelot.model.Player play)
        {
            lock (readPlayerlock)
            {
                using (StreamWriter sw = new StreamWriter("worldsavePl.txt", true))
                {
                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}", Convert.ToInt32(play.Serial), play.Name, play.Pass, (int)play.Class,
    play.Stage, play.LightRad, play.Transparancy, play.Map, play.Loc.X, play.Loc.Y, play.Face,
    play.apStr, play.apMen, play.apDex, play.apVit, play.Extra, play.HP, play.HPCur, play.MP, play.MPCur, play.Level,
    play.XP, play.Gold, play.MagicLearnedString()));
                }
            }
        }

        public static void UpdatePlayer(LKCamelot.model.Player play)
        {
            lock (readPlayerlock)
            {
                using (StreamReader sr = new StreamReader("worldsavePl.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        if (line[1] != play.Name)
                            continue;

                        using (StreamWriter sw = new StreamWriter("worldsavePl.txt", true))
                        {
                            sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}", Convert.ToInt32(play.Serial), play.Name, play.Pass, (int)play.Class,
            play.Stage, play.LightRad, play.Transparancy, play.Map, play.Loc.X, play.Loc.Y, play.Face,
            play.apStr, play.apMen, play.apDex, play.apVit, play.Extra, play.HP, play.HPCur, play.MP, play.MPCur, play.Level,
            play.XP, play.Gold, play.MagicLearnedString()));
                        }
                    }
                }
            }
        }

        public static List<string> LoadName(string name)
        {
            List<string> ret = null;
            lock (readPlayerlock)
            {
                using (StreamReader sr = new StreamReader("worldsavePl.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        if (line[1] != name)
                            continue;

                        ret.Add(line[1]);
                        ret.Add(line[2]);
                    }
                }
            }
            return ret;
        }

        public static object readPlayerlock = new object();
        public static LKCamelot.model.Player LoadPlayer(io.IOClient client, string name)
        {
            lock (readPlayerlock)
            {
                LKCamelot.model.Player ret = null;
                using (StreamReader sr = new StreamReader("worldsavePl.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        if (line[1] != name)
                            continue;

                        ret = new LKCamelot.model.Player(client);

                        ret.Serial = Convert.ToInt32(line[0]);
                        ret.Name = line[1];
                        ret.Pass = line[2];
                        ret.Class = (LKCamelot.library.Class)Convert.ToInt32(line[3]);
                        ret.Stage = (byte)Convert.ToInt32(line[4]);
                        ret.LightRad = (byte)Convert.ToInt32(line[5]);
                        ret.Transparancy = (byte)Convert.ToInt32(line[6]);
                        ret.Map = line[7];
                        ret.Loc = new model.Point2D(Convert.ToInt32(line[8]), Convert.ToInt32(line[9]));
                        ret.Face = (byte)Convert.ToInt32(line[10]);
                        ret.apStr = (ushort)Convert.ToInt32(line[11]);
                        ret.apMen = (ushort)Convert.ToInt32(line[12]);
                        ret.apDex = (ushort)Convert.ToInt32(line[13]);
                        ret.apVit = (ushort)Convert.ToInt32(line[14]);
                        ret.m_Extra = (ushort)Convert.ToInt32(line[15]);
                        ret.m_HP = (ushort)Convert.ToInt32(line[16]);
                        ret.m_HPCur = (ushort)Convert.ToInt32(line[17]);
                        ret.m_MP = (ushort)Convert.ToInt32(line[18]);
                        ret.m_MPCur = Convert.ToInt32(line[19]);
                        ret.m_Level = (short)Convert.ToInt32(line[20]);
                        ret.m_XP = Convert.ToInt32(line[21]);
                        ret.m_Gold = Convert.ToUInt64(line[22]);
                        ret.LoadMagic(line[23]);
                    }
                }
                return ret;
            }
        }

        public static void SaveItems(List<script.item.Item> items)
        {
            using (StreamWriter sw = new StreamWriter("worldsaveIt.txt"))
            {
                foreach (var item in items.OrderBy(xe => xe.Name))
                {
                    if (item.InvSlot >= 0)
                    {
                        string parsedType = item.GetType().Name.ToString();
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", Convert.ToInt32(item.m_Serial), parsedType, item.m_ItemID, item.ParSer, item.InvSlot, item.Stage, item.Quantity));
                    }
                }
            }
        }

        public static void SaveAuctionItems(List<script.item.AuctionItem> items)
        {
            using (StreamWriter sw = new StreamWriter("worldsaveAi.txt"))
            {
                foreach (var item in items.OrderBy(xe => xe.item.Name))
                {
                    if (item.item.InvSlot >= 0)
                    {
                        string parsedType = item.item.GetType().Name.ToString();
                        sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", Convert.ToInt32(item.item.m_Serial),
                            parsedType, item.item.m_ItemID, item.item.ParSer, item.item.InvSlot,
                            item.item.Stage, item.item.Quantity, item.goldprice, item.agoldprice, item.flags,
                            item.sellerSerial, item.buyerSerial, (int)item.state));
                    }
                }
            }
        }

        public static void BackUpData()
        {
            string path = "backup" + Path.DirectorySeparatorChar + (int)DateTime.Now.Year;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += Path.DirectorySeparatorChar + (int)DateTime.Now.Month;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += Path.DirectorySeparatorChar + (int)DateTime.Now.Day;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            try
            {
                File.Copy("worldsavePl.txt", path+Path.DirectorySeparatorChar+"worldsavePl-" + DateTime.Now.TimeOfDay.Hours +DateTime.Now.TimeOfDay.Minutes + ".txt");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            try
            {
                File.Copy("worldsaveIt.txt", path + Path.DirectorySeparatorChar+"worldsaveIt-" + DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + ".txt");
            }
            catch { }
            try
            {
                File.Copy("worldsaveAi.txt", path + Path.DirectorySeparatorChar + "worldsaveAi-" + DateTime.Now.TimeOfDay.Hours + DateTime.Now.TimeOfDay.Minutes + ".txt");
            }
            catch { }
        }

        public static List<script.item.Item> LoadItems()
        {
            var ret = new List<script.item.Item>();
            using (StreamReader sr = new StreamReader("worldsaveIt.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    script.item.Item temp = null;
                    try
                    {
                        temp = (script.item.Item)Activator.CreateInstance(Type.GetType("LKCamelot.script.item." + line[1]), (LKCamelot.model.Serial)Convert.ToInt32(line[0]));
                    }
                    catch { Console.WriteLine(line[1]); continue; }

                    temp.m_ItemID = Convert.ToInt32(line[2]);
                    temp.ParSer = Convert.ToInt32(line[3]);
                    try
                    {
                        temp.InvSlot = Convert.ToInt32(line[4]);
                    }
                    catch {
                        temp.InvSlot = 0;
                    }
                    temp.Stage = Convert.ToInt32(line[5]);
                    temp.Quantity = Convert.ToInt32(line[6]);
                    ret.Add(temp);
                }
            }
            return ret;
        }

        public static List<script.item.AuctionItem> LoadAuctions()
        {
            var ret = new List<script.item.AuctionItem>();
            using (StreamReader sr = new StreamReader("worldsaveAi.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    script.item.Item temp = null;
                    script.item.AuctionItem temp2 =  null;
                    try
                    {
                        temp = (script.item.Item)Activator.CreateInstance(Type.GetType("LKCamelot.script.item." + line[1]), (LKCamelot.model.Serial)Convert.ToInt32(line[0]));
                    }
                    catch { Console.WriteLine(line[1]); continue; }

                    temp.m_ItemID = Convert.ToInt32(line[2]);
                    temp.ParSer = Convert.ToInt32(line[3]);
                    temp.InvSlot = Convert.ToInt32(line[4]);
                    temp.Stage = Convert.ToInt32(line[5]);
                    temp.Quantity = Convert.ToInt32(line[6]);
                    temp2 = new script.item.AuctionItem(temp,
                        Convert.ToUInt64(line[7]), Convert.ToInt32(line[9]));
                    temp2.item = temp;
                    temp2.sellerSerial = Convert.ToInt32(line[10]);
                    temp2.buyerSerial = Convert.ToInt32(line[11]);
                    temp2.state = (script.item.aucState)Convert.ToInt32(line[12]);
                    ret.Add(temp2);
                }
            }
            return ret;
        }
    }
}
