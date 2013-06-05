using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class BoneDryGreen : Monster
    {
        public override string Name { get { return "Bone Dry"; } }
        public override int HP { get { return 120; } }

        public override int AC { get { return 34; } }
        public override int Hit { get { return 63; } }
        public override int Dam { get { return 36; } }

        public override int XP { get { return 126; } }
        public override int Color { get { return 2; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(.1, typeof(script.item.Crown), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.Robe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.Helmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.LargeShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.1, typeof(script.item.IronSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.Saber), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.Rapier), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.SpikedClub), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.Cape), "10d22+250", 40, 1, 1),
                    new LootPackEntry(.5, typeof(script.item.SmallAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d22+250", 40, 1, 1),
                });
            }
        }

        public BoneDryGreen()
            : base(24)
        {
        }

        public BoneDryGreen(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 24;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BoneDryGreen(Serial serial)
            : base(serial)
        {
        }
    }
}
