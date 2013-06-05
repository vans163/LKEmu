using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
    public class AngelicArmor : BaseArmor
    {
        public override string Name { get { return "ANGELIC ARMOR"; } }

        public override int DamBase { get { return 0; } }
        public override int ACBase { get { return 190; } }

        public override int DexBonus { get { return 1000; } }
        public override int MenBonus { get { return 1500; } }

        public override int StrReq { get { return 0; } }
        public override int DexReq { get { return 3500; } }
        public override int MenReq { get { return 7500; } }

        public override int InitMinHits { get { return 300; } }
        public override int InitMaxHits { get { return 300; } }

        public override int SellPrice { get { return 500000; } } 

        public override int APStage
        {
            get
            {
                var ret = 3;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 4;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 3;
                }
                return ret;
            }
        }

        public override int LevelReq { get { return 240; } }
        public override Class ClassReq { get { return Class.Wizard | Class.Shaman; } }
        public override ArmorType ArmorType { get { return ArmorType.Armor; } }

        public AngelicArmor()
            : base(8)
        {
        }

        public AngelicArmor(Serial serial)
            : base(serial)
        {
        }
    }
} 