using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class PythonScale : BaseArmor
    {
        public override string Name { get { return "Python Scale"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 120; } }

        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 300; } }
        public override int InitMaxHits { get { return 300; } }

        public override int APStage { get { return 3; } }

        public override int SellPrice { get { return 200000; } } 

        public override int LevelReq { get { return 100; } }
        public override Class ClassReq { get { return Class.Shaman; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public PythonScale()
            : base(8)
        {
        }

        public PythonScale(Serial serial)
            : base(serial)
        {
        }
    }
}
