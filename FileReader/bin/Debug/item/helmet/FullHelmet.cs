using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FullHelmet : BaseArmor
	{
		public override string Name { get { return "Full Helmet"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 49; } }

		public override int StrReq { get { return 417; } }
		public override int DexReq { get { return 120; } }

		public override int InitMinHits { get { return 800; } }
		public override int InitMaxHits { get { return 800; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public FullHelmet() : base (4)
		{
		}

		public FullHelmet(Serial serial) : base (serial)
		{
		}
	}
}
