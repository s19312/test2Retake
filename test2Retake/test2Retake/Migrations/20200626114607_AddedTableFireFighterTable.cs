using Microsoft.EntityFrameworkCore.Migrations;

namespace test2Retake.Migrations
{
    public partial class AddedTableFireFighterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FireFighter",
                columns: table => new
                {
                    IdFireFighter = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireFighter_pk", x => x.IdFireFighter);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireFighter");
        }
    }
}
