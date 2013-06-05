using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class LongStaff : BaseWeapon
    {
        public override string Name { get { return "Long Staff"; } }

        public override int DamBase { get { return 107; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 72; } }
        public override int MenReq { get { return 275; } }
        public override int DexReq { get { return 0; } }
        public override int HitBonus { get { return 64; } }
        public override int MPBonus { get { return 0; } }
        public override int ReduceCast { get { return 800; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 100000; } }
        public override int SellPrice { get { return 25000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane; } }

        public LongStaff()
            : base(32)
        {
        }

        public LongStaff(Serial serial)
            : base(serial)
        {
        }
    }
}
