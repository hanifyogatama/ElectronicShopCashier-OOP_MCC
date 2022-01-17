using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Catalog 
    {
       
        public List<Item> _items { get; set; } = new List<Item>();
         
        private void GetAllItem(List<Item> items)
        {
            int no = 0;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|{0,-5}|{1,-13}|{2,-23}|{3,-15}|{4,-6}|", "No", "Id Item", "Name", "Price", "Stock");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine("|{0,-5}|{1,-13}|{2,-23}|{3,-15}|{4,-6}|", (no+1), item.IdItem , Capitalize(item.NameItem), $"Rp. {FormatNominal(item.PriceItem)}", item.StockItem);
                no++;
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        private void TableFormat(string id, string name, int price, int stock)
        {

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|{0,-13}|{1,-23}|{2,-15}|{3,-6}|", "Id Item", "Name", "Price", "Stock");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|{0,-13}|{1,-23}|{3,-15}|{3,-6}|", id, Capitalize(name), $"Rp. {FormatNominal(price)}", stock);
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void DisplayAllitem()
        {
            int itemLength = _items.Count;
            if (itemLength != 0)
            {
                GetAllItem(_items);
            }
            else
            {
                GetMessage(ConsoleColor.Yellow, "Record is empty");
            }
        }

        public void UpdateItem(string id)
        {
            var item = _items.FirstOrDefault(x => x.IdItem == id);
            if (item == null)
            {
                Console.WriteLine("Record not found");
            }
            else
            {
                TableFormat(item.IdItem, item.NameItem, item.PriceItem, item.StockItem);
                Console.Write("Update Name : ");
                string nameUpdate = StringInputAlert(Console.ReadLine(), "Name cannot be empty", "Update Name : ");



                Console.Write("Update Price : ");
                int priceUpdate = Convert.ToInt32(Console.ReadLine());
                int priceUpdateNew = InputLessZeroAlert(priceUpdate, "Update Price : ");

                Console.Write("Update Stock : ");
                int stockUpdate = Convert.ToInt32(Console.ReadLine());
                int stockUpdateNew = InputLessZeroAlert(stockUpdate, "Update Stock : ");

                item.NameItem = nameUpdate;
                item.PriceItem = priceUpdateNew;
                item.StockItem = stockUpdateNew;
                GetMessage(ConsoleColor.Green, "Record updated successfully");
                TableFormat(item.IdItem, item.NameItem, item.PriceItem, item.StockItem);
            }
        }

        public void DeleteItem(string id)
        {
            
            var item = _items.FirstOrDefault(i => i.IdItem == id);
            if (item == null)
            {
                Console.WriteLine("Record not found");
            }
            else
            {
                Console.WriteLine("Are you sure to delete this record");
                TableFormat(item.IdItem, item.NameItem, item.PriceItem, item.StockItem);
                //Console.WriteLine($"{item.IdItem} {item.NameItem} Rp. {FormatNominal(item.PriceItem)} {item.StockItem}");
                Console.WriteLine("Press y / n ");
                string choose = Console.ReadLine().ToUpper().Trim(); 
                switch(choose)
                {
                    case "Y":
                        _items.Remove(item);
                        GetMessage(ConsoleColor.Green, "Record deleted successfully");
                        break;
                    case "N":
                        GetMessage(ConsoleColor.Red, "Record failed to delete");
                        break;
                    default:
                        GetMessage(ConsoleColor.Red, "Invalid input");
                        break;
                } 
            }
        }

        public static string FormatNominal(int number)
        {
            return number.ToString("#,##0");
        }
        public static string Capitalize(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        // alert int in zero condition
        public static int InputLessZeroAlert(int input, string msg)
        {
            while (input <= 0)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    GetMessage(ConsoleColor.Red, "Inputan bukan angka atau kosong", msg);
                    continue;
                }
            }

            return input;
        }

        public static void GetMessage(ConsoleColor color, string message1)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.ResetColor();
        }

        public static void GetMessage(ConsoleColor color, string message1, string message2)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.ResetColor();
            Console.Write(message2);
        }

        public static string StringInputAlert(string stringInput, string msg, string msg2)
        {
            while ((string.IsNullOrEmpty(stringInput)) || string.IsNullOrWhiteSpace(stringInput))
            {
                GetMessage(ConsoleColor.Red, msg, msg2);
                stringInput = Console.ReadLine();
            }
            return stringInput;
        }

        public void itemLength()
        {
            var item = _items.Count();
            Console.WriteLine(item);
        }

    }
}
