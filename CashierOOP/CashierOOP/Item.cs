using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Item
    {
        
        public Item(string idItem, string nameItem, int priceItem, int stockItem)
        {
            IdItem = idItem;
            NameItem = nameItem;
            PriceItem = priceItem;
            StockItem = stockItem;
        }

        public string IdItem { get; set; }
        public string NameItem { get; set; }
        public int PriceItem { get; set; }
        public int StockItem { get; set; }

    }
}
