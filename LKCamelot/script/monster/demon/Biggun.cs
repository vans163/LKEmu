using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Rowedy : Monster
    {
        public override string Name { get { return "Rowedy"; } }
        public override int HP { get { return 3000; } }
        public override int Dam { get { return 350; } }
        public override int AC { get { return 195; } }
        public override int Hit { get { return 270; } }
        public override int XP { get { return 65000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.001, typeof(script.item.Wand), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.001, typeof(script.item.WarPike), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.WarStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.Javelin), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.GoldPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.DarkMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.Protectoria), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.PythonScale), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.BraveRing), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.ThunderStormBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.BigBangBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.AssassinBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.RevelationBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(20.0, typeof(script.item.Gold), "10d20+3000", 40, 1, 1),
                });
            }
        }

        public Rowedy()
            : base(35)
        {
        }

        public Rowedy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 35;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Rowedy(Serial serial)
            : base(serial)
        {
        }
    }

    public class Biggun : Monster
    {
        public override string Name { get { return "Biggun"; } }
        public override int HP { get { return 5000; } }
        public override int Dam { get { return 300; } }
        public override int AC { get { return 235; } }
        public override int Hit { get { return 550; } }
        public override int XP { get { return 75000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {  
                    new LootPackEntry(0.001, typeof(script.item.Wand), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.001, typeof(script.item.WarPike), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.WarStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.Javelin), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.GoldPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.DarkMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.Protectoria), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.PythonScale), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.BraveRing), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.ThunderStormBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.BigBangBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.AssassinBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.RevelationBook), "5d500+8000", 40, 1, 1),
                    new LootPackEntry(20.0, typeof(script.item.Gold), "10d20+3500", 40, 1, 1),
                });
            }
        }

        public Biggun()
            : base(36)
        {
        }

        public Biggun(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 36;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Biggun(Serial serial)
            : base(serial)
        {
        }
    }
}
