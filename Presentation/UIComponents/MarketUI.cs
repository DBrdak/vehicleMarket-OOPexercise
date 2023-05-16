using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UIComponents
{
    public class MarketUI : UI
    {
        public static void DisplayMarket()
        {
            DisplayNicely("Wyszukiwarka ogłoszeń", ConsoleColor.Blue);
            Console.WriteLine("(1) Wyświetl wszystkie ogłoszenia\n(2) Wybierz kategorię\n(3) Dodaj ogłoszenie\n(4) Usuń ogłoszenie");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    MarketResultsUI.DisplayResults();
                    break;
                case "2":
                    Console.WriteLine("(1) Samochody osobowe\n(2) Samochody ciężarowe\n(3) Motocykle");
                    var input = Console.ReadLine();
                    Console.Clear();
                    MarketResultsUI.SetType(input);
                    MarketResultsUI.DisplayResults();
                    break;
                case "3":
                    Console.Clear();
                    MarketCommandUI.DisplayCreationUI();
                    break;
                case "4":
                    Console.Clear();
                    MarketCommandUI.DisplayDeletionUI();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayMarket();
                    break;
            }
        }
    }
}
