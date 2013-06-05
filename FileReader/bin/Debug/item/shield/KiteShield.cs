using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class KiteShield : BaseArmor
	{
		public override string Name { get { return "Kite Shield"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 560; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1000; } }
		public override int InitMaxHits { get { return 1000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public KiteShield() : base (17)
		{
		}

		public KiteShield(Serial serial) : base (serial)
		{
		}
	}
}
