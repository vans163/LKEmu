using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class HornHelmet : BaseArmor
	{
		public override string Name { get { return "Horn Helmet"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 206; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 525; } }
		public override int InitMaxHits { get { return 525; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public HornHelmet() : base (4)
		{
		}

		public HornHelmet(Serial serial) : base (serial)
		{
		}
	}
}
