using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class PigmyBlue : Monster
    {
        public override string Name { get { return "Pigmy"; } }
        public override int HP { get { return 40; } }
        public override int Dam { get { return 6; } }
        public override int AC { get { return 6; } }
        public override int Hit { get { return 41; } }
        public override int XP { get { return 28; } }
        public override int Color { get { return 3; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.FireBallBook), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(1.0, typeof(script.item.Hatchet), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(2.0, typeof(script.item.Club), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(2.0, typeof(script.item.Sickle), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(2.0, typeof(script.item.Dagger), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(2.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2.5, typeof(script.item.Rag), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(2.5, typeof(script.item.Hood), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public PigmyBlue()
            : base(15)
        {
        }

        public PigmyBlue(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 15;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public PigmyBlue(Serial serial)
            : base(serial)
        {
        }
    }
}
