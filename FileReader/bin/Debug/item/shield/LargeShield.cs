using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class LargeShield : BaseArmor
	{
		public override string Name { get { return "Large Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 38; } }

		public override int StrReq { get { return 209; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 380; } }
		public override int InitMaxHits { get { return 380; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public LargeShield() : base (17)
		{
		}

		public LargeShield(Serial serial) : base (serial)
		{
		}
	}
}
