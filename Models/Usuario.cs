using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public int? IdRoles { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual Role? IdRolesNavigation { get; set; }
}
