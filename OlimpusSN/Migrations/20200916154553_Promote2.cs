using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations
{
    public partial class Promote2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonAll_UserCommon_PersonCommonId",
                table: "PersonAll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCommon",
                table: "UserCommon");

            migrationBuilder.RenameTable(
                name: "UserCommon",
                newName: "PersonCommon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonCommon",
                table: "PersonCommon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAll_PersonCommon_PersonCommonId",
                table: "PersonAll",
                column: "PersonCommonId",
                principalTable: "PersonCommon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonAll_PersonCommon_PersonCommonId",
                table: "PersonAll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonCommon",
                table: "PersonCommon");

            migrationBuilder.RenameTable(
                name: "PersonCommon",
                newName: "UserCommon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCommon",
                table: "UserCommon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonAll_UserCommon_PersonCommonId",
                table: "PersonAll",
                column: "PersonCommonId",
                principalTable: "UserCommon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
