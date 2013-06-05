using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Helmet : BaseArmor
	{
		public override string Name { get { return "HELMET"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 27; } }

		public override int StrReq { get { return 185; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 450; } }
		public override int InitMaxHits { get { return 450; } }
        public override int SellPrice { get { return 15000; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Helmet() : base (4)
		{
		}

		public Helmet(Serial serial) : base (serial)
		{
		}
	}
}
