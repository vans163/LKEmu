using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class PowerStrong : BaseWeapon
    {
        public override string Name { get { return "Power Strong"; } }

        public override int DamBase { get { return 220; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 1720; } }
        public override int DexReq { get { return 1326; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 125000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public PowerStrong()
            : base(13)
        {
        }

        public PowerStrong(Serial serial)
            : base(serial)
        {
        }
    }
}
