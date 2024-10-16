using System;
using System.Collections.Generic;

namespace Hims.Arquitecture.Models;

public partial class Branches
{
    public int SucursalId { get; set; }

    public string NombreSucursal { get; set; } = null!;

    public int HorarioSucursal { get; set; }

    public string UbicacionSucursal { get; set; } = null!;

}
