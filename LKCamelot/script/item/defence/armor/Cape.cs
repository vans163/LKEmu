using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cape : BaseArmor
	{
		public override string Name { get { return "Cape"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 30; } }

		public override int StrReq { get { return 93; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 250; } }
		public override int InitMaxHits { get { return 250; } }
        public override ulong BuyPrice { get { return 75000; } }
        public override int SellPrice { get { return 5000; } }

        public override int APStage
        {
            get
            {
                var ret = 1;
                if (Parent != null)
                {
                    if (Parent.Class == (Class.Swordsman | Class.Knight))
                        ret = 1;
                    else if (Parent.Class == (Class.Shaman | Class.Wizard))
                        ret = 1;
                }
                return ret;
            }
        }

		public override Class ClassReq { get { return 0; } }
		public override ArmorType ArmorType { get { return ArmorType.Armor; } }

		public Cape() : base (6)
		{
		}

		public Cape(Serial serial) : base (serial)
		{
            m_ItemID = 6;
		}
	}
}
