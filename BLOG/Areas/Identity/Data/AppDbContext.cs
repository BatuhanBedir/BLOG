using BLOG.Areas.Identity.Data;
using BLOG.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BLOG.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
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
        string standardRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole = new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" };
        IdentityRole standardRole = new IdentityRole { Id = standardRoleId, Name = "Standard", NormalizedName = "STANDARD" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standardRole);


        string adminAppUserId = Guid.NewGuid().ToString();
        string standardAppUserId = Guid.NewGuid().ToString();
        var hasher = new PasswordHasher<IdentityUser>();

        AppUser adminUser = new AppUser
        {
            Id = adminAppUserId,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",     //seed data atarken girmemiz lazım
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        AppUser standardUser = new AppUser
        {
            Id = standardAppUserId,
            FirstName = "Standard",
            LastName = "Standard",
            Email = "standard@standard.com",
            NormalizedEmail = "STANDARD@STANDARD.COM",
            UserName = "standard@standard.com",
            NormalizedUserName = "STANDARD@STANDARD.COM",
            EmailConfirmed = true,
        };
        standardUser.PasswordHash = hasher.HashPassword(standardUser, "Standard123!");

        builder.Entity<AppUser>().HasData(adminUser);
        builder.Entity<AppUser>().HasData(standardUser);


        //rolleri user la eşleştirme/aratabloya atma

        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminAppUserId };
        IdentityUserRole<string> standardUserRole = new IdentityUserRole<string> { RoleId = standardRoleId, UserId = standardAppUserId };

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standardUserRole);

        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminAppUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true",
        });
    }
}
