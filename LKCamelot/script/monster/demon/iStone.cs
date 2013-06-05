using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class iStone : Monster
    {
        public override string Name { get { return "Stone"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 83; } }
        public override int AC { get { return 69; } }
        public override int Hit { get { return 100; } }
        public override int XP { get { return 681; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 1200; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FireShotBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.AssassinBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.LongStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.Harpoon), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.ToughLeather), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.LargeShield), "15d10+225", 1, 1, 1),
                    
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public iStone()
            : base(6)
        {
        }

        public iStone(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 6;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iStone(Serial serial)
            : base(serial)
        {
        }
    }
}
