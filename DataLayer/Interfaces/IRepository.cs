using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Find(int id);
        IEnumerable<T> GetAll();
        Task Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
