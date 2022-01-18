using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierOOP
{
    public class Utils
    {

        public static void TableFormat(string id, string name, int price, int stock)
        {

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("|{0,-13}|{1,-23}|{2,-15}|{3,-6}|", "Id Item", "Name", "Price", "Stock");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("|{0,-13}|{1,-23}|{2,-15}|{3,-6}|", id, name, $"Rp. {Utils.FormatNominal(price)}", stock);
            Console.WriteLine("--------------------------------------------------------------");
        }

        public static string StringInputAlert(string stringInput, string msg, string msg2)
        {
            while ((string.IsNullOrEmpty(stringInput)) || string.IsNullOrWhiteSpace(stringInput))
            {
                GetMessageAlert(ConsoleColor.Red, msg, msg2);
                stringInput = Console.ReadLine();
            }
            return stringInput;
        }

        public static string FormatNominal(int number)
        {
            return number.ToString("#,##0");
        }

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
                    GetMessageAlert(ConsoleColor.Red, "input cannot be empty", msg);
                    continue;
                }
            }

            return input;
        }

        public static void GetMessageAlert(ConsoleColor color, string message1, string message2)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.Write(message2);
            Console.ResetColor();
        }

        public static void Loading()
        {
            Console.Write("Loading");
            for (int i = 0; i <= 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(400);
            }

        }

        public static void GetMessageAlert(ConsoleColor color, string message1)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message1);
            Console.ResetColor();
        }

        public static string GetEmptyStringAlert(string stringInput, string msg)
        {
            while (string.IsNullOrEmpty(stringInput) || string.IsNullOrWhiteSpace(stringInput))
            {
                Utils.GetMessageAlert(ConsoleColor.Red, "input cannot be empty");
                Utils.ClearTwoLinesAbove();
                Console.Write(msg);
                stringInput = Console.ReadLine();
            }
            return stringInput;
        }

        public static void ClearTwoLinesAbove()
        {
            System.Threading.Thread.Sleep(1400);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            RemoveCurrentConsoleLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            RemoveCurrentConsoleLine();
        }

        public static void RemoveCurrentConsoleLine()
        {
            int currentCursorLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursorLine);
        }
    }
}
