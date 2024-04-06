using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Username
{
    public int Idusernames { get; set; }

    public string Username1 { get; set; } = null!;

    public int IdAlumnos { get; set; }
}
