using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Stone : Monster
    {
        public override string Name { get { return "Stone"; } }
        public override int HP { get { return 1000; } }
        public override int Dam { get { return 154; } }
        public override int AC { get { return 110; } }
        public override int Hit { get { return 155; } }
        public override int XP { get { return 5250; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Robe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BroadSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.IceAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.HornHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Hack), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Crown), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public Stone()
            : base(6)
        {
        }

        public Stone(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 6;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Stone(Serial serial)
            : base(serial)
        {
        }
    }
}
