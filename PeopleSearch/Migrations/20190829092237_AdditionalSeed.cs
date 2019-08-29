using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Migrations
{
    public partial class AdditionalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "State", "ZipCode" },
                values: new object[] { 6, "300 MLK Blvd.", "Apt 1602", "Central City", "CA", 77777 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "State", "ZipCode" },
                values: new object[] { 7, "2600 Ocean Ave", null, "Coast City", "WA", 51255 });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "Age", "FirstName", "ImageUrl", "LastName" },
                values: new object[] { 6, 6, 27, "Barry", "/images/ballen.jpg", "Allen" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "Age", "FirstName", "ImageUrl", "LastName" },
                values: new object[] { 7, 7, 34, "John", "/images/jstewart.jpg", "Stewart" });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 6, 8 },
                    { 6, 2 },
                    { 6, 4 },
                    { 7, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "PersonId", "InterestId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "PersonId", "InterestId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "PersonId", "InterestId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "PersonId", "InterestId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "PersonId", "InterestId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
