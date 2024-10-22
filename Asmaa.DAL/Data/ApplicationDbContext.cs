using Asmaa.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asma.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var roleAdiminId = Guid.NewGuid().ToString();
            var roleUserId = Guid.NewGuid().ToString();
            var roleSuperAdiminId = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(
                //                                                      لانه داخل الايدينتي يوزر يكون الايدي سترينج
                new IdentityRole { Id = roleAdiminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = roleSuperAdiminId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = roleUserId.ToString(), Name = "User", NormalizedName = "USER" }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@comp.com",
                NormalizedUserName = "ADMIN@COMP.COM",
                Email = "admin@comp.com",
                NormalizedEmail = "ADMIN@COMP.COM",
                EmailConfirmed = true,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@1212");
            var superAdmin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superAdmin@comp.com",
                NormalizedUserName = "SUPERADMIN@COMP.COM",
                Email = "superAdmin@comp.com",
                NormalizedEmail = "SUPERADMIN@COMP.COM",
                EmailConfirmed = true,
            };
            superAdmin.PasswordHash = hasher.HashPassword(adminUser, "SuperAdmin@1212");
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@comp.com",
                NormalizedUserName = "User@COMP.COM",
                Email = "user@comp.com",
                NormalizedEmail = "USER@COMP.COM",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(adminUser, "User@1212");
            builder.Entity<ApplicationUser>().HasData(user, superAdmin, adminUser);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = roleAdiminId, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = roleUserId, UserId = user.Id },
                new IdentityUserRole<string> { RoleId = roleSuperAdiminId, UserId = superAdmin.Id }
                );
            base.OnModelCreating(builder);
        }
        public DbSet<LastProduct> LastProducts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonal> Testimonals { get; set; }
        public DbSet<MainHome> MainHomes { get; set; }

    }
}
