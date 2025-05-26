using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MutipleStoreWebApp.Migrations
{
    /// <inheritdoc />
    public partial class orderTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusChanged = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47741e2f-6ed9-4c5e-a577-24dd18dc6a0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb27b2e6-75a1-4a4b-8113-9546b44e0c63", "AQAAAAIAAYagAAAAEJo/ebikbIspAtZLocs/MhI6x1cQ+8jtMGmRRZjS1MMxrkvYKINrYhd5tzeG+6CsUw==", "465de930-56bf-41b2-a8e1-9eaf35947417" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7db00e3d-12e3-4f9e-99ff-796223ed024f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a7e664e-f7aa-4fe6-bfa3-8bcf9ff01588", "AQAAAAIAAYagAAAAEPhP+4QQNbWkIbyuGsUNpQ9cMSizJK0gYWYHbqqlMPk1tXfknATNNI/Evyz7exOFVw==", "17e88451-5424-4835-976e-5473c182d41c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7f0b276-1e12-4ca5-b85c-ff5615874655",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4afd704b-2ee0-4006-8899-0a72469bb1a0", "AQAAAAIAAYagAAAAELJ2dwjz6XAVjoDVsUGFrIxlSW+l60qY24/1t+ZOhE6kej/OAKEyHOEQSTbo40ar8A==", "4bbc310a-ff1e-4b8e-b24f-0c61d95b9f85" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AppUserId",
                table: "Order",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Order");

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
    }
}
