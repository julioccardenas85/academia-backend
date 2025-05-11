using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Academia
{
    public int Idacademias { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdDirecciones { get; set; }

    public string? Telefono { get; set; }

    public virtual Direccione? IdDireccionesNavigation { get; set; }
}
