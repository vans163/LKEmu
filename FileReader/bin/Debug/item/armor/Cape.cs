using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cape : BaseArmor
	{
		public override string Name { get { return "Cape"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 30; } }

		public override int StrReq { get { return 93; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 250; } }
		public override int InitMaxHits { get { return 250; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Cape() : base (5)
		{
		}

		public Cape(Serial serial) : base (serial)
		{
		}
	}
}
