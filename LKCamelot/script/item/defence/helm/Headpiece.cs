using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Headpiece : BaseArmor
	{
		public override string Name { get { return "Headpiece"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 10; } }

		public override int StrReq { get { return 60; } }
		public override int DexReq { get { return 18; } }

		public override int InitMinHits { get { return 120; } }
		public override int InitMaxHits { get { return 120; } }
        public override int SellPrice { get { return 4000; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Headpiece() : base (4)
		{
		}

		public Headpiece(Serial serial) : base (serial)
		{
		}
	}
}
