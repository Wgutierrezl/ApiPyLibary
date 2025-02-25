using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entities
{
    public class Prestamo
    {
        [Key]
        public int PrestamoID {  get; set; }
        public int LibroID { get; set; }
        public int UsuarioID { get; set; }
        public DateOnly FechaPrestamo { get; set; }
        public DateOnly FechaDevolucion { get; set; }
        public string? Estado { get; set; }
    }
}
