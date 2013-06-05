using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;
using LKCamelot.model;
namespace LKCamelot.script.item
{
    public enum ArmorType
    {
        Shield = 1,
        Armor = 2,
        Helmet = 3,
        Ring = 4,
        Amulet = 5,
    }

    public enum Upgrade
    {
        None = 0,
        Graceful = 1,
        Glorious = 2,
        Brilliance = 3,
        Honesty = 4,
        Venerable = 5,
        Valuable = 6,
        Loyal = 7,
        Holy = 8,
        Sacrosant = 9,
        Godly = 10,
    }

    public interface IAura
    {
        int Aura();
    }

    public class BaseArmor : Item
    {
        public virtual int InitMinHits { get { return 0; } }
        public virtual int InitMaxHits { get { return 0; } }

        public virtual ArmorType ArmorType { get { return 0; } }
        public virtual Upgrade Upgrade { get { return 0; } }

        public virtual int APStage { get { return 0; } }

        public BaseArmor(int itemID) : base(itemID)
        {
            //m_HitPoints = m_MaxHitPoints = Utility.RandomMinMax( InitMinHits, InitMaxHits );
        }

        public BaseArmor(LKCamelot.model.Serial serial)
            : base(serial)
        {
        }
    }
}

//private static Random m_Random = new Random();

/*
		public static int RandomMinMax( int min, int max )
		{
			if ( min > max )
			{
				int copy = min;
				min = max;
				max = copy;
			}
			else if ( min == max )
			{
				return min;
			}

			return min + m_Random.Next( (max - min) + 1 );
		}
*/