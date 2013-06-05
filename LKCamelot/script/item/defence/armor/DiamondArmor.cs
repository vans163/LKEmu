using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class DiamondArmor : BaseArmor
    {
        public override string Name { get { return "DIAMOND ARMOR"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 200; } }

        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 0; } }

        public override int InitMinHits { get { return 300; } }
        public override int InitMaxHits { get { return 300; } }

        public override int APStage { get { return 3; } }

        public override int SellPrice { get { return 250000; } } 

        public override int LevelReq { get { return 110; } }
        public override Class ClassReq { get { return Class.Wizard | Class.Shaman; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public DiamondArmor()
            : base(8)
        {
        }

        public DiamondArmor(Serial serial)
            : base(serial)
        {
        }
    }
}
