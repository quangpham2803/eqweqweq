using System;
using System.Collections.Generic;

namespace hentaweb_v2.Models
{
    public partial class UserSystem
    {
        public UserSystem()
        {
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public int UserLevel { get; set; }
        public string UserImage { get; set; } = null!;
        public string UserInfo { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
