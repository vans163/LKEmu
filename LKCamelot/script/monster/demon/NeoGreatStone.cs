using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class NeoGreatStone : Monster
    {
        public override string Name { get { return "Neo Great Stone"; } }
        public override int HP { get { return 18000; } }
        public override int Dam { get { return 250; } }
        public override int AC { get { return 230; } }
        public override int Hit { get { return 120; } }
        public override int XP { get { return 9500; } }
        public override int Color { get { return 1; } }
        public override int SpawnTime { get { return 120000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.5, typeof(script.item.DeadlyBoomBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(1.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(1.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(2, typeof(script.item.WarStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Javelin), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2.2, typeof(script.item.HardLeather), "10d22+250", 40, 1, 1),
                    new LootPackEntry(2.2, typeof(script.item.LeatherArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(2.2, typeof(script.item.IceAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(2.0, typeof(script.item.TowerShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(2.0, typeof(script.item.BroadSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public NeoGreatStone()
            : base(6)
        {
        }

        public NeoGreatStone(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 6;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public NeoGreatStone(Serial serial)
            : base(serial)
        {
        }
    }
}
