using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;
using Application.Data;
using Application.Interfaces;
using Domain.Common;
using Domain.Common.Enums.Querying;
using Domain.Core;

namespace Application.Repositories
{
    public class Repository : IRepository
    {
        private static readonly List<Vehicle> _context = DataContext.Vehicles;

        public List<Vehicle> GetList<T>(int pageNumber) where T : Vehicle => 
            _context
                .Where(v => v.GetType().IsSubclassOf(typeof(T)) || v.GetType() == typeof(T))
                .Order().AtPage(pageNumber).ToList();

        public List<Vehicle> GetList<T>(int pageNumber, IComparer<Vehicle> comparer = null, Order order = Order.ASC) where T : Vehicle
        {
            var enumerable = _context
                .Where(v => v.GetType().IsSubclassOf(typeof(T)) || v.GetType() == typeof(T))
                .Order(comparer).AtPage(pageNumber).ToList();

            return enumerable;
        }

        public Vehicle Get(int id)
        {
            var vehicle =  _context.FirstOrDefault(v => v.Id == id);

            if(vehicle is null)
                return null;

            return vehicle;
        }

        public void AddNew<T>(T vehicle) where T : Vehicle => _context.Add(vehicle);

        public bool Delete(int id, string phoneNumber)
        {
            var vehicleToRemove = _context.FirstOrDefault(v => v.Id == id);

            if (vehicleToRemove is null)
                return false;

            _context.Remove(vehicleToRemove);
            return true;
        }

        public bool Bid(int id, int amount)
        {
            var vehicle = _context.FirstOrDefault(v => v.Id == id);

            if (vehicle is null)
                return false;

            vehicle.OnBid(amount);
            return true;
        }
    }
}
