using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class Episode
    {
        public int EpisodeId { get; set; }
        public string EpisodeName { get; set; } = null!;
        public string EpisodeTime { get; set; } = null!;
        public string EpisodeUrl { get; set; } = null!;
        public int FilmId { get; set; }

        public virtual Film Film { get; set; } = null!;
    }
}
