using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class WarBadGirl : Monster
    {
        public override string Name { get { return "War Bad Girl"; } }
        public override int HP { get { return 150; } }
        public override int Dam { get { return 24; } }
        public override int AC { get { return 25; } }
        public override int Hit { get { return 56; } }
        public override int XP { get { return 67; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(.1, typeof(script.item.Headgear), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.QuiltedArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.Cap), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.Cape), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.IronSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.Rapier), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.ShortStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.ShortSpear), "15d10+225", 1, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.ThunderCrossBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.Saber), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.FlameRoundBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.SmallAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d22+250", 40, 1, 1),
                });
            }
        }

        public WarBadGirl()
            : base(7)
        {
        }

        public WarBadGirl(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 7;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public WarBadGirl(Serial serial)
            : base(serial)
        {
        }
    }
}
