using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IWorkGroup: IWork
    {
        public IRepository<Models.Group> Groups { get; }
    }
}
