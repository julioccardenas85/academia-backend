using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Direccione
{
    public int Iddirecciones { get; set; }

    public string Calle { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public int IdColonias { get; set; }

    public virtual ICollection<Academia> Academia { get; set; } = new List<Academia>();

    public virtual Colonia IdColoniasNavigation { get; set; } = null!;

    public virtual ICollection<Instructore> Instructores { get; set; } = new List<Instructore>();

    public virtual ICollection<Padre> Padres { get; set; } = new List<Padre>();
}
