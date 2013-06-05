using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GiantHammer : BaseWeapon
    {
        public override string Name { get { return "Giant Hammer"; } }

        public override int DamBase { get { return 245; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 3025; } }
        public override int DexReq { get { return 2600; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }

        public override int SellPrice { get { return 200000; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

        public GiantHammer()
            : base(16)
        {
        }

        public GiantHammer(Serial serial)
            : base(serial)
        {
        }
    }
}
