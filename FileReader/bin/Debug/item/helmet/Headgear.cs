using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Headgear : BaseArmor
	{
		public override string Name { get { return "Headgear"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 20; } }

		public override int StrReq { get { return 143; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 310; } }
		public override int InitMaxHits { get { return 310; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Headgear() : base (4)
		{
		}

		public Headgear(Serial serial) : base (serial)
		{
		}
	}
}
