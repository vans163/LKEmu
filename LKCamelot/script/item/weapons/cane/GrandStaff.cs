using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GrandStaff : BaseWeapon
    {
        public override string Name { get { return "Grand Staff"; } }

        public override int DamBase { get { return 160; } }
        public override int ACBase { get { return 124; } }

        public override int StrReq { get { return 148; } }
        public override int MenReq { get { return 599; } }
        public override int DexReq { get { return 0; } }
        public override int ReduceCast { get { return 1000; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int LevelReq { get { return 80; } }
        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane2; } }

        public GrandStaff()
            : base(33)
        {
        }

        public GrandStaff(Serial serial)
            : base(serial)
        {
        }
    }
}
