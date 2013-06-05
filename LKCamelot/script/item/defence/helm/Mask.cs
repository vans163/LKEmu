using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Mask : BaseArmor
	{
		public override string Name { get { return "MASK"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 15; } }

		public override int StrReq { get { return 101; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 180; } }
		public override int InitMaxHits { get { return 180; } }
        public override ulong BuyPrice { get { return 50000; } }
        public override int SellPrice { get { return 5000; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Mask() : base (4)
		{
		}

		public Mask(Serial serial) : base (serial)
		{
            m_ItemID = 4;
		}
	}
}
