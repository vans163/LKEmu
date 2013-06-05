using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemDummy : Monster
    {
        public override string Name { get { return "Item Dummy"; } }
        public override int HP { get { return 5000; } }
        public override int Dam { get { return 490; } }
        public override int AC { get { return 300; } }
        public override int Hit { get { return 467; } }
        public override int XP { get { return 1; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 600; } }
        public override int SpawnTime { get { return 900000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(2, typeof(script.item.AssassinBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.FireHawkBook), "15d10+225", 1, 1, 1),
                // new LootPackEntry(2 typeof(script.item.FreezingBook), "10d22+250", 40, 1, 1),
                // new LootPackEntry(2, typeof(script.item.StoneCurseBook), "10d22+250", 40, 1, 1),

                    new LootPackEntry(2, typeof(script.item.WarStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.Javelin), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.FullHelmet), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.ToughLeather), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BreastPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.BattleAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(2, typeof(script.item.GrandShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+4200", 40, 1, 1),
                });
            }
        }

        public ItemDummy()
            : base(13)
        {
        }

        public ItemDummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 13;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemDummy(Serial serial)
            : base(serial)
        {
        }
    }
}
