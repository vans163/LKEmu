using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class Gold : Item
    {
        public override string Name { get { return Quantity+" Gold"; } }

        public Gold() : base(40) //40 41 42 43
        {
        }

        public Gold(Serial serial)
            : base(serial)
        {
        }

        public override void Use(Player player)
        {
            player.HPCur = player.HP;
            Delete(player);
        }
    }
}
