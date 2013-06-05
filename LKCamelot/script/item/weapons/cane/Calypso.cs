using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Calypso : BaseWeapon
    {
        public override string Name { get { return "Calypso"; } }

        public override int DamBase { get { return 160; } }
        public override int ACBase { get { return 130; } }

        public override int StrReq { get { return 180; } }
        public override int MenReq { get { return 700; } }
        public override int DexReq { get { return 0; } }
        public override int LevelReq { get { return 90; } }

        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int ReduceCast { get { return 1100; } }
        public override int SellPrice { get { return 250000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane2; } }

        public Calypso()
            : base(33)
        {
        }

        public Calypso(Serial serial)
            : base(serial)
        {
        }
    }
}
