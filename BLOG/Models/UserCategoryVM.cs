using BLOG.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BLOG.Models
{
    public class UserCategoryVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public string UserId { get; set; }

    }
}
