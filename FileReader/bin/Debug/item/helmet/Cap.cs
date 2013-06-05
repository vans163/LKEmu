using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cap : BaseArmor
	{
		public override string Name { get { return "Cap"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 7; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 65; } }
		public override int InitMaxHits { get { return 65; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Helmet; } }

		public Cap() : base (4)
		{
		}

		public Cap(Serial serial) : base (serial)
		{
		}
	}
}
