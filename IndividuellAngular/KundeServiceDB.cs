using IndividuellAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividuellAngular
{
    public class KundeServiceDB
    {
        private readonly KundeServiceContext _dbcontext;

        //Tilkobling til db
        public KundeServiceDB(KundeServiceContext dbcontext)
        {
            _dbcontext = dbcontext;
            //_dbcontext.Database.EnsureDeleted();
            _dbcontext.Database.EnsureCreated();
        }

        //Metoder for faq
        public List<KategoriOgSporsmal> hentAlleFaq()
        {
            var alleKategorier = _dbcontext.AlleKategorier.ToList();
            List<KategoriOgSporsmal> alleKategorierListe = new List<KategoriOgSporsmal>();


            foreach (var enKategori in alleKategorier)
            {
                var enFaq = _dbcontext.AlleFaq.Where(faq => faq.kategoriNavn.kategoriId == enKategori.kategoriId).ToList();
                var etKategoriogsporsmal = new KategoriOgSporsmal
                {
                    kategoriId = enKategori.kategoriId,
                    kategoriNavn = enKategori.kategoriNavn,
                    AlleFAQList = enFaq,
                };
                alleKategorierListe.Add(etKategoriogsporsmal);
            }
            return alleKategorierListe;
        }

        //Metoder for innsporsmal
        public bool lagreEtSporsmal(innsporsmal innSporsmal)
        {
            var nyttSporsmal = new InnSporsmal
            {
                navn = innSporsmal.navn,
                email = innSporsmal.email,
                sporsmal = innSporsmal.sporsmal
            };

            try
            {
                _dbcontext.Add(nyttSporsmal);
                _dbcontext.SaveChanges();
            }
            catch (Exception error)
            {
                return false;
            }
            return true;
        }

        public List<innsporsmal> hentAlleInnSporsmal()
        {
            List<innsporsmal> alleInnSporsmal = _dbcontext.AlleInnSporsmal.Select(s => new innsporsmal()
            {
                id = s.id,
                navn = s.navn,
                email = s.email,
                sporsmal = s.sporsmal
            }).ToList();
            return alleInnSporsmal;
        }


        //Metoder for upvote og downvote
        public bool endreUpvote(int id)
        {
            FAQ funnetFAQ = _dbcontext.AlleFaq.First(k => k.id == id);
            if(funnetFAQ == null)
            {
                return false;
            }

            funnetFAQ.upvote++;
            try
            {
                _dbcontext.SaveChanges();
            }
            catch(Exception feil)
            {
                return false;
            }
            return true;
        }

        public bool endreDownvote(int id)
        {
            FAQ funnetFAQ = _dbcontext.AlleFaq.First(k => k.id == id);
            if (funnetFAQ == null)
            {
                return false;
            }

            funnetFAQ.downvote++;
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }
}
