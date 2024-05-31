using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Instructore
{
    public int Idinstructores { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public int? IdDirecciones { get; set; }

    public string? Telefono { get; set; }

    public string? Usuario { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual Direccione? IdDireccionesNavigation { get; set; }
}
