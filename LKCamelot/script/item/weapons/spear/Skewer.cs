using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Skewer : BaseWeapon
    {
        public override string Name { get { return "Skewer"; } }

        public override int DamBase { get { return 94; } }
        public override int ACBase { get { return 0; } }
        public override int HitBonus { get { return 44; } }
        public override int MPBonus { get { return 56; } }

        public override int StrReq { get { return 54; } }
        public override int MenReq { get { return 120; } }
        public override int DexReq { get { return 0; } }
        public override int ReduceCast { get { return 600; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 100000; } }
        public override int SellPrice { get { return 20000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear; } }

        public Skewer()
            : base(34)
        {
        }

        public Skewer(Serial serial)
            : base(serial)
        {
            m_ItemID = 34;
        }
    }
}
