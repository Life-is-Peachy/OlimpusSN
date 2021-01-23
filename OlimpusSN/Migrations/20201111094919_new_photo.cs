using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlimpusSN.Migrations
{
    public partial class new_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonCommon",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PersonCommon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonEducation",
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
                    table.PrimaryKey("PK_PersonEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonEmployement",
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
                    table.PrimaryKey("PK_PersonEmployement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
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
                    table.PrimaryKey("PK_PersonHobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonAll",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonCommonId = table.Column<long>(nullable: true),
                    PersonHobbiesId = table.Column<long>(nullable: true),
                    PersonEducationId = table.Column<long>(nullable: true),
                    PersonEmployementId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAll", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAll_PersonCommon_PersonCommonId",
                        column: x => x.PersonCommonId,
                        principalTable: "PersonCommon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAll_PersonEducation_PersonEducationId",
                        column: x => x.PersonEducationId,
                        principalTable: "PersonEducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAll_PersonEmployement_PersonEmployementId",
                        column: x => x.PersonEmployementId,
                        principalTable: "PersonEmployement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAll_PersonHobbies_PersonHobbiesId",
                        column: x => x.PersonHobbiesId,
                        principalTable: "PersonHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    PersonAllId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_PersonAll_PersonAllId",
                        column: x => x.PersonAllId,
                        principalTable: "PersonAll",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerFirstName = table.Column<string>(nullable: true),
                    OwnerLasnName = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAll_PersonCommonId",
                table: "PersonAll",
                column: "PersonCommonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAll_PersonEducationId",
                table: "PersonAll",
                column: "PersonEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAll_PersonEmployementId",
                table: "PersonAll",
                column: "PersonEmployementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAll_PersonHobbiesId",
                table: "PersonAll",
                column: "PersonHobbiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserID",
                table: "Photos",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonAllId",
                table: "Users",
                column: "PersonAllId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PersonAll");

            migrationBuilder.DropTable(
                name: "PersonCommon");

            migrationBuilder.DropTable(
                name: "PersonEducation");

            migrationBuilder.DropTable(
                name: "PersonEmployement");

            migrationBuilder.DropTable(
                name: "PersonHobbies");
        }
    }
}
