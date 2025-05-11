using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class GruposView
{
    public int Idgrupos { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdInstructores { get; set; }

    public string Instructor { get; set; } = null!;
}
