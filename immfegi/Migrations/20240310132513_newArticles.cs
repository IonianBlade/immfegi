using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace immfegi.Migrations
{
    public partial class newArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ArticleNameOnRussian = table.Column<string>(type: "text", nullable: false),
                    ArticleNameOnEnglish = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    ArticlePath = table.Column<string>(type: "text", nullable: false),
                    RequestPath = table.Column<string>(type: "text", nullable: false),
                    UploadDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ArticleFormStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    ArticleName = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    ArticleActivities = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ArticlePath = table.Column<string>(type: "text", nullable: false),
                    RequestPath = table.Column<string>(type: "text", nullable: false),
                    UploadDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ArticleFormStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserArticlesCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserArticlesCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserArticlesCollection_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserArticlesCollection_AspNetUsers_ApplicationUs~",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSchoolArticlesCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    SchoolArticleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSchoolArticlesCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSchoolArticlesCollection_AspNetUsers_Applica~",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSchoolArticlesCollection_SchoolArticles_Scho~",
                        column: x => x.SchoolArticleId,
                        principalTable: "SchoolArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd54dddd-e7f6-4ab7-b593-816047f06edd", "AQAAAAEAACcQAAAAEO8y0oob0pxJhO/VJX1sE9zmsvMIlxF3mT4/ddj38c+t+mMOqWh2DD5niBu62Vi5/Q==", "514142f1-39d4-46d4-b5b9-06df0ac2de59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b07f1a1-2fbe-409d-81c2-72f10f8051cd", "AQAAAAEAACcQAAAAEJfHEwRY8r5oe/tLfb3u6le9V2+WYgcxN1jYGkhOjG2tX0WoFy6pvU8FKZnsljxZVQ==", "77636592-3af8-4aad-9324-8fd2e76f0c5f" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserArticlesCollection_ApplicationUserId",
                table: "ApplicationUserArticlesCollection",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserArticlesCollection_ArticleId",
                table: "ApplicationUserArticlesCollection",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSchoolArticlesCollection_ApplicationUserId",
                table: "ApplicationUserSchoolArticlesCollection",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSchoolArticlesCollection_SchoolArticleId",
                table: "ApplicationUserSchoolArticlesCollection",
                column: "SchoolArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserArticlesCollection");

            migrationBuilder.DropTable(
                name: "ApplicationUserSchoolArticlesCollection");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "SchoolArticles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578e71a9-7773-4b3d-b5fa-57f6c7b320e2", "AQAAAAEAACcQAAAAEPHJFVSx9knaSqjWWKoWrjYCJVbg+ch2bQv/ffJhI6O9XbuqUrdCBrBQ7+1uWsAqcw==", "babf6ffa-85aa-4406-96ac-c81d862f0f8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "531d0a42-d6df-4269-b7b3-d313e7e4477a", "AQAAAAEAACcQAAAAEKRpYwiFxSWZ2zI06C6g8q91yA2UB/bOqSM+ZavaJaBbcG48j0AVK2ZUpdTp7FaV3A==", "436911f1-fb1f-4ec4-8e00-f2033b4c73d9" });
        }
    }
}
