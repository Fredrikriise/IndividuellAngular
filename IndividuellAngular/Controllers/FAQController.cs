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


        //Update api/faq/"id"
        [Route("[action]/{id}")]
        [HttpPut("{id}")]
        public JsonResult Put(int id)
        {
            if(ModelState.IsValid)
            {
                var kundeserviceDb = new KundeServiceDB(_dbcontext);
                bool OK = kundeserviceDb.endreUpvote(id);
                if(OK)
                {
                    return Json("Endring av upoate var suksessfult");
                }
            }
            return Json("Kunne ikke endre upvote");
        }

        //Update api/faq/"id"
        [Route("[action]/{id}")]
        [HttpPut("{id}")]
        public JsonResult PutDown(int id)
        {
            if (ModelState.IsValid)
            {
                var kundeserviceDb = new KundeServiceDB(_dbcontext);
                bool OK = kundeserviceDb.endreDownvote(id);
                if (OK)
                {
                    return Json("Endring av downvote var suksessfult");
                }
            }
            return Json("Kunne ikke endre downvote");
        }

    }
}