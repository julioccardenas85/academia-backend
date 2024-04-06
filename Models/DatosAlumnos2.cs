using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class DatosAlumnos2
{
    public int Nombre { get; set; }

    public int Apellidos { get; set; }

    public int Cumpleaños { get; set; }

    public int NombreDelPadre { get; set; }

    public int ApellidosDelPadre { get; set; }

    public int IdGrupos { get; set; }

    public int Grupo { get; set; }
}
