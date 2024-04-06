using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Colonia
{
    public int Idcolonias { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdCps { get; set; }

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual Cp IdCpsNavigation { get; set; } = null!;
}
