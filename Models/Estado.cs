using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Estado
{
    public int Idestados { get; set; }

    public string Estado1 { get; set; } = null!;

    public int IdPaises { get; set; }

    public virtual Paise IdPaisesNavigation { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
