using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class SD : Monster
    {
        public override string Name { get { return "You vagely see it. Dancing in the shadows..."; } }
        public override int HP { get { return 25000; } }
        public override int AC { get { return 9000; } }
        public override int Hit { get { return 0; } }
        public override int Dam { get { return 0; } }
        public override int XP { get { return 0; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 100; } }
        public override Race Race { get { return Race.Undead; } }
        public override int Transp { get { return 13; } }
        public override int WalkSpeed { get { return Int32.MaxValue; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public SD()
            : base(226)
        {
        }

        public SD(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 226;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public SD(Serial serial)
            : base(serial)
        {
        }
    }
}