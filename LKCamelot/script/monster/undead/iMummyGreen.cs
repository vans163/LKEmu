using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class iMummyGreen : Monster
    {
        public override string Name { get { return "Mummy"; } }
        public override int HP { get { return 200; } }
        public override int Dam { get { return 76; } }
        public override int AC { get { return 65; } }
        public override int Hit { get { return 94; } }
        public override int XP { get { return 535; } }
        public override int Color { get { return 2; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.TeleportBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.TripleBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.TwisterBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireWallBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FlyingSwordBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonOfFireBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Crook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LightningWallBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Skewer), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderCrossBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iMummyGreen()
            : base(3)
        {
        }

        public iMummyGreen(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 3;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iMummyGreen(Serial serial)
            : base(serial)
        {
        }
    }
}
