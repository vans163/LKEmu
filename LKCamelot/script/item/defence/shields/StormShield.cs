using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class StormShield : BaseArmor
    {
        public override string Name { get { return "STORM SHIELD"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 110; } }

        public override int StrReq { get { return 956; } }
        public override int DexReq { get { return 650; } }

        public override int InitMinHits { get { return 880; } }
        public override int InitMaxHits { get { return 880; } }
        public override int SellPrice { get { return 75000; } }

        public override Class ClassReq { get { return Class.Knight; } }
        public override ArmorType ArmorType { get { return ArmorType.Shield; } }

        public StormShield()
            : base(19)
        {
        }

        public StormShield(Serial serial)
            : base(serial)
        {
        }
    }
}
