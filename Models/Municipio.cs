using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Municipio
{
    public int Idmunicipios { get; set; }

    public string Municipio1 { get; set; } = null!;

    public int IdEstados { get; set; }

    public virtual ICollection<Cp> Cps { get; set; } = new List<Cp>();

    public virtual Estado IdEstadosNavigation { get; set; } = null!;
}
