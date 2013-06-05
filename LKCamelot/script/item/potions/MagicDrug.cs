using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class MagicDrug : BasePotion
    {
        public override string Name { get { return "Magic Drug"; } }
        public override ulong BuyPrice { get { return 250; } }

        public MagicDrug() : base(21)
        {
        }

        public MagicDrug(Serial serial): base(serial)
        {
            m_ItemID = 21;
        }

        public override void Use(Player player)
        {
            player.MPCur += player.MP / 2;
            base.Use(player);
        }
    }
}
