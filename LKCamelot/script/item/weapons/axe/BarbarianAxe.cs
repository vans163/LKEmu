using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BarbarianAxe : BaseWeapon
    {
        public override string Name { get { return "Barbarian Axe"; } }

        public override int DamBase { get { return 182; } }
        public override int ACBase { get { return 0; } }

        public override int StrReq { get { return 810; } }
        public override int DexReq { get { return 95; } }

        public override int InitMinHits { get { return 700; } }
        public override int InitMaxHits { get { return 700; } }

        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override WeaponType WeaponType { get { return WeaponType.Axe; } }

        public BarbarianAxe()
            : base(16)
        {
        }

        public BarbarianAxe(Serial serial)
            : base(serial)
        {
        }
    }
}
