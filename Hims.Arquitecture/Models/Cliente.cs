using System;
using System.Collections.Generic;

namespace Hims.Arquitecture.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoPostal { get; set; }

    public int NumeroCliente { get; set; }

    public string? Genero { get; set; }

    public string? Cumpleaños { get; set; }

    public string? Grupos { get; set; }

    public string? App { get; set; }

    public string? CifNif { get; set; }

    public string? RazonSocial { get; set; }
}
