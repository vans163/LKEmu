using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemMummy : Monster
    {
        public override string Name { get { return "Item Mummy"; } }
        public override int HP { get { return 450; } }
        public override int Dam { get { return 200; } }
        public override int AC { get { return 115; } }
        public override int Hit { get { return 181; } }
        public override int XP { get { return 1863; } }//changed to reflect blue mummy x3
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 600000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.ThunderCrossBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.TeleportBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BattleShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.ChestGuard), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.LargeAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.FullHelmet), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BattleArmor), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+3200", 40, 1, 1),
                    /*should drop Book of Oblivion, (Chest Guard, Large Axe,
                    Full Helmet, Battle Armor, Battle Shield). Shouldn't drop Thunder Cross, Teleport.
                    */
                });
            }
        }

        public ItemMummy()
            : base(5)
        {
        }

        public ItemMummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 5;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemMummy(Serial serial)
            : base(serial)
        {
        }
    }
}
