using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class Gladiator : BaseArmor
    {
        public override string Name { get { return "Gladiator"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 80; } }

        public override int StrReq { get { return 765; } }
        public override int DexReq { get { return 612; } }
        public override int LevelReq { get { return 90; } }

        public override int InitMinHits { get { return 310; } }
        public override int InitMaxHits { get { return 310; } }
        public override int SellPrice { get { return 150000; } }

        public override Class ClassReq { get { return 0; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public Gladiator()
            : base(181)
        {
        }

        public Gladiator(Serial serial)
            : base(serial)
        {
        }
    }
}
