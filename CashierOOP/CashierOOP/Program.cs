using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    internal class Program : Catalog
    {

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
           
            Catalog catalog = new Catalog();
            Cashier cashier = new Cashier();

            // int num = Convert.ToInt32(catalog._items.Count());
            



            bool isContinue2 = true;
            string inputBack;
            do
            {
                Console.Clear();
                Console.WriteLine("Catalog Menu");
                Console.WriteLine("1) Add Item");
                Console.WriteLine("2) List Item");
                Console.WriteLine("3) Delete Item");
                Console.WriteLine("4) Edit Item\n");
                Console.WriteLine("Transaction Menu");
                Console.WriteLine("5) Transaction");
                Console.WriteLine("6) History Transaction\n");
                Console.Write("Choose Option : ");
                string inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                    addItem:
                        Console.Clear();
                        Console.WriteLine("ADD ITEM");
                        Console.Write("Enter Id : ");
                        // string idItem = Console.ReadLine();
                        string idItem = StringInputAlert(Console.ReadLine(), "Id cannot be empty", "Enter Id : ");
                        Console.Write("Name Item : ");
                        string namaItem = Console.ReadLine();
                        Console.Write("Price Item : ");
                        int priveItem = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Stock Item : ");
                        int stockItem = Convert.ToInt32(Console.ReadLine());

                        var newItem = new Item(idItem, namaItem, priveItem, stockItem);
                        catalog.AddItem(newItem);
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto addItem;
                        }
                        break;
                    case "2":
                    listItem:
                        Console.Clear();
                        Console.WriteLine("List Item");
                        catalog.DisplayAllitem();
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto listItem;
                        }
                        break;
                    case "3":
                    deleteItem:
                        Console.Clear();
                        Console.WriteLine("DELETE ITEM");
                        catalog.DisplayAllitem();
                        Console.Write("Enter Id Item : ");
                        string id = Console.ReadLine().Trim();
                        catalog.DeleteItem(id);
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto deleteItem;
                        }
                        break;
                    case "4":
                    updateItem:
                        Console.Clear();
                        Console.WriteLine("UPDATE ITEM");
                        catalog.DisplayAllitem();
                        Console.Write("Enter Id Item : ");
                        string id2 = Console.ReadLine().Trim();
                        catalog.UpdateItem(id2);
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto updateItem;
                        }
                        break;
                    case "5":
                        transaction:
                        Console.Clear();
                        catalog.DisplayAllitem();
                        Console.WriteLine("Masukkan data");
                        

                        Console.Write("Id Transaction : ");
                        string idTransaction = Console.ReadLine();

                        Console.Write("Id Item : ");
                        string idItem2 = Console.ReadLine();

                        Console.Write("Name Item : ");
                        string nameItem = Console.ReadLine();

                        Console.Write("Price Item : Rp. ");
                        int priceItem = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Quantity Item : ");
                        int qtyItem = Convert.ToInt32(Console.ReadLine());

                        int total = priceItem + qtyItem;

                        var newTransaction = new Transaction(idTransaction, idItem2, nameItem, priceItem, qtyItem, total);
                        cashier.AddItem(newTransaction);

                        cashier.DisplayAllTrans();
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto transaction;
                        }
                        break;
                    case "6":
                        historyTrans:
                        Console.Clear();
                        Console.WriteLine("History Transaction");
                        cashier.DisplayAllTrans();
                        Console.Write("Back to menu catalog menu (Y/N): ");
                        inputBack = Console.ReadLine().ToUpper();
                        if (inputBack == "Y")
                        {
                            isContinue2 = true;
                        }
                        else if (inputBack == "N")
                        {
                            goto historyTrans;
                        }
                        break;
                        
                    default:
                        GetMessage(ConsoleColor.Red, "Input invalid try again");
                        break;
                }
            } while (isContinue2);

        }

        // exit
        static void Exit()
        {
            Console.WriteLine("Terima kasih");
            Environment.Exit(0);
        }

        
    }
}
