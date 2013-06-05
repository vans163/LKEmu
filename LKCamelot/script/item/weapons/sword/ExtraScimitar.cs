using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class ExtraScimitar : BaseWeapon
    {
        public override string Name { get { return "Extra Scimitar"; } }

        public override int DamBase { get { return 150; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 750; } }
        public override int DexReq { get { return 300; } }
        public override int MenReq { get { return 0; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 75000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public ExtraScimitar()
            : base(13)
        {
        }

        public ExtraScimitar(Serial serial)
            : base(serial)
        {
        }
    }
}
