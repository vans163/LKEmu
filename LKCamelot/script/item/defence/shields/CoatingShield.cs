using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class CoatingShield : BaseArmor
	{
		public override string Name { get { return "Coating Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 59; } }

		public override int StrReq { get { return 325; } }
		public override int DexReq { get { return 92; } }

		public override int InitMinHits { get { return 600; } }
		public override int InitMaxHits { get { return 600; } }
        public override int SellPrice { get { return 11000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public CoatingShield() : base (18)
		{
		}

		public CoatingShield(Serial serial) : base (serial)
		{
		}
	}
}
