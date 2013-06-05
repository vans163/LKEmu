using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class WarPike : BaseWeapon
    {
        public override string Name { get { return "War Pike"; } }

        public override int DamBase { get { return 166; } }
        public override int ACBase { get { return 78; } }
        public override int HitBonus { get { return 95; } }
        public override int MPBonus { get { return 132; } }

        public override int StrReq { get { return 138; } }
        public override int MenReq { get { return 310; } }
        public override int DexReq { get { return 208; } }

        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int ReduceCast { get { return 1000; } }
        public override int SellPrice { get { return 75000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear2; } }

        public WarPike()
            : base(35)
        {
        }

        public WarPike(Serial serial)
            : base(serial)
        {
        }
    }
}
