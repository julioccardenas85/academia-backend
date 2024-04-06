using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Paise
{
    public int Idpaises { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();
}
