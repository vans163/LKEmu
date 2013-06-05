using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class TriangleShield : BaseArmor
	{
		public override string Name { get { return "Triangle Shield"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 26; } }

		public override int StrReq { get { return 151; } }
		public override int DexReq { get { return 45; } }

		public override int InitMinHits { get { return 280; } }
		public override int InitMaxHits { get { return 280; } }
        public override int SellPrice { get { return 5000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Shield; } }

		public TriangleShield() : base (17)
		{
		}

		public TriangleShield(Serial serial) : base (serial)
		{
		}
	}
}
