using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GreatLance : BaseWeapon
    {
        public override string Name { get { return "Great Lance"; } }

        public override int DamBase { get { return 182; } }
        public override int ACBase { get { return 120; } }
        public override int HitBonus { get { return 0; } }
        public override int MPBonus { get { return 189; } }

        public override int StrReq { get { return 190; } }
        public override int MenReq { get { return 425; } }
        public override int DexReq { get { return 0; } }
        public override int ReduceCast { get { return 1000; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 100000; } }
        public override int LevelReq { get { return 80; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear2; } }

        public GreatLance()
            : base(35)
        {
        }

        public GreatLance(Serial serial)
            : base(serial)
        {
        }
    }
}
