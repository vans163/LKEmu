using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Skeleton : Monster
    {
        public override string Name { get { return "Skeleton"; } }
        public override int HP { get { return 100; } }
        public override int Dam { get { return 15; } }
        public override int AC { get { return 5; } }
        public override int Hit { get { return 20; } }
        public override int XP { get { return 32; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.Saber), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.Rapier), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.SpikedClub), "10d22+250", 40, 1, 1),
                    new LootPackEntry(1, typeof(script.item.Cape), "10d22+250", 40, 1, 1),//added
                    new LootPackEntry(1, typeof(script.item.SmallAxe), "10d22+250", 40, 1, 1),//added
                    new LootPackEntry(1, typeof(script.item.Cap), "10d22+250", 40, 1, 1),//added
                    new LootPackEntry(1, typeof(script.item.SmallShield), "10d22+250", 40, 1, 1),//added
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d18+70", 40, 1, 1),
                });
            }
        }

        public Skeleton()
            : base(1)
        {
        }

        public Skeleton(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 1;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Skeleton(Serial serial)
            : base(serial)
        {
        }
    }
}
