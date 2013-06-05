using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class WildDog : Monster
    {
        public override string Name { get { return "Wild Dog"; } }
        public override int HP { get { return 15; } }
        public override int Dam { get { return 2; } }
        public override int AC { get { return 0; } }
        public override int Hit { get { return 6; } }
        public override int XP { get { return 5; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Animal; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(1.0, typeof(script.item.SmallShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.Hood), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2.0, typeof(script.item.WoodenSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2.0, typeof(script.item.BambooKnife), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(5.0, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(5.0, typeof(script.item.Rag), "15d10+225", 1, 1, 1),//added
                    new LootPackEntry(15.0, typeof(script.item.DogBone), "15d10+225", 1, 1, 1)
                });
            }
        }

        public WildDog()
            : base(27)
        {
        }

        public WildDog(Serial temps, int x, int y, string map)
            : this(temps)
        {
            m_MonsterID = 27;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temps;
        }

        public WildDog(Serial serial)
            : base(serial)
        {
        }
    }
}
