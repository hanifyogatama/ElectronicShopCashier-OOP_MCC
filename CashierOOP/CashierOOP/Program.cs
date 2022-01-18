using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Program 
    {
        static void Main(string[] args)
        {
           
            Catalog catalog = new Catalog();
            // Cashier cashier = new Cashier();
            bool backToMenu = true;
            bool isStay = true;
 
            string inputBack;
            do
            {
                Menu.GetMenuIntro();
                try
                {
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            CreateItem(isStay, catalog);
                            break;
                        case 2:
                            ShowItem(isStay, catalog);
                            break;
                        case 3:
                            SearchItem(isStay, catalog);
                            break;
                        case 4:
                            UpdateItem(isStay, catalog);
                            break;
                        case 5:
                            DeleteItem(isStay, catalog);
                            break;
                        case 6:
                        
                            break;
                        case 7:
                        
                            break;
                        case 8:
                            break;
                        case 9:
                            Console.WriteLine("Thank you");
                            backToMenu = false;
                            break;
                        default:
                            Utils.GetMessageAlert(ConsoleColor.Red, "Menu not available");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Utils.GetMessageAlert(ConsoleColor.Red, "Input is empty or wrong character");
                    Console.ReadKey();
                }
                
            } while (backToMenu);

        }

        public static void CreateItem(bool isStay, Catalog catalog)
        {
            while (isStay)
            {
                Console.Clear();
                catalog.AddItem();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void ShowItem(bool isStay, Catalog catalog)
        {
            while (isStay)
            {
                Console.Clear();
                catalog.DisplayAllitem();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void SearchItem(bool isStay, Catalog catalog)
        {
            while (isStay)
            {
                Console.Clear();
                catalog.SearchItem();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void UpdateItem(bool isStay, Catalog catalog)
        {
            while (isStay)
            {
                Console.Clear();
                catalog.UpdateItem();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }

        public static void DeleteItem(bool isStay, Catalog catalog)
        {
            while (isStay)
            {
                Console.Clear();
                catalog.DeleteItem();
                bool answerToStay = Menu.RepeatSubMenu(isStay);
                isStay = answerToStay;
            }
        }



    }
}
