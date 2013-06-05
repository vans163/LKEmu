using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Viking : Monster
    {
        public override string Name { get { return "Viking"; } }
        public override int HP { get { return 200; } }
        public override int Dam { get { return 80; } }
        public override int AC { get { return 68; } }
        public override int Hit { get { return 97; } }
        public override int XP { get { return 621; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.Simitar), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Cloak), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.TriangleShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Cape), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Helmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Cutlass), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d24+300", 40, 1, 1),
                });
            }
        }

        public Viking()
            : base(32)
        {
        }

        public Viking(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 32;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Viking(Serial serial)
            : base(serial)
        {
        }
    }
}
