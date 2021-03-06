using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class FullDress : BaseArmor
	{
		public override string Name { get { return "Full Dress"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 19; } }

		public override int StrReq { get { return 18; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 180; } }
		public override int InitMaxHits { get { return 180; } }
        public override ulong BuyPrice { get { return 15000; } }
        public override int SellPrice { get { return 3000; } }

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

		public FullDress() : base (6)
		{
		}

		public FullDress(Serial serial) : base (serial)
		{
            m_ItemID = 6;
		}
	}
}
