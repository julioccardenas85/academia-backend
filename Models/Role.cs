using System;
using System.Collections.Generic;

namespace Server.Models;

/// <summary>
/// 	
/// </summary>
public partial class Role
{
    public int Idroles { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
