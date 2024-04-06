using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Padre
{
    public int Idpadres { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int? IdDirecciones { get; set; }

    public string? Telefono { get; set; }

    public virtual Direccione? IdDireccionesNavigation { get; set; }
}
