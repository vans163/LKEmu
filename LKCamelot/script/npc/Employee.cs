using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.npc
{
    public class Employee : BaseNPC
    {
        public override string Name { get { return "Employee"; } }
        public override string Map { get { return "Village1"; } }
        public override string ChatString { get { return "Employee: Click on me to see the menu."; } }
        public override int ID { get { return (int)LKCamelot.library.NPCs.Employee; } }
        public override int X { get { return 128; } }
        public override int Y { get { return 90; } }
        public override int Face { get { return 1; } }
        public override int Sprite { get { return 2; } }
        public override int aSpeed { get { return 1; } }
        public override int aFrames { get { return 1; } }

        List<script.item.Item> templ = new List<script.item.Item>()
            {
                new script.item.HealBook(1),
                new script.item.PlusHealBook(1),
                new script.item.ElectronicBallBook(1),
                new script.item.FireBallBook(1),

                new script.item.MagicArmorBook(1),
                new script.item.RainbowArmorBook(1),
                new script.item.GuardianSwordBook(1),
                new script.item.FireProtectorBook(1),

                new script.item.TeagueShieldBook(1),
                new script.item.MagicShieldBook(1),
                new script.item.ZigZagBook(1),
                new script.item.MentalSwordBook(1),

                new script.item.SidewinderBook(1),
                new script.item.Dai(1),
                new script.item.Zel(1),

            };

        public override void Buy(model.Player player, int buyslot)
        {
            if (player.GetFreeSlot() != -1 && player.Gold >= templ[buyslot].BuyPrice)
            {
                LKCamelot.script.item.Item tempitem = null;
                if (buyslot == 0)
                {
                    tempitem = new script.item.HealBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 1)
                {
                    tempitem = new script.item.PlusHealBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 2)
                {
                    tempitem = new script.item.ElectronicBallBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 3)
                {
                    tempitem = new script.item.FireBallBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 4)
                {
                    tempitem = new script.item.MagicArmorBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 5)
                {
                    tempitem = new script.item.RainbowArmorBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 6)
                {
                    tempitem = new script.item.GuardianSwordBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 7)
                {
                    tempitem = new script.item.FireProtectorBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                //
                if (buyslot == 8)
                {
                    tempitem = new script.item.TeagueShieldBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                        tempitem).Compile());
                }
                if (buyslot == 9)
                {
                    tempitem = new script.item.MagicShieldBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 10)
                {
                    tempitem = new script.item.ZigZagBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 11)
                {
                    tempitem = new script.item.MentalSwordBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 12)
                {
                    tempitem = new script.item.SidewinderBook().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 13)
                {
                    tempitem = new script.item.Dai().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }
                if (buyslot == 14)
                {
                    tempitem = new script.item.Zel().Inventory(player);
                    player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(
                       tempitem).Compile());
                }

                LKCamelot.model.World.NewItems.TryAdd(tempitem.m_Serial, tempitem);
                player.Gold -= (uint)templ[buyslot].BuyPrice;
            }

        }

        public Employee()
        {
        }

        public override GUMP Gump
        {
            get
            {
                return new GUMP((int)LKCamelot.library.NPCs.Employee, 0xff85, 0x03ff, 0x70, "Menu", templ);
            }
        }
    }
}
