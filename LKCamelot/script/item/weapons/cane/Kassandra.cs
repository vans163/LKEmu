using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Kassandra : BaseWeapon
    {
        public override string Name { get { return "Kassandra"; } }

        public override int DamBase { get { return 150; } }
        public override int ACBase { get { return 170; } }
        public override int HitBonus { get { return 150; } }
        public override int MPBonus { get { return 0; } }

        public override int StrReq { get { return 200; } }
        public override int MenReq { get { return 4500; } }
        public override int DexReq { get { return 5500; } }

        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int ReduceCast { get { return 1150; } }
        public override int LevelReq { get { return 160; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override WeaponType WeaponType { get { return WeaponType.Cane2; } }

        public Kassandra()
            : base(33)
        {
        }

        public Kassandra(Serial serial)
            : base(serial)
        {
        }
    }
}
