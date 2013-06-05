using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class iDummy : Monster
    {
        public override string Name { get { return "Dummy"; } }
        public override int HP { get { return 1200; } }
        public override int AC { get { return 175; } }
        public override int Hit { get { return 243; } }
        public override int Dam { get { return 270; } }
        public override int XP { get { return 29824; } }
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
                    new LootPackEntry(0.02, typeof(script.item.AssassinBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DemonDeathBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongSpear), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Cain), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iDummy()
            : base(14)
        {
        }

        public iDummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iDummy(Serial serial)
            : base(serial)
        {
        }
    }

    public class iDummyRed : Monster
    {
        public override string Name { get { return "Dummy"; } }
        public override int HP { get { return 450; } }
        public override int AC { get { return 185; } }
        public override int Hit { get { return 250; } }
        public override int Dam { get { return 281; } }
        public override int XP { get { return 33382; } }
        public override int Color { get { return 1; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.AssassinBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DemonDeathBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongSpear), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Cain), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iDummyRed()
            : base(14)
        {
        }

        public iDummyRed(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iDummyRed(Serial serial)
            : base(serial)
        {
        }
    }

    public class iDummyGreen : Monster
    {
        public override string Name { get { return "Dummy"; } }
        public override int HP { get { return 500; } }
        public override int AC { get { return 185; } }
        public override int Hit { get { return 259; } }
        public override int Dam { get { return 292; } }
        public override int XP { get { return 36940; } }
        public override int Color { get { return 2; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.AssassinBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DemonDeathBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongSpear), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Cain), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iDummyGreen()
            : base(14)
        {
        }

        public iDummyGreen(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iDummyGreen(Serial serial)
            : base(serial)
        {
        }
    }

    public class iDummyBlue : Monster
    {
        public override string Name { get { return "Dummy"; } }
        public override int HP { get { return 600; } }
        public override int AC { get { return 190; } }
        public override int Hit { get { return 267; } }
        public override int Dam { get { return 302; } }
        public override int XP { get { return 44056; } }
        public override int Color { get { return 3; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.FireHawkBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.AssassinBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.FireShotBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DemonDeathBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongSpear), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Cain), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iDummyBlue()
            : base(14)
        {
        }

        public iDummyBlue(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iDummyBlue(Serial serial)
            : base(serial)
        {
        }
    }
}
