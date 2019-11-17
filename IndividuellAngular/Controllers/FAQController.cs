using IndividuellAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace IndividuellAngular.Controllers
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly KundeServiceContext _dbcontext;

        //Metode for tilkobling til database
        public FAQController(KundeServiceContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //GET api/faq - Lister alle faqene
        [HttpGet]
        public JsonResult Get()
        {
            var kundeserviceDb = new KundeServiceDB(_dbcontext);
            List<KategoriOgSporsmal> alleFAQ = kundeserviceDb.hentAlleFaq();
            return Json(alleFAQ);
        }

        // POST api/faq - Oppretter ny faq
        [HttpPost]
        public JsonResult Post([FromBody]faq innFaq)
        {
            if (ModelState.IsValid)
            {
                var kundeserviceDb = new KundeServiceDB(_dbcontext);
                bool OK = kundeserviceDb.largeEnFaq(innFaq);
                if (OK)
                {
                    return Json("Opprettelse av ny FAQ var suksessfult!");
                }
            }
            return Json("Opprettelse av ny FAQ feilet!");
        }

        //Update api/faq/"id"
        [HttpPut("{id}")]
        public JsonResult Put(int id)
        {
            if(ModelState.IsValid)
            {
                var kundeserviceDb = new KundeServiceDB(_dbcontext);
                bool OK = kundeserviceDb.endreUpvote(id);
                if(OK)
                {
                    return Json("Endring av upvate var suksessfult");
                }
            }
            return Json("Kunne ikke endre upvote");
        }
        
    }
}