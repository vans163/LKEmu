using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKCamelot.script.item
{
    public enum aucState
    {
        forsale = 1,
        sold = 2,
        claimed = 4
    }

    public class AuctionItem
    {
        public Item item;
        public ulong goldprice;
        public long agoldprice;
        public int flags;
        public int sellerSerial;
        public int buyerSerial;
        public aucState state;

        public AuctionItem(Item item, ulong goldprice, int flags, long agoldprice = 0)
        {
            this.item = item;
            this.goldprice = goldprice;
            this.flags = flags;
        }
    }
}
