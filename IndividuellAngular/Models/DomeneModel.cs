using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellAngular.Models
{
    public class faq
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,9999}$")]
        public string sporsmal { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,9999}$")]
        public string svar { get; set; }
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,9999}$")]
        public string kategori { get; set; }

    }

    public class innsporsmal
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9 \\-]{2,50}$")]
        public string navn { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,999}$")]
        public string sporsmal { get; set; }
    }
}
