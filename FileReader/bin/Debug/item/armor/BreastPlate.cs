using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BreastPlate : BaseArmor
	{
		public override string Name { get { return "Breast Plate"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 177; } }

		public override int StrReq { get { return 553; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1150; } }
		public override int InitMaxHits { get { return 1150; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public BreastPlate() : base (5)
		{
		}

		public BreastPlate(Serial serial) : base (serial)
		{
		}
	}
}
