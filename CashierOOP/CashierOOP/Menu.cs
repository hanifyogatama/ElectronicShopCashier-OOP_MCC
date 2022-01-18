using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Menu
    {
        public static void GetMenuIntro()
        {
            Console.Clear();
            Console.WriteLine("Catalog Menu");
            Console.WriteLine("1) Add Item");
            Console.WriteLine("2) List Item");
            Console.WriteLine("3) Search Item");
            Console.WriteLine("4) Update Item");
            Console.WriteLine("5) Delete Item\n");
            Console.WriteLine("Transaction Menu");
            Console.WriteLine("6) Transaction");
            Console.WriteLine("7) History Transaction");
            Console.WriteLine("9) Exit\n");
            Console.Write("Choose Option : ");
        }

        public static bool RepeatSubMenu(bool isStay)
        {
            bool isReapeatDialog = true;

            while (isReapeatDialog)
            {
                Console.Write("Back to main menu [y] or repeat this section [n] : ");
                string inputBack = Console.ReadLine().ToLower().Trim();
                switch (inputBack)
                {
                    case "y":
                        isStay = false;
                        isReapeatDialog = false;
                        break;
                    case "n":
                        isStay = true;
                        isReapeatDialog = false;
                        break;
                    default:
                        Utils.GetMessageAlert(ConsoleColor.Red, "input an invalid");
                        Console.ReadLine();
                        isReapeatDialog = true;
                        break;
                }
            }
            return isStay;
        }
    }
}
