using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Matricula
{
    public int Idmatriculas { get; set; }

    public int IdAlumnos { get; set; }

    public int IdGrupos { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public virtual Alumno IdAlumnosNavigation { get; set; } = null!;

    public virtual Grupo IdGruposNavigation { get; set; } = null!;
}
