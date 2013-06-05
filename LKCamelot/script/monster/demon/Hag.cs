using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Hag : Monster
    {
        public override string Name { get { return "Hag"; } }
        public override int HP { get { return 2000; } }
        public override int Dam { get { return 500; } }
        public override int AC { get { return 268; } }
        public override int Hit { get { return 480; } }
        public override int XP { get { return 10000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderCrossBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public Hag()
            : base(29)
        {
        }

        public Hag(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 29;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Hag(Serial serial)
            : base(serial)
        {
        }
    }
}
