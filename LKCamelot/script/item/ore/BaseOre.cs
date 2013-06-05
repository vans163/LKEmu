using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LKCamelot.library;
using LKCamelot.model;
namespace LKCamelot.script.item
{
    public class BaseOre : Item
    {
        public enum OreTypeE
        {
            PB = 1,
            PN = 2,
            PG = 3,
        }

        public int Hits = 0;
        public virtual int XP { get { return 0; } }
        public override bool Stackable { get { return true; } }

        public virtual void SetSprite()
        {
            if (Stage == (int)OreTypeE.PG)
                m_ItemID = 1;
            if (Stage == (int)OreTypeE.PN)
                m_ItemID = 2;
            if (Stage == (int)OreTypeE.PB)
                m_ItemID = 3;
        }

        public virtual void DropOre(Player player)
        {
            var roll = Util.Random(1, 100);
            if (roll <= 20) Stage = (int)OreTypeE.PG;
            if (roll <= 50 && roll > 20) Stage = (int)OreTypeE.PN;
            if (roll > 50) Stage = (int)OreTypeE.PB;

            var tempitem = this.Inventory(player);
            (tempitem as BaseOre).SetSprite();
            if (tempitem.Quantity == 1)
            {
                player.client.SendPacket(new LKCamelot.model.AddItemToInventory2(tempitem).Compile());
                World.NewItems.TryAdd((tempitem as script.item.Item).m_Serial, (tempitem as script.item.Item));
            }
        }

        public BaseOre(int itemID)
            : base(itemID)
        {
            SetSprite();
        }

        public BaseOre(Serial serial)
            : base(serial)
        {
            SetSprite();
        }
    }
}
