using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemSkel : Monster
    {
        public override string Name { get { return "Item Skel"; } }
        public override int HP { get { return 350; } }

        public override int AC { get { return 85; } }
        public override int Hit { get { return 157; } }
        public override int Dam { get { return 121; } }

        public override int XP { get { return 459; } } //xp reflects blue skel x3
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 300000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.ThunderCrossBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TeleportBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Helmet), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Robe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Crown), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.IronSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.LargeShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "5d10+1800", 40, 1, 1),
                    //shouldn't drop Thundercross, Teleport
                });
            }
        }

        public ItemSkel()
            : base(23)
        {
        }

        public ItemSkel(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 23;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemSkel(Serial serial)
            : base(serial)
        {
        }
    }
}
