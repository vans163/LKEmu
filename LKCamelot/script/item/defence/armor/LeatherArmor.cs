using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class LeatherArmor : BaseArmor
	{
		public override string Name { get { return "Leather Armor"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 83; } }

		public override int StrReq { get { return 251; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 580; } }
		public override int InitMaxHits { get { return 580; } }
        public override int SellPrice { get { return 20000; } }

        public override int APStage
        {
            get
            {
                var ret = 2;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 2;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 2;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public LeatherArmor() : base (6)
		{
		}

		public LeatherArmor(Serial serial) : base (serial)
		{
		}
	}
}
