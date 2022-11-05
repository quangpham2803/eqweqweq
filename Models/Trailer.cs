using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class Trailer
    {
        public int TrailerId { get; set; }
        public string TrailerName { get; set; } = null!;
        public string TrailerUrl { get; set; } = null!;
        public int FilmId { get; set; }

        public virtual Film Film { get; set; } = null!;
    }
}
