using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations
{
    public partial class Another2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoCommon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "InfoEducation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhereEducated = table.Column<string>(nullable: true),
                    PeriodOfEducation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoEmployement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhereEmployemented = table.Column<string>(nullable: true),
                    PeriodOfEmployement = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEmployement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoHobbies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "PersonSummary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoComonId = table.Column<long>(nullable: false),
                    InfoCommonId = table.Column<long>(nullable: true),
                    InfoHobbiesId = table.Column<long>(nullable: false),
                    InfoEducationId = table.Column<long>(nullable: false),
                    InfoEmployementId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSummary_InfoCommon_InfoCommonId",
                        column: x => x.InfoCommonId,
                        principalTable: "InfoCommon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonSummary_InfoEducation_InfoEducationId",
                        column: x => x.InfoEducationId,
                        principalTable: "InfoEducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSummary_InfoEmployement_InfoEmployementId",
                        column: x => x.InfoEmployementId,
                        principalTable: "InfoEmployement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSummary_InfoHobbies_InfoHobbiesId",
                        column: x => x.InfoHobbiesId,
                        principalTable: "InfoHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonSummaryId",
                table: "AspNetUsers",
                column: "PersonSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSummary_InfoCommonId",
                table: "PersonSummary",
                column: "InfoCommonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSummary_InfoEducationId",
                table: "PersonSummary",
                column: "InfoEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSummary_InfoEmployementId",
                table: "PersonSummary",
                column: "InfoEmployementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSummary_InfoHobbiesId",
                table: "PersonSummary",
                column: "InfoHobbiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonSummary_PersonSummaryId",
                table: "AspNetUsers",
                column: "PersonSummaryId",
                principalTable: "PersonSummary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonSummary_PersonSummaryId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PersonSummary");

            migrationBuilder.DropTable(
                name: "InfoCommon");

            migrationBuilder.DropTable(
                name: "InfoEducation");

            migrationBuilder.DropTable(
                name: "InfoEmployement");

            migrationBuilder.DropTable(
                name: "InfoHobbies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonSummaryId",
                table: "AspNetUsers");
        }
    }
}
