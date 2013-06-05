using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Surplice : BaseArmor
	{
		public override string Name { get { return "Surplice"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 24; } }

		public override int StrReq { get { return 22; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 220; } }
		public override int InitMaxHits { get { return 220; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Surplice() : base (5)
		{
		}

		public Surplice(Serial serial) : base (serial)
		{
		}
	}
}
