using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Rod : BaseWeapon
    {
        public override string Name { get { return "Rod"; } }

        public override int DamBase { get { return 21; } }
        public override int ACBase { get { return 12; } }

        public override int StrReq { get { return 18; } }
        public override int MenReq { get { return 51; } }
        public override int DexReq { get { return 0; } }
        public override int HitBonus { get { return 8; } }
        public override int MPBonus { get { return 26; } }
        public override int ReduceCast { get { return 200; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 1000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane; } }

        public Rod()
            : base(32)
        {
        }

        public Rod(Serial serial)
            : base(serial)
        {
            m_ItemID = 32;
        }
    }
}
