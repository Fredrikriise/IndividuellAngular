using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellAngular.Models
{
    //Tilleggsklasse for modelbuilder
    public static class ModelbuilderExtension
    {
        public static void SeedToDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ()
                {
                    id = 1,
                    sporsmal = "Hvordan kjøper jeg billett?",
                    svar = "Du kan kjøpe billett fra: Vy.no, Vy appen, billettautomat, betjent stasjon, narvesen, om bord i toget og hos kundeservice.",
                    kategoriId = 1,
                },
                new FAQ
                {
                    id = 2,
                    sporsmal = "Hvordan kjøper jeg periodebillett?",
                    svar = "Det enkleste for deg er å kjøpe periodebilletten i appen. Du kan ikke kjøpre periodebillett om bord.",
                    kategoriId = 1,
                },
                new FAQ
                {
                    id = 3,
                    sporsmal = "Hva er reisekort?",
                    svar = "Med reisekort reiser du med elektronisk billett hos Vy og Ruter, som samarbeider om kortsystemet elektronisk reisekort. Reisekortet gjelder i Oslo og Akershus. Du kan kjøpe reisekort fra kundeservice eller på betjent stasjon.",
                    kategoriId = 1,
                },
                new FAQ
                {
                    id = 4,
                    sporsmal = "Hvordan kan jeg endre eller avbestille billetten?",
                    svar = "For å endre billetten din, må du først avbestille den og så kjøpe ny billett til avgangen du skal reise med.",
                    kategoriId = 2,
                },
                new FAQ
                {
                    id = 5,
                    sporsmal = "Hvordan endrer jeg navn på billetten?",
                    svar = "Når du kjøper billetter så er det navnet til den som bestiller som står på billettene. Det er altså ikke noe i veien for at det står samme navn på flere billetter, så lenge personen som bestilte billettene skal være med på reisen. Hvis ikke personen står som oppført på billettene blir med på reisen, ring eller chat med kundeservice for å endre navn.",
                    kategoriId = 2,
                },
                new FAQ
                {
                    id = 6,
                    sporsmal = "Jeg har glemt noe om bord. Hvordan kontakter jeg dere om hittegods?",
                    svar = "Dersom du har glemt noe om bord kan du kontakte kundeservice som vil videreføre deg til hittegodskontoret som passer deg. Her vil en ansatt kunne svare på om det du har mistet har ankommet hittegodskontoret.",
                    kategoriId = 3,
                },
                new FAQ
                {
                    id = 7,
                    sporsmal = "Hvor mye bagasje kan jeg ha med?",
                    svar = "Du kan ta med deg inntil 30 kilo fordelt på maksimum 3 kolli. Har du mer enn dette og skal reise mellom Oslo og Voss/Bergen eller Trondheim, kan du benytte deg av bagasjetransport.",
                    kategoriId = 3,
                }
            );

            modelBuilder.Entity<Kategori>().HasData(
                new Kategori
                {
                    kategoriId = 1,
                    kategoriNavn = "Billetter",
                },
                new Kategori
                {
                    kategoriId = 2,
                    kategoriNavn = "Endringer",
                },
                new Kategori
                {
                    kategoriId = 3,
                    kategoriNavn = "Bagasje og kjæledyr",
                }
            );

            modelBuilder.Entity<InnSporsmal>().HasData(
                new InnSporsmal
                {
                    id = 1,
                    navn = "Fredrik Riise",
                    email = "fredrik1998@hotmail.com",
                    sporsmal = "Dersom toget blir innstilt, dekkes taxi av dere?",
                },
                new InnSporsmal
                {
                    id = 2,
                    navn = "Per Persen",
                    email = "per.persen@gmail.com",
                    sporsmal = "Hvem kontakter jeg dersom jeg har mistet noe på toget deres?",
                },
                new InnSporsmal
                {
                    id = 3,
                    navn = "Karoline Martinsen",
                    email = "karoline.m95@gmail.com",
                    sporsmal = "Jeg hadde billett, men fikk fortsatt bot. Hvordan kan jeg klage?",
                }
            );
        }
    }
}
