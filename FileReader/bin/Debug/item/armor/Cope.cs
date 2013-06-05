using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cope : BaseArmor
	{
		public override string Name { get { return "Cope"; } }

		public override int DamBase { get { return 57; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 169; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 400; } }
		public override int InitMaxHits { get { return 400; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Cope() : base (5)
		{
		}

		public Cope(Serial serial) : base (serial)
		{
		}
	}
}
