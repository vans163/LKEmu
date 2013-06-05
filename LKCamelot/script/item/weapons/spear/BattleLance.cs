using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BattleLance : BaseWeapon
    {
        public override string Name { get { return "Battle Lance"; } }

        public override int DamBase { get { return 146; } }
        public override int ACBase { get { return 119; } }

        public override int StrReq { get { return 209; } }
        public override int MenReq { get { return 501; } }
        public override int DexReq { get { return 343; } }
        public override int ReduceCast { get { return 700; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 25000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear; } }

        public BattleLance()
            : base(35)
        {
        }

        public BattleLance(Serial serial)
            : base(serial)
        {
        }
    }
}
