using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypesRepository : Repository<CoverType>, ICoverTypesRepository
    {
        private ApplicationDbContext _db;

        public CoverTypesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
