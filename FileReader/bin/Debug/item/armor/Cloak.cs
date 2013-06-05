using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cloak : BaseArmor
	{
		public override string Name { get { return "Cloak"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 52; } }

		public override int StrReq { get { return 143; } }
		public override int DexReq { get { return 42; } }

		public override int InitMinHits { get { return 360; } }
		public override int InitMaxHits { get { return 360; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Cloak() : base (5)
		{
		}

		public Cloak(Serial serial) : base (serial)
		{
		}
	}
}
