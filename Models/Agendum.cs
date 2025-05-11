using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Agendum
{
    public int IdAgenda { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    public string Color { get; set; } = null!;

    public sbyte? AllDay { get; set; }
}
