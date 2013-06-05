using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BSAmulet : BaseArmor
    {
        public override string Name { get { return "BLESSED S-AMULET"; } }

        public override int DamBase { get { return 150; } }
        public override int ACBase { get { return 0; } }
        public override int MPBonus { get { return 250; } }
        public override int HitBonus { get { return 150; } }

        public override bool Blessed { get { return true; } }

        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 65; } }
        public override int InitMaxHits { get { return 65; } }
        public override ulong BuyPrice { get { return 8000; } }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Amulet; } }

        public BSAmulet()
            : base(82)
        {
        }

        public BSAmulet(Serial serial)
            : base(serial)
        {
        }
    }
}
