using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ShineHelmet : BaseArmor
	{
		public override string Name { get { return "Shine Helmet"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 61; } }

		public override int StrReq { get { return 274; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 660; } }
		public override int InitMaxHits { get { return 660; } }
        public override int SellPrice { get { return 90000; } }

		public override Class ClassReq { get { return Class.Wizard; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public ShineHelmet() : base (4)
		{
		}

		public ShineHelmet(Serial serial) : base (serial)
		{
		}
	}
}
