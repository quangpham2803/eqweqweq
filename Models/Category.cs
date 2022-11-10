using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class Category
    {
        public Category()
        {
            FilmFilms = new HashSet<Film>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; } = null!;

        public virtual ICollection<Film> FilmFilms { get; set; }
    }
}
