using BLOG.Areas.Identity.Data;
using BLOG.Entities.Abstract;
using BLOG.Repository.Abstract;
using System.Linq.Expressions;

namespace BLOG.Repository.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext db;

        public GenericRepository(AppDbContext db)
        {
            this.db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                db.Set<T>().Add(entity);
                return db.SaveChanges() > 0;
            }
            catch 
            {
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                db.Set<T>().Remove(entity);
                return db.SaveChanges() > 0;
            }
            catch 
            {
                return false;
            }
        }
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }
        //public T GetById(int id)
        //{
        //    return db.Set<T>().FirstOrDefault(a => a.Id == id);
        //}
        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().SingleOrDefault(predicate);
        }
        public bool Update(T entity)
        {
            try
            {
                db.Set<T>().Update(entity);
                return db.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
