using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandCategory",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategory", x => new { x.BrandId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BrandCategory_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandSubcategory",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(nullable: false),
                    SubcategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandSubcategory", x => new { x.BrandId, x.SubcategoryId });
                    table.ForeignKey(
                        name: "FK_BrandSubcategory_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandSubcategory_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Image = table.Column<string>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    SubcategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000001"), "9780a11b-0a17-42a3-b69f-e83e146ce759", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("00000001-0000-0000-0000-000000000002"), "c7ba269e-71c5-4db9-9f83-fae778d9643b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), 0, "Rijselstraat 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brugge", "c8554266-b401-4519-9aeb-a9283053fc59", "superAdmin@guitarshop.com", true, false, null, "SUPERADMIN@GUITARSHOP.COM", "SUPERADMIN@GUITARSHOP.COM", "AQAAAAEAACcQAAAAEAlcOQelnKOuN1F/cq6B9wKxmvbZfuSJMoJ8EnGG+qfHHDDlPKWJ8Ci/ZeOtLkulIw==", "0490876543", false, 8000, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINB", false, "superAdmin@guitarshop.com" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), 0, "Rijselstraat 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brugge", "c8554266-b401-4519-9aeb-a9283053fc58", "admin@guitarshop.com", true, false, null, "ADMIN@GUITARSHOP.COM", "ADMIN@GUITARSHOP.COM", "AQAAAAEAACcQAAAAEEvhOID+U2y8CgjBY722kUZvPZmAO07He4lQnzCdOAd501POOGhLt3j+BX/o+wTh1Q==", "0499876543", false, 8000, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "admin@guitarshop.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedOn", "Image", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0001-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/NfyW4skP/Gibson.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibson" },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/vBQJL50W/Fender.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender" },
                    { new Guid("00000000-0000-0000-0001-000000000013"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/LX90c2Kf/Strymon.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strymon" },
                    { new Guid("00000000-0000-0000-0001-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/W46HYtKT/Kemper.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemper" },
                    { new Guid("00000000-0000-0000-0001-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/rmfYc3MH/Vox.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vox" },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/CMr3kBkq/Marshall.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall" },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/mrGfkvMp/Boss.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boss" },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/DzKNc1xx/EVH.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh" },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/g28QCg5V/Roland.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roland" },
                    { new Guid("00000000-0000-0000-0001-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/1tJLW4db/Gretsch.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gretsch" },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/8ccxxNQc/Ibanez.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez" },
                    { new Guid("00000000-0000-0000-0001-000000000014"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/d0mMy5js/Elixir.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elixir" },
                    { new Guid("00000000-0000-0000-0001-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/cH9bR2gS/Taylor.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor" },
                    { new Guid("00000000-0000-0000-0001-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/SK43kWFw/Martin.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin" },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/L5J0NDLZ/Yamaha.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Image", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/8CHNz2QB/Electric-Guitars.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric guitars" },
                    { new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/3NWK6nqj/Amps.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amps" },
                    { new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/HLhHMQnV/Bass-Guitars.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bass guitars" },
                    { new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Kz3bDR3Q/Cables.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cables" },
                    { new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/vTRsqbWy/Capodasters.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Capodasters" },
                    { new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/mgZG6dFP/Effects.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Effects" },
                    { new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/7P7DCJkZ/Miscellaneous-Instruments.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miscellaneous instruments" },
                    { new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/jd4bcVCV/Pickups.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pickups" },
                    { new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/zXrNTDzS/Strings.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strings" },
                    { new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/rwhL6SSQ/Western-Guitars.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acoustic guitars" },
                    { new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/66d3kmTc/Ukuleles.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukuleles" },
                    { new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/prDt34ZF/Classical-Guitars.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classical guitars" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("00000001-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new Guid("00000001-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "BrandCategory",
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000005") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000005") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000005") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000013"), new Guid("00000000-0000-0000-0002-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000004") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0002-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000009") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0002-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0002-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0002-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000012") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000008") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000003") },
                    { new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0002-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000012"), new Guid("00000000-0000-0000-0002-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "LastEditedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0003-000000000036"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single coil pickups" },
                    { new Guid("00000000-0000-0000-0003-000000000035"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Humbucker pickups" },
                    { new Guid("00000000-0000-0000-0003-000000000037"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other pickups" },
                    { new Guid("00000000-0000-0000-0003-000000000005"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other electric guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000004"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Double cut electric guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000034"), new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other miscellaneous instruments" },
                    { new Guid("00000000-0000-0000-0003-000000000012"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric bass guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000038"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric strings" },
                    { new Guid("00000000-0000-0000-0003-000000000039"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acoustic strings" },
                    { new Guid("00000000-0000-0000-0003-000000000040"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nylon strings" },
                    { new Guid("00000000-0000-0000-0003-000000000041"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other strings" },
                    { new Guid("00000000-0000-0000-0003-000000000002"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Telecaster electric guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000001"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stratocaster electric guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000042"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dreadnought guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000043"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Semi acoustic guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000044"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other acoustic guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000045"), new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concert ukuleles" },
                    { new Guid("00000000-0000-0000-0003-000000000046"), new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other ukuleles" },
                    { new Guid("00000000-0000-0000-0003-000000000003"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single cut electric guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000033"), new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banjos" },
                    { new Guid("00000000-0000-0000-0003-000000000030"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expression effects" },
                    { new Guid("00000000-0000-0000-0003-000000000031"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other effects" },
                    { new Guid("00000000-0000-0000-0003-000000000013"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acoustic bass guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000014"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 string bass guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000011"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabinets" },
                    { new Guid("00000000-0000-0000-0003-000000000015"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1/4 classical guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000016"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3/4 classical guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000017"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4/4 classical guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000018"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other classical guitars" },
                    { new Guid("00000000-0000-0000-0003-000000000010"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tops" },
                    { new Guid("00000000-0000-0000-0003-000000000009"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loadboxes" },
                    { new Guid("00000000-0000-0000-0003-000000000008"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modeling combo amps" },
                    { new Guid("00000000-0000-0000-0003-000000000032"), new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mandolines" },
                    { new Guid("00000000-0000-0000-0003-000000000019"), new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guitar cables" },
                    { new Guid("00000000-0000-0000-0003-000000000021"), new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patch cables" },
                    { new Guid("00000000-0000-0000-0003-000000000007"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solid state combo amps" },
                    { new Guid("00000000-0000-0000-0003-000000000006"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tube combo amps" },
                    { new Guid("00000000-0000-0000-0003-000000000023"), new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curved capodasters" },
                    { new Guid("00000000-0000-0000-0003-000000000024"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reverb / Delay / Echo effects" },
                    { new Guid("00000000-0000-0000-0003-000000000025"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tremolo / Vibrato / Rotary effects" },
                    { new Guid("00000000-0000-0000-0003-000000000026"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Distortion effects" },
                    { new Guid("00000000-0000-0000-0003-000000000027"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overdrive effects" },
                    { new Guid("00000000-0000-0000-0003-000000000028"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compressor effects" },
                    { new Guid("00000000-0000-0000-0003-000000000029"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wah wah effects" },
                    { new Guid("00000000-0000-0000-0003-000000000020"), new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Speaker cables" },
                    { new Guid("00000000-0000-0000-0003-000000000022"), new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flat capodasters" }
                });

            migrationBuilder.InsertData(
                table: "BrandSubcategory",
                columns: new[] { "BrandId", "SubcategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000035") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0003-000000000035") },
                    { new Guid("00000000-0000-0000-0001-000000000012"), new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000036") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0003-000000000009") },
                    { new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0003-000000000038") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0003-000000000008") },
                    { new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0003-000000000023") },
                    { new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0003-000000000039") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000040") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0003-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0003-000000000011") },
                    { new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0003-000000000034") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000023") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000022") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0003-000000000021") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0003-000000000025") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0003-000000000019") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000017") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0003-000000000026") },
                    { new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000016") },
                    { new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0003-000000000029") },
                    { new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0003-000000000013") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000013") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000032") },
                    { new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0003-000000000046") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000014") },
                    { new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000013"), new Guid("00000000-0000-0000-0003-000000000024") },
                    { new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0003-000000000045") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000045") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0003-000000000002") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000045") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000044") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000043") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0003-000000000004") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000005") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0003-000000000005") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000004") },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000041") },
                    { new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0003-000000000006") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedOn", "Image", "LastEditedOn", "Name", "Price", "SubcategoryId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0001-000000000013"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/g0sX6hz6/strymon-el-capistan-dtape-delay-1-GIT0022459-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strymon el capistan tape delay", 1000m, new Guid("00000000-0000-0000-0003-000000000024") },
                    { new Guid("00000000-0000-0000-0000-000000000060"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/J4ZH30MK/fender-fullerton-tele-uke-butterscotch-blonde-1-GIT0052267-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender fullerton tele uke butterscotch blonde", 1000m, new Guid("00000000-0000-0000-0003-000000000045") },
                    { new Guid("00000000-0000-0000-0000-000000000055"), new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/ZYvbGQ9M/elixir-a-git-snaren-10-47-16002-nanoweb-phosphor-bronze-1-GIT0008353-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elixir acoustic nanoweb phosphor bronze", 1000m, new Guid("00000000-0000-0000-0003-000000000039") },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/tJZYfmhh/boss-tr-2-tremolo-1-GIT0000578-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boxx tr-2 tremolo", 1000m, new Guid("00000000-0000-0000-0003-000000000025") },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0001-000000000013"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/fyGJhjK1/strymon-big-sky-multi-reverb-1-GIT0029813-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strymon big sky multi reverb", 1000m, new Guid("00000000-0000-0000-0003-000000000024") },
                    { new Guid("00000000-0000-0000-0000-000000000056"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/8P8pNbMP/fender-nylon-git-snaren-100-clear-tie-end-1-GIT0018438-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender nylon classical", 1000m, new Guid("00000000-0000-0000-0003-000000000040") },
                    { new Guid("00000000-0000-0000-0000-000000000153"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/0yP9J2VT/fender-california-coast-concert-ukulele-strings-1-GIT0044910-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender concert ukulele", 1000m, new Guid("00000000-0000-0000-0003-000000000041") },
                    { new Guid("00000000-0000-0000-0000-000000000061"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/FHxfq6fL/ibanez-ukc10-ukulele-1-GIT0023444-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez ukc10 ukulele", 1000m, new Guid("00000000-0000-0000-0003-000000000045") },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/MTrn98j6/boss-ds-2-turbo-distortion-1-GIT0000572-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boss ds-2 turbo distortion", 1000m, new Guid("00000000-0000-0000-0003-000000000026") },
                    { new Guid("00000000-0000-0000-0000-000000000051"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/DZb6hF3Z/fender-double-tap-bridge-humbucker-1-GIT0054676-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender double tap bridge humbucker", 1000m, new Guid("00000000-0000-0000-0003-000000000035") },
                    { new Guid("00000000-0000-0000-0000-000000000059"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Gtbx0DLL/yamaha-silent-guitar-slg-200-s-crimson-red-burst-steel-strings-1-GIT0052653-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha silent guitar crimson red burst", 1000m, new Guid("00000000-0000-0000-0003-000000000044") },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000007"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/NM0y80FC/vox-v847a-wah-1-GIT0011824-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vox v847a wah", 1000m, new Guid("00000000-0000-0000-0003-000000000029") },
                    { new Guid("00000000-0000-0000-0000-000000000052"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/6QPcFqSg/fender-custom-shop-nocaster-tele-2er-set-singlecooils-1-GIT0001347-001.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender custom shop nocaster tele set singlecoils", 1000m, new Guid("00000000-0000-0000-0003-000000000036") },
                    { new Guid("00000000-0000-0000-0000-000000000048"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/1tsvS2M1/ibanez-m510e-bs-mandoline-brown-sunburst-1-GIT0012278-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez m510e bs manoline brown sunburst", 1000m, new Guid("00000000-0000-0000-0003-000000000032") },
                    { new Guid("00000000-0000-0000-0000-000000000058"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/7hXMqLhg/fender-am-acoustasonic-stratocaster-transparent-sonic-blue-1-GIT0052562-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender am acoustasonic transparant sonic blue", 1000m, new Guid("00000000-0000-0000-0003-000000000043") },
                    { new Guid("00000000-0000-0000-0000-000000000057"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/XqrkLbQ3/yamaha-fg3-1-GIT0049915-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha fg3", 1000m, new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0000-000000000049"), new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0002-000000000008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/63cYpc12/gretsch-g5700-lap-steel-tobacco-sunburst-1-GIT0003805-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gretsch g5700 lap steel tobacco sunburst", 1000m, new Guid("00000000-0000-0000-0003-000000000034") },
                    { new Guid("00000000-0000-0000-0000-000000000156"), new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/XJHg9JKQ/taylor-builder-s-edition-717e-wild-honey-burst-1-GIT0048533-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor 717e wild honey burst", 1000m, new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0000-000000000155"), new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/2jtw61S5/martin-guitars-hd-28-ambertone-1-GIT0045786-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin hd 28 ambertone", 1000m, new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0000-000000000154"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000011"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/SRH7tvv9/fender-ct-redondo-special-mah-1-GIT0053479-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender ct redondo special mah", 1000m, new Guid("00000000-0000-0000-0003-000000000042") },
                    { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/8CcwyMyL/evh-frankensteen-humbucker-1-GIT0020048-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh frankensteen humbucker", 1000m, new Guid("00000000-0000-0000-0003-000000000035") },
                    { new Guid("00000000-0000-0000-0000-000000000053"), new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/4ycXpKkg/elixir-19002-optiweb-1-GIT0040893-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elixir electric optiweb", 1000m, new Guid("00000000-0000-0000-0003-000000000038") },
                    { new Guid("00000000-0000-0000-0000-000000000054"), new Guid("00000000-0000-0000-0001-000000000014"), new Guid("00000000-0000-0000-0002-000000000010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/tChXTVNd/elixir-e-git-snaren-09-42-12002-nanoweb-1-ACC0000532-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elixir electric nanoweb", 1000m, new Guid("00000000-0000-0000-0003-000000000038") },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/ZqfwTCdJ/fender-american-original-60s-precision-bass-rw-surf-green-1-BAS0010757-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender american original 60s precision bass rw surf green", 1000m, new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/NFr4QD6c/fender-fscst-smart-capo-standaard-curved-1-GIT0019827-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender smart capo standard curved", 1000m, new Guid("00000000-0000-0000-0003-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000116"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/hGKj1GhW/fender-tone-master-deluxe-reverb-1-GIT0050563-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender tone master deluxe reverb", 1000m, new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000115"), new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/5y4ScJsZ/vox-ac30hw2-combo-1-GIT0020205-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vox ac30hw2 combo", 1000m, new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/26fxwhhj/vox-ac15c1x-1-GIT0037041-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vox ac15c1x", 1000m, new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/9f9pZJ4N/marshall-jvm-410-c-combo-1-GIT0010132-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall jvm 410 c combo", 1000m, new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/QdHSxXjD/evh-5150iii-2x12-50w-6l6-combo-ivory-1-GIT0045576-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh 5150iii 2x12 50w 6l6 combo ivory", 1000m, new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/gkMNWwF4/fender-64-custom-deluxe-reverb-1-GIT0042604-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender 64 custom deluxe reverb", 1000m, new Guid("00000000-0000-0000-0003-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/rpB6j0Zf/fender-limited-edition-59-250k-jazzmaster-dlx-closet-classic-desert-sand-cz550958-1-GIT0056948-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender limited edition 59 jazzmaster dlx classic desert sand", 1000m, new Guid("00000000-0000-0000-0003-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/W1fcDfGL/gibson-70s-flying-v-classic-white-1-GIT0051791-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibson 70s flying v classic white", 1000m, new Guid("00000000-0000-0000-0003-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/W1zQP6Q9/yamaha-revstar-rs620-seg-snake-eye-green-1-GIT0045092-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha revstar rs620 seg snake eye green", 1000m, new Guid("00000000-0000-0000-0003-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000117"), new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/SxFjjdhK/boss-katana-artist-mkii-1-GIT0052539-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boss katana artist mkii", 1000m, new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/x8PW9sfZ/gibson-sg-standard-61-vintage-cherry-1-GIT0049508-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibson sg standard 61 vintage cherry", 1000m, new Guid("00000000-0000-0000-0003-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Qxm3DMVM/gretsch-g5230t-electromatic-jet-ft-single-cut-bigsby-airline-silver-1-GIT0047791-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gretsch g5230t electromatic jet ft single cut bigsby airline silver", 1000m, new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Kjb6SX2L/gibson-les-paul-tribute-satin-tobacco-sunburst-1-GIT0049503-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibson les paul tribute satin tobacco sunburst", 1000m, new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0001-000000000002"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/KzB6HGdx/gibson-les-paul-studio-smokehouse-burst-1-GIT0049498-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibson les paul studio smokehouse burst", 1000m, new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/T2q8jPVc/ibanez-azs2200-bk-prestige-black-1-GIT0055975-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez azs2200 bk prestige black", 1000m, new Guid("00000000-0000-0000-0003-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/W14P1PJw/fender-american-ultra-telecaster-rw-ultraburst-1-GIT0050649-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender american ultra telecaster rw ultrabust", 1000m, new Guid("00000000-0000-0000-0003-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/pXqg711h/ibanez-martin-miller-mm1-tab-az-signature-transparent-aqua-blue-1-GIT0044682-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez martin miller mm1 tab az signature transparent aqua blue", 1000m, new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/JzFS7H8R/evh-striped-series-frankie-1-GIT0052080-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh striped series frankie", 1000m, new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/0NMR7dn6/fender-eric-clapton-stratocaster-mn-almond-green-masterbuilt-todd-krause-cz552554-1-GIT0057454-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender eric clapton stratocaster almond green", 1000m, new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/59wJPgVL/fender-american-ultra-stratocaster-hss-mn-ultraburst-1-GIT0050645-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender american ultra stratocaster ultraburst", 1000m, new Guid("00000000-0000-0000-0003-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0001-000000000003"), new Guid("00000000-0000-0000-0002-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/VLYxKc4P/gretsch-g6128t-players-edition-jet-ft-bigsby-roundup-orange-1-GIT0051980-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gretsch g6128t players edition jet ft bigsby roundup orange", 1000m, new Guid("00000000-0000-0000-0003-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/zf0p7Vz9/taylor-capo-6-string-bright-nickel-1-GIT0049116-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor capo 6 string nickel curved", 1000m, new Guid("00000000-0000-0000-0003-000000000023") },
                    { new Guid("00000000-0000-0000-0000-000000000118"), new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/PqKq3k8L/roland-jc-120b-jazz-chorus-combo-1-GIT0000966-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roland jc 120b jazz chorus combo", 1000m, new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0001-000000000011"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Z58nNNbx/vox-vx50-gtv-1-GIT0048389-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vox vx50 gtv", 1000m, new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000006"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Px7yG98y/ibanez-igcz10-capodaster-1-GIT0046854-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez igcz10 capo flat", 1000m, new Guid("00000000-0000-0000-0003-000000000022") },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/rmsjPMzz/roland-ric-bpc-patchkabel-0-15-m-1-ACC0007020-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roland ric bpc patchcable 0,15m", 1000m, new Guid("00000000-0000-0000-0003-000000000021") },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/c4n9Wxhn/roland-ric-g10a-gold-series-1-ACC0007014-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roland ric g10a gold series 6m", 1000m, new Guid("00000000-0000-0000-0003-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/sgPTBTtf/yamaha-c-40-m-mat-1-GIT0019253-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha c 40 m", 1000m, new Guid("00000000-0000-0000-0003-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/Jh1PjbLN/yamaha-cs-40-nt-3-4-natural-1-GIT0000644-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha cs 40 nt 3/4 natural", 1000m, new Guid("00000000-0000-0000-0003-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/C1zmdSGk/fender-american-professional-ii-jazz-bass-v-mn-roasted-pine-1-BAS0011257-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender american professional ii azz bass v mn roasted pine", 1000m, new Guid("00000000-0000-0000-0003-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0001-000000000006"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/s2fndp1n/taylor-gs-mini-e-koa-bass-1-BAS0010808-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor gs mini e koa bass", 1000m, new Guid("00000000-0000-0000-0003-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/C1XJqX7t/fender-fa-450ce-bass-3-tone-sunburst-1-BAS0010213-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender fa 450ce bass 3 tone sunburst", 1000m, new Guid("00000000-0000-0000-0003-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/HkgZ3Gm1/yamaha-bbp34-vintage-sunburst-1-BAS0009170-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha bbp34 vintage sunburst", 1000m, new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000119"), new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/15Nf9TbT/marshall-mg50fx-mg-gold-guitar-combo-amplifier-1-GIT0043010-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall mg50fx mg gold", 1000m, new Guid("00000000-0000-0000-0003-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0001-000000000004"), new Guid("00000000-0000-0000-0002-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/tCPvhqLz/ibanez-standard-sr600e-ast-antique-brown-stained-burst-1-BAS0011488-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibanez standard sr600e ast antique brown stained burst", 1000m, new Guid("00000000-0000-0000-0003-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/9QQXDnkC/marshall-1960-ahw-cabinet-1-GIT0006190-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall 1960 ahw cabinet", 1000m, new Guid("00000000-0000-0000-0003-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0001-000000000010"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/nL6nwchh/marshall-jtm45-head-2245-1-GIT0009522-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall jtm45 head", 1000m, new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/nzBn8bXY/evh-5150iii-50w-el34-head-1-GIT0043477-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh 5150iii 50w el34 head", 1000m, new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0001-000000000001"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/XvZV8y3P/fender-bassbreaker-45-head-1-GIT0037389-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender bassbreaker 45 head", 1000m, new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0001-000000000012"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/VvF16qBJ/kemper-prof-ler-power-head-remote-1-GIT0034433-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemper prof ler power head remote", 1000m, new Guid("00000000-0000-0000-0003-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0001-000000000015"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/K8pGB5XL/boss-waza-tube-amp-expander-1-GIT0047642-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boss waza tube amp expander", 1000m, new Guid("00000000-0000-0000-0003-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/MKdqJYp4/fender-tone-master-super-reverb-1-GIT0056974-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fender tone master super reverb", 1000m, new Guid("00000000-0000-0000-0003-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0001-000000000009"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/4NJs00sV/roland-blauwscube-artist-combo-1-GIT0032556-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roland blauwscube artist combo", 1000m, new Guid("00000000-0000-0000-0003-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0001-000000000005"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/wMzggfJK/yamaha-thr30ii-wireless-1-GIT0051343-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yamaha thr30ii wireless", 1000m, new Guid("00000000-0000-0000-0003-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0001-000000000008"), new Guid("00000000-0000-0000-0002-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/XNKnQWSn/evh-5150-iconic-series-4x12-cabinet-black-1-GIT0057179-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evh 5150 iconic series 4x12 cabinet", 1000m, new Guid("00000000-0000-0000-0003-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000062"), new Guid("00000000-0000-0000-0001-000000000007"), new Guid("00000000-0000-0000-0002-000000000012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.postimg.cc/9Q2RL2f2/martin-guitars-c1k-concert-uke-solid-hawaiian-koa-1-GIT0030099-000.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin c1k concert uke solid hawaiian koa", 1000m, new Guid("00000000-0000-0000-0003-000000000046") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategory_CategoryId",
                table: "BrandCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandSubcategory_SubcategoryId",
                table: "BrandSubcategory",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BrandCategory");

            migrationBuilder.DropTable(
                name: "BrandSubcategory");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
