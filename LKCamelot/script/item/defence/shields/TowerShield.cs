using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class TowerShield : BaseArmor
	{
		public override string Name { get { return "Tower Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 50; } }

		public override int StrReq { get { return 267; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 480; } }
		public override int InitMaxHits { get { return 480; } }
        public override int SellPrice { get { return 15000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public TowerShield() : base (18)
		{
		}

		public TowerShield(Serial serial) : base (serial)
		{
		}
	}
}
