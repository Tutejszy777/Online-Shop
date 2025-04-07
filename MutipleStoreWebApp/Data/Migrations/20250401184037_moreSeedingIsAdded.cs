using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MutipleStoreWebApp.Migrations
{
    /// <inheritdoc />
    public partial class moreSeedingIsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1528b5d-e9c1-4703-a838-fc38eff1a5e9", "AQAAAAIAAYagAAAAELiy+GLc+I6rTS3mNk/p/l8Mpaz+STNBrj8LhOsyhKjJFRjKrIR1HsWV3cOi0qY6fQ==", "e289dbb8-7c9f-45a6-8f60-186ba109e99d" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Name", "OwnerEmail" },
                values: new object[] { 1, "DEFAULT", "DEFAULT", "owner@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastLoggin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StoreId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a", 0, "9a17f4c5-39d7-4df7-a794-de5ac9a91e58", "owner@localhost.com", true, "owner", new DateOnly(1, 1, 1), "owner", false, null, "OWNER@LOCALHOST.COM", "OWNER@LOCALHOST.COM", "AQAAAAIAAYagAAAAECb+UgN65CuDuF8umXuRKSdsfh3wI4GdEMrXO16DncOEshEgVS55MKP0Lp4pdfwMhQ==", null, false, "e39b6321-6f65-4b36-b9bf-3415ce804d2e", 1, false, "owner@localhost.com" },
                    { "7db00e3d-12e3-4f9e-99ff-796223ed024f", 0, "210b40b6-1bbb-48e5-9b68-fd248b44e279", "customer@localhost.com", true, "customer", new DateOnly(1, 1, 1), "customer", false, null, "CUSTOMER@LOCALHOST.COM", "CUSTOMER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOAYMdyWUtiIuCYuMG79hjzcGprkJzLRLoOBWbhmIsYx9msxwZC7YornUAQIsbm/gg==", null, false, "95af5a15-bd59-4058-88cf-8968938965d6", 1, false, "customer@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "StoreId" },
                values: new object[] { 1, "item", "DEFAULT", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1d102caa-dcd1-4c0d-ac38-76e2b8b04f33", "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a" },
                    { "fc57d154-917f-4485-9f9d-2f745c3490f9", "7db00e3d-12e3-4f9e-99ff-796223ed024f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d102caa-dcd1-4c0d-ac38-76e2b8b04f33", "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc57d154-917f-4485-9f9d-2f745c3490f9", "7db00e3d-12e3-4f9e-99ff-796223ed024f" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db00e3d-12e3-4f9e-99ff-796223ed024f");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bf3ed34-0a89-4756-8cc5-54671a730f93", "AQAAAAIAAYagAAAAEBVWw3PQYSz/2RNry/4trCfXjMFtS4m2gQ54n6chrJZhUlPcSgckRpqdOi5Ctb4yQA==", "a63aaccc-ed3d-4501-88ac-bf7ddd9e9f2f" });
        }
    }
}
