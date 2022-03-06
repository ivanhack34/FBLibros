using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBLibros.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Edicion { get; set; }
        [Required]
        public DateTime FechaPublicacion { get; set; }
    }
}
