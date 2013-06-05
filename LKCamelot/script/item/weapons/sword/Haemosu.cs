using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Haemosu : BaseWeapon
    {
        public override string Name { get { return "HAEMOSU"; } }

        public override int DamBase { get { return 250; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 2102; } }
        public override int DexReq { get { return 2925; } }
        public override int MenReq { get { return 300; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 200000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public Haemosu()
            : base(181)
        {
        }

        public Haemosu(Serial serial)
            : base(serial)
        {
        }
    }
}
