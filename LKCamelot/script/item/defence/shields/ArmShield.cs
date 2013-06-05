using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ArmShield : BaseArmor
	{
		public override string Name { get { return "Arm Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 84; } }

		public override int StrReq { get { return 442; } }
		public override int DexReq { get { return 125; } }

		public override int InitMinHits { get { return 790; } }
		public override int InitMaxHits { get { return 790; } }
        public override int SellPrice { get { return 25000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public ArmShield() : base (19)
		{
		}

		public ArmShield(Serial serial) : base (serial)
		{
		}
	}
}
