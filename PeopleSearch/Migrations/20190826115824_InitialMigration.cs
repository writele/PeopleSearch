using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 80, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    InterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.PersonId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1000 Wayne Manor Dr.", null, "Gotham", "NJ", 22222 },
                    { 2, "404 7th St.", "Apt. 603", "National City", "WA", 54545 },
                    { 3, "1200 Main Ave.", "Suite 300", "New York City", "NY", 72172 },
                    { 4, "1418 Trade St.", "Apt 1606", "Metropolis", "PA", 72172 },
                    { 5, "1333 West Sharon St.", null, "Gotham", "NJ", 22244 }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Title" },
                values: new object[,]
                {
                    { 1, "Books" },
                    { 2, "Writing" },
                    { 3, "Movies" },
                    { 4, "Sports" },
                    { 5, "Hiking" },
                    { 6, "Travel" },
                    { 7, "Animals" },
                    { 8, "Video Games" },
                    { 9, "Board Games" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AddressId", "Age", "FirstName", "ImageUrl", "LastName" },
                values: new object[,]
                {
                    { 1, 1, 37, "Bruce", "/images/bwayne.jpg", "Wayne" },
                    { 2, 2, 22, "Kara", "/images/kdanvers.jpg", "Danvers" },
                    { 3, 3, 54, "Diana", "/images/dprince.jpg", "Prince" },
                    { 4, 4, 35, "Clark", "/images/ckent.jpg", "Kent" },
                    { 5, 5, 25, "Barbara", "/images/bgordon.jpg", "Gordon" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 1, 6 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 9 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 8 },
                    { 5, 1 },
                    { 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
