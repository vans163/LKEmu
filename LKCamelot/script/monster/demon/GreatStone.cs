using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class GreatStone : Monster
    {
        public override string Name { get { return "Great Stone"; } }
        public override int HP { get { return 2500; } }
        public override int Dam { get { return 185; } }
        public override int AC { get { return 130; } }
        public override int Hit { get { return 174; } }
        public override int XP { get { return 9519; } }
        public override int Color { get { return 0; } }
        public override int WalkSpeed { get { return 1300; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.05, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.AssassinBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.FlyingSwordBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.DragonOfFireBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HornHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Robe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Hack), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Crown), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeShield), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public GreatStone()
            : base(6)
        {
        }

        public GreatStone(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 6;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public GreatStone(Serial serial)
            : base(serial)
        {
        }
    }
}
