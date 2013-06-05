using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ChainMail : BaseArmor
	{
		public override string Name { get { return "Chain Mail"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 155; } }

		public override int StrReq { get { return 485; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1050; } }
		public override int InitMaxHits { get { return 1050; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public ChainMail() : base (5)
		{
		}

		public ChainMail(Serial serial) : base (serial)
		{
		}
	}
}
