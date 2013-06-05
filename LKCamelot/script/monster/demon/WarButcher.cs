using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class WarButcher : Monster
    {
        public override string Name { get { return "War Butcher"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 30; } }
        public override int AC { get { return 12; } }
        public override int Hit { get { return 35; } }
        public override int XP { get { return 108; } }//adjusted
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 180000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(10.5, typeof(script.item.Club), "15d10+225", 1, 1, 1),
                    new LootPackEntry(10.5, typeof(script.item.ShortStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(10.5, typeof(script.item.ShortSpear), "15d10+225", 1, 1, 1),
                    new LootPackEntry(10.5, typeof(script.item.ShortSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.5, typeof(script.item.Surplice), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.5, typeof(script.item.FullDress), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.5, typeof(script.item.SmallShield), "15d10+225", 1, 1, 1),

                    new LootPackEntry(16.0, typeof(script.item.Gold), "10d10+450", 40, 1, 1),
                });
            }
        }

        public WarButcher()
            : base(12)
        {
        }

        public WarButcher(Serial temps, int x, int y, string map)
            : this(temps)
        {
            m_MonsterID = 12;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temps;
        }

        public WarButcher(Serial serial)
            : base(serial)
        {
        }
    }
}
