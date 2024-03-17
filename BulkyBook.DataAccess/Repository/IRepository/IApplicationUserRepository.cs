using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    // Interface for ApplicationUser repository
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        // Inherits IRepository<T> for basic CRUD operations
    }
}

