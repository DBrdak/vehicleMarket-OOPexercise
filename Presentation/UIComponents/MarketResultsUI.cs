using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.Repositories;
using Domain.Common;
using Domain.Common.Enums.Querying;
using Domain.Core;
using Presentation.DisplayExtensions;

namespace Presentation.UIComponents
{
    public class MarketResultsUI : MarketUI
    {
        private static readonly Repository _repository = new ();
        private static List<Vehicle> vehicles = new();
        private static IComparer<Vehicle> _sortOpt = null;

        public static void DisplayResults(int pageNumber = 1, string T = nameof(Vehicle))
        {
            Console.Clear();
            DisplayNicely($"{"ID",-7} {"Marka",-15} {"Model", -20} {"Rok produkcji", -13} {"Przebieg", -12} {"Cena", -12}", ConsoleColor.Blue);

            vehicles = HandleCategoryChoice(T, pageNumber);

            Console.WriteLine(vehicles.ListToString());

            var isPageChangeAllowed = HandlePagination(pageNumber, vehicles.Count);

            var input = Console.ReadLine();
            HandleResultDisplay(pageNumber, input, isPageChangeAllowed, T);
        }

        private static void HandleFilter()
        {
            //TODO
        }

        private static void HandleResultDisplay(int pageNumber, string input, bool[] isPageChangeAllowed, string searchType)
        {
            switch (input, isPageChangeAllowed[1], isPageChangeAllowed[0])
            {
                case (">", true, _):
                    Console.Clear();
                    DisplayResults(pageNumber += 1);
                    break;
                case ("<", _, true):
                    Console.Clear();
                    DisplayResults(pageNumber -= 1);
                    break;
                case (">", false, _):
                    Console.Clear();
                    DisplayResults(pageNumber);
                    break;
                case ("<", _, false):
                    Console.Clear();
                    DisplayResults(pageNumber);
                    break;
                case ("s", _, _):
                    HandleSorting(searchType);
                    break;
                case ("x", _, _):
                    Console.Clear();
                    DisplayMainPage();
                    break;
                case ("f", _, _):
                    Console.Clear();
                    //HandleFilter();
                    break;
                default:
                    try
                    {
                        Console.Clear();
                        var vehicle = _repository.Get(int.Parse(input));
                        DisplaySingle(vehicle);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }

                    break;
            }
        }

        private static void HandleSorting(string T)
        {
            Console.Clear();
            Console.WriteLine("Wybierz rodzaj sortowania:");
            Console.WriteLine("(1) Marka\n(2) Wiek\n(3) Przebieg\n(4) Cena");
            var input = Console.ReadLine().Split('-');

            switch (input[0])
            {
                case ("1"):
                    _sortOpt = new Sorter.MakeSort();
                    DisplayResults(1, T);
                    break;
                case ("2"):
                    _sortOpt = new Sorter.AgeSort();
                    DisplayResults(1, T);
                    break;
                case ("3"):
                    _sortOpt = new Sorter.MileageSort();
                    DisplayResults(1, T);
                    break;
                case ("4"):
                    _sortOpt = new Sorter.PriceSort();
                    DisplayResults(1, T);
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    _sortOpt = null;
                    DisplayResults(1, T);
                    break;
            }
        }

        private static List<Vehicle> HandleCategoryChoice(string T, int pageNumber)
        {
            switch (T)
            {
                case "Vehicle":
                    return _repository.GetList<Vehicle>(pageNumber, _sortOpt);
                    break;
                case "2":
                    return _repository.GetList<Truck>(pageNumber, _sortOpt);
                    break;
                case "1":
                    return _repository.GetList<Car>(pageNumber, _sortOpt);
                    break;
                case "3":
                    return _repository.GetList<Motorbike>(pageNumber, _sortOpt);
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayResults();
                    break;
            }

            return null;
        }

        private static bool[] HandlePagination(int pageNumber, int vehiclesCount)
        {
            var (nextPageAllowed, prevPageAllowed) = (false, false);
            var baseMessage = "(ID) Wyświetl ogłoszenie o żądanym ID (s) Opcje sortowania (f) Opcje filtrowania (x) Wróć do strony głównej";

            switch ((pageNumber <= 1, vehiclesCount < 10))
            {
                case (true, true):
                    Console.WriteLine(baseMessage);
                    break;
                case (true, false):
                    Console.WriteLine("(>) Następna strona " + baseMessage);
                    nextPageAllowed = true;
                    break;
                case (false, true):
                    Console.WriteLine("(<) Poprzednia strona " + baseMessage);
                    prevPageAllowed = true;
                    break;
                case (false, false):
                    Console.WriteLine("(<) Poprzednia strona (>) Następna strona " + baseMessage);
                    prevPageAllowed = true;
                    nextPageAllowed = true;
                    break;
            }

            return new [] {prevPageAllowed, nextPageAllowed};
        }

        private static void DisplaySingle(Vehicle vehicle)
        {
            DisplaySplitedNicely(vehicle.ToDetailedString(), ConsoleColor.Blue);
            Console.WriteLine("\n(1) Licytuj (2) Wróć do wyszukiwarki");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    MarketCommandUI.DisplayBid();
                    break;
                case "2":
                    Console.Clear();
                    DisplayResults();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplaySingle(vehicle);
                    break;
            }
        }
    }
}
