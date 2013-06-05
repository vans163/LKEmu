using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class RocketMaul : BaseWeapon
    {
        public override string Name { get { return "Rocket Maul"; } }

        public override int DamBase { get { return 215; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 1502; } }
        public override int DexReq { get { return 400; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        
        public override int SellPrice { get { return 150000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Hammer; } }

        public RocketMaul()
            : base(16)
        {
        }

        public RocketMaul(Serial serial)
            : base(serial)
        {
        }
    }
}
