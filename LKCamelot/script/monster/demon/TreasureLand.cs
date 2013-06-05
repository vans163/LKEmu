using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class HoundsOfDoom : Monster
    {
        public override string Name { get { return "Hounds Of Doom"; } }
        public override int HP { get { return 10500; } }
        public override int Dam { get { return 600; } }
        public override int AC { get { return 1500; } }
        public override int Hit { get { return 2400; } }
        public override int XP { get { return 250000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public HoundsOfDoom()
            : base(19)
        {
        }

        public HoundsOfDoom(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 19;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public HoundsOfDoom(Serial serial)
            : base(serial)
        {
        }
    }

    public class BoneTrio1 : Monster
    {
        public override string Name { get { return "Bone Trio"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 2500; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public BoneTrio1()
            : base(215)
        {
        }

        public BoneTrio1(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 215;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BoneTrio1(Serial serial)
            : base(serial)
        {
        }
    }

    public class BoneTrio2 : Monster
    {
        public override string Name { get { return "Bone Trio"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 2500; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public BoneTrio2()
            : base(220)
        {
        }

        public BoneTrio2(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 220;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BoneTrio2(Serial serial)
            : base(serial)
        {
        }
    }

    public class BoneTrio3 : Monster
    {
        public override string Name { get { return "Bone Trio"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 2500; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public BoneTrio3()
            : base(221)
        {
        }

        public BoneTrio3(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 221;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BoneTrio3(Serial serial)
            : base(serial)
        {
        }
    }

    public class BioRubber : Monster
    {
        public override string Name { get { return "Bio Rubber"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 3000; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public BioRubber()
            : base(219)
        {
        }

        public BioRubber(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 219;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BioRubber(Serial serial)
            : base(serial)
        {
        }
    }

    public class Mercenary : Monster
    {
        public override string Name { get { return "Mercenary"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 3000; } }
        public override int XP { get { return 750000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public Mercenary()
            : base(209)
        {
        }

        public Mercenary(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 209;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Mercenary(Serial serial)
            : base(serial)
        {
        }
    }

    public class Leo : Monster
    {
        public override string Name { get { return "Leo"; } }
        public override int HP { get { return 15500; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 4000; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public Leo()
            : base(210)
        {
        }

        public Leo(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 210;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Leo(Serial serial)
            : base(serial)
        {
        }
    }

    public class SmokeGiant : Monster
    {
        public override string Name { get { return "Smoke Giant"; } }
        public override int HP { get { return 20500; } }
        public override int Dam { get { return 5900; } }
        public override int AC { get { return 6900; } }
        public override int Hit { get { return 5900; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.05, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public SmokeGiant()
            : base(224)
        {
        }

        public SmokeGiant(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 224;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public SmokeGiant(Serial serial)
            : base(serial)
        {
        }
    }

    public class Spot : Monster
    {
        public override string Name { get { return "Spot"; } }
        public override int HP { get { return 10500; } }
        public override int Dam { get { return 1200; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 4000; } }
        public override int XP { get { return 250000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.02, typeof(script.item.CurveShockBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.WindySpiritBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.FrameStrikeBook), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LaurelCrown), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondStick), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.LionHeart), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DragonBlade), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PowerStrong), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.PigBasket), "10d12+150", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Calypso), "10d12+150", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d12+15000", 40, 1, 1),
                });
            }
        }

        public Spot()
            : base(210)
        {
        }

        public Spot(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 210;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Spot(Serial serial)
            : base(serial)
        {
        }
    }
}
