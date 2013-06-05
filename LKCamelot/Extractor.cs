using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.IO;
namespace LKCamelot
{
    public static class Extractor
    {
        public static void ExtractMonsters()
        {

            var ppep = Assembly.GetExecutingAssembly().GetTypes().Where(xe => xe.BaseType == typeof(script.monster.Monster)).Select(xe=>xe).ToList();

            using (StreamWriter outp = File.AppendText(@"mobdump.txt"))
            {
                foreach (var mob in ppep)
                {
                    var temp = Activator.CreateInstance(mob);
                    var name = temp.GetType().GetProperty("Name").GetValue(temp, null);
                    var hp = temp.GetType().GetProperty("HP").GetValue(temp, null);
                    var dam = temp.GetType().GetProperty("Dam").GetValue(temp, null);
                    var ac = temp.GetType().GetProperty("AC").GetValue(temp, null);
                    var hit = temp.GetType().GetProperty("Hit").GetValue(temp, null);
                    var xp = temp.GetType().GetProperty("XP").GetValue(temp, null);
                    var color = temp.GetType().GetProperty("Color").GetValue(temp, null);
                    var walks = temp.GetType().GetProperty("WalkSpeed").GetValue(temp, null);
                    var attacks = temp.GetType().GetProperty("AttackSpeed").GetValue(temp, null);
                    var spawn = temp.GetType().GetProperty("SpawnTime").GetValue(temp, null);
                    var race = temp.GetType().GetProperty("Race").GetValue(temp, null);
                    var loot = temp.GetType().GetProperty("Loot").GetValue(temp, null);
                    script.monster.LootPackEntry[] test = null;
                    string lstring = "";
                    string colors = "0";
                    if (color.ToString() == "1")
                        colors = "Red";
                    if (color.ToString() == "2")
                        colors = "Green";
                    if (color.ToString() == "3")
                        colors = "Blue";
                    if (loot != null)
                    {
                        test = (loot as script.monster.LootPack).m_Entries;
                        foreach (var ent in test)
                        {
                            if (ent.t_item.Name == "Gold")
                            {
                                lstring += ent.m_Quantity.Count+"d"+ ent.m_Quantity.Sides+"+"+ent.m_Quantity.Bonus+" "+ent.t_item.Name;
                            }
                            else
                            {
                                lstring += ent.t_item.Name;
                            }
                            lstring += " ";
                            lstring += "(" + (ent.m_Chance * 0.01) + "%), ";
                        }
                        outp.WriteLine("|-");
                        outp.WriteLine("| 1 || " + name + " || " + colors + " || 1 || " + hp + " || " + dam + " || " + hit + " || " + ac + " || " + xp + " || " + spawn + " || " + race + " || " + walks + " || " + attacks + " || ?? || " +lstring);          
                    }
                    else
                    {
                        outp.WriteLine("|-");
                        outp.WriteLine("| 1 || " + name + " || " + color + " || 1 || " + hp + " || " + dam + " || " + hit + " || " + ac + " || " + xp + " || " + spawn + " || " + race + " || " + walks + " || " + attacks + " || ?? || ?? ||");
                    }
                    
                }
            }
        }
    }
}
