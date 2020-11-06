using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using quanlythietbi.Data.Entities;
using quanlythietbi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace quanlythietbi.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                  new AppConfig() { Key = "HomeTitle", Value = "This is home page of QLTB" },
                  new AppConfig() { Key = "HomeKeyWord", Value = "This is HomeKeyWord of QLTB" },
                  new AppConfig() { Key = "HomeDescription", Value = "This is HomeDescription of QLTB" }
                );

            // any guid
            var roleId = new Guid("CA7EE66A-FE33-4985-940B-29AE960E5C9D");
            var adminId = new Guid("47EBC4FE-DC48-4AB2-9AE5-0B7E25EFEC50");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "domanhlinh1@gmail.com",
                NormalizedEmail = "domanhlinh1@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc@123"),
                SecurityStamp = string.Empty,
                FirstName = "Linh",
                LastName = "Do"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }

    }

}

