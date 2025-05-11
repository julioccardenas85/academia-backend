using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class MatriculasView
{
    public int Idmatriculas { get; set; }

    public int IdUsuarios { get; set; }

    public string NombreAlumno { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int IdGrupos { get; set; }

    public string NombreGrupo { get; set; } = null!;

    public DateOnly? FechaIngreso { get; set; }
}
