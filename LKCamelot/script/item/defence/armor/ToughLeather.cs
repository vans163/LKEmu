using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ToughLeather : BaseArmor
	{
		public override string Name { get { return "Tough Leather"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 117; } }

		public override int StrReq { get { return 345; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 750; } }
		public override int InitMaxHits { get { return 750; } }
        public override int SellPrice { get { return 40000; } }

        public override int APStage
        {
            get
            {
                var ret = 2;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 2;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 2;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public ToughLeather() : base (6)
		{
		}

		public ToughLeather(Serial serial) : base (serial)
		{
		}
	}
}
