using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketWithDependency.Migrations
{
    public partial class AddedStuffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stuffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stuffDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    StuffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stuffDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stuffDetails_Stuffs_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stuffDetails_StuffId",
                table: "stuffDetails",
                column: "StuffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stuffDetails");

            migrationBuilder.DropTable(
                name: "Stuffs");
        }
    }
}
