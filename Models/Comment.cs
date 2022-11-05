using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class Comment
    {
        public int UserUserId { get; set; }
        public int FilmFilmId { get; set; }
        public string CommentContent { get; set; } = null!;
        public DateTime CommentTime { get; set; }

        public virtual Film FilmFilm { get; set; } = null!;
        public virtual UserSystem UserUser { get; set; } = null!;
    }
}
