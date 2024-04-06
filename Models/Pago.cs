using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Pago
{
    public int Idpagos { get; set; }

    public int IdAlumnos { get; set; }

    public DateOnly Fecha { get; set; }

    public float Importe { get; set; }

    public string Concepto { get; set; } = null!;

    public string MedioPago { get; set; } = null!;

    public virtual Alumno IdAlumnosNavigation { get; set; } = null!;
}
