using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Excalido : BaseWeapon
    {
        public override string Name { get { return "Excalido"; } }

        public override int DamBase { get { return 206; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 940; } }
        public override int DexReq { get { return 419; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }

        public override int SellPrice { get { return 85000; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public Excalido()
            : base(13)
        {
        }

        public Excalido(Serial serial)
            : base(serial)
        {
        }
    }
}
