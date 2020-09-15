using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations.UserDb
{
    public partial class PersonSummaryInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfoSumId",
                table: "InfoCommon");

            migrationBuilder.AddColumn<long>(
                name: "PersonSummaryId",
                table: "InfoCommon",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "InfoEducation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonSummaryId = table.Column<long>(nullable: false),
                    WhereEducated = table.Column<string>(nullable: true),
                    PeriodOfEducation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoHobbies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonSummaryId = table.Column<long>(nullable: false),
                    Hobbies = table.Column<string>(nullable: true),
                    FavMusic = table.Column<string>(nullable: true),
                    FavTV = table.Column<string>(nullable: true),
                    FavBooks = table.Column<string>(nullable: true),
                    FavMovies = table.Column<string>(nullable: true),
                    FavWriters = table.Column<string>(nullable: true),
                    FavGames = table.Column<string>(nullable: true),
                    OtherInterests = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoHobbies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoEducation");

            migrationBuilder.DropTable(
                name: "InfoHobbies");

            migrationBuilder.DropColumn(
                name: "PersonSummaryId",
                table: "InfoCommon");

            migrationBuilder.AddColumn<long>(
                name: "UserInfoSumId",
                table: "InfoCommon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
