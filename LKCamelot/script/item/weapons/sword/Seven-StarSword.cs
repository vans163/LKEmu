using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class SevenStarSword : BaseWeapon
	{
		public override string Name { get { return "Seven-Star Sword"; } }

		public override int DamBase { get { return 120; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 583; } }
		public override int DexReq { get { return 166; } }

		public override int InitMinHits { get { return 900; } }
		public override int InitMaxHits { get { return 900; } }
		
		public override int SellPrice { get { return 35000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public SevenStarSword() : base (13)
		{
		}

		public SevenStarSword(Serial serial) : base (serial)
		{
		}
	}
}
