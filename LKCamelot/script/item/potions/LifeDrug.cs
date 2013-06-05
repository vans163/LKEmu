using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class LifeDrug : BasePotion
    {
        public override string Name { get { return "Life Drug"; } }
        public override ulong BuyPrice { get { return 250; } }

        public LifeDrug()
            : base(20)
        {
        }

        public LifeDrug(Serial serial)
            : base(serial)
        {
            m_ItemID = 20;
        }

        public override void Use(Player player)
        {
            player.HPCur += player.HP / 2;
            base.Use(player);
        }
    }
}
