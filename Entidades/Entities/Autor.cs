using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entities
{
    public class Autor
    {
        [Key]
        public int AutorID { get; set; }
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Email { get; set; }
    }
}
