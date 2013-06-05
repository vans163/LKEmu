using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BambooSpear : BaseWeapon
    {
        public override string Name { get { return "Bamboo Spear"; } }

        public override int DamBase { get { return 25; } }
        public override int ACBase { get { return 10; } }
        public override int HitBonus { get { return 5; } }
        public override int MPBonus { get { return 24; } }
        public override int ReduceCast { get { return 200; } }
        public override int StrReq { get { return 21; } }
        public override int MenReq { get { return 42; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 1000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override WeaponType WeaponType { get { return WeaponType.Spear; } }

        public BambooSpear()
            : base(34)
        {
        }

        public BambooSpear(Serial serial)
            : base(serial)
        {
            m_ItemID = 34;
        }
    }
}
