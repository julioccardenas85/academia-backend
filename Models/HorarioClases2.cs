using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class HorarioClases2
{
    public int Día { get; set; }

    public int Clase { get; set; }

    public int Hora { get; set; }

    public int NombreDelInstructor { get; set; }

    public int ApellidoDelInstructor { get; set; }
}
