using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations
{
    public partial class AnotherOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSummary_InfoCommon_InfoCommonId",
                table: "PersonSummary");

            migrationBuilder.DropColumn(
                name: "InfoComonId",
                table: "PersonSummary");

            migrationBuilder.AlterColumn<long>(
                name: "InfoCommonId",
                table: "PersonSummary",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSummary_InfoCommon_InfoCommonId",
                table: "PersonSummary",
                column: "InfoCommonId",
                principalTable: "InfoCommon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSummary_InfoCommon_InfoCommonId",
                table: "PersonSummary");

            migrationBuilder.AlterColumn<long>(
                name: "InfoCommonId",
                table: "PersonSummary",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "InfoComonId",
                table: "PersonSummary",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSummary_InfoCommon_InfoCommonId",
                table: "PersonSummary",
                column: "InfoCommonId",
                principalTable: "InfoCommon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
