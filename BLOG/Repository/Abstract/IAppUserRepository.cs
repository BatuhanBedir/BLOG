using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;

namespace BLOG.Repository.Abstract
{
    public interface IAppUserRepository:IRepository<AppUser>//
    {
        public AppUser GetById(string id);
        public AppUser GetByIdIncludeCategory(string Id);

        
        //public AppUser IncludeCategory(string appUserId);
    }
}
