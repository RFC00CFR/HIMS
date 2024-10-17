using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hims.Arquitecture.Models
{
    public partial class Servicio
    {
        public int IdServicio { get; set; }

        public string NombreDelServicio { get; set; } = null!;

        public int DuracionServicio { get; set; }

        public decimal PrecioServicio { get; set; }
    }
}
