using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GeneralSword : BaseWeapon
    {
        public override string Name { get { return "General Sword"; } }

        public override int DamBase { get { return 200; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 1100; } }
        public override int DexReq { get { return 750; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public GeneralSword()
            : base(13)
        {
        }

        public GeneralSword(Serial serial)
            : base(serial)
        {
        }
    }
}
