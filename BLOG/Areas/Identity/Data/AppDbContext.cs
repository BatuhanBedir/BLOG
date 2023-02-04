using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLOG.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AppUser> AspNetUser { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AppUserEntityConfiguration());

        string adminRoleId = Guid.NewGuid().ToString();
        string standartRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole = new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" };
        IdentityRole standartRole = new IdentityRole { Id = standartRoleId, Name = "Standart", NormalizedName = "STANDART" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standartRole);

        string adminAppUserId = Guid.NewGuid().ToString();
        string standartAppUserId = Guid.NewGuid().ToString();
        var hasher = new PasswordHasher<IdentityUser>();

        AppUser adminUser = new AppUser
        {
            Id = adminAppUserId,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Description = "Admin",
            EmailConfirmed = true,
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        AppUser standartUser = new AppUser
        {
            Id=standartAppUserId,
            FirstName="Standart",
            LastName="Standart",
            Email="standart@standart.com",
            NormalizedEmail="STANDART@STANDART.COM",
            UserName="standart@standart.com",
            NormalizedUserName="STANDART@STANDART.COM",
            Description="Standart",
            EmailConfirmed=true,
        };
        standartUser.PasswordHash = hasher.HashPassword(standartUser, "Standart123!");

        builder.Entity<AppUser>().HasData(adminUser);
        builder.Entity<AppUser>().HasData(standartUser);

        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminAppUserId };
        IdentityUserRole<string> standartUserRole = new IdentityUserRole<string> { RoleId = standartRoleId, UserId = standartAppUserId };

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standartUserRole);

        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminAppUserId,
            Id=1,
            ClaimType="IsAdmin",
            ClaimValue="true",
        });
    }
}
