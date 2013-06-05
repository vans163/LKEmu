using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class DragonBlade : BaseWeapon
    {
        public override string Name { get { return "Dragon Blade"; } }

        public override int DamBase { get { return 240; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 2102; } }
        public override int DexReq { get { return 2925; } }
        public override int MenReq { get { return 506; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 150000; } }

        public override Class ClassReq { get { return Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Sword; } }

        public DragonBlade()
            : base(13)
        {
        }

        public DragonBlade(Serial serial)
            : base(serial)
        {
        }
    }
}
