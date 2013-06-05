using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FieldCap : BaseArmor
	{
		public override string Name { get { return "Field Cap"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 41; } }

		public override int StrReq { get { return 322; } }
		public override int DexReq { get { return 92; } }

		public override int InitMinHits { get { return 720; } }
		public override int InitMaxHits { get { return 720; } }
        public override int SellPrice { get { return 60000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public FieldCap() : base (4)
		{
		}

		public FieldCap(Serial serial) : base (serial)
		{
		}
	}
}
