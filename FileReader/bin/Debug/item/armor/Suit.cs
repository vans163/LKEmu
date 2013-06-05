using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Suit : BaseArmor
	{
		public override string Name { get { return "Suit"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 13; } }

		public override int StrReq { get { return 15; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 150; } }
		public override int InitMaxHits { get { return 150; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Suit() : base (5)
		{
		}

		public Suit(Serial serial) : base (serial)
		{
		}
	}
}
