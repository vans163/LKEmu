using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class HeadCutter : Monster
    {
        public override string Name { get { return "Head Cutter"; } }
        public override int HP { get { return 150; } }
        public override int Dam { get { return 26; } }
        public override int AC { get { return 28; } }
        public override int Hit { get { return 57; } }
        public override int XP { get { return 78; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.5, typeof(script.item.RoundShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.ShortStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.ShortSpear), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.Club), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.ShortSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.Surplice), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.FullDress), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.5, typeof(script.item.BambooHat), "15d10+225", 1, 1, 1),

                    new LootPackEntry(15, typeof(script.item.Gold), "10d10+450", 40, 1, 1),
                });
            }
        }

        public HeadCutter()
            : base(30)
        {
        }

        public HeadCutter(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 30;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public HeadCutter(Serial serial)
            : base(serial)
        {
        }
    }
}
