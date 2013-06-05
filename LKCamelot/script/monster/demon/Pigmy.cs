using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Pigmy : Monster
    {
        public override string Name { get { return "Pigmy"; } }
        public override int HP { get { return 25; } }
        public override int Dam { get { return 2; } }
        public override int AC { get { return 1; } }
        public override int Hit { get { return 16; } }
        public override int XP { get { return 15; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get 
            { 
                return new LootPack(new LootPackEntry[]
                {
                    
                    new LootPackEntry(0.1, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.Hatchet), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.ExecutionBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(5.0, typeof(script.item.Hood), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(5.0, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(5.0, typeof(script.item.Rag), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+50", 40, 1, 1),
                } );
            }
        }

        public Pigmy() : base(15)
        {
        }

        public Pigmy(Serial temp, int x, int y, string map) : this(temp)
        {
            m_MonsterID = 15;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Pigmy(Serial serial) : base(serial)
        {
        }
    }
}
