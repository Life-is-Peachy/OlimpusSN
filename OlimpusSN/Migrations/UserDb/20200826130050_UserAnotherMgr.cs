using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations.UserDb
{
    public partial class UserAnotherMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonSummaryId",
                table: "InfoHobbies");

            migrationBuilder.DropColumn(
                name: "PersonSummaryId",
                table: "InfoEducation");

            migrationBuilder.DropColumn(
                name: "PersonSummaryId",
                table: "InfoCommon");

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
                name: "InfoSummary",
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
                    table.PrimaryKey("PK_InfoSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoSummary_InfoCommon_InfoCommonId",
                        column: x => x.InfoCommonId,
                        principalTable: "InfoCommon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoSummary_InfoEducation_InfoEducationId",
                        column: x => x.InfoEducationId,
                        principalTable: "InfoEducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoSummary_InfoEmployement_InfoEmployementId",
                        column: x => x.InfoEmployementId,
                        principalTable: "InfoEmployement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoSummary_InfoHobbies_InfoHobbiesId",
                        column: x => x.InfoHobbiesId,
                        principalTable: "InfoHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSummary_InfoCommonId",
                table: "InfoSummary",
                column: "InfoCommonId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSummary_InfoEducationId",
                table: "InfoSummary",
                column: "InfoEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSummary_InfoEmployementId",
                table: "InfoSummary",
                column: "InfoEmployementId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSummary_InfoHobbiesId",
                table: "InfoSummary",
                column: "InfoHobbiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoSummary");

            migrationBuilder.DropTable(
                name: "InfoEmployement");

            migrationBuilder.AddColumn<long>(
                name: "PersonSummaryId",
                table: "InfoHobbies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PersonSummaryId",
                table: "InfoEducation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PersonSummaryId",
                table: "InfoCommon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
