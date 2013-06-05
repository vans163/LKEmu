using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class FullLifeDrug : BasePotion
    {
        public override string Name { get { return "Full Life Drug"; } }
        public override ulong BuyPrice { get { return 500; } }

        public FullLifeDrug()
            : base(22)
        {
        }

        public FullLifeDrug(Serial serial)
            : base(serial)
        {
            m_ItemID =22;
        }

        public override void Use(Player player)
        {
            player.HPCur = player.HP;
            base.Use(player);
        }
    }
}
