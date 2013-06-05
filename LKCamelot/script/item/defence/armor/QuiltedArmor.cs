using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class QuiltedArmor : BaseArmor
	{
		public override string Name { get { return "Quilted Armor"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 66; } }

		public override int StrReq { get { return 194; } }
		public override int DexReq { get { return 56; } }

		public override int InitMinHits { get { return 480; } }
		public override int InitMaxHits { get { return 480; } }
        public override int SellPrice { get { return 5000; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

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
                        ret = 1;
                }
                return ret;
            }
        }

		public QuiltedArmor() : base (6)
		{
		}

		public QuiltedArmor(Serial serial) : base (serial)
		{
		}
	}
}
