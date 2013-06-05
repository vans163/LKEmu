using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public enum PotionEffect
    {
    }

    public class BasePotion : Item
    {
        private PotionEffect m_PotionEffect;
        public PotionEffect PotionEffect
        {
            get
            {
                return m_PotionEffect;
            }
            set
            {
                m_PotionEffect = value;
          //      InvalidateProperties();
            }
        }
        /*

         */
        public override void Use(Player player)
        {
            Delete(player);
        }

        public BasePotion(int itemID) : base(itemID)
        {
        }

        public BasePotion(Serial serial) : base(serial)
        {
        }

        public override string ParsedStats
        {
            get
            {
                string ret = "";
                ret += Name;

                return ret;
            }
        }
    }
}
