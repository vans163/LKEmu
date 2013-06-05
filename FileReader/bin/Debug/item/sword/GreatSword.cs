using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class GreatSword : BaseWeapon
	{
		public override string Name { get { return "Great Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 157; } }

		public override int StrReq { get { return 620; } }
		public override int DexReq { get { return 176; } }

		public override int InitMinHits { get { return 1200; } }
		public override int InitMaxHits { get { return 1200; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public GreatSword() : base (10)
		{
		}

		public GreatSword(Serial serial) : base (serial)
		{
		}
	}
}
