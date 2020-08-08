using MarketWithDependency.Contracts;
using MarketWithDependency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWithDependency.Repository
{
    public class StuffRepository : IStuffRepository
    {
        private readonly MarketDbContext _db;
        public StuffRepository(MarketDbContext db)
        {
            _db = db;
        }
        public bool Create(Stuff entity)
        {
            _db.Stuffs.Add(entity);
            return Save();
        }

        public bool Delete(Stuff entity)
        {
            _db.Stuffs.Remove(entity);
            return Save();
        }

        public ICollection<Stuff> FindAll()
        {
            var Stuff = _db.Stuffs.ToList();
            return Stuff;
        }

        public Stuff FindById(int id)
        {
            var stuff = _db.Stuffs.Find(id);
            return stuff;
        }

        public ICollection<Stuff> GetStuff(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Stuff entity)
        {
            _db.Stuffs.Update(entity);
            return Save();
        }
    }
}
