using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Cp
{
    public int IdCps { get; set; }

    public string Cp1 { get; set; } = null!;

    public int IdMunicipios { get; set; }

    public virtual ICollection<Colonia> Colonia { get; set; } = new List<Colonia>();

    public virtual Municipio IdMunicipiosNavigation { get; set; } = null!;
}
