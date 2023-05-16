using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private static List<Vehicle> _vehicles = new();
        private static IComparer<Vehicle> _sortOpt = null;
        private static string _filter = null;
        private static string[] _filterValue = null;
        private static string T = nameof(Vehicle);

        public static void GetUserAdvertisments()
        {
            _filter = "PhoneNumber";
            _filterValue = new[] { PhoneNumber };

            Console.Clear();
            DisplayNicely($"{"ID",-7} {"Marka",-15} {"Model",-20} {"Rok produkcji",-13} {"Przebieg",-12} {"Cena",-12}", ConsoleColor.Blue);
            _vehicles = _repository.GetList<Vehicle>().SetFilter(_filter, _filterValue[0]);
            Console.WriteLine(_vehicles.ListToString());
            Dispose();
        }

        public static void SetType(string type) => T = type;

        public static void DisplayResults(int pageNumber = 1)
        {
            Console.Clear();
            DisplayNicely($"{"ID",-7} {"Marka",-15} {"Model", -20} {"Rok produkcji", -13} {"Przebieg", -12} {"Cena", -12}", ConsoleColor.Blue);

            _vehicles = HandleCategoryChoice(T, pageNumber);

            Console.WriteLine(_vehicles.ListToString());

            var isPageChangeAllowed = HandlePagination(pageNumber, _vehicles.Count);
            var input = Console.ReadLine();

            HandleResultDisplay(pageNumber, input, isPageChangeAllowed, T);
        }

        private static void HandleFilter()
        {
            Console.WriteLine("Wybierz filtr:\n");
            Console.WriteLine("(1) Marka\n(2) Miasto\n(3) Cena\n(4) Rok produkcji\n(5) Przebieg\n(6) Twoje ogłoszenia\n(7) Wyczyść filtry");
            var filter = Console.ReadLine();
            string[] filterValue = null;
            if (filter != "6" && filter != "7")
            {
                Console.WriteLine("Wartość filtra [Format dla liczb: 100-200][Format dla tekstu: Audi]:");
                filterValue = new[] { Console.ReadLine() };

                if (char.IsDigit(filterValue[0].ElementAt(0)))
                    filterValue = filterValue[0].Split('-');
            }

            switch (filter)
            {
                case "1":
                    _filter = "Make";
                    _filterValue = filterValue;
                    DisplayResults();
                    break;
                case "2":
                    _filter = "City";
                    _filterValue = filterValue;
                    DisplayResults();
                    break;
                case "3":
                    _filter = "Price";
                    _filterValue = filterValue;
                    DisplayResults();
                    break;
                case "4":
                    _filter = "ProductionYear";
                    _filterValue = filterValue;
                    DisplayResults();
                    break;
                case "5":
                    _filter = "Mileage";
                    _filterValue = filterValue;
                    DisplayResults();
                    break;
                case "6":
                    _filter = "PhoneNumber";
                    _filterValue = new []{PhoneNumber};
                    DisplayResults();
                    break;
                case "7":
                    _filter = null;
                    _filterValue = null;
                    DisplayResults();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayResults();
                    break;
            }
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
                    Dispose();
                    DisplayMainPage();
                    break;
                case ("f", _, _):
                    Console.Clear();
                    HandleFilter();
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
                    DisplayResults();
                    break;
                case ("2"):
                    _sortOpt = new Sorter.AgeSort();
                    DisplayResults();
                    break;
                case ("3"):
                    _sortOpt = new Sorter.MileageSort();
                    DisplayResults();
                    break;
                case ("4"):
                    _sortOpt = new Sorter.PriceSort();
                    DisplayResults();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    _sortOpt = null;
                    DisplayResults();
                    break;
            }
        }

        private static List<Vehicle> HandleCategoryChoice(string T, int pageNumber)
        {
            var list = new List<Vehicle>();

            switch (T)
            {
                case "Vehicle":
                    list = _repository.GetList<Vehicle>(pageNumber, _sortOpt);
                    break;
                case "2":
                    list = _repository.GetList<Truck>(pageNumber, _sortOpt);
                    break;
                case "1":
                    list = _repository.GetList<Car>(pageNumber, _sortOpt);
                    break;
                case "3":
                    list = _repository.GetList<Motorbike>(pageNumber, _sortOpt);
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayResults();
                    break;
            }

            if (_filter != null && _filterValue != null && _filterValue.Length == 2)
                list = list.SetFilter(_filter, new Range(int.Parse(_filterValue[0]), int.Parse(_filterValue[1])));
            else if(_filter != null && _filterValue != null && _filterValue.Length == 1)
                list = list.SetFilter(_filter, _filterValue[0]);

            return list;
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

        public static void DisplaySingle(Vehicle vehicle)
        {
            DisplaySplitedNicely(vehicle.ToDetailedString(), ConsoleColor.Blue);
            var bidAllowed = false;

            if(PhoneNumber == vehicle.PhoneNumber)
                Console.WriteLine("\n(2) Wróć do wyszukiwarki");
            else
            {
                Console.WriteLine("\n(1) Licytuj (2) Wróć do wyszukiwarki");
                bidAllowed = true;
            }

            switch (Console.ReadLine(), bidAllowed)
            {
                case ("1", true):
                    Console.Clear();
                    MarketCommandUI.DisplayBid(vehicle);
                    break;
                case ("2", _):
                    Console.Clear();
                    DisplayResults();
                    break;
                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplaySingle(vehicle);
                    break;
            }
        }

        private static void Dispose()
        {
            _vehicles = new();
            _sortOpt = null;
            _filter = null;
            _filterValue = null;
            string T = nameof(Vehicle);
    }
    }
}
