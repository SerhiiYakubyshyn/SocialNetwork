using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IWorkPost: IWork
    {
        public IRepository<Models.Post> Posts { get; }
    }
}
