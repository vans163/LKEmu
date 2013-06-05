using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SquareShield : BaseArmor
	{
		public override string Name { get { return "Square Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 15; } }

		public override int StrReq { get { return 93; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 180; } }
		public override int InitMaxHits { get { return 180; } }
        public override int SellPrice { get { return 4000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public SquareShield() : base (17)
		{
		}

		public SquareShield(Serial serial) : base (serial)
		{
		}
	}
}
