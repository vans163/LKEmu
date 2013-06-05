using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class Cope : BaseArmor
	{
		public override string Name { get { return "Cope"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 57; } }

		public override int StrReq { get { return 169; } }
		public override int DexReq { get { return 0; } }

		public override int InitMinHits { get { return 400; } }
		public override int InitMaxHits { get { return 400; } }
        public override int SellPrice { get { return 37500; } }

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

		public Cope() : base (6)
		{
		}

		public Cope(Serial serial) : base (serial)
		{
		}
	}
}
