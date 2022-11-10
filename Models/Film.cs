using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class Film
    {
        public Film()
        {
            Comments = new HashSet<Comment>();
            Episodes = new HashSet<Episode>();
            Ratings = new HashSet<Rating>();
            Trailers = new HashSet<Trailer>();
            CategoryCats = new HashSet<Category>();
        }

        public int FilmId { get; set; }
        public string FilmName { get; set; } = null!;
        public string FilmPoster { get; set; } = null!;
        public string FilmInfo { get; set; } = null!;
        public int FilmViewed { get; set; }
        public int FilmYear { get; set; }
        public string FilmArea { get; set; } = null!;
        public float FilmRating { get; set; }
        public int FilmCountEp { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Trailer> Trailers { get; set; }

        public virtual ICollection<Category> CategoryCats { get; set; }
    }
}
