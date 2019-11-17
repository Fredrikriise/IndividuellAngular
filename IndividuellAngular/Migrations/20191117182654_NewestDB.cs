using Microsoft.EntityFrameworkCore.Migrations;

namespace IndividuellAngular.Migrations
{
    public partial class NewestDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "sporsmal", "svar" },
                values: new object[] { "Hvordan kjøper jeg billett?", "Du kan kjøpe billett fra: Vy.no, Vy appen, billettautomat, betjent stasjon, narvesen, om bord i toget og hos kundeservice." });

            migrationBuilder.UpdateData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "kategoriId", "sporsmal", "svar" },
                values: new object[] { 1, "Hvordan kjøper jeg periodebillett?", "Det enkleste for deg er å kjøpe periodebilletten i appen. Du kan ikke kjøpre periodebillett om bord." });

            migrationBuilder.InsertData(
                table: "AlleFaq",
                columns: new[] { "id", "downvote", "kategoriId", "sporsmal", "svar", "upvote" },
                values: new object[,]
                {
                    { 3, 0, 1, "Hva er reisekort?", "Med reisekort reiser du med elektronisk billett hos Vy og Ruter, som samarbeider om kortsystemet elektronisk reisekort. Reisekortet gjelder i Oslo og Akershus. Du kan kjøpe reisekort fra kundeservice eller på betjent stasjon.", 0 },
                    { 4, 0, 2, "Hvordan kan jeg endre eller avbestille billetten?", "For å endre billetten din, må du først avbestille den og så kjøpe ny billett til avgangen du skal reise med.", 0 },
                    { 5, 0, 2, "Hvordan endrer jeg navn på billetten?", "Når du kjøper billetter så er det navnet til den som bestiller som står på billettene. Det er altså ikke noe i veien for at det står samme navn på flere billetter, så lenge personen som bestilte billettene skal være med på reisen. Hvis ikke personen står som oppført på billettene blir med på reisen, ring eller chat med kundeservice for å endre navn.", 0 }
                });

            migrationBuilder.InsertData(
                table: "AlleInnSporsmal",
                columns: new[] { "id", "email", "navn", "sporsmal" },
                values: new object[] { 3, "karoline.m95@gmail.com", "Karoline Martinsen", "Jeg hadde billett, men fikk fortsatt bot. Hvordan kan jeg klage?" });

            migrationBuilder.UpdateData(
                table: "AlleKategorier",
                keyColumn: "kategoriId",
                keyValue: 1,
                column: "kategoriNavn",
                value: "Billetter");

            migrationBuilder.UpdateData(
                table: "AlleKategorier",
                keyColumn: "kategoriId",
                keyValue: 2,
                column: "kategoriNavn",
                value: "Endringer");

            migrationBuilder.InsertData(
                table: "AlleKategorier",
                columns: new[] { "kategoriId", "kategoriNavn" },
                values: new object[] { 3, "Bagasje og kjæledyr" });

            migrationBuilder.InsertData(
                table: "AlleFaq",
                columns: new[] { "id", "downvote", "kategoriId", "sporsmal", "svar", "upvote" },
                values: new object[] { 6, 0, 3, "Jeg har glemt noe om bord. Hvordan kontakter jeg dere om hittegods?", "Dersom du har glemt noe om bord kan du kontakte kundeservice som vil videreføre deg til hittegodskontoret som passer deg. Her vil en ansatt kunne svare på om det du har mistet har ankommet hittegodskontoret.", 0 });

            migrationBuilder.InsertData(
                table: "AlleFaq",
                columns: new[] { "id", "downvote", "kategoriId", "sporsmal", "svar", "upvote" },
                values: new object[] { 7, 0, 3, "Hvor mye bagasje kan jeg ha med?", "Du kan ta med deg inntil 30 kilo fordelt på maksimum 3 kolli. Har du mer enn dette og skal reise mellom Oslo og Voss/Bergen eller Trondheim, kan du benytte deg av bagasjetransport.", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AlleInnSporsmal",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AlleKategorier",
                keyColumn: "kategoriId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "sporsmal", "svar" },
                values: new object[] { "TestSpørsmål", "Testsvar" });

            migrationBuilder.UpdateData(
                table: "AlleFaq",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "kategoriId", "sporsmal", "svar" },
                values: new object[] { 2, "TestSpørsmål", "Testsvar" });

            migrationBuilder.UpdateData(
                table: "AlleKategorier",
                keyColumn: "kategoriId",
                keyValue: 1,
                column: "kategoriNavn",
                value: "Bestilling");

            migrationBuilder.UpdateData(
                table: "AlleKategorier",
                keyColumn: "kategoriId",
                keyValue: 2,
                column: "kategoriNavn",
                value: "Betaling");
        }
    }
}
