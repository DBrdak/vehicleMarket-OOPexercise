using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Car;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Common.Eventing;
using Domain.Motorbike;
using Domain.Truck;

namespace Presentation.UIComponents
{
    public class MarketCommandUI : MarketUI
    {
        private static Repository _repository = new();

        public static void DisplayDeletionUI()
        {
            MarketResultsUI.GetUserAdvertisments();

            Console.WriteLine("(ID) Usuń ogłoszenie o żądanym ID (x) Wróć do strony głównej");
            var input = Console.ReadLine();

            switch (input)
            {
                case "x":
                    Console.Clear();
                    DisplayMainPage();
                    break;

                default:
                    try
                    {
                        Console.Clear();
                        _repository.Delete(int.Parse(input), PhoneNumber);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                    break;
            }
            DisplayDeletionUI();
        }

        public static void DisplayCreationUI()
        {
            DisplayNicely("Podaj informacje o pojeździe", ConsoleColor.Blue);
            Console.WriteLine("Kategoria: (1) Samochód osobowy (2) Samochód ciężarowy (3) Motocykl");
            var category = Console.ReadLine();
            var values = new List<string>();

            switch (category)
            {
                case "1":
                    GetVehicleValues(values);
                    GetCarValues(values);
                    _repository.AddNew<Car>(values.ToArray());
                    break;

                case "2":
                    GetVehicleValues(values);
                    GetTruckValues(values);
                    _repository.AddNew<Truck>(values.ToArray());
                    break;

                case "3":
                    GetVehicleValues(values);
                    GetMotorbikeValues(values);
                    _repository.AddNew<Motorbike>(values.ToArray());
                    break;

                default:
                    DisplayError("Wybrano złą wartość, proszę spróbować ponownie");
                    DisplayCreationUI();
                    break;
            }

            MarketResultsUI.GetUserAdvertisments();

            Console.WriteLine("(inny klawisz) Dodaj kolejne ogłoszenie (x) Wróć do strony głównej");
            var input = Console.ReadLine();

            switch (input)
            {
                case "x":
                    Console.Clear();
                    DisplayMainPage();
                    break;

                default:
                    DisplayCreationUI();
                    break;
            }
        }

        private static void GetMotorbikeValues(List<string> values)
        {
            Console.Write("Rodzaj napędu: ");
            values.Add(Console.ReadLine().FromTranslatedString<DrivingType>());
            Console.Write("Rodzaj motocykla: ");
            values.Add(Console.ReadLine().FromTranslatedString<MotorbikeType>());
        }

        private static void GetTruckValues(List<string> values)
        {
            Console.Write("Moment obrotowy: ");
            values.Add(Console.ReadLine());
            Console.Write("DMC: ");
            values.Add(Console.ReadLine());
            Console.Write("Wymiary zabudowy: ");
            values.Add(Console.ReadLine());
            Console.Write("Liczba osi: ");
            values.Add(Console.ReadLine());
            Console.Write("Rodzaj zabudowy: ");
            values.Add(Console.ReadLine().FromTranslatedString<TruckType>());
        }

        private static void GetCarValues(List<string> values)
        {
            Console.Write("Liczba miejsc siedzących: ");
            values.Add(Console.ReadLine());
            Console.Write("Liczba drzwi: ");
            values.Add(Console.ReadLine());
            Console.Write("Wersja modelu: ");
            values.Add(Console.ReadLine());
            Console.Write("Rodzaj samochodu: ");
            values.Add(Console.ReadLine().FromTranslatedString<CarType>());
        }

        private static void GetVehicleValues(List<string> values)
        {
            Console.Write("Marka: ");
            values.Add(Console.ReadLine());
            Console.Write("Model: ");
            values.Add(Console.ReadLine());
            Console.Write("Rok produkcji: ");
            values.Add(Console.ReadLine());
            Console.Write("Przebieg: ");
            values.Add(Console.ReadLine());
            Console.Write("Moc: ");
            values.Add(Console.ReadLine());
            Console.Write("Pojemność skokowa: ");
            values.Add(Console.ReadLine());
            Console.Write("Rodzaj paliwa: ");
            values.Add(Console.ReadLine().FromTranslatedString<Fuel>());
            Console.Write("Miasto: ");
            values.Add(Console.ReadLine());
            values.Add(PhoneNumber);
            Console.Write("Cena: ");
            values.Add(Console.ReadLine());
        }

        public static void DisplayBid(Vehicle vehicle)
        {
            Console.WriteLine("Podaj kwotę o jaką chcesz podbić cenę:");
            var amount = int.Parse(Console.ReadLine());
            _repository.Bid(vehicle, amount);

            Thread.Sleep(2500);
            Console.Clear();
            MarketResultsUI.DisplaySingle(vehicle);
        }
    }
}