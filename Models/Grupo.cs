using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Grupo
{
    public int Idgrupos { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdInstructores { get; set; }

    public int IdAcademias { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Academia IdAcademiasNavigation { get; set; } = null!;

    public virtual Instructore IdInstructoresNavigation { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
