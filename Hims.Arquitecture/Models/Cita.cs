using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hims.Arquitecture.Models
{
    public partial class Cita
    {
        public int CitaId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public int IdServicio { get; set; }

        public DateTime FechaCita { get; set; }

        public string Estado { get; set; } = "Activa";

        public string? Comentarios { get; set; }

    }
}
