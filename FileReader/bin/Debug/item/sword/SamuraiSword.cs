using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SamuraiSword : BaseWeapon
	{
		public override string Name { get { return "Samurai Sword"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 550; } }
		public override int DexReq { get { return 157; } }

		public override int InitMinHits { get { return 800; } }
		public override int InitMaxHits { get { return 800; } }

		public override Class ClassReq { get { return Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public SamuraiSword() : base (10)
		{
		}

		public SamuraiSword(Serial serial) : base (serial)
		{
		}
	}
}
