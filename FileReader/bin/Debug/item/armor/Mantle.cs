using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Mantle : BaseArmor
	{
		public override string Name { get { return "Mantle"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 39; } }

		public override int StrReq { get { return 118; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 300; } }
		public override int InitMaxHits { get { return 300; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Mantle() : base (5)
		{
		}

		public Mantle(Serial serial) : base (serial)
		{
		}
	}
}
