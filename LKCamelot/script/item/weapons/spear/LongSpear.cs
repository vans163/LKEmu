using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class LongSpear : BaseWeapon
    {
        public override string Name { get { return "Long Spear"; } }

        public override int DamBase { get { return 88; } }
        public override int ACBase { get { return 45; } }
        public override int HitBonus { get { return 63; } }
        public override int MPBonus { get { return 0; } }

        public override int StrReq { get { return 70; } }
        public override int MenReq { get { return 165; } }
        public override int DexReq { get { return 106; } }
        public override int ReduceCast { get { return 700; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 37500; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear; } }

        public LongSpear()
            : base(34)
        {
        }

        public LongSpear(Serial serial)
            : base(serial)
        {
        }
    }
}
