using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class RoundShield : BaseArmor
	{
		public override string Name { get { return "Round Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 8; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 80; } }
		public override int InitMaxHits { get { return 80; } }

		public override Class ClassReq { get { return Class.Beginner | Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public RoundShield() : base (17)
		{
		}

		public RoundShield(Serial serial) : base (serial)
		{
		}
	}
}
