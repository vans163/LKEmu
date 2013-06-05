using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class iWarDummy : Monster
    {
        public override string Name { get { return "War Dummy"; } }
        public override int HP { get { return 3000; } }
        public override int AC { get { return 190; } }
        public override int Hit { get { return 267; } }
        public override int Dam { get { return 402; } }
        public override int XP { get { return 40498; } }
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
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongStaff), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Harpoon), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iWarDummy()
            : base(14)
        {
        }

        public iWarDummy(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iWarDummy(Serial serial)
            : base(serial)
        {
        }
    }

    public class iWarDummyRed : Monster
    {
        public override string Name { get { return "War Dummy"; } }
        public override int HP { get { return 450; } }
        public override int AC { get { return 195; } }
        public override int Hit { get { return 275; } }
        public override int Dam { get { return 313; } }
        public override int XP { get { return 47614; } }
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
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongStaff), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Harpoon), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iWarDummyRed()
            : base(14)
        {
        }

        public iWarDummyRed(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iWarDummyRed(Serial serial)
            : base(serial)
        {
        }
    }

    public class iWarDummyGreen : Monster
    {
        public override string Name { get { return "War Dummy"; } }
        public override int HP { get { return 500; } }
        public override int AC { get { return 205; } }
        public override int Hit { get { return 291; } }
        public override int Dam { get { return 333; } }
        public override int XP { get { return 56395; } }
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
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongStaff), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Harpoon), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iWarDummyGreen()
            : base(14)
        {
        }

        public iWarDummyGreen(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iWarDummyGreen(Serial serial)
            : base(serial)
        {
        }
    }

    public class iWarDummyBlue : Monster
    {
        public override string Name { get { return "War Dummy"; } }
        public override int HP { get { return 600; } }
        public override int AC { get { return 210; } }
        public override int Hit { get { return 299; } }
        public override int Dam { get { return 343; } }
        public override int XP { get { return 61618; } }
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
                    new LootPackEntry(0.1, typeof(script.item.ExecutionBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.LongStaff), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.Harpoon), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.BattleArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.LargeAxe), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullHelmet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Claymore), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iWarDummyBlue()
            : base(14)
        {
        }

        public iWarDummyBlue(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 14;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iWarDummyBlue(Serial serial)
            : base(serial)
        {
        }
    }
}
