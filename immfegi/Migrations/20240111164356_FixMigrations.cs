using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace immfegi.Migrations
{
    public partial class FixMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScientificDirectorPatronymic",
                table: "SchoolArticleForms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3298e89c-2e9d-4755-b77f-5e2ad1065f37", "AQAAAAEAACcQAAAAEGObgREFyyPlJU4zO8n4wyWLLmuTnsIrGYjfDGkHZUQ5NAfjpSlGnCiHKYh5CwXV6w==", "e3dbbc6d-0cea-4ee9-9f26-1a70fe6fd23c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09c55d0d-4ab3-4143-b819-19f92236c92f", "AQAAAAEAACcQAAAAEElEwMIZjmsNAB6bgjLyeVCXROURO9TDB6B+f2tyYL4sYyeyiAC1hBfUByFZTrCAVQ==", "234afc3d-27e1-4bac-83d6-567c7679691a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScientificDirectorPatronymic",
                table: "SchoolArticleForms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1881919b-0623-405a-96fa-df3a667144e3", "AQAAAAEAACcQAAAAEId9torwfIlvTKgj5xuZgn7D8HpezerHVPunzeo8wf4WCKkZ9pNvcs8sslVa3Gw1Kg==", "53a1a972-5846-4272-98f8-42e96b148b64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3404a82f-e2d6-40ee-a45a-eb5d66522623", "AQAAAAEAACcQAAAAEKFfHxRiH39JrVzSIbjqG+1ueCmZ0IuTiAn1pNzDhKscH1rpMXA2RwBZjp0wAe25fA==", "7708daf4-4dbf-480f-8047-702916f8402c" });
        }
    }
}
