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

        /// <summary>
        /// AppUser nesnesinin Category özelliğine(bilgisine) erişmek için Include yöntemini kullanır
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Category özelliği de dahil edilmiş AppUser nesnesini döndürür.</returns>
        public AppUser GetByIdIncludeCategory(string Id)
        {
           return db.Set<AppUser>().Include(a => a.Category).FirstOrDefault(a => a.Id == Id);
        }

        //    //sadwqd
        //    public AppUser IncludeCategory(string appUserId)
        //    {
        //        return db.Set<AppUser>().Include(q => q.Category).FirstOrDefault(a => a.Id == appUserId);
        //    }
    }
}
