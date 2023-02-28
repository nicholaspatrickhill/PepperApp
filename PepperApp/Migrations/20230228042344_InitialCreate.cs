using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PepperApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peppers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PepperName = table.Column<string>(type: "TEXT", nullable: true),
                    PepperHeatClass = table.Column<string>(type: "TEXT", nullable: true),
                    PepperScovilleUnitMin = table.Column<int>(type: "INTEGER", nullable: false),
                    PepperScovilleUnitMax = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peppers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Peppers",
                columns: new[] { "Id", "IsReadOnly", "PepperHeatClass", "PepperName", "PepperScovilleUnitMax", "PepperScovilleUnitMin" },
                values: new object[,]
                {
                    { new Guid("135d96a8-29e7-4804-86db-462ab90c11a2"), true, "medium-hot", "Thai Chili", 100000, 50000 },
                    { new Guid("2b31826c-993b-4a5f-a362-22b184dbbd9f"), true, "medium-hot", "Cayenne", 50000, 30000 },
                    { new Guid("2c80af23-1ebd-4516-8996-1a4074836365"), true, "super-hot", "Carolina Reaper", 2200000, 1400000 },
                    { new Guid("435fafff-ecf7-48ce-9a32-147f77a3e983"), true, "medium-hot", "Serrano", 23000, 10000 },
                    { new Guid("46f0d70f-ba24-4a61-8e00-ba5288e53f59"), true, "mild", "Bell Pepper", 0, 0 },
                    { new Guid("a8e26d11-a9ce-4c36-a146-c16df5639b2e"), true, "super-hot", "Ghost Pepper", 1100000, 855000 },
                    { new Guid("af7c3106-8847-4b11-adf4-0daea5b73819"), true, "hot", "Scotch Bonnet", 350000, 100000 },
                    { new Guid("d10c5bc3-f4c0-45e0-872e-6c10266c9940"), true, "hot", "Habanero", 350000, 100000 },
                    { new Guid("d98e4119-4839-4a86-a197-f0579272d93f"), true, "medium", "Jalapeno", 8000, 2500 },
                    { new Guid("de49b21d-ecdd-4fea-8202-fd44e90c692c"), true, "mild", "Anaheim", 2500, 500 },
                    { new Guid("e0712107-4fa9-4891-a157-f52c28e6f513"), true, "mild", "Banana Pepper", 500, 0 },
                    { new Guid("edb4ec07-0182-461d-b0ff-757818e3377b"), true, "mild", "Poblano", 2000, 1000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peppers");
        }
    }
}
