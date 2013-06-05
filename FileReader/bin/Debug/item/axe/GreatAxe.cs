using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class GreatAxe : BaseWeapon
	{
		public override string Name { get { return "Great Axe"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 168; } }

		public override int StrReq { get { return 660; } }
		public override int DexReq { get { return 189; } }

		public override int InitMinHits { get { return 1100; } }
		public override int InitMaxHits { get { return 1100; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public GreatAxe() : base (14)
		{
		}

		public GreatAxe(Serial serial) : base (serial)
		{
		}
	}
}
