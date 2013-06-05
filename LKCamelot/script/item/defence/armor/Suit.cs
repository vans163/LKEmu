using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Suit : BaseArmor
	{
		public override string Name { get { return "SUIT"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 13; } }

		public override int StrReq { get { return 15; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 150; } }
		public override int InitMaxHits { get { return 150; } }
        public override ulong BuyPrice { get { return 5000; } }
        public override int SellPrice { get { return 1000; } }

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

		public Suit() : base (5)
		{
		}

		public Suit(Serial serial) : base (serial)
		{
            m_ItemID = 5;
		}
	}
}
