using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemHardBoil : Monster
    {
        public override string Name { get { return "Item Hard Boil"; } }
        public override int HP { get { return 12900; } }
        public override int Dam { get { return 790; } }
        public override int AC { get { return 380; } }
        public override int Hit { get { return 667; } }
        public override int XP { get { return 1; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 600; } }
        public override int SpawnTime { get { return 1200000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(1, typeof(script.item.UltraBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.MagmaHandBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.Wand), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.WarPike), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.RevelationBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.CoreaSword), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.WidePlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.SamuraiPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.FullPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(3, typeof(script.item.DeadlyBoomBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(3, typeof(script.item.AssassinBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+3200", 40, 1, 1),
                });
            }
        }

        public ItemHardBoil()
            : base(9)
        {
        }

        public ItemHardBoil(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 9;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemHardBoil(Serial serial)
            : base(serial)
        {
        }
    }
}
