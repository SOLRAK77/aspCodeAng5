using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Followers
    {
        public int UserId { get; set; }
        public int FollowedId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Users Followed { get; set; }
        public Users User { get; set; }
    }
}
