using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyQuiz.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyQuiz.Infrastructure.AllContexts
{
    public class QuizPrivilageContext : IdentityDbContext<Priv_User, Priv_Role, int>
    {
        public QuizPrivilageContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Priv_User> priv_Users { get; set; }
        public DbSet<Priv_Role> priv_Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            #region Configuration 

            builder.Entity<Priv_Role>(entity =>
            {
                entity.ToTable("Roles", "Privilage");
            });

            builder.Entity<Priv_User>(entity =>
            {
                entity.ToTable("Users", "Privilage");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles", "Privilage");
            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims", "Privilage");
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins", "Privilage");
            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens", "Privilage");
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims", "Privilage");
            });
            #endregion



            #region Data

            builder.Entity<Priv_Role>().HasData(
                   new Priv_Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                   new Priv_Role { Id = 2, Name = "Student", NormalizedName = "STUDENT" }
              );


            builder.Entity<Priv_User>().HasData(new Priv_User
            {
                Id = 1,
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<Priv_User>().HashPassword(null, "P@ssw0rd123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1
            });
            #endregion


        }



    }
}
