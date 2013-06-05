using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class ShortSpear : BaseWeapon
    {
        public override string Name { get { return "Short Spear"; } }

        public override int DamBase { get { return 46; } }
        public override int ACBase { get { return 0; } }
        public override int HitBonus { get { return 16; } }
        public override int MPBonus { get { return 33; } }

        public override int StrReq { get { return 35; } }
        public override int MenReq { get { return 68; } }
        public override int DexReq { get { return 0; } }
        public override int ReduceCast { get { return 300; } }
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 15000; } }
        public override int SellPrice { get { return 5000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear; } }

        public ShortSpear()
            : base(34)
        {
        }

        public ShortSpear(Serial serial)
            : base(serial)
        {
            m_ItemID = 34;
        }
    }
}
