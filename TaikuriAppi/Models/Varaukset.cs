using System;
using System.Collections.Generic;

namespace TaikuriAppi.Models
{
    public partial class Varaukset
    {
        public int VarausId { get; set; }
        public DateTime Päivämäärä { get; set; }
        public int? TaikuriId { get; set; }
        public int? AsiakasId { get; set; }

        public virtual Asiaka? Asiakas { get; set; }
        public virtual Taikuri? Taikuri { get; set; }
    }
}
