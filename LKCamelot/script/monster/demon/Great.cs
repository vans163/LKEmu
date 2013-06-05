using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Phantom : Monster
    {
        public override string Name { get { return "Phantom"; } }
        public override int HP { get { return 25000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 2000000; } }
        public override int Color { get { return 0; } }
        public override byte FrameType { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public Phantom()
            : base(227)
        {
        }

        public Phantom(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 227;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Phantom(Serial serial)
            : base(serial)
        {
        }
    }

    public class Temptress : Monster
    {
        public override string Name { get { return "Temptress"; } }
        public override int HP { get { return 25000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 2000000; } }
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
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public Temptress()
            : base(223)
        {
        }

        public Temptress(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 223;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Temptress(Serial serial)
            : base(serial)
        {
        }
    }

    public class Solo : Monster
    {
        public override string Name { get { return "Solo"; } }
        public override int HP { get { return 25000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 2000000; } }
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
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public Solo()
            : base(225)
        {
        }

        public Solo(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 225;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Solo(Serial serial)
            : base(serial)
        {
        }
    }

    public class FireDragon : Monster
    {
        public override string Name { get { return "Fire Dragon"; } }
        public override int HP { get { return 25000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 2000000; } }
        public override int Color { get { return 0; } }
        public override byte FrameType { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.01, typeof(script.item.FSofdk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+55550", 40, 1, 1),
                });
            }
        }

        public FireDragon()
            : base(216)
        {
        }

        public FireDragon(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 216;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public FireDragon(Serial serial)
            : base(serial)
        {
        }
    }

    public class PrincessShea : Monster
    {
        public override string Name { get { return "Princess Shea"; } }
        public override int HP { get { return 30000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override byte FrameType { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public PrincessShea()
            : base(11)
        {
        }

        public PrincessShea(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 11;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public PrincessShea(Serial serial)
            : base(serial)
        {
        }
    }

    public class QueenSpriss : Monster
    {
        public override string Name { get { return "Queen Spriss"; } }
        public override int HP { get { return 30000; } }
        public override int Dam { get { return 6500; } }
        public override int AC { get { return 10000; } }
        public override int Hit { get { return 6500; } }
        public override int XP { get { return 1000000; } }
        public override int Color { get { return 0; } }
        public override byte FrameType { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.01, typeof(script.item.KVSword), "10d3000+25550", 40, 1, 1),
                    new LootPackEntry(0.16, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.6, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.6, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public QueenSpriss()
            : base(226)
        {
        }

        public QueenSpriss(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 226;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public QueenSpriss(Serial serial)
            : base(serial)
        {
        }
    }

    public class Centeur : Monster
    {
        public override string Name { get { return "Centeur"; } }
        public override int HP { get { return 15000; } }
        public override int Dam { get { return 5900; } }
        public override int AC { get { return 6900; } }
        public override int Hit { get { return 5900; } }
        public override int XP { get { return 500000; } }
        public override int Color { get { return 0; } }
        public override byte FrameType { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.08, LKCamelot.script.Packs.CSWSFS, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatArmorPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, LKCamelot.script.Packs.GreatWeaponPack, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.ArmorPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.3, LKCamelot.script.Packs.WeaponPack110, "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+25550", 40, 1, 1),
                });
            }
        }

        public Centeur()
            : base(222)
        {
        }

        public Centeur(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 222;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Centeur(Serial serial)
            : base(serial)
        {
        }
    }
}
