using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class BambooKnife : BaseWeapon
	{
		public override string Name { get { return "Bamboo Knife"; } }

		public override int DamBase { get { return 4; } }
		public override int ACBase { get { return 0; } }

		public override int StrReq { get { return 0; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 70; } }
		public override int InitMaxHits { get { return 70; } }
       		public override ulong BuyPrice { get { return 1000; } }
       		public override int SellPrice { get { return 200; } }
        

		public override Class ClassReq { get { return Class.Beginner | Class.Knight | Class.Swordsman; } }
		public override WeaponType WeaponType { get { return WeaponType.Sword; } }

		public BambooKnife() : base (10)
		{
		}

		public BambooKnife(Serial serial) : base (serial)
		{
            m_ItemID = 10;
		}
	}
}
