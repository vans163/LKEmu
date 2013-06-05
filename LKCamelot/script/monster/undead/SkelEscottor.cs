using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class SkelEscottor : Monster
    {
        public override string Name { get { return "Skel Escottor"; } }
        public override int HP { get { return 500; } }
        public override int Dam { get { return 76; } }
        public override int AC { get { return 65; } }
        public override int Hit { get { return 74; } }
        public override int XP { get { return 570; } }
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
                    new LootPackEntry(0.1, typeof(script.item.Cloak), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.TriangleShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Cape), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Helmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.SmallAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d24+300", 40, 1, 1),
                });
            }
        }

        public SkelEscottor()
            : base(23)
        {
        }

        public SkelEscottor(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 23;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public SkelEscottor(Serial serial)
            : base(serial)
        {
        }
    }
}
