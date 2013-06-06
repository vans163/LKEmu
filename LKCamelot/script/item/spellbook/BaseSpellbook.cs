using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;
using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class BaseSpellbook : Item
    {
        public virtual int MenReqPl { get { return 0; } }
        public virtual int DexReqPl { get { return 0; } }
        public virtual int StrReqPl { get { return 0; } }

        public virtual int LevelReqPl { get { return 0; } }

        public virtual spells.Spell SpellTaught { get { return null; } }

        public BaseSpellbook(int itemID) : base(itemID)
        {
        }

        public BaseSpellbook(Serial serial) : base(serial)
        {
            m_ItemID = 3;
        }

        public override void Use(Player player)
        {
            if (player.LearnSpell(this))
            {
                this.Delete(player);
            }
        }
    }

    public class ThunderStormBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF THUNDER STORM"; } }
        public override int MenReq { get { return 485; } }
        public override int MenReqPl { get { return 11; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override ulong BuyPrice { get { return 100000; } }
        public override int SellPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.ThunderStorm(); } }

        public ThunderStormBook()
            : base(3)
        {
        }

        public ThunderStormBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class ElectronicBallBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF ELECTRONIC BALL"; } }
        public override int MenReq { get { return 24; } }
        public override int MenReqPl { get { return 4; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 200; } }

        public override spells.Spell SpellTaught { get { return new spells.ElectronicBall(); } }

        public ElectronicBallBook() : base(3)
        {
        }

        public ElectronicBallBook(Serial serial) : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class WindySpiritBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF WINDY SPIRIT"; } }
        public override int MenReq { get { return 1200; } }
        public override int MenReqPl { get { return 00; } }
        public override int DexReq { get { return 1000; } }
        public override int DexReqPl { get { return 20; } }
        public override int LevelReq { get { return 135; } }
        public override int LevelReqPl { get { return 2; } }
        public override Class ClassReq { get { return Class.Shaman; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 1000000; } }

        public override spells.Spell SpellTaught { get { return new spells.WindySpirit(); } }

        public WindySpiritBook()
            : base(3)
        {
        }

        public WindySpiritBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class FrameStrikeBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FRAME STRIKE"; } }
        public override int StrReq { get { return 3000; } }
        public override int StrReqPl { get { return 300; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 135; } }
        public override int LevelReqPl { get { return 2; } }
        public override Class ClassReq { get { return Class.Knight; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 1000000; } }

        public override spells.Spell SpellTaught { get { return new spells.FrameStrike(); } }

        public FrameStrikeBook()
            : base(3)
        {
        }

        public FrameStrikeBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class CurveShockBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF CURVE SHOCK"; } }
        public override int MenReq { get { return 1100; } }
        public override int MenReqPl { get { return 20; } }
        public override int DexReq { get { return 1100; } }
        public override int DexReqPl { get { return 30; } }
        public override int LevelReq { get { return 135; } }
        public override int LevelReqPl { get { return 2; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 1000000; } }

        public override spells.Spell SpellTaught { get { return new spells.CurveShock(); } }

        public CurveShockBook()
            : base(3)
        {
        }

        public CurveShockBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class TwisterBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF TWISTER"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 00; } }
        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 90; } }
        public override int LevelReqPl { get { return 2; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.Twister(); } }
        public override Class ClassReq { get { return Class.Knight; } }
        public TwisterBook()
            : base(3)
        {
        }

        public TwisterBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class TripleBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF TRIPLE"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int StrReq { get { return 0; } }
        public override int LevelReq { get { return 90; } }
        public override int LevelReqPl { get { return 2; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.Triple(); } }
        public override Class ClassReq { get { return Class.Swordsman; } }
        public TripleBook()
            : base(3)
        {
        }

        public TripleBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class TeleportBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF TELEPORT"; } }
        public override int MenReq { get { return 60; } }
        public override int MenReqPl { get { return 16; } }
        public override int DexReq { get { return 92; } }
        public override int DexReqPl { get { return 4; } }
        public override int LevelReq { get { return 0; } }

        public override ulong BuyPrice { get { return 25000; } }
        public override int SellPrice { get { return 12500; } }

        public override spells.Spell SpellTaught { get { return new spells.Teleport(); } }

        public TeleportBook()
            : base(3)
        {
        }

        public TeleportBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class SidewinderBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF SIDEWINDER"; } }
        public override int MenReq { get { return 105; } }
        public override int MenReqPl { get { return 15; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Swordsman | Class.Shaman; } }

        public override ulong BuyPrice { get { return 30000; } }
        public override int SellPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.Sidewinder(); } }

        public SidewinderBook()
            : base(3)
        {
        }

        public SidewinderBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class AssassinSpecialBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF ASSASSIN SPECIAL"; } }
        public override int MenReq { get { return 1200; } }
        public override int MenReqPl { get { return 30; } }
        public override int DexReq { get { return 1000; } }
        public override int DexReqPl { get { return 20; } }
        public override int LevelReq { get { return 111; } }
        public override int LevelReqPl { get { return 1; } }
        public override Class ClassReq { get { return Class.Shaman; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 100000; } }

        public override spells.Spell SpellTaught { get { return new spells.AssassinSpecial(); } }

        public AssassinSpecialBook()
            : base(3)
        {
        }

        public AssassinSpecialBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class FireBallBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FIRE BALL"; } }
        public override int MenReq { get { return 28; } }
        public override int MenReqPl { get { return 7; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override ulong BuyPrice { get { return 1000; } }
        public override int SellPrice { get { return 500; } }

        public override spells.Spell SpellTaught { get { return new spells.FireBall(); } }

        public FireBallBook()
            : base(3)
        {
        }

         public FireBallBook(Serial serial) : base(serial)
        {
        }
    }

    public class FlameRoundBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FLAME ROUND"; } }
        public override int MenReq { get { return 38; } }
        public override int MenReqPl { get { return 9; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override int SellPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.FlameRound(); } }

        public FlameRoundBook()
            : base(3)
        {
        }

        public FlameRoundBook(Serial serial) : base(serial)
        {
        }
    }

    public class ThunderCrossBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF THUNDER CROSS"; } }
        public override int MenReq { get { return 53; } }
        public override int MenReqPl { get { return 13; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override int SellPrice { get { return 7500; } }

        public override spells.Spell SpellTaught { get { return new spells.ThunderCross(); } }

        public ThunderCrossBook()
            : base(3)
        {
        }

        public ThunderCrossBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class GrandBigBangBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF GRAND BIG BANG"; } }
        public override int MenReq { get { return 1100; } }
        public override int MenReqPl { get { return 20; } }
        public override int DexReq { get { return 1100; } }
        public override int DexReqPl { get { return 30; } }
        public override int LevelReq { get { return 111; } }

        public override int SellPrice { get { return 100000;}}

        public override spells.Spell SpellTaught { get { return new spells.GrandBigBang(); } }
        public override Class ClassReq { get { return Class.Wizard; } }
        public GrandBigBangBook()
            : base(3)
        {
        }

        public GrandBigBangBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class BigBangBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF BIG BANG"; } }
        public override int MenReq { get { return 690; } }
        public override int MenReqPl { get { return 10; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        
        public override int SellPrice { get { return 20000;}}

        public override spells.Spell SpellTaught { get { return new spells.BigBang(); } }
        public override Class ClassReq { get { return Class.Wizard; } }
        public BigBangBook()
            : base(3)
        {
        }

        public BigBangBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class UltraBigBangBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF ULTRA BIG BANG"; } }
        public override int MenReq { get { return 720; } }
        public override int MenReqPl { get { return 15; } }
        public override int DexReq { get { return 205; } }
        public override int DexReqPl { get { return 7; } }
        public override int LevelReq { get { return 0; } }
        public override int LevelReqPl { get { return 0; } }

        public override int SellPrice { get { return 75000; } }

        public override spells.Spell SpellTaught { get { return new spells.UltraBigBang(); } }
        public override Class ClassReq { get { return Class.Wizard; } }
        public UltraBigBangBook()
            : base(3)
        {
        }

        public UltraBigBangBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class BlackHandBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF BLACK HAND"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 90; } }
        public override int LevelReqPl { get { return 2; } }

        public override int SellPrice { get { return 50000; } }

        public override spells.Spell SpellTaught { get { return new spells.BlackHand(); } }
        public override Class ClassReq { get { return Class.Shaman; } }

        public BlackHandBook()
            : base(3)
        {
        }

        public BlackHandBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class AssassinBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF ASSASSIN"; } }
        public override int MenReq { get { return 435; } }
        public override int MenReqPl { get { return 10; } }
        public override int DexReq { get { return 234; } }
        public override int DexReqPl { get { return 7; } }
        public override int LevelReq { get { return 0; } }

        public override int SellPrice { get { return 50000; } }

        public override spells.Spell SpellTaught { get { return new spells.Assassin(); } }
        public override Class ClassReq { get { return Class.Shaman; } }
        public AssassinBook()
            : base(3)
        {
        }

        public AssassinBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class TraceBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF TRACE"; } }
        public override int MenReq { get { return 38; } }
        public override int MenReqPl { get { return 10; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override ulong BuyPrice { get { return 40000; } }
        public override int SellPrice { get { return 15000; } }

        public override spells.Spell SpellTaught { get { return new spells.Trace(); } }

        public TraceBook()
            : base(3)
        {
        }

        public TraceBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class RevelationBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF REVELATION"; } }
        public override int MenReq { get { return 475; } }
        public override int MenReqPl { get { return 9; } }
        public override int DexReq { get { return 268; } }
        public override int DexReqPl { get { return 6; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Shaman;}}
        public override ulong BuyPrice { get { return 4000; } }

        public override int SellPrice { get { return 25000; } }

        public override spells.Spell SpellTaught { get { return new spells.Revelation(); } }

        public RevelationBook()
            : base(3)
        {
        }

        public RevelationBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class MagmaHandBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF MAGMA HAND"; } }
        public override int MenReq { get { return 900; } }
        public override int MenReqPl { get { return 20; } }
        public override int DexReq { get { return 500; } }
        public override int DexReqPl { get { return 15; } }
        public override int LevelReq { get { return 101; } }
        public override int LevelReqPl { get { return 1; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override int SellPrice { get { return 50000; } }

        public override spells.Spell SpellTaught { get { return new spells.MagmaHand(); } }

        public MagmaHandBook()
            : base(3)
        {
        }

        public MagmaHandBook(Serial serial)
            : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class HealBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF HEAL"; } }
        public override int MenReq { get { return 22; } }
        public override int MenReqPl { get { return 4; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override ulong BuyPrice { get { return 4000; } }

        public override spells.Spell SpellTaught { get { return new spells.Heal(); } }

        public HealBook()
            : base(3)
        {
        }

         public HealBook(Serial serial) : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class PlusHealBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF PLUS HEAL"; } }
        public override int MenReq { get { return 200; } }
        public override int MenReqPl { get { return 5; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }

        public override ulong BuyPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.PlusHeal(); } }

        public PlusHealBook()
            : base(3)
        {
        }

         public PlusHealBook(Serial serial) : base(serial)
        {
            m_ItemID = 3;
        }
    }

    public class MagicArmorBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF MAGIC ARMOR"; } }
        public override int MenReq { get { return 24; } }
        public override int MenReqPl { get { return 4; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Knight; } }

        public override ulong BuyPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.MagicArmor(); } }

        public MagicArmorBook()
            : base(3)
        {
        }

         public MagicArmorBook(Serial serial) : base(serial)
        {
        }
    }

    public class MentalSwordBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF MENTAL SWORD"; } }
        public override int MenReq { get { return 30; } }
        public override int MenReqPl { get { return 5; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 31; } }
        public override Class ClassReq { get { return Class.Knight; } }

        public override ulong BuyPrice { get { return 15000; } }

        public override spells.Spell SpellTaught { get { return new spells.MentalSword(); } }

        public MentalSwordBook()
            : base(3)
        {
        }

        public MentalSwordBook(Serial serial) : base(serial)
        {
        }
    }

    public class RainbowArmorBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF RAINBOW ARMOR"; } }
        public override int MenReq { get { return 312; } }
        public override int MenReqPl { get { return 24; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override ulong BuyPrice { get { return 50000; } }

        public override spells.Spell SpellTaught { get { return new spells.RainbowArmor(); } }

        public RainbowArmorBook() 
            : base(3)
        {
        }

         public RainbowArmorBook(Serial serial) : base(serial)
        {
        }
    }

    public class GuardianSwordBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF GUARDIAN SWORD"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 98; } }
        public override int DexReqPl { get { return 8; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Swordsman; } }

        public override ulong BuyPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.GuardianSword(); } }

        public GuardianSwordBook()
            : base(3)
        {
        }

        public GuardianSwordBook(Serial serial) : base(serial)
        {
        }
    }

    public class FireProtectorBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FIRE PROTECTOR"; } }
        public override int MenReq { get { return 162; } }
        public override int MenReqPl { get { return 14; } }
        public override int DexReq { get { return 65; } }
        public override int DexReqPl { get { return 8; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Shaman; } }

        public override ulong BuyPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.FireProtector(); } }

        public FireProtectorBook()
            : base(3)
        {
        }

        public FireProtectorBook(Serial serial) : base(serial)
        {
        }
    }

    public class TeagueShieldBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF TEAGUE SHIELD"; } }
        public override int MenReq { get { return 112; } }
        public override int MenReqPl { get { return 9; } }
        public override int DexReq { get { return 45; } }
        public override int DexReqPl { get { return 5; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Shaman; } }

        public override ulong BuyPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.TeagueShield(); } }

        public TeagueShieldBook()
            : base(3)
        {
        }

        public TeagueShieldBook(Serial serial) : base(serial)
        {
        }
    }

    public class MagicShieldBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF MAGIC SHIELD"; } }
        public override int MenReq { get { return 140; } }
        public override int MenReqPl { get { return 14; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override ulong BuyPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.MagicShield(); } }

        public MagicShieldBook()
            : base(3)
        {
        }

        public MagicShieldBook(Serial serial) : base(serial)
        {
        }
    }

    public class ZigZagBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF ZIG ZAG"; } }
        public override int MenReq { get { return 17; } }
        public override int MenReqPl { get { return 3; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }

        public override ulong BuyPrice { get { return 800; } }

        public override spells.Spell SpellTaught { get { return new spells.ZigZag(); } }

        public ZigZagBook()
            : base(3)
        {
        }

         public ZigZagBook(Serial serial) : base(serial)
        {
        }
    }

    public class DragonOfFireBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF DRAGON OF FIRE"; } }
        public override int MenReq { get { return 686; } }
        public override int MenReqPl { get { return 12; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override int SellPrice { get { return 30000; } }

        public override spells.Spell SpellTaught { get { return new spells.DragonOfFire(); } }

        public DragonOfFireBook()
            : base(3)
        {
        }

        public DragonOfFireBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class FireHawkBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FIRE HAWK"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 50; } }
        public override int LevelReqPl { get { return 5; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override int SellPrice { get { return 20000; } }

        public override spells.Spell SpellTaught { get { return new spells.FireHawk(); } }

        public FireHawkBook()
            : base(3)
        {
        }

        public FireHawkBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class LightningWallBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF LIGHTNING WALL"; } }
        public override int MenReq { get { return 56; } }
        public override int MenReqPl { get { return 14; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }

        public override int SellPrice { get { return 15000; } }

        public override spells.Spell SpellTaught { get { return new spells.LightningWall(); } }

        public LightningWallBook()
            : base(3)
        {
        }

        public LightningWallBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class FireWallBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FIRE WALL"; } }
        public override int MenReq { get { return 50; } }
        public override int MenReqPl { get { return 12; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 3; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }

        public override int SellPrice { get { return 10000; } }

        public override spells.Spell SpellTaught { get { return new spells.FireWall(); } }

        public FireWallBook()
            : base(3)
        {
        }

        public FireWallBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class FireShotBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FIRE SHOT"; } }
        public override int MenReq { get { return 98; } }
        public override int MenReqPl { get { return 26; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return 0; } }

        public override int SellPrice { get { return 15000; } }

        public override spells.Spell SpellTaught { get { return new spells.FireShot(); } }

        public FireShotBook()
            : base(3)
        {
        }

        public FireShotBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class DeadlyBoomBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF DEADLY BOOM"; } }
        public override int MenReq { get { return 450; } }
        public override int MenReqPl { get { return 10; } }
        public override int DexReq { get { return 0; } }
        public override int DexReqPl { get { return 0; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Wizard; } }

        public override int SellPrice { get { return 25000; } }

        public override spells.Spell SpellTaught { get { return new spells.DeadlyBoom(); } }

        public DeadlyBoomBook()
            : base(3)
        {
        }

        public DeadlyBoomBook(Serial serial)
            : base(serial)
        {
        }
    }

    public class DemonDeathBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF DEMON DEATH"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 260; } }
        public override int DexReqPl { get { return 12; } }
        public override int LevelReq { get { return 50; } }
        public override int LevelReqPl { get { return 5; } }
        public override Class ClassReq { get { return Class.Swordsman; } }

        public override ulong BuyPrice { get { return 50000; } }
        public override int SellPrice { get { return 5000; } }

        public override spells.Spell SpellTaught { get { return new spells.DemonDeath(); } }

        public DemonDeathBook()
            : base(3)
        {
        }

        public DemonDeathBook(Serial serial) : base(serial)
        {
        }
    }

    public class ExecutionBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF EXECUTION"; } }
        public override int MenReq { get { return 0; } }
        public override int MenReqPl { get { return 0; } }
        public override int DexReq { get { return 260; } }
        public override int DexReqPl { get { return 6; } }
        public override int LevelReq { get { return 0; } }
        public override Class ClassReq { get { return Class.Swordsman; } }

        public override ulong BuyPrice { get { return 0; } }
        public override int SellPrice { get { return 500; } }

        public override spells.Spell SpellTaught { get { return new spells.Execution(); } }

        public ExecutionBook()
            : base(3)
        {
        }

        public ExecutionBook(Serial serial) : base(serial)
        {
        }
    }

    public class FlyingSwordBook : BaseSpellbook
    {
        public override string Name { get { return "BOOK OF FLYING SWORD"; } }
        public override int MenReq { get { return 130; } }
        public override int MenReqPl { get { return 5; } }
        public override int DexReq { get { return 360; } }
        public override int DexReqPl { get { return 5; } }
        public override int LevelReq { get { return 80; } }
        public override Class ClassReq { get { return Class.Swordsman; } }

        public override ulong BuyPrice { get { return 0; } }
        public override int SellPrice { get { return 25000; } }

        public override spells.Spell SpellTaught { get { return new spells.FlyingSword(); } }

        public FlyingSwordBook()
            : base(3)
        {
        }

        public FlyingSwordBook(Serial serial) : base(serial)
        {
        }
    }
}
