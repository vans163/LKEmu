using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class ChestGuard : BaseArmor
	{
		public override string Name { get { return "Chest Guard"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 119; } }

		public override int StrReq { get { return 373; } }
		public override int DexReq { get { return 107; } }

		public override int InitMinHits { get { return 770; } }
		public override int InitMaxHits { get { return 770; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public ChestGuard() : base (5)
		{
		}

		public ChestGuard(Serial serial) : base (serial)
		{
		}
	}
}
