using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class LogAlumno
{
    public int IdlogAlumnos { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime Fecha { get; set; }
}
