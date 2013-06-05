using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class HardLeather : BaseArmor
	{
		public override string Name { get { return "Hard Leather"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 92; } }

		public override int StrReq { get { return 282; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 660; } }
		public override int InitMaxHits { get { return 660; } }
        public override int SellPrice { get { return 30000; } }

        public override int APStage
        {
            get
            {
                var ret = 1;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 1;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 2;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public HardLeather() : base (6)
		{
		}

		public HardLeather(Serial serial) : base (serial)
		{
		}
	}
}
