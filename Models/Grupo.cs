using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Grupo
{
    public int Idgrupos { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdInstructores { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Usuario? IdInstructoresNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
