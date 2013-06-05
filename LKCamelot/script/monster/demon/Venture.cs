using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.monster
{
    public class Medusa : Monster
    {
        public override string Name { get { return "Medusa"; } }
        public override int HP { get { return 800; } }
        public override int Dam { get { return 350; } }
        public override int AC { get { return 260; } }
        public override int Hit { get { return 450; } }
        public override int XP { get { return 90000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public Medusa()
            : base(200)
        {
        }

        public Medusa(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 200;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Medusa(Serial serial)
            : base(serial)
        {
        }
    }

    public class TwinCobra : Monster
    {
        public override string Name { get { return "Twin Cobra"; } }
        public override int HP { get { return 800; } }
        public override int Dam { get { return 350; } }
        public override int AC { get { return 260; } }
        public override int Hit { get { return 450; } }
        public override int XP { get { return 90000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public TwinCobra()
            : base(201)
        {
        }

        public TwinCobra(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 201;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public TwinCobra(Serial serial)
            : base(serial)
        {
        }
    }

    public class DeadlyMessenger : Monster
    {
        public override string Name { get { return "Deadly Messenger"; } }
        public override int HP { get { return 900; } }
        public override int Dam { get { return 500; } }
        public override int AC { get { return 285; } }
        public override int Hit { get { return 550; } }
        public override int XP { get { return 110000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public DeadlyMessenger()
            : base(203)
        {
        }

        public DeadlyMessenger(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 203;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public DeadlyMessenger(Serial serial)
            : base(serial)
        {
        }
    }

    public class WildMonk : Monster
    {
        public override string Name { get { return "Wild Monk"; } }
        public override int HP { get { return 900; } }
        public override int Dam { get { return 500; } }
        public override int AC { get { return 285; } }
        public override int Hit { get { return 550; } }
        public override int XP { get { return 110000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.1, typeof(script.item.GoldPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.DarkMail), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.1, typeof(script.item.Protectoria), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.3, typeof(script.item.PowerStrong), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "2d1000+3000", 40, 1, 1),
                });
            }
        }

        public WildMonk()
            : base(202)
        {
        }

        public WildMonk(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 202;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public WildMonk(Serial serial)
            : base(serial)
        {
        }
    }

    public class vViking : Monster
    {
        public override string Name { get { return "Viking"; } }
        public override int HP { get { return 500; } }
        public override int Dam { get { return 250; } }
        public override int AC { get { return 160; } }
        public override int Hit { get { return 230; } }
        public override int XP { get { return 22500; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public vViking()
            : base(35)
        {
        }

        public vViking(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 35;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public vViking(Serial serial)
            : base(serial)
        {
        }
    }

    public class vButcher : Monster
    {
        public override string Name { get { return "Butcher"; } }
        public override int HP { get { return 500; } }
        public override int Dam { get { return 230; } }
        public override int AC { get { return 140; } }
        public override int Hit { get { return 200; } }
        public override int XP { get { return 16500; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.2, typeof(script.item.FlameRoundBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Saw), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.5, typeof(script.item.Buckler), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+80", 40, 1, 1),
                });
            }
        }

        public vButcher()
            : base(8)
        {
        }

        public vButcher(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 8;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public vButcher(Serial serial)
            : base(serial)
        {
        }
    }

    public class DevilKid : Monster
    {
        public override string Name { get { return "Devil Kid"; } }
        public override int HP { get { return 7000; } }
        public override int Dam { get { return 650; } }
        public override int AC { get { return 385; } }
        public override int Hit { get { return 750; } }
        public override int XP { get { return 150000; } } //150000
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.005, typeof(script.item.DiamondArmor), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.005, typeof(script.item.GoliathPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.AssassinSpecialBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.GrandBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.Excalido), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.BarbarianAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.ArmShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.BoneMail), "15d10+225", 1, 1, 1), 
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d1000+3000", 40, 1, 1),
                });
            }
        }

        public DevilKid()
            : base(18)
        {
        }

        public DevilKid(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 18;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public DevilKid(Serial serial)
            : base(serial)
        {
        }
    }

    public class vIronGolem : Monster
    {
        public override string Name { get { return "Iron Golem"; } }
        public override int HP { get { return 9000; } }
        public override int Dam { get { return 750; } }
        public override int AC { get { return 445; } }
        public override int Hit { get { return 850; } }
        public override int XP { get { return 210000; } } //210000
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.008, typeof(script.item.GoliathPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.008, typeof(script.item.DiamondArmor), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.08, typeof(script.item.AssassinSpecialBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.08, typeof(script.item.GrandBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d1000+3000", 40, 1, 1),
                });
            }
        }

        public vIronGolem()
            : base(34)
        {
        }

        public vIronGolem(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 34;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public vIronGolem(Serial serial)
            : base(serial)
        {
        }
    }

    public class vGolemGuard : Monster
    {
        public override string Name { get { return "Golem Guard"; } }
        public override int HP { get { return 8000; } }
        public override int Dam { get { return 600; } }
        public override int AC { get { return 360; } }
        public override int Hit { get { return 700; } }
        public override int XP { get { return 120000; } } //120000
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.005, typeof(script.item.DiamondArmor), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.005, typeof(script.item.GoliathPlate), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.AssassinSpecialBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.GrandBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.Excalido), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.BarbarianAxe), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.ArmShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.BoneMail), "15d10+225", 1, 1, 1), 
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d1000+3000", 40, 1, 1),
                });
            }
        }

        public vGolemGuard()
            : base(34)
        {
        }

        public vGolemGuard(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 34;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public vGolemGuard(Serial serial)
            : base(serial)
        {
        }
    }

    public class SuperIronGolem : Monster
    {
        public override string Name { get { return "Super Iron Golem"; } }
        public override int HP { get { return 9000; } }
        public override int Dam { get { return 850; } }
        public override int AC { get { return 470; } }
        public override int Hit { get { return 1100; } }
        public override int XP { get { return 255000; } } //255000
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.0075, typeof(script.item.Cadeceus), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.0075, typeof(script.item.ForkedSpear), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.015, typeof(script.item.FamilyShield), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.015, typeof(script.item.RocketMaul), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.015, typeof(script.item.WarriorAngel), "15d10+225", 1, 1, 1),                                    
                    new LootPackEntry(0.009, typeof(script.item.DiamondArmor), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.GoliathPlate), "15d10+225", 1, 1, 1), 
                    new LootPackEntry(0.009, typeof(script.item.GoldVest), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.AssassinSpecialBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.GrandBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d1000+3000", 40, 1, 1),
                });
            }
        }

        public SuperIronGolem()
            : base(34)
        {
        }

        public SuperIronGolem(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 34;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public SuperIronGolem(Serial serial)
            : base(serial)
        {
        }
    }

    public class Rioter : Monster
    {
        public override string Name { get { return "Rioter"; } }
        public override int HP { get { return 12500; } }
        public override int Dam { get { return 555; } }
        public override int AC { get { return 500; } }
        public override int Hit { get { return 3333; } }
        public override int XP { get { return 300000; } } //300000
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.01, typeof(script.item.GrandStaff), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.01, typeof(script.item.GreatLance), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.AssassinSpecialBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.05, typeof(script.item.GrandBigBangBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.009, typeof(script.item.GoldVest), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "10d1000+5000", 40, 1, 1),
                });
            }
        }

        public Rioter()
            : base(37)
        {
        }

        public Rioter(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 37;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Rioter(Serial serial)
            : base(serial)
        {
        }
    }

    public class BloodShot : Monster
    {
        public override string Name { get { return "BLOOD SHOT"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 80; } }
        public override int AC { get { return 75; } }
        public override int Hit { get { return 100; } }
        public override int XP { get { return 3000; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.05, typeof(script.item.FireWallBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.075, typeof(script.item.TripleBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.075, typeof(script.item.TwisterBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d30+400", 40, 1, 1),
                });
            }
        }

        public BloodShot()
            : base(38)
        {
        }

        public BloodShot(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 38;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public BloodShot(Serial serial)
            : base(serial)
        {
        }
    }

    public class Scorpian : Monster
    {
        public override string Name { get { return "SCORPIAN"; } }
        public override int HP { get { return 300; } }
        public override int Dam { get { return 100; } }
        public override int AC { get { return 100; } }
        public override int Hit { get { return 150; } }
        public override int XP { get { return 4500; } }
        public override int Color { get { return 0; } }
        public override int SpawnTime { get { return 30000; } }
        public override Race Race { get { return Race.Demon; } }

        public override LootPack Loot
        {
            get
            {
                return new LootPack(new LootPackEntry[]
                {
                    new LootPackEntry(0.075, typeof(script.item.TripleBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(0.075, typeof(script.item.TwisterBook), "15d10+225", 1, 1, 1),
               //     new LootPackEntry(1.0, typeof(script.item.DemonDeathBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(1.0, typeof(script.item.FireWallBook), "15d10+225", 1, 1, 1),
                    new LootPackEntry(15.0, typeof(script.item.Gold), "5d10+400", 40, 1, 1),
                });
            }
        }

        public Scorpian()
            : base(39)
        {
        }

        public Scorpian(Serial temp, int x, int y, string map)
            : this(temp)
        {
            m_MonsterID = 39;
            m_Loc = new Point2D(x, y);
            m_SpawnLoc = new Point2D(m_Loc.X, m_Loc.Y);
            m_Map = map;
            m_Serial = temp;
        }

        public Scorpian(Serial serial)
            : base(serial)
        {
        }
    }
}
