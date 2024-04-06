using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Dia
{
    public int Iddias { get; set; }

    public string Dias { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
