using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class UnicornProtectoria : BaseArmor
    {
        public override string Name { get { return "Unicorn Protectoria"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 100; } }

        public override int StrReq { get { return 450; } }
        public override int DexReq { get { return 5000; } }
        public override int MenReq { get { return 7500; } }
        public override int VitReq { get { return 0; } }
        public override int LevelReq { get { return 240; } }

        public override int InitMinHits { get { return 310; } }
        public override int InitMaxHits { get { return 310; } }
        public override int SellPrice { get { return 250000; } }

        public override Class ClassReq { get { return Class.Wizard | Class.Shaman; } }
        public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

        public UnicornProtectoria()
            : base(45)
        {
        }

        public UnicornProtectoria(Serial serial)
            : base(serial)
        {
        }
    }
} 