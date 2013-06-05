using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FullPlate : BaseArmor
	{
		public override string Name { get { return "Full Plate"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 714; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1500; } }
		public override int InitMaxHits { get { return 1500; } }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public FullPlate() : base (5)
		{
		}

		public FullPlate(Serial serial) : base (serial)
		{
		}
	}
}
using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Ring : BaseWeapon
	{
		public override string Name { get { return "Ring"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1000; } }
		public override int InitMaxHits { get { return 1000; } }

		public override Class ClassReq { get { return 0; } }
		public override WeaponType WeaponType { get { return WeaponType.Ring; } }

		public Ring() : base (10)
		{
		}

		public Ring(Serial serial) : base (serial)
		{
		}
	}
}
using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Amulet : BaseWeapon
	{
		public override string Name { get { return "Amulet"; } }

		public override int DamBase { get { return ; } }
		public override int ACBase { get { return ; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 1000; } }
		public override int InitMaxHits { get { return 1000; } }

		public override Class ClassReq { get { return 0; } }
		public override WeaponType WeaponType { get { return WeaponType.Amulet; } }

		public Amulet() : base (10)
		{
		}

		public Amulet(Serial serial) : base (serial)
		{
		}
	}
}
