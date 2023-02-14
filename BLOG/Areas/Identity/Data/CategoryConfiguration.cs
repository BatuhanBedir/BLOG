using BLOG.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLOG.Areas.Identity.Data
{
    public class CategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
