using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.npc
{
    public class Boy : BaseNPC
    {
        public override string Name { get { return "Boy"; } }
        public override string Map { get { return "Arnold"; } }
        public override string ChatString { get { return "Boy: Where is my toy sword."; } }
        public override int ID { get { return (int)LKCamelot.library.NPCs.AnvilBoy; } }
        public override int X { get { return 13; } }
        public override int Y { get { return 11; } }
        public override int Face { get { return 1; } }
        public override int Sprite { get { return 7; } }
        public override int aSpeed { get { return 1; } }
        public override int aFrames { get { return 1; } }

        List<script.item.Item> templ = new List<script.item.Item>()
            {
                new script.item.Rod(1),
                new script.item.ShortStaff(1),
                new script.item.Crook(1),

                new script.item.BambooSpear(1),
                new script.item.ShortSpear(1),
                new script.item.Skewer(1),
            };

        public override void Buy(model.Player player, int buyslot)
        {
            if (player.GetFreeSlot() != -1 && player.Gold >= templ[buyslot].BuyPrice)
            {
                LKCamelot.script.item.Item tempitem = null;
                if (buyslot == 0)
                {
                    tempitem = new script.item.Rod().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 1)
                {
                    tempitem = new script.item.ShortStaff().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 2)
                {
                    tempitem = new script.item.Crook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 3)
                {
                    tempitem = new script.item.BambooSpear().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 4)
                {
                    tempitem = new script.item.ShortSpear().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 5)
                {
                    tempitem = new script.item.Skewer().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }

                LKCamelot.model.World.NewItems.TryAdd(tempitem.m_Serial, tempitem);
                player.Gold -= (uint)templ[buyslot].BuyPrice;
            }

        }

        public Boy()
        {
        }

        public override GUMP Gump
        {
            get
            {
                return new GUMP((int)LKCamelot.library.NPCs.AnvilBoy, 0xff85, 0x03ff, 0x70, "Menu", templ);
            }
        }
    }
}
