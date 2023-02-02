using BLOG.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BLOG.Areas.Identity.Data
{
    public class ArticleConfiguration
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Content).IsRequired();
        }
    }
}
