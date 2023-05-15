using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : Vehicle
    {
        List<Vehicle> GetList();

        Vehicle Get(int id);

        void AddNew(T vehicle);

        bool Delete(int id, string phoneNumber);

        bool Bid(int id, int amount);
    }
}
