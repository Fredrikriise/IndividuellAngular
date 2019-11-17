using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellAngular.Models
{
    public class KategoriOgSporsmal
    {
        public int kategoriId { get; set; }
        public string kategoriNavn { get; set; }
        public List<FAQ> AlleFAQList { get; set; }
    }
}
