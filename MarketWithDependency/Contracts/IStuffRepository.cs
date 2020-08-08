using MarketWithDependency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWithDependency.Contracts
{
    public interface IStuffRepository : IRepositoryBase<Stuff>

    {
        ICollection<Stuff> GetStuff(int id);
    }
}
