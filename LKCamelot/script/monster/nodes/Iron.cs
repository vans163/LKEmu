using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Iron : BaseNode
    {
        public override string Name { get { return "IRON"; } }
        public override int HP { get { return 6000; } }
        public override int Dam { get { return 0; } }
        public override int AC { get { return 0; } }
        public override int XP { get { return 5; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 1200; } }
        public override int SpawnTime { get { return 60000; } }
        public override Race Race { get { return Race.Demon; } }
        public override script.item.BaseOre OreDrop { get { return new script.item.IronOre(); } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                 //   new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+3000", 40, 1, 1),
                });
            }
        }

        public Iron()
            : base(4)
        {
        }

        public Iron(Serial temp, int x, int y, string map)
            : this(temp)
        {
            LastAction = int.MaxValue;
            m_MonsterID = 4;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Iron(Serial serial)
            : base(serial)
        {
        }
    }
}
