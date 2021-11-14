using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {            
            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            const string AdminRoleId = "10000000-0000-0000-0000-000000000001";
            const string AdminRoleName = "Admin";

            const string AdminUserId = "10000000-0000-0000-0000-000000000001";
            const string AdminUserName = "admin@guitarshop.com";
            const string AdminUserPassword = "Test123?";

            User adminUser = new User
            {
                Id = AdminUserId,
                UserName = AdminUserName,
                NormalizedUserName = AdminUserName.ToUpper(),
                Email = AdminUserName,
                NormalizedEmail = AdminUserName.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", //Random string
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58", //Random guid string
                Address = "Rijselstraat 5",
                PostalCode = 8000,
                City = "Brugge",
                PhoneNumber = "0499876543", 
            };

            const string TestUserRoleId = "10000000-0000-0000-0000-000000000002";
            const string TestUserRoleName = "TestUser";

            const string TestUserUserId = "10000000-0000-0000-0000-000000000002";
            const string TestUserUserName = "testUser@guitarshop.com";
            const string TestUserUserPassword = "Test123?";

            User testUser = new User
            {
                Id = TestUserUserId,
                UserName = TestUserUserName,
                NormalizedUserName = TestUserUserName.ToUpper(),
                Email = TestUserUserName,
                NormalizedEmail = TestUserUserName.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", //Random string
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc59", //Random guid string
                Address = "Rijselstraat 5",
                PostalCode = 8000,
                City = "Brugge",
                PhoneNumber = "0490876543", 
            };



            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, AdminUserPassword);
            testUser.PasswordHash = passwordHasher.HashPassword(testUser, TestUserUserPassword);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AdminRoleId,
                Name = AdminRoleName,
                NormalizedName = AdminRoleName.ToUpper()
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = TestUserRoleId,
                Name = TestUserRoleName,
                NormalizedName = TestUserRoleName.ToUpper()
            });

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId
            });
        }
    }
}
