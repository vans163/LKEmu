using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class ItemStone : Monster
    {
        public override string Name { get { return "Item Stone"; } }
        public override int HP { get { return 5000; } }
        public override int Dam { get { return 242; } }
        public override int AC { get { return 156; } }
        public override int Hit { get { return 195; } }
        public override int XP { get { return 1; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 600; } }
        public override int SpawnTime { get { return 600000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(1.5, typeof(script.item.FireHawkBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.AssassinBook), "15d10+225", 1, 1, 1),
                 //  new LootPackEntry(1.5, typeof(script.item.TransparencyBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.FlyingSwordBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.DragonOfFireBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(1, typeof(script.item.RingMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.ChainMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.LargeHack), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.Maul), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1, typeof(script.item.BoneMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(25.0, typeof(script.item.Gold), "10d20+3200", 40, 1, 1),
                });
            }
        }

        public ItemStone()
            : base(5)
        {
        }

        public ItemStone(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 5;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public ItemStone(Serial serial)
            : base(serial)
        {
        }
    }
}
