using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Crook : BaseWeapon
    {
        public override string Name { get { return "Crook"; } }

        public override int DamBase { get { return 66; } }
        public override int ACBase { get { return 44; } }

        public override int StrReq { get { return 33; } }
        public override int MenReq { get { return 152; } }
        public override int DexReq { get { return 0; } }
        public override int HitBonus { get { return 0; } }
        public override int MPBonus { get { return 65; } }
        public override int ReduceCast { get { return 600; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 100000; } }
        public override int SellPrice { get { return 20000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane; } }

        public Crook()
            : base(32)
        {
        }

        public Crook(Serial serial)
            : base(serial)
        {
            m_ItemID = 32;
        }
    }
}
