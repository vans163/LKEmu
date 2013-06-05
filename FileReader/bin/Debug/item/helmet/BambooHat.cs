using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BambooHat : BaseArmor
	{
		public override string Name { get { return "Bamboo Hat"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 121; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 230; } }
		public override int InitMaxHits { get { return 230; } }

		public override Class ClassReq { get { return Class.Shaman; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public BambooHat() : base (4)
		{
		}

		public BambooHat(Serial serial) : base (serial)
		{
		}
	}
}
