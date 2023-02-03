using BLOG.Entities.Concrete;

namespace BLOG.Repository.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        public Category GetById(int id);
    }
}
