using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Rapier : BaseWeapon
	{
		public override string Name { get { return "Rapier"; } }

		public override int DamBase { get { return 16; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 64; } }
		public override int DexReq { get { return 22; } }

		public override int InitMinHits { get { return 180; } }
		public override int InitMaxHits { get { return 180; } }
		
		public override int SellPrice { get { return 750; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public Rapier() : base (10)
		{
		}

		public Rapier(Serial serial) : base (serial)
		{
		}
	}
}
