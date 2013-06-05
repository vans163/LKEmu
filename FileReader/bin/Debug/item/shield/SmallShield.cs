using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SmallShield : BaseArmor
	{
		public override string Name { get { return "Small Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 11; } }

		public override int StrReq { get { return 22; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 130; } }
		public override int InitMaxHits { get { return 130; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public SmallShield() : base (17)
		{
		}

		public SmallShield(Serial serial) : base (serial)
		{
		}
	}
}
