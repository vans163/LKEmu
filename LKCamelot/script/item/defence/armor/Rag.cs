using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Rag : BaseArmor
	{
		public override string Name { get { return "Rag"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 8; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 80; } }
		public override int InitMaxHits { get { return 80; } }
        public override ulong BuyPrice { get { return 5000; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Rag() : base (5)
		{
		}

		public Rag(Serial serial) : base (serial)
		{
		}
	}
}
