using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.npc
{
    public class Arnold : BaseNPC
    {
        public override string Name { get { return "Arnold"; } }
        public override string Map { get { return "Arnold"; } }
        public override string ChatString { get { return "Arnold: Click on me to see the menu."; } }
        public override int ID { get { return (int)LKCamelot.library.NPCs.Arnold; } }
        public override int X { get { return 9; } }
        public override int Y { get { return 9; } }
        public override int Face { get { return 1; } }
        public override int Sprite { get { return 1; } }
        public override int aSpeed { get { return 4; } }
        public override int aFrames { get { return 7; } }

        List<script.item.Item> templ = new List<script.item.Item>()
            {
                new script.item.Suit((LKCamelot.model.Serial)1),
                new script.item.Surplice(1),
                new script.item.Cape(1),
                new script.item.Robe(1),

                new script.item.BambooKnife(1),
                new script.item.WoodenSword(1),
                new script.item.ShortSword(1),
                new script.item.Saw(1),

                new script.item.SpikedClub(1),
                new script.item.MorningStar(1),
                new script.item.SmallShield(1),
                new script.item.Hood(1),

                new script.item.Crown(1),
                new script.item.Mask(1),
                new script.item.FullDress(1),
                new script.item.Mace(1),
            };

        public override void Buy(model.Player player, int buyslot)
        {
            if (player.GetFreeSlot() != -1 && player.Gold >= templ[buyslot].BuyPrice)
            {
                LKCamelot.script.item.Item tempitem = null;
                if (buyslot == 0)
                {
                    tempitem = new script.item.Suit().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 1)
                {
                    tempitem = new script.item.Surplice().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 2)
                {
                    tempitem = new script.item.Cape().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 3)
                {
                    tempitem = new script.item.Robe().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 4)
                {
                    tempitem = new script.item.BambooKnife().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 5)
                {
                    tempitem = new script.item.WoodenSword().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 6)
                {
                    tempitem = new script.item.ShortSword().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 7)
                {
                    tempitem = new script.item.Saw().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 8)
                {
                    tempitem = new script.item.SpikedClub().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 9)
                {
                    tempitem = new script.item.MorningStar().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 10)
                {
                    tempitem = new script.item.SmallShield().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 11)
                {
                    tempitem = new script.item.Hood().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 12)
                {
                    tempitem = new script.item.Crown().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 13)
                {
                    tempitem = new script.item.Mask().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 14)
                {
                    tempitem = new script.item.FullDress().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 15)
                {
                    tempitem = new script.item.Mace().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }

                LKCamelot.model.World.NewItems.TryAdd(tempitem.m_Serial, tempitem);
                player.Gold -= (uint)templ[buyslot].BuyPrice;
            }
        }

        public Arnold()
        {
        }

        public override GUMP Gump
        {
            get
            {
                return new GUMP((int)LKCamelot.library.NPCs.Arnold, 0xff85, 0x03ff, 0x70, "Menu", templ);
            }
        }
    }
}
