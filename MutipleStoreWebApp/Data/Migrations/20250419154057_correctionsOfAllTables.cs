using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MutipleStoreWebApp.Migrations
{
    /// <inheritdoc />
    public partial class correctionsOfAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Stores",
                newName: "Slug");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7da42fc-fcf6-4513-b57b-e4f123657a27", "AQAAAAIAAYagAAAAEIEp8nlVPM/F/cl3aSDUfcpsvzrdD2UvyJ+65WMQIAV4IWzSeyiUJ5/Z9MXnITdCYg==", "f74d39ac-e383-424c-944b-eae93ed8e042" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db00e3d-12e3-4f9e-99ff-796223ed024f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22a21fa3-d9bc-4a7c-8fde-7cd7e8239e41", "AQAAAAIAAYagAAAAEJdne8Q49pszts3eZYgujSVajHG0gMzGYlOLh5wtUGIhQ4UkQW4q1T1PmEnAPXk+7Q==", "a3c77435-c559-4f30-a176-63973ca2dcd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "106cb247-3753-4406-a084-594015b02c92", "AQAAAAIAAYagAAAAEH9TQGpT912bV3VkZ9Q9oMYX6NwYya1eJeG4Mp+oSBd2/sjd3kJyoG5rUqkQ7m/eKg==", "0c666a27-7b47-42c9-ab6c-6bbb857d0ddb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Stores",
                newName: "Address");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a17f4c5-39d7-4df7-a794-de5ac9a91e58", "AQAAAAIAAYagAAAAECb+UgN65CuDuF8umXuRKSdsfh3wI4GdEMrXO16DncOEshEgVS55MKP0Lp4pdfwMhQ==", "e39b6321-6f65-4b36-b9bf-3415ce804d2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db00e3d-12e3-4f9e-99ff-796223ed024f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "210b40b6-1bbb-48e5-9b68-fd248b44e279", "AQAAAAIAAYagAAAAEOAYMdyWUtiIuCYuMG79hjzcGprkJzLRLoOBWbhmIsYx9msxwZC7YornUAQIsbm/gg==", "95af5a15-bd59-4058-88cf-8968938965d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1528b5d-e9c1-4703-a838-fc38eff1a5e9", "AQAAAAIAAYagAAAAELiy+GLc+I6rTS3mNk/p/l8Mpaz+STNBrj8LhOsyhKjJFRjKrIR1HsWV3cOi0qY6fQ==", "e289dbb8-7c9f-45a6-8f60-186ba109e99d" });
        }
    }
}
