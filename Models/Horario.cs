using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Horario
{
    public int Idhorarios { get; set; }

    public int IdGrupos { get; set; }

    public int IdDias { get; set; }

    public TimeOnly Hora { get; set; }

    public string? Salon { get; set; }

    public virtual Dia IdDiasNavigation { get; set; } = null!;

    public virtual Grupo IdGruposNavigation { get; set; } = null!;
}
