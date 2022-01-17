using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Transaction : Catalog 
    {

        public Transaction(string idTransaction, string idItem, string name, int price, int quantity, int total)
        {
            IdTransaction = idTransaction;  
            IdItem = idItem;
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = total;
           
        }

        public string IdTransaction { get; set; }
        public string IdItem { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

    }
}
