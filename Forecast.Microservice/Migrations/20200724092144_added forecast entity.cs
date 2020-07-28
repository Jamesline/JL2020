using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forecast.Microservice.Migrations
{
    public partial class addedforecastentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Month = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    BU = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coges", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coges");
        }
    }
}
