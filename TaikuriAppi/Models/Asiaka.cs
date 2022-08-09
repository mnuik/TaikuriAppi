using System;
using System.Collections.Generic;

namespace TaikuriAppi.Models
{
    public partial class Asiaka
    {
        public Asiaka()
        {
            Varauksets = new HashSet<Varaukset>();
        }

        public int AsiakasId { get; set; }
        public string Etunimi { get; set; } = null!;
        public string Sukunimi { get; set; } = null!;
        public string Osoite { get; set; } = null!;
        public int Puhelinnumero { get; set; }
        public int Sähköposti { get; set; }

        public virtual ICollection<Varaukset> Varauksets { get; set; }
    }
}
