using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class GrandeurHelmet : BaseArmor
	{
		public override string Name { get { return "Grandeur Helmet"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 513; } }
		public override int DexReq { get { return 146; } }

		public override int InitMinHits { get { return 1000; } }
		public override int InitMaxHits { get { return 1000; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public GrandeurHelmet() : base (4)
		{
		}

		public GrandeurHelmet(Serial serial) : base (serial)
		{
		}
	}
}
