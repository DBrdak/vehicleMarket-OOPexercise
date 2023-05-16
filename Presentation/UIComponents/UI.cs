using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.UIComponents
{
    public class UI
    {
        [RegularExpression("^\\+\\d{1,3}\\d{9}$")]
        private readonly string _phoneNumber;

        public UI()
        {
            //_phoneNumber = SignIn();
            Console.Clear();
            DisplayMainPage();
        }

        protected static void DisplayMainPage()
        {
            DisplayNicely("Witaj w Vehicle Market!", ConsoleColor.Green);
            Console.WriteLine("(1) Przejdź do wyszukiwania\n(2) Pokaż instrukcję korzystania z aplikacji");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    MarketUI.DisplayMarket();
                    break;
                case "2":
                    Console.Clear();
                    ManualUI.DisplayManual();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayMainPage();
                    break;
            }
        }

        //private string SignIn()
        //{
        //    bool validationResult = true;
        //    string input;

        //    do
        //    {
        //        Console.Write("(Logowanie) Podaj numer telefonu [Format: +48555666777]: ");
        //        input = Console.ReadLine();
        //        validationResult = Regex.IsMatch(input, "^\\+\\d{1,3}\\d{9}$");

        //        if (!validationResult)
        //        {
        //            DisplayError("Zły format");
        //        }

        //    } while (!validationResult);

        //    return input;
        //}

        protected static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
        }

        protected static void DisplayNicely(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected static void DisplaySplitedNicely(string message, ConsoleColor color)
        {
            var arr = message.Split('\n');

            foreach (var item in arr)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(item.Split(':')[0]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(item.Split(':')[1]);
            }
        }
    }
}
