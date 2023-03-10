using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PepperApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peppers",
                columns: table => new
                {
                    PepperId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PepperName = table.Column<string>(type: "TEXT", nullable: true),
                    PepperHeatClass = table.Column<string>(type: "TEXT", nullable: true),
                    PepperScovilleUnitMin = table.Column<int>(type: "INTEGER", nullable: false),
                    PepperScovilleUnitMax = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peppers", x => x.PepperId);
                });

            migrationBuilder.InsertData(
                table: "Peppers",
                columns: new[] { "PepperId", "IsReadOnly", "PepperHeatClass", "PepperName", "PepperScovilleUnitMax", "PepperScovilleUnitMin" },
                values: new object[,]
                {
                    { new Guid("0f008a7d-7a39-44c3-a633-aca915d10bc4"), true, "medium", "Jalapeno", 8000, 2500 },
                    { new Guid("2d60a7c6-2580-423b-8b1b-c18ba2741bcc"), true, "hot", "Scotch Bonnet", 350000, 100000 },
                    { new Guid("384e7fed-0b0b-4ffa-b2f6-d4dc6c0c6dc6"), true, "medium-hot", "Serrano", 23000, 10000 },
                    { new Guid("7e6354ce-9bdb-4d1c-9950-9c5e142af144"), true, "mild", "Poblano", 2000, 1000 },
                    { new Guid("9adbc0ea-4054-4531-a224-7a999395cc7a"), true, "mild", "Anaheim", 2500, 500 },
                    { new Guid("aa84715b-bf26-4de2-9bf8-854c63aab24d"), true, "super-hot", "Ghost Pepper", 1100000, 855000 },
                    { new Guid("aea587b7-0896-4df0-8b38-c68c650e62fa"), true, "mild", "Banana Pepper", 500, 0 },
                    { new Guid("bca6042a-f862-446a-8953-4a9dd544b27c"), true, "mild", "Bell Pepper", 0, 0 },
                    { new Guid("d8797ab4-2660-4d87-9354-43a417b6c682"), true, "hot", "Habanero", 350000, 100000 },
                    { new Guid("dd7f3107-61ca-4fa0-989f-c4acf9d442b0"), true, "medium-hot", "Thai Chili", 100000, 50000 },
                    { new Guid("f1ee99b2-a44b-4ba8-8c9b-c5c09095763f"), true, "medium-hot", "Cayenne", 50000, 30000 },
                    { new Guid("fcbeaeee-d83a-4b49-89db-fca3f01c55ef"), true, "super-hot", "Carolina Reaper", 2200000, 1400000 }
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
