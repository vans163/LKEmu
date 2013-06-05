using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Butcher : Monster
    {
        public override string Name { get { return "Butcher"; } }
        public override int HP { get { return 150; } }
        public override int Dam { get { return 21; } }
        public override int AC { get { return 23; } }
        public override int Hit { get { return 52; } }
        public override int XP { get { return 60; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.5, typeof(script.item.Club), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.ShortSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.Surplice), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.FullDress), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.SmallShield), "15d10+225", 1, 1, 1),

                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d10+450", 40, 1, 1),
                });
            }
        }

        public Butcher()
            : base(8)
        {
        }

        public Butcher(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 8;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Butcher(Serial serial)
            : base(serial)
        {
        }
    }
}
