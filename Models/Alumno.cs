using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Alumno
{
    public int Idalumnos { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string? User { get; set; }

    public string? Contacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
