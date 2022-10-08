using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCrud.Server.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToyType = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toys_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "LEGO" },
                    { 2, "Hot Wheels" },
                    { 3, "Funko" },
                    { 4, "Marvel" }
                });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "Id", "BrandId", "Name", "ToyType" },
                values: new object[,]
                {
                    { 1, 1, "Star Wars Star Destroyer", 4 },
                    { 2, 3, "Pop Cyberpunk 2077 - Johnny Silverhand", 0 },
                    { 3, 2, "Honda Civic Type S", 0 },
                    { 4, 4, "Spiderman - The Game (PS5)", 2 },
                    { 5, 4, "Iron Man Action Figure", 0 },
                    { 6, 4, "Hulk Action Figure", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toys_BrandId",
                table: "Toys",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
