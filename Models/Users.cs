using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Users
    {
        public Users()
        {
            FollowersFollowed = new HashSet<Followers>();
            FollowersUser = new HashSet<Followers>();
            Mensajes = new HashSet<Mensajes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }

        public ICollection<Followers> FollowersFollowed { get; set; }
        public ICollection<Followers> FollowersUser { get; set; }
        public ICollection<Mensajes> Mensajes { get; set; }
    }
}
