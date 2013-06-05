using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class GolemGuard : Monster
    {
        public override string Name { get { return "Golem Guard"; } }
        public override int HP { get { return 6000; } }
        public override int Dam { get { return 480; } }
        public override int AC { get { return 380; } }
        public override int Hit { get { return 650; } }
        public override int XP { get { return 90000; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 1200; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.UltraBigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.MagmaHandBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.BigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.WidePlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatMaul), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public GolemGuard()
            : base(31)
        {
        }

        public GolemGuard(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 31;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public GolemGuard(Serial serial)
            : base(serial)
        {
        }
    }
}
