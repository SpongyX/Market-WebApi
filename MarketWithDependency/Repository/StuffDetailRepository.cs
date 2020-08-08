using MarketWithDependency.Contracts;
using MarketWithDependency.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWithDependency.Repository
{
    public class StuffDetailRepository : IStuffDetailRepository
    {
        private readonly MarketDbContext _db;

        public StuffDetailRepository(MarketDbContext db)
        {
            _db = db;
        }
        public bool Create(StuffDetail entity)
        {
            _db.stuffDetails.Add(entity);
            return Save();
        }

        public bool Delete(StuffDetail entity)
        {
            _db.stuffDetails.Remove(entity);
            return Save();
        }

        public ICollection<StuffDetail> FindAll()
        {
            var stuffdetails = _db.stuffDetails
                            .Include(q => q.Stuff)
                            .ToList();
            return stuffdetails;
        }

        public StuffDetail FindById(int id)
        {
            var stuffdetails = _db.stuffDetails
                                     .Include(q => q.Stuff)
                                     .FirstOrDefault(q => q.Id == id);
            return stuffdetails;
        }

        public ICollection<StuffDetail> GetStuffDetail(int stuffid)
        {
            var stuffdetailid = FindAll()
                            .Where(q => q.StuffId == stuffid)
                            .ToList();
            return stuffdetailid;
        }

        public bool isExists(int id)
        {
            var exists = _db.stuffDetails.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(StuffDetail entity)
        {
            _db.stuffDetails.Update(entity);
            return Save();
        }
    }
}
