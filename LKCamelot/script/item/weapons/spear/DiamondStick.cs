using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class DiamondStick : BaseWeapon
    {
        public override string Name { get { return "Diamond Stick"; } }

        public override int DamBase { get { return 180; } }
        public override int ACBase { get { return 110; } }
        public override int HitBonus { get { return 0; } }
        public override int MPBonus { get { return 189; } }

        public override int StrReq { get { return 220; } }
        public override int MenReq { get { return 525; } }
        public override int DexReq { get { return 0; } }
        public override int ReduceCast { get { return 1100; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 150000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear2; } }

        public DiamondStick()
            : base(35)
        {
        }

        public DiamondStick(Serial serial)
            : base(serial)
        {
        }
    }
}
