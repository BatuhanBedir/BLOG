using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using BLOG.Repository.Abstract;

namespace BLOG.Repository.Concrete
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private readonly AppDbContext db;

        public CategoryRepository(AppDbContext db):base(db)
        {
            this.db = db;
        }
    }
}
