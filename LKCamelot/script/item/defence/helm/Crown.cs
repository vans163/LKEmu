using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Crown : BaseArmor
	{
		public override string Name { get { return "Crown"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 33; } }

		public override int StrReq { get { return 227; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 600; } }
		public override int InitMaxHits { get { return 600; } }
        public override ulong BuyPrice { get { return 100000; } }
        public override int SellPrice { get { return 20000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Wizard; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Crown() : base (4)
		{
		}

		public Crown(Serial serial) : base (serial)
		{
            m_ItemID = 4;
		}
	}
}
