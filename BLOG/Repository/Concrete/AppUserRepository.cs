using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using BLOG.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BLOG.Repository.Concrete
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext db;

        public AppUserRepository(AppDbContext db):base(db)
        {
            this.db = db;
        }
        public AppUser GetById(string id)
        {
            return db.Set<AppUser>().FirstOrDefault(a => a.Id == id);
        }

        public AppUser GetByIdIncludeCategory(string Id)
        {
           return db.Set<AppUser>().Include(a => a.Category).FirstOrDefault(a => a.Id == Id);
        }


    }
}
