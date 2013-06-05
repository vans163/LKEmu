using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class ShortStaff : BaseWeapon
    {
        public override string Name { get { return "Short Staff"; } }

        public override int DamBase { get { return 34; } }
        public override int ACBase { get { return 24; } }

        public override int StrReq { get { return 24; } }
        public override int MenReq { get { return 92; } }
        public override int DexReq { get { return 0; } }
        public override int HitBonus { get { return 25; } }
        public override int MPBonus { get { return 48; } }
        public override int ReduceCast { get { return 300; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 15000; } }
        public override int SellPrice { get { return 3000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane; } }

        public ShortStaff()
            : base(32)
        {
        }

        public ShortStaff(Serial serial)
            : base(serial)
        {
            m_ItemID = 32;
        }
    }
}
