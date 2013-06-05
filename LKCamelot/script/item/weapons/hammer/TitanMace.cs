using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class TitanMace : BaseWeapon
    {
        public override string Name { get { return "Titan Mace"; } }

        public override int DamBase { get { return 230; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 1950; } }
        public override int DexReq { get { return 1100; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 175000; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

        public TitanMace()
            : base(16)
        {
        }

        public TitanMace(Serial serial)
            : base(serial)
        {
        }
    }
}
