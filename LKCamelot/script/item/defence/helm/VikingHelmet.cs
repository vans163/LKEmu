using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class VikingHelmet : BaseArmor
    {
        public override string Name { get { return "Viking Helmet"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 63; } }

        public override int StrReq { get { return 650; } }
        public override int DexReq { get { return 200; } }

        public override int InitMinHits { get { return 1000; } }
        public override int InitMaxHits { get { return 1000; } }
        public override int SellPrice { get { return 100000; } }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public VikingHelmet()
            : base(4)
        {
        }

        public VikingHelmet(Serial serial)
            : base(serial)
        {
        }
    }
}
