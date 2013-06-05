using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class PigmyKing : Monster
    {
        public override string Name { get { return "Small King"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 30; } }
        public override int AC { get { return 7; } }
        public override int Hit { get { return 44; } }
        public override int XP { get { return 44; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 360000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(20, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(20, typeof(script.item.ThunderCrossBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(20, typeof(script.item.Fleuret), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(20, typeof(script.item.Epee), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(20, typeof(script.item.Mace), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(20, typeof(script.item.Headgear), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(25, typeof(script.item.Gold), "5d10+500", 40, 1, 1),
                });
            }
        }

        public PigmyKing()
            : base(16)
        {
        }

        public PigmyKing(Serial temps, int x, int y, string map)
            : this(temps)
        {
            m_MonsterID = 16;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temps;
        }

        public PigmyKing(Serial serial)
            : base(serial)
        {
        }
    }
}
