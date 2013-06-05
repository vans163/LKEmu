using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class WidePlate : BaseArmor
	{
		public override string Name { get { return "Wide Plate"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 673; } }
		public override int DexReq { get { return 190; } }

		public override int InitMinHits { get { return 1400; } }
		public override int InitMaxHits { get { return 1400; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public WidePlate() : base (5)
		{
		}

		public WidePlate(Serial serial) : base (serial)
		{
		}
	}
}
