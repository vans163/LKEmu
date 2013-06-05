using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BastardSword : BaseWeapon
	{
		public override string Name { get { return "Bastard Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 566; } }
		public override int DexReq { get { return 160; } }

		public override int InitMinHits { get { return 800; } }
		public override int InitMaxHits { get { return 800; } }

		public override Class ClassReq { get { return Class.Knight; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public BastardSword() : base (10)
		{
		}

		public BastardSword(Serial serial) : base (serial)
		{
		}
	}
}
