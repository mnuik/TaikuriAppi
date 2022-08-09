using System;
using System.Collections.Generic;

namespace TaikuriAppi.Models
{
    public partial class Taikuri
    {
        public Taikuri()
        {
            Varauksets = new HashSet<Varaukset>();
        }

        public int TaikuriId { get; set; }
        public string Taiteilijanimi { get; set; } = null!;
        public string Toimialat { get; set; } = null!;
        public string Taidot { get; set; } = null!;
        public string Lokaatio { get; set; } = null!;

        public virtual ICollection<Varaukset> Varauksets { get; set; }
    }
}
