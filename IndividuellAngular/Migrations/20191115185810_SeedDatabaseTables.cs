using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividuellAngular.Migrations
{
    public partial class SeedDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlleInnSporsmal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    navn = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sporsmal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlleInnSporsmal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlleKategorier",
                columns: table => new
                {
                    kategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategoriNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlleKategorier", x => x.kategoriId);
                });

            migrationBuilder.CreateTable(
                name: "AlleFaq",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sporsmal = table.Column<string>(nullable: true),
                    svar = table.Column<string>(nullable: true),
                    kategoriId = table.Column<int>(nullable: false),
                    upvote = table.Column<int>(nullable: false),
                    downvote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlleFaq", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlleFaq_AlleKategorier_kategoriId",
                        column: x => x.kategoriId,
                        principalTable: "AlleKategorier",
                        principalColumn: "kategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlleInnSporsmal",
                columns: new[] { "id", "email", "navn", "sporsmal" },
                values: new object[,]
                {
                    { 1, "fredrik1998@hotmail.com", "Fredrik Riise", "Dersom toget blir innstilt, dekkes taxi av dere?" },
                    { 2, "per.persen@gmail.com", "Per Persen", "Hvem kontakter jeg dersom jeg har mistet noe på toget deres?" }
                });

            migrationBuilder.InsertData(
                table: "AlleKategorier",
                columns: new[] { "kategoriId", "kategoriNavn" },
                values: new object[,]
                {
                    { 1, "Bestilling" },
                    { 2, "Betaling" }
                });

            migrationBuilder.InsertData(
                table: "AlleFaq",
                columns: new[] { "id", "downvote", "kategoriId", "sporsmal", "svar", "upvote" },
                values: new object[] { 1, 0, 1, "TestSpørsmål", "Testsvar", 0 });

            migrationBuilder.InsertData(
                table: "AlleFaq",
                columns: new[] { "id", "downvote", "kategoriId", "sporsmal", "svar", "upvote" },
                values: new object[] { 2, 0, 2, "TestSpørsmål", "Testsvar", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AlleFaq_kategoriId",
                table: "AlleFaq",
                column: "kategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlleFaq");

            migrationBuilder.DropTable(
                name: "AlleInnSporsmal");

            migrationBuilder.DropTable(
                name: "AlleKategorier");
        }
    }
}
