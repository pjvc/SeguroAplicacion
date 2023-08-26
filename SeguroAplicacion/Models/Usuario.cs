using System;
using System.Collections.Generic;

namespace SeguroAplicacion.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Cedula { get; set; }

    public string? Cliente { get; set; }

    public int? Telefono { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Seguro> Seguros { get; set; } = new List<Seguro>();
}
