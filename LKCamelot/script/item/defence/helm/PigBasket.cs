using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class PigBasket : BaseArmor
    {
        public override string Name { get { return "PigBasket"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 70; } }

        public override int StrReq { get { return 438; } }
        public override int DexReq { get { return 312; } }
        public override int MenReq { get { return 308; } }

        public override int InitMinHits { get { return 310; } }
        public override int InitMaxHits { get { return 310; } }
        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return Class.Shaman; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public PigBasket()
            : base(44)
        {
        }

        public PigBasket(Serial serial)
            : base(serial)
        {
        }
    }
}
