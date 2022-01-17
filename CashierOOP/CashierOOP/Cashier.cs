using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Cashier : Catalog
    {
        private List<Transaction> _transaction { get; set; } = new List<Transaction>();

        private void GetAllTrans(List<Transaction> transactions)
        {
            int no = 0;
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-5}|{1,-13}|{2,-13}|{3,-15}|{4,-15}|{5,-8}|{6,-17}|", "No", "Id Trans", "Id Item", "Name", "Price", "Qty", "Total");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (var transaction in transactions)
            {
                Console.WriteLine("|{0,-5}|{1,-13}|{2,-13}|{3,-15}|{4,-15}|{5,-8}|{6,-17}|", (no + 1), transaction.IdTransaction, transaction.IdItem, Capitalize(transaction.Name), $"Rp. {FormatNominal(transaction.Price)}", transaction.Quantity, $"Rp. {FormatNominal(transaction.Total)}");
                no++;
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }

        public void AddItem(Transaction transaction)
        {
            _transaction.Add(transaction);
        }

        public void DisplayAllTrans()
        {
            int itemLength = _transaction.Count;
            if (itemLength != 0)
            {
                GetAllTrans(_transaction);
            }
            else
            {
                Console.WriteLine("Record is empty");
            }
        }

    }
}
