using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PepperApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPropertyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("2afc8c95-dedf-4cc4-a9b7-9c4bb2f804db"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("52498c3d-ac08-4505-88c8-879011bd048b"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("63f66c06-6687-4fab-95dd-3405febf119b"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("703bf461-4e38-49ae-be27-a180f465e0de"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("8254d853-5537-4f91-bc0d-89ef951b3260"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("875bf4de-b0a4-4ea4-9547-78bbde038e68"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("94e7b4e8-2dca-4016-8964-64ddde6858e8"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("b1091cde-d116-4123-9840-ccdd374f98bb"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("bc21f44f-9143-42d5-b62c-3c739f5aa82f"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("ce55ef03-95d6-4712-b181-d9c8b43f9fe3"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("eb8cb0d3-3fd5-4f2c-9e6a-15e32cf686c8"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("f0330b3c-2808-4430-bad9-42a67b4feba1"));

            migrationBuilder.InsertData(
                table: "Peppers",
                columns: new[] { "PepperId", "IsReadOnly", "PepperHeatClass", "PepperName", "PepperScovilleUnitMaximum", "PepperScovilleUnitMinimum" },
                values: new object[,]
                {
                    { new Guid("0082b608-5266-4b99-af79-1ed4c00ca3ab"), true, "medium-hot", "Thai Chili", 100000, 50000 },
                    { new Guid("06095ceb-330e-4756-a16e-a3c734ec3150"), true, "super-hot", "Ghost Pepper", 1100000, 855000 },
                    { new Guid("08a360d2-06d7-4886-882c-a889dce0328a"), true, "medium", "Jalapeno", 8000, 2500 },
                    { new Guid("250366a0-f451-4bc1-9518-22099707aa05"), true, "hot", "Scotch Bonnet", 350000, 100000 },
                    { new Guid("72db5903-7c97-42b0-8048-9c7a70c5ea77"), true, "medium-hot", "Serrano", 23000, 10000 },
                    { new Guid("7c4f423b-db89-4f83-9c44-b09eaa9d025b"), true, "mild", "Bell Pepper", 0, 0 },
                    { new Guid("8fc15408-9a2d-446a-95ee-ac7cf6be023c"), true, "super-hot", "Carolina Reaper", 2200000, 1400000 },
                    { new Guid("9beb9f57-daac-42be-b65e-576207d51960"), true, "mild", "Poblano", 2000, 1000 },
                    { new Guid("ca569753-34f6-433e-8ec8-589f79f0252f"), true, "hot", "Habanero", 350000, 100000 },
                    { new Guid("ce7772cc-2717-41db-9ea0-5f1fd79567ce"), true, "medium-hot", "Cayenne", 50000, 30000 },
                    { new Guid("e1aae56b-5acc-4ced-b882-421857453b24"), true, "mild", "Anaheim", 2500, 500 },
                    { new Guid("fb668cc2-594e-4b9e-8c6a-fca36fb2b868"), true, "mild", "Banana Pepper", 500, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("0082b608-5266-4b99-af79-1ed4c00ca3ab"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("06095ceb-330e-4756-a16e-a3c734ec3150"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("08a360d2-06d7-4886-882c-a889dce0328a"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("250366a0-f451-4bc1-9518-22099707aa05"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("72db5903-7c97-42b0-8048-9c7a70c5ea77"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("7c4f423b-db89-4f83-9c44-b09eaa9d025b"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("8fc15408-9a2d-446a-95ee-ac7cf6be023c"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("9beb9f57-daac-42be-b65e-576207d51960"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("ca569753-34f6-433e-8ec8-589f79f0252f"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("ce7772cc-2717-41db-9ea0-5f1fd79567ce"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("e1aae56b-5acc-4ced-b882-421857453b24"));

            migrationBuilder.DeleteData(
                table: "Peppers",
                keyColumn: "PepperId",
                keyValue: new Guid("fb668cc2-594e-4b9e-8c6a-fca36fb2b868"));

            migrationBuilder.InsertData(
                table: "Peppers",
                columns: new[] { "PepperId", "IsReadOnly", "PepperHeatClass", "PepperName", "PepperScovilleUnitMaximum", "PepperScovilleUnitMinimum" },
                values: new object[,]
                {
                    { new Guid("2afc8c95-dedf-4cc4-a9b7-9c4bb2f804db"), true, "super-hot", "Ghost Pepper", 1100000, 855000 },
                    { new Guid("52498c3d-ac08-4505-88c8-879011bd048b"), true, "hot", "Scotch Bonnet", 350000, 100000 },
                    { new Guid("63f66c06-6687-4fab-95dd-3405febf119b"), true, "medium-hot", "Serrano", 23000, 10000 },
                    { new Guid("703bf461-4e38-49ae-be27-a180f465e0de"), true, "mild", "Poblano", 2000, 1000 },
                    { new Guid("8254d853-5537-4f91-bc0d-89ef951b3260"), true, "mild", "Bell Pepper", 0, 0 },
                    { new Guid("875bf4de-b0a4-4ea4-9547-78bbde038e68"), true, "mild", "Anaheim", 2500, 500 },
                    { new Guid("94e7b4e8-2dca-4016-8964-64ddde6858e8"), true, "medium-hot", "Thai Chili", 100000, 50000 },
                    { new Guid("b1091cde-d116-4123-9840-ccdd374f98bb"), true, "hot", "Habanero", 350000, 100000 },
                    { new Guid("bc21f44f-9143-42d5-b62c-3c739f5aa82f"), true, "medium-hot", "Cayenne", 50000, 30000 },
                    { new Guid("ce55ef03-95d6-4712-b181-d9c8b43f9fe3"), true, "mild", "Banana Pepper", 500, 0 },
                    { new Guid("eb8cb0d3-3fd5-4f2c-9e6a-15e32cf686c8"), true, "medium", "Jalapeno", 8000, 2500 },
                    { new Guid("f0330b3c-2808-4430-bad9-42a67b4feba1"), true, "super-hot", "Carolina Reaper", 2200000, 1400000 }
                });
        }
    }
}
