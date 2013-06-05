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

namespace FileReader
{
    public partial class FRForm : Form
    {
        public FRForm()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
          //  SpellTemplate();
          //  BookTemplate();
         //   ItemTemplate();
             MapLoad();


      //      var input = File.ReadAllBytes(@"C:\transfer\format\atd\bubble.atz");
      //      var test = input.Count() / 255;

       //     FileStream _FileStream = new System.IO.FileStream(@"C:\transfer\format\atd\bubble_.atz", FileMode.Append, System.IO.FileAccess.Write);

        //        for (int x = 0; x < test; x++)
        //        {
        //            var tooken = input.Take(255).ToArray<Byte>();
        //            var tt = UnpackATD(tooken);
         //           _FileStream.Write(tt, 0, tt.Length);
        //        }
            
        }

        public class ItemTemp
        {
            public string Name;
            public string Type;
            public string Level;
            public string StrReq;
            public string DexReq;
            public string Dura;
            public string AC;
            public string Dam;
            public string ClassReq;
        }
        public static List<ItemTemp> tempitem = new List<ItemTemp>();

        public void ItemTemplate()
        {
            StreamReader reader = File.OpenText(@"itemkr.txt");
            string line;
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var parse = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                if (parse.Count() <= 1 || parse[1] == "bg")
                    continue;
                ItemTemp newt = new ItemTemp();
                int itr = 0;
                if (parse.Count() == 11)
                {
                    newt.Name = textInfo.ToTitleCase(parse[0].ToLower()) +" "+ textInfo.ToTitleCase(parse[1].ToLower());
                    itr += 2;
                }
                else
                {
                    newt.Name = textInfo.ToTitleCase(parse[itr++].ToLower());
                }
                newt.Type = textInfo.ToTitleCase(parse[itr++].ToLower());
                newt.StrReq = parse[itr++];
                newt.DexReq = parse[itr++];
                newt.Dura = parse[itr++];
                List<string> clas = new List<string>();
                if (parse[itr++] == "O")
                    clas.Add("Class.Beginner");
                if (parse[itr++] == "O")
                    clas.Add("Class.Knight");
                if (parse[itr++] == "O")
                    clas.Add("Class.Swordsman");
                if (parse[itr++] == "O")
                    clas.Add("Class.Wizard");
                if (parse[itr++] == "O")
                    clas.Add("Class.Shaman");
                foreach (var mem in clas)
                {
                    if (clas.Count == 1)
                    {
                        newt.ClassReq = mem;
                        break;
                    }
                    newt.ClassReq += mem+" | ";
                }
                if (clas.Count > 1)
                    newt.ClassReq = newt.ClassReq.Substring(0, (newt.ClassReq.Count()-3));
                if(clas.Count == 5)
                    newt.ClassReq = "0";
            tempitem.Add(newt);
            }
            reader.Close();
            StreamReader reader2 = File.OpenText(@"itemen.txt");
            while (!reader2.EndOfStream)
            {
                line = reader2.ReadLine();
                var parse = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ItemTemp item;
                int itre = 1;
                if (parse.Count() == 8)
                {
                    item = tempitem.Where(xe => xe.Name == (parse[1]+" "+parse[2])).FirstOrDefault();
                    itre += 2;
                }
                else
                {
                    item = tempitem.Where(xe => xe.Name == parse[itre]).FirstOrDefault();
                    itre++;
                }

                item.Level = parse[itre++];
                if (Convert.ToInt32(parse[0]) < 37)
                {
                    itre += 2;
                    item.AC = parse[itre++];
                    item.Dam = parse[itre];
                }
                else
                {
                    itre+=3;
                    item.AC = parse[itre];
                    item.Dam = "0";
                }
            }
            reader2.Close();
   /*         using (StreamWriter outp = File.AppendText(@"itemsBack.txt"))
            {
                foreach (var item in tempitem)
                {
                    outp.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", item.Name, item.Type, item.StrReq, item.DexReq, item.Dura, item.AC, item.Dam, item.ClassReq));
                }
            }*/
            string path = "hi";
            foreach (var item in tempitem)
            {
                int bas = 10;
                if (item.Type.ToLower() == "sword")
                {
                    path = @"item\sword\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                    bas = 10;
                }
                if (item.Type.ToLower() == "axe")
                {
                    bas = 14;
                    path = @"item\axe\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                }
                if (item.Type.ToLower() == "hammer")
                {
                    bas = 35;
                    path = @"item\hammer\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                }
                if (item.Type.ToLower() == "helmet")
                {
                    bas = 4;
                    path = @"item\helmet\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                }
                if (item.Type.ToLower() == "shield")
                {
                    bas = 17;
                    path = @"item\shield\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                }
                if (item.Type.ToLower() == "armor")
                {
                    bas = 5;
                    path = @"item\armor\" + Regex.Replace(item.Name, @"\s+", "") + ".cs";
                }

                using (StreamWriter outp = File.AppendText(path))
                {
                    outp.WriteLine("using LKCamelot.library;");
                    outp.WriteLine("using LKCamelot.model;");
                    outp.WriteLine("");
                    outp.WriteLine("namespace LKCamelot.script.item");
                    outp.WriteLine("{");
                    if (item.Type.ToLower() == "armor" || item.Type.ToLower() == "shield" || item.Type.ToLower() == "helmet")
                    {
                        outp.WriteLine("\tpublic class " + Regex.Replace(item.Name, @"\s+", "") + " : BaseArmor");
                    }
                    else
                    {
                        outp.WriteLine("\tpublic class " + Regex.Replace(item.Name, @"\s+", "") + " : BaseWeapon");
                    }
                    outp.WriteLine("\t{");
                    outp.WriteLine("\t\tpublic override string Name { get { return \""+item.Name+"\"; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic override int DamBase { get { return "+item.Dam+"; } }");
                    outp.WriteLine("\t\tpublic override int ACBase { get { return " + item.AC + "; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic override int StrReq { get { return "+item.StrReq+"; } }");
                    outp.WriteLine("\t\tpublic override int DexReq { get { return " + item.DexReq + "; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic override int InitMinHits { get { return "+item.Dura+"; } }");
                    outp.WriteLine("\t\tpublic override int InitMaxHits { get { return " + item.Dura + "; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic override Class ClassReq { get { return " + item.ClassReq + "; } }");
                    if (item.Type.ToLower() == "armor" || item.Type.ToLower() == "shield" || item.Type.ToLower() == "helmet")
                    {
                        outp.WriteLine("\t\tpublic override ArmorType ArmorType { get { return ArmorType." + item.Type + "; } }");
                    }
                    else
                    {
                        outp.WriteLine("\t\tpublic override WeaponType WeaponType { get { return WeaponType." + item.Type + "; } }");
                    }
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic " + Regex.Replace(item.Name, @"\s+", "") + "() : base ("+bas+")");
                    outp.WriteLine("\t\t{");
                    outp.WriteLine("\t\t}");
                    outp.WriteLine("");
                    outp.WriteLine("\t\tpublic " + Regex.Replace(item.Name, @"\s+", "") + "(Serial serial) : base (serial)");
                    outp.WriteLine("\t\t{");
                    outp.WriteLine("\t\t}");
                    outp.WriteLine("\t}");
                    outp.WriteLine("}");
                }
            }

        }

        public void BookTemplate()
        {
            StreamReader reader = File.OpenText(@"spells.txt");
            StreamWriter outp = File.AppendText(@"spellsB.txt");
            string line = "";
            while (!reader.EndOfStream)
            {
                while (line != null && line.IndexOf("public void") == -1)
                    line = reader.ReadLine();

                if (line.IndexOf("void") != -1)
                {
                    int Set = line.IndexOf("Set");
                    int Brack = line.IndexOf("(");
                    var SpellName = line.Substring((Set + 3), (Brack - (Set + 3)));
                    outp.WriteLine("public class " + SpellName + "Book" + " : BaseSpellbook");
                    outp.WriteLine("{");
                    var SpellNameSplit = Regex.Split(SpellName, @"(?<!^)(?=[A-Z])");
                    if (SpellNameSplit.Count() == 2)
                    {
                        outp.WriteLine("\tpublic override string Name { get { return \"Book of " + SpellNameSplit[0] + " " + SpellNameSplit[1] + "\"; } }");
                    }
                    if (SpellNameSplit.Count() == 1)
                    {
                        outp.WriteLine("\tpublic override string Name { get { return \"Book of " + SpellNameSplit[0] + "\"; } }");
                    }
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    var SpellIcon = Regex.Match(line, @"\d+");
                 //   outp.WriteLine("\tpublic override int SpellLearnedIcon { get { return " + SpellIcon.Value + "; } }");
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    int Equal = line.IndexOf("=") + 1;
                    int Coln = line.IndexOf(";");
                    var MagType = line.Substring(Equal, (Coln - Equal));
                    line = reader.ReadLine();
                    Equal = line.IndexOf("=") + 1;
                    Coln = line.IndexOf(";");
                    var ClassReq = line.Substring(Equal, (Coln - Equal));
                    line = reader.ReadLine();
                    Equal = line.IndexOf("=") + 1;
                    Coln = line.IndexOf(";");
                    var MenReq = line.Substring(Equal, (Coln - Equal));
                    line = reader.ReadLine();
                    Equal = line.IndexOf("=") + 1;
                    Coln = line.IndexOf(";");
                    var MenReqPl = line.Substring(Equal, (Coln - Equal));
                    line = reader.ReadLine();
                    var DexReq = "0";
                    var Level = "";
                    if (line.IndexOf("DexReq") != -1)
                    {
                        Equal = line.IndexOf("=") + 1;
                        Coln = line.IndexOf(";");
                        DexReq = line.Substring(Equal, (Coln - Equal));
                    }
                    else if (line.IndexOf("LevelReq") != -1)
                    {
                        Equal = line.IndexOf("=") + 1;
                        Coln = line.IndexOf(";");
                        Level = line.Substring(Equal, (Coln - Equal));
                    }
                    line = reader.ReadLine();
                    var DexReqPl = "0";
                    if (line.IndexOf("DexReqPl") != -1)
                    {
                        Equal = line.IndexOf("=") + 1;
                        Coln = line.IndexOf(";");
                        DexReqPl = line.Substring(Equal, (Coln - Equal));
                    }
                    line = reader.ReadLine();
                    if (line.IndexOf("LevelReq") != -1)
                    {
                        Equal = line.IndexOf("=") + 1;
                        Coln = line.IndexOf(";");
                        Level = line.Substring(Equal, (Coln - Equal));
                    }
                    outp.WriteLine("\tpublic override int MenReq { get { return" + MenReq + "; } }");
                    outp.WriteLine("\tpublic override int MenReqPl { get { return" + MenReqPl + "; } }");
                    outp.WriteLine("\tpublic override int DexReq { get { return " + DexReq + "; } }");
                    outp.WriteLine("\tpublic override int DexReqPl { get { return " + DexReqPl + "; } }");
                    outp.WriteLine("\tpublic override int LevelReq { get { return" + Level + "; } }");
                    outp.WriteLine("\tpublic override Class ClassReq { get { return" + ClassReq + "; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\tpublic override int spells.Spell SpellTaught { get { return new spells." + SpellName + "(); } }");
                    outp.WriteLine("");
                    outp.WriteLine("\tpublic "+SpellName+"Book() : base(3)");
                    outp.WriteLine("\t{");
                    outp.WriteLine("\t}");
                    outp.WriteLine("}");
                    outp.WriteLine("");
                }
            }
        }

        public void SpellTemplate()
        {
            StreamReader reader = File.OpenText(@"spells.txt");
            StreamWriter outp = File.AppendText(@"spells0.txt");//File.Open(@"spellsO.txt", FileMode.Append, FileAccess.Write);
            string line = "";
            while (!reader.EndOfStream)
            {
                while (line != null && line.IndexOf("public void") == -1)
                      line = reader.ReadLine();

                if (line.IndexOf("void") != -1)
                {
                    int Set = line.IndexOf("Set");
                    int Brack = line.IndexOf("(");
                    var SpellName = line.Substring((Set + 3), (Brack - (Set + 3)));
                    outp.WriteLine("public class " + SpellName + " : Spell");
                    outp.WriteLine("{");
                    var SpellNameSplit = Regex.Split(SpellName, @"(?<!^)(?=[A-Z])");
                    if (SpellNameSplit.Count() == 2)
                    {
                        outp.WriteLine("\tpublic override string Name { get { return \"" + SpellNameSplit[0].ToUpper() + " " + SpellNameSplit[1].ToUpper() + "\"; } }");
                    }
                    if (SpellNameSplit.Count() == 1)
                    {
                        outp.WriteLine("\tpublic override string Name { get { return \"" + SpellNameSplit[0].ToUpper() + "\"; } }");
                    }
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    var SpellIcon = Regex.Match(line, @"\d+");
                    outp.WriteLine("\tpublic override int SpellLearnedIcon { get { return " + SpellIcon.Value + "; } }");
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    int Equal = line.IndexOf("=") + 1;
                    int Coln = line.IndexOf(";");
                    var MagType = line.Substring(Equal, (Coln - Equal));
                    line = reader.ReadLine();
                    Equal = line.IndexOf("=") + 1;
                    Coln = line.IndexOf(";");
                    var ClassReq = line.Substring(Equal, (Coln - Equal));
                    outp.WriteLine("\tpublic override LKCamelot.library.MagicType mType { get { return LKCamelot.library." + MagType + "; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\tpublic override int DamBase { get { return 0; } }");
                    outp.WriteLine("\tpublic override int DamPl { get { return 0; } }");
                    outp.WriteLine("\tpublic override int ManaCost { get { return 0; } }");
                    outp.WriteLine("\tpublic override int ManaCostPl { get { return 6; } }");
                    outp.WriteLine("");
                    outp.WriteLine("\tpublic override SpellSequence Seq");
                    outp.WriteLine("\t{");
                    outp.WriteLine("\t\tget");
                    outp.WriteLine("\t\t{");
                    outp.WriteLine("\t\t\treturn new SpellSequence(");
                    outp.WriteLine("\t\t\t\t0,  //oncast");
                    outp.WriteLine("\t\t\t\t0,  //moving");
                    outp.WriteLine("\t\t\t\t0,  //impact");
                    outp.WriteLine("\t\t\t\t0,  //thickness");
                    outp.WriteLine("\t\t\t\t0,  //type");
                    outp.WriteLine("\t\t\t\t0,  //speed");
                    outp.WriteLine("\t\t\t\t0,  //streak");
                    outp.WriteLine("\t\t\t\t);");
                    outp.WriteLine("\t\t\t}");
                    outp.WriteLine("\t\t}");
                    outp.WriteLine("");
                    outp.WriteLine("\tpublic " + SpellName + "()");
                    outp.WriteLine("\t{");
                    outp.WriteLine("\t}");
                    outp.WriteLine("}");
                    outp.WriteLine("");
                }
            }
        }



        public Byte[] UnpackATZ0() //bubble.atz
        {
            var input = File.ReadAllBytes(@"C:\transfer\format\atd\bubble.atz");
            var init1036 = input.Take(1036).ToArray<Byte>(); //1036
            init1036[0] = 0; init1036[1] = 0; init1036[2] = 0; init1036[3] = 0; init1036[4] = 0;
            int arrayItr = 1036;


            var segSize = input.Skip(arrayItr).Take(20).ToArray<Byte>();
            var outLoop = segSize[0];
            var inLoop = segSize[4];

            var segData = input.Skip(arrayItr + segSize.Count()).Take(outLoop * inLoop).ToArray<Byte>();
            int PtrsegData = 0;

            Byte var_1A, var_1C, var_1E, var_20, var_22, var_24;


            for (int x = 0; x < outLoop; x++)
            {
                for (int y = 0; y < inLoop; y++)
                {
                    var_1A = segData[PtrsegData];
                    var_1C = init1036[PtrsegData+1];//(var_1A * 4) + init1036[0];
                    var_1E = init1036[PtrsegData+2];
                    var_20 = init1036[PtrsegData+3];
                    var_22 = Convert.ToByte(var_1C >> 3);
                    if (var_1C == 0 || var_22 != 0)
                    {
                        var_1C = var_22;
                    }
                    else
                    {
                        var_1C = 1;                   
                    }
                    var_22 = Convert.ToByte(var_1E >> 3);

                    if (var_1E == 0 || var_22 != 0)
                    {
                        var_1E = var_22;
                    }
                    else
                    {
                        var_1E = 1;
                    }

                    var_22 = Convert.ToByte(var_20 >> 3);

                    if (var_20 == 0 || var_22 != 0)
                    {
                        var_20 = var_22;
                    }
                    else
                    {
                        var_20 = 1;
                    }

                    //push var_20

                    var_24 = UnpackATZ0Call1(var_1E, var_1C);

                    /* wtf?
                    CODE:00435F61 43C mov     eax, [ebp+var_14]
                    CODE:00435F64 43C mov     dx, [ebp+var_24]
                    CODE:00435F68 43C mov     [eax], dx
                    CODE:00435F6B 43C inc     [ebp+OrigDatavar_18]
                    CODE:00435F6E 43C add     [ebp+var_14], 2
                    CODE:00435F72 43C inc     [ebp+CountUpvar_C]
                    CODE:00435F75 43C dec     [ebp+CountDvar_2C]
                    CODE:00435F78 43C jnz     loc_435E92
                    */

                    PtrsegData++;
                }
            }

            return null;
        }

        public Byte UnpackATZ0Call1(Byte cx, Byte dx)
        {
            var a = Convert.ToByte(((cx << 5) + 0x0) & 0xFF);
            var b = Convert.ToByte((dx << 0x0A) & 0xFF);

            return Convert.ToByte(a+b);//arg_0 aka EBX pushed  
        }

        public Byte[] UnpackATD(Byte[] data)
        {
            var v3 = data;
            List<Byte> temp = new List<Byte>();
            Byte[] ret = null;
            int count = 0;
            Byte var_9, var_B, var_A;

            do
            {
                var_9 = data[count];
                var_A = Convert.ToByte(var_9 & 0xF0);
                var_B = Convert.ToByte(var_9 & 0xF);
                var_9 = Convert.ToByte((var_A >> 4) + ((var_B << 4) & 0xFF));
                temp.Add(var_9);
                count++;
            } while (count != 255);

            ret = temp.ToArray<Byte>();
            return ret;
        }
    }
}
