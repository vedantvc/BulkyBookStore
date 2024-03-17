using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
namespace BulkyBook.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db; // Database context field

        // Constructor to initialize the repository with the database context
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; // Assigning the injected ApplicationDbContext to the private field _db
        }
    }
}
