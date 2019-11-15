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
                    sporsmal = "TestSpørsmål",
                    svar = "Testsvar",
                    kategoriId = 1,
                },
                new FAQ
                {
                    id = 2,
                    sporsmal = "TestSpørsmål",
                    svar = "Testsvar",
                    kategoriId = 2,
                }
            );

            modelBuilder.Entity<Kategori>().HasData(
                new Kategori
                {
                    kategoriId = 1,
                    kategoriNavn = "Bestilling",
                },
                new Kategori
                {
                    kategoriId = 2,
                    kategoriNavn = "Betaling",
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
                }
            );
        }
    }
}
