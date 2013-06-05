using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BoneMail : BaseArmor
	{
		public override string Name { get { return "Bone Mail"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 150; } }

		public override int StrReq { get { return 429; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 950; } }
		public override int InitMaxHits { get { return 950; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public BoneMail() : base (5)
		{
		}

		public BoneMail(Serial serial) : base (serial)
		{
		}
	}
}
