using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class iHardBoil : Monster
    {
        public override string Name { get { return "HARDBOIL"; } }
        public override int HP { get { return 6000; } }
        public override int AC { get { return 225; } }
        public override int Hit { get { return 306; } }
        public override int Dam { get { return 853; } }
        public override int XP { get { return 66843; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.019, typeof(script.item.UltraBigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.MagmaHandBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.BigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.DeadlyBoomBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.WidePlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatMaul), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iHardBoil()
            : base(28)
        {
        }

        public iHardBoil(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 28;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iHardBoil(Serial serial)
            : base(serial)
        {
        }
    }

    public class iHardBoilRed : Monster
    {
        public override string Name { get { return "HARDBOIL"; } }
        public override int HP { get { return 550; } }
        public override int AC { get { return 220; } }
        public override int Hit { get { return 314; } }
        public override int Dam { get { return 363; } }
        public override int XP { get { return 72066; } }
        public override int Color { get { return 1; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.019, typeof(script.item.UltraBigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.MagmaHandBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.BigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.DeadlyBoomBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.WidePlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatMaul), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iHardBoilRed()
            : base(28)
        {
        }

        public iHardBoilRed(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 28;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iHardBoilRed(Serial serial)
            : base(serial)
        {
        }
    }

    public class iHardBoilGreen : Monster
    {
        public override string Name { get { return "HARDBOIL"; } }
        public override int HP { get { return 600; } }
        public override int AC { get { return 225; } }
        public override int Hit { get { return 323; } }
        public override int Dam { get { return 373; } }
        public override int XP { get { return 77235; } }
        public override int Color { get { return 2; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.019, typeof(script.item.UltraBigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.MagmaHandBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.BigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.DeadlyBoomBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.WidePlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatMaul), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iHardBoilGreen()
            : base(28)
        {
        }

        public iHardBoilGreen(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 28;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iHardBoilGreen(Serial serial)
            : base(serial)
        {
        }
    }

    public class iHardBoilBlue : Monster
    {
        public override string Name { get { return "HARDBOIL"; } }
        public override int HP { get { return 700; } }
        public override int AC { get { return 229; } }
        public override int Hit { get { return 328; } }
        public override int Dam { get { return 382; } }
        public override int XP { get { return 77290; } }
        public override int Color { get { return 3; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.019, typeof(script.item.UltraBigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.MagmaHandBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.ThunderStormBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.025, typeof(script.item.BigBangBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.DeadlyBoomBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.15, typeof(script.item.RevelationBook), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.FullPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatSword), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.WidePlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GreatMaul), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+550", 40, 1, 1),
                });
            }
        }

        public iHardBoilBlue()
            : base(28)
        {
        }

        public iHardBoilBlue(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 28;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public iHardBoilBlue(Serial serial)
            : base(serial)
        {
        }
    }
}
