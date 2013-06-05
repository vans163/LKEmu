using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Excalibur : BaseWeapon
    {
        public override string Name { get { return "Excalibur"; } }

        public override int DamBase { get { return 250; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 1000; } }
        public override int DexReq { get { return 0; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public Excalibur()
            : base(13)
        {
        }

        public Excalibur(Serial serial)
            : base(serial)
        {
        }
    }
}
