using BulkyBook.Models;


namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICoverTypesRepository : IRepository<CoverType>
    {
        void Update(CoverType category);
    }
}
