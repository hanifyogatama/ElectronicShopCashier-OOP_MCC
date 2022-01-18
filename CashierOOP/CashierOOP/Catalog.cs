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
                Console.WriteLine("|{0,-5}|{1,-13}|{2,-23}|{3,-15}|{4,-6}|", (no+1), item.IdItem , item.NameItem, $"Rp. {Utils.FormatNominal(item.PriceItem)}", item.StockItem);
                no++;
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void AddItem()
        {

            Console.Write("Id Item      : ");
            string idItem = Utils.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Id Item      : ");

            Console.Write("Name Item    : ");
            string nameItem = Utils.GetEmptyStringAlert(Console.ReadLine().ToLower().Trim(), "Name Item    : ");

            Console.Write("Price Item   : ");
            int priceItem = Convert.ToInt32(Console.ReadLine());
            int price = Utils.InputLessZeroAlert(priceItem, "Price Item   : ");

            Console.Write("Stock Item   : ");
            int stockItem = Convert.ToInt32(Console.ReadLine());
            int stock = Utils.InputLessZeroAlert(stockItem, "Stock Item   : ");

            var item = new Item(idItem, nameItem, price, stock);
            _items.Add(item);
            Utils.GetMessageAlert(ConsoleColor.Green, "Record has been added");
        }

        public void DisplayAllitem()
        {
            Console.WriteLine("List Item");
            int itemLength = _items.Count;
            if (itemLength != 0)
            {
                Console.WriteLine("Amount of data : {0}", itemLength);
                GetAllItem(_items);
            }
            else
            {
                Utils.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
        }

        public void SearchItem()
        {
            int lengthList = _items.Count();
            if (lengthList == 0)
            {
                Utils.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
            else
            {
                Console.Write("Search By Name : ");
                string inputIdItem = Console.ReadLine().ToLower();
                var isItemMatching = _items.Where(x => x.NameItem.Contains(inputIdItem)).ToList();

                if ((string.IsNullOrEmpty(inputIdItem)) || string.IsNullOrWhiteSpace(inputIdItem))
                {
                    Utils.GetMessageAlert(ConsoleColor.Red, "Input is invalid");
                }
                else
                {
                    GetAllItem(isItemMatching);
                }
            }
        }

        public void UpdateItem()
        {
            int lengthList = _items.Count();
            if (lengthList == 0)
            {
                Utils.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Update Item");
                DisplayAllitem();
                for (int i = 0; i <= _items.Count() - 1; i++)
                {
                    Item item1 = _items[i];
                    Console.Write("Enter Id Item : ");
                    string idItem = Console.ReadLine();
                    if (idItem == item1.IdItem)
                    {
                       
                        Console.Write("Update Name : ");
                        string nameUpdate = Utils.StringInputAlert(Console.ReadLine(), "Name item cannot be empty", "Update Name : ");

                        Console.Write("Update Price : ");
                        int priceUpdate = Convert.ToInt32(Console.ReadLine());
                        int priceUpdateNew = Utils.InputLessZeroAlert(priceUpdate, "Update Price : ");

                        Console.Write("Update Stock : ");
                        int stockUpdate = Convert.ToInt32(Console.ReadLine());
                        int stockUpdateNew = Utils.InputLessZeroAlert(stockUpdate, "Update Stock : ");

                        item1.NameItem = nameUpdate;
                        item1.PriceItem = priceUpdateNew;
                        item1.StockItem = stockUpdateNew;
                        Utils.TableFormat(item1.IdItem, item1.NameItem, item1.PriceItem, item1.StockItem);
                        Utils.GetMessageAlert(ConsoleColor.Green, "Record updated successfully");
                    }
                    else
                    {
                        Utils.GetMessageAlert(ConsoleColor.Red, "Id not found!");
                        Console.ReadKey();
                    }
                }
            }
        }

        public void DeleteItem()
        {
            int lengthList = _items.Count();
            if (lengthList == 0)
            {
                Utils.GetMessageAlert(ConsoleColor.Yellow, "Record is empty");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Delete Item");
                DisplayAllitem();
                Console.Write("Enter Id Item : ");
                string id = Console.ReadLine().Trim().ToLower();

                var item = _items.FirstOrDefault(i => i.IdItem == id);
                if (item == null)
                {
                    Console.WriteLine("Record not found");
                }
                else
                {
                    Console.WriteLine("Are you sure to delete this record");
                    Utils.TableFormat(item.IdItem, item.NameItem, item.PriceItem, item.StockItem);
                    Console.Write("Press y / n : ");
                    string choose = Console.ReadLine().ToUpper().Trim();
                    switch (choose)
                    {
                        case "Y":
                            _items.Remove(item);
                            Utils.GetMessageAlert(ConsoleColor.Green, "Record deleted successfully");
                            break;
                        case "N":
                            Utils.GetMessageAlert(ConsoleColor.Red, "Record failed to delete");
                            break;
                        default:
                            Utils.GetMessageAlert(ConsoleColor.Red, "Invalid input");
                            break;
                    }
                }
            }
        }
    }
}
