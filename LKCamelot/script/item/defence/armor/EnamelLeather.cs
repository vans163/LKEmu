using LKCamelot.library;
using LKCamelot.model;

namespace LKCamelot.script.item
{
	public class EnamelLeather : BaseArmor
	{
		public override string Name { get { return "Enamel Leather"; } }

		public override int DamBase { get { return 0; } }
		public override int ACBase { get { return 101; } }

		public override int StrReq { get { return 313; } }
		public override int DexReq { get { return 90; } }

		public override int InitMinHits { get { return 720; } }
		public override int InitMaxHits { get { return 720; } }
        public override int SellPrice { get { return 27500; } }

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

		public EnamelLeather() : base (6)
		{
		}

		public EnamelLeather(Serial serial) : base (serial)
		{
		}
	}
}
