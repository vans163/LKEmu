using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GMArmor : BaseArmor
    {
        public override string Name { get { return "GM's Armor"; } }
        public override string FlavorText { get { return "\"Solid Gooold.\""; } }
        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 0; } }
        public override bool Blessed { get { return true; } }

        public override int ReduceCast { get { return 1500; } }
        public override int ReduceSwing { get { return 450; } }

        public override int InitMinHits { get { return 500; } }
        public override int InitMaxHits { get { return 500; } }

        public override int APStage { get { return 5; } }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public GMArmor()
            : base(78)
        {
        }

        public GMArmor(Serial serial)
            : base(serial)
        {
        }
    }
}
