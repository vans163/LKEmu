using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class TwoHandSword : BaseWeapon
	{
		public override string Name { get { return "Two-Hand Sword"; } }

		public override int DamBase { get { return 122; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 500; } }
		public override int DexReq { get { return 144; } }

		public override int InitMinHits { get { return 900; } }
		public override int InitMaxHits { get { return 900; } }
		
		public override int SellPrice { get { return 50000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public TwoHandSword() : base (13)
		{
		}

		public TwoHandSword(Serial serial) : base (serial)
		{
		}
	}
}
