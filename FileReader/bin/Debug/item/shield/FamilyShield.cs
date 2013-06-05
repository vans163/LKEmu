using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FamilyShield : BaseArmor
	{
		public override string Name { get { return "Family Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 94; } }

		public override int StrReq { get { return 501; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 880; } }
		public override int InitMaxHits { get { return 880; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public FamilyShield() : base (17)
		{
		}

		public FamilyShield(Serial serial) : base (serial)
		{
		}
	}
}
