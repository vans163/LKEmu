using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BattleAxe : BaseWeapon
	{
		public override string Name { get { return "Battle Axe"; } }

		public override int DamBase { get { return 134; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 540; } }
		public override int DexReq { get { return 153; } }

		public override int InitMinHits { get { return 950; } }
		public override int InitMaxHits { get { return 950; } }
		
		public override int SellPrice { get { return 50000; } }

		public override Class ClassReq { get { return Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Axe; } }

		public BattleAxe() : base (16)
		{
		}

		public BattleAxe(Serial serial) : base (serial)
		{
		}
	}
}
