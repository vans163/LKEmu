using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class GrandeurPride : BaseArmor
    {
        public override string Name { get { return "GRANDEUR PRIDE"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 100; } }

        public override int StrReq { get { return 1025; } }
        public override int DexReq { get { return 765; } }
        public override int LevelReq { get { return 100; } }

        public override int InitMinHits { get { return 310; } }
        public override int InitMaxHits { get { return 310; } }
        public override int SellPrice { get { return 200000; } }

        public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public GrandeurPride()
            : base(180)
        {
        }

        public GrandeurPride(Serial serial)
            : base(serial)
        {
        }
    }
}
