using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entities
{
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }
        public int IDAutor { get; set; }
        public string? Titulo { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Disponibilidad { get; set; }
    }
}
