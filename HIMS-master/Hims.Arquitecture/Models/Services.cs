using System;
using System.Collections.Generic;

namespace Hims.Arquitecture.Models;

public partial class Services
{
    public int ServiceId { get; set; }

    public int CorteCabello { get; set; }

    public string Afeitado { get; set; } = null!;

    public string ArregloBarba { get; set; } = null!;

    public string Tratamientos { get; set; } = null!;

    public string Paquetes { get; set; } = null!;

   }
