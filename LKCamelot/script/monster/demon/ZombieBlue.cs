using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ZombieBlue : Monster
    {
        public override string Name { get { return "Zombie"; } }
        public override int HP { get { return 50; } }

        public override int AC { get { return 18; } }
        public override int Hit { get { return 48; } }
        public override int Dam { get { return 16; } }

        public override int XP { get { return 48; } }
        public override int Color { get { return 3; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.RoundShield), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.Fleuret), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.SpikedClub), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.Cape), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.Rag), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.SmallShield), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.2, typeof(script.item.Cap), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(0.5, typeof(script.item.Suit), "10d19+200", 40, 1, 1),//added
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d19+200", 40, 1, 1),
                });
            }
        }

        public ZombieBlue()
            : base(17)
        {
        }

        public ZombieBlue(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 17;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ZombieBlue(Serial serial)
            : base(serial)
        {
        }
    }
}
