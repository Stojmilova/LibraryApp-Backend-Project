using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class Init33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    NumbersOfCopies = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, "Bob", "Bobsky", "(?\\?-??3#>L?q", "bob007" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Context", "Genre", "NumbersOfCopies", "Title", "UserId" },
                values: new object[] { 1, "Annie Auerbach", @"SpongeBob's ego--and head--swell when he is selected to  
                    star in a television special as the world's biggest daredevil,  
                    but hotshot producer Barry Cuda has another role in mind for him.", 6, 10, "SpongeBob Superstar", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Context", "Genre", "NumbersOfCopies", "Title", "UserId" },
                values: new object[] { 2, "Clive Cussler", @"Marine explorer Dirk Pitt must rely on the nautical lore
                    of Jules Verne to stop a ruthless oil baron with his sights set on political
                    power in this #1 New York Times-bestselling series.", 5, 8, "Valhalla rising", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
