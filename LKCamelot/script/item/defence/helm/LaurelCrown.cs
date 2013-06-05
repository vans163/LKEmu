using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class LaurelCrown : BaseArmor
    {
        public override string Name { get { return "LaurelCrown"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 90; } }

        public override int StrReq { get { return 325; } }
        public override int DexReq { get { return 725; } }
        public override int MenReq { get { return 1025; } }

        public override int InitMinHits { get { return 310; } }
        public override int InitMaxHits { get { return 310; } }
        public override int SellPrice { get { return 175000; } }

        public override Class ClassReq { get { return Class.Wizard; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public LaurelCrown()
            : base(47)
        {
        }

        public LaurelCrown(Serial serial)
            : base(serial)
        {
        }
    }
}
