using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Data;
using Application.Interfaces;
using Domain.Core;

namespace Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : Vehicle
    {
        private readonly List<Vehicle> _context = DataContext.Vehicles;

        public List<Vehicle> GetList()
        {
            return _context
                .Where(v => v.GetType() == typeof(T))
                .ToList();
        }

        public Vehicle Get(int id)
        {
            var vehicle =  _context.FirstOrDefault(v => v.Id == id);

            if(vehicle is null)
                return null;

            return vehicle;
        }

        public void AddNew(T vehicle) => _context.Add(vehicle);

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
