using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Enums.Querying;
using Domain.Core;

namespace Application.Interfaces
{
    public interface IRepository
    {
        List<Vehicle> GetList<T>(int pageNumber) where T : Vehicle;

        List<Vehicle> GetList<T>(int pageNumber, IComparer<Vehicle> comparer = null, Order order = Order.ASC) where T : Vehicle;

        Vehicle Get(int id);

        void AddNew<T>(string[] vehicle) where T : Vehicle;

        bool Delete(int id, string phoneNumber);

        void Bid(Vehicle vehicle, int amount);
    }
}
