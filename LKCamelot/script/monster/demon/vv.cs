using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class SkelGiant : Monster
    {
        public override string Name { get { return "Skel Giant"; } }
        public override int HP { get { return 13000; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 1000; } }
        public override int Hit { get { return 2500; } }
        public override int XP { get { return 300000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),
                 //   new LootPackEntry(0.025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
                  //  new LootPackEntry(0.025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+15000", 40, 1, 1), 
                });
            }
        }

        public SkelGiant()
            : base(26)
        {
        }

        public SkelGiant(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 26;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public SkelGiant(Serial serial)
            : base(serial)
        {
        }
    }

    public class Gargoyle : Monster
    {
        public override string Name { get { return "Gargoyle"; } }
        public override int HP { get { return 20000; } }
        public override int Dam { get { return 1000; } }
        public override int AC { get { return 1500; } }
        public override int Hit { get { return 3000; } }
        public override int XP { get { return 400000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),

                 //   new LootPackEntry(0.025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
                  //  new LootPackEntry(0.025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+15000", 40, 1, 1),
                });
            }
        }

        public Gargoyle()
            : base(204)
        {
        }

        public Gargoyle(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 204;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Gargoyle(Serial serial)
            : base(serial)
        {
        }
    }

    public class Ninja : Monster
    {
        public override string Name { get { return "Ninja"; } }
        public override int HP { get { return 32000; } }
        public override int Dam { get { return 1000; } }
        public override int AC { get { return 3300; } }
        public override int Hit { get { return 2500; } }
        public override int XP { get { return 800000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),

                  //  new LootPackEntry(0.0025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
                  //  new LootPackEntry(0.0025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+20000", 40, 1, 1),
                });
            }
        }

        public Ninja()
            : base(213)
        {
        }

        public Ninja(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 213;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Ninja(Serial serial)
            : base(serial)
        {
        }
    }

    public class Necromancer : Monster
    {
        public override string Name { get { return "Necromancer"; } }
        public override int HP { get { return 32000; } }
        public override int Dam { get { return 1200; } }
        public override int AC { get { return 3600; } }
        public override int Hit { get { return 3200; } }
        public override int XP { get { return 950000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public virtual byte FrameType { get { return 0; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.05, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),

          //          new LootPackEntry(0.0025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
            //        new LootPackEntry(0.0025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+20000", 40, 1, 1),
                });
            }
        }

        public Necromancer()
            : base(205)
        {
        }

        public Necromancer(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 205;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Necromancer(Serial serial)
            : base(serial)
        {
        }
    }

    public class LoupGarou : Monster
    {
        public override string Name { get { return "Loup Garou"; } }
        public override int HP { get { return 32000; } }
        public override int Dam { get { return 1800; } }
        public override int AC { get { return 3700; } }
        public override int Hit { get { return 3500; } }
        public override int XP { get { return 1050000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Undead; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),

           //         new LootPackEntry(0.0025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
             //       new LootPackEntry(0.0025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+15000", 40, 1, 1),
                });
            }
        }

        public LoupGarou()
            : base(208)
        {
        }

        public LoupGarou(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 208;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public LoupGarou(Serial serial)
            : base(serial)
        {
        }
    }

    public class GhostKnight : Monster
    {
        public override string Name { get { return "Ghost Knight"; } }
        public override int HP { get { return 29000; } }
        public override int Dam { get { return 3000; } }
        public override int AC { get { return 5500; } }
        public override int Hit { get { return 6000; } }
        public override int XP { get { return 2000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.05, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),

           //         new LootPackEntry(0.0025, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
             //       new LootPackEntry(0.0025, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d300+22000", 40, 1, 1),
                });
            }
        }

        public GhostKnight()
            : base(207)
        {
        }

        public GhostKnight(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 207;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public GhostKnight(Serial serial)
            : base(serial)
        {
        }
    }

    public class DevilGuard : Monster
    {
        public override string Name { get { return "Devil Guard"; } }
        public override int HP { get { return 15000; } }
        public override int Dam { get { return 2000; } }
        public override int AC { get { return 4000; } }
        public override int Hit { get { return 4000; } }
        public override int XP { get { return 500000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.03, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.03, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.CelestialArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.AmityPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.03, LKCamelot.script.Packs.VVArmorPack, "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.01, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.AngelicArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.CelestialArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.GoldVest), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d3000+20550", 40, 1, 1),
                });
            }
        }

        public DevilGuard()
            : base(211)
        {
        }

        public DevilGuard(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 211;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public DevilGuard(Serial serial)
            : base(serial)
        {
        }
    }

    public class Devil : Monster
    {
        public override string Name { get { return "Devil"; } }
        public override int HP { get { return 32000; } }
        public override int Dam { get { return 3000; } }
        public override int AC { get { return 7000; } }
        public override int Hit { get { return 6000; } }
        public override int XP { get { return 5000000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 3000000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.UnicornProtectoria), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1), 
                    new LootPackEntry(0.1, typeof(script.item.GoliathPlate), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DiamondArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.CelestialArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.AmityPlate), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.1, typeof(script.item.Excalibur), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DaeungDaegum), "10d22+250", 40, 1, 1),

                    new LootPackEntry(0.2, typeof(script.item.Tomahawk), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.2, typeof(script.item.GiantHammer), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Kassandra), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.TaegkFan), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.HolyDefender), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.GrandeurPride), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.SRing), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.02, typeof(script.item.SAmulet), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.AngelicArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.CelestialArmor), "10d22+250", 40, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d30+55000", 40, 1, 1),
                });
            }
        }

        public Devil()
            : base(212)
        {
        }

        public Devil(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 212;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Devil(Serial serial)
            : base(serial)
        {
        }
    }
}
