using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class BraveRing : BaseArmor
    {
        public override string Name { get { return "RING OF BRAVERY"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 0; } }
        public override int ReduceSwing { get { return 150; } }


        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 65; } }
        public override int InitMaxHits { get { return 65; } }
        public override ulong BuyPrice { get { return 8000; } }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Ring; } }

        public BraveRing()
            : base(1)
        {
        }

        public BraveRing(Serial serial)
            : base(serial)
        {
        }
    }
}
