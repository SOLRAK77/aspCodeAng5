using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class Mensajes
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Mensaje { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}
