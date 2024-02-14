using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFCloudAPIRecap.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokedex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokedex", x => x.Id);
                    table.CheckConstraint("CK_hp", "HP > 0");
                });

            migrationBuilder.CreateTable(
                name: "Typelist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typelist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Pokemon",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Pokemon", x => new { x.TypeId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_Type_Pokemon_Pokedex_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokedex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Type_Pokemon_Typelist_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Typelist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Type_Pokemon_PokemonId",
                table: "Type_Pokemon",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Type_Pokemon");

            migrationBuilder.DropTable(
                name: "Pokedex");

            migrationBuilder.DropTable(
                name: "Typelist");
        }
    }
}
