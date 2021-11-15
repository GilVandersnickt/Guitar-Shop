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
            // Roles
            Guid SuperAdminRoleId = Guid.Parse("00000001-0000-0000-0000-000000000001");
            string SuperAdminRoleName = "SuperAdmin";

            Guid AdminRoleId = Guid.Parse("00000001-0000-0000-0000-000000000002");
            string AdminRoleName = "Admin";

            // SuperAdmin User
            Guid SuperAdminUserId = Guid.Parse("10000000-0000-0000-0000-000000000001");
            const string SuperAdminUserName = "superAdmin@guitarshop.com";
            const string SuperAdminUserPassword = "Test123?";

            // Admin User
            Guid AdminUserId = Guid.Parse("10000000-0000-0000-0000-000000000002");
            const string AdminUserName = "admin@guitarshop.com";
            const string AdminUserPassword = "Test123?";

            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            var usersToSeed = new List<User>();

            User superAdminUser = new User
            {
                Id = SuperAdminUserId,
                UserName = SuperAdminUserName,
                NormalizedUserName = SuperAdminUserName.ToUpper(),
                Email = SuperAdminUserName,
                NormalizedEmail = SuperAdminUserName.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", //Random string
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc59", //Random guid string
                Address = "Rijselstraat 5",
                PostalCode = 8000,
                City = "Brugge",
                PhoneNumber = "0490876543",
            };

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

            superAdminUser.PasswordHash = passwordHasher.HashPassword(superAdminUser, SuperAdminUserPassword);
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, AdminUserPassword);

            usersToSeed.Add(superAdminUser);
            usersToSeed.Add(adminUser);

            modelBuilder.Entity<User>().HasData(usersToSeed);

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = AdminRoleId,
                    Name = AdminRoleName,
                    NormalizedName = AdminRoleName.ToUpper()
                },
                new IdentityRole<Guid>
                {
                    Id = SuperAdminRoleId,
                    Name = SuperAdminRoleName,
                    NormalizedName = SuperAdminRoleName.ToUpper()
                });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = AdminRoleId,
                    UserId = AdminUserId
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = SuperAdminRoleId,
                    UserId = SuperAdminUserId
                });

        }
    }
}
