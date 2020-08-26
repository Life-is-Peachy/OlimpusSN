using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations.UserDb
{
    public partial class UserInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoCommon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserInfoSumId = table.Column<long>(nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    AboutMe = table.Column<string>(nullable: true),
                    Birthplace = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Married = table.Column<int>(nullable: false),
                    Political = table.Column<string>(nullable: true),
                    Religious = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoCommon", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoCommon");
        }
    }
}
