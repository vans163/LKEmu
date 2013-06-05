using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemButcher : Monster
    {
        public override string Name { get { return "Item Butcher"; } }
        public override int HP { get { return 2000; } }
        public override int Dam { get { return 185; } }
        public override int AC { get { return 108; } }
        public override int Hit { get { return 167; } }
        public override int XP { get { return 1107; } }//updated blue butcher x3
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 360000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.ThunderCrossBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TeleportBook), "15d10+225", 1, 1, 1),
             //  new LootPackEntry(2, typeof(script.item.ComebackBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.HardLeather), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.EnamelLeather), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.FieldCap), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TowerShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+2200", 40, 1, 1),
                });
            }
        }

        public ItemButcher()
            : base(12)
        {
        }

        public ItemButcher(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 12;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemButcher(Serial serial)
            : base(serial)
        {
        }
    }
}
