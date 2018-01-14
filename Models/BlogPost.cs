using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public partial class BlogPost
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
