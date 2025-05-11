using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Pago
{
    public int Id { get; set; }

    public long? PaymentId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public decimal? Monto { get; set; }

    public string? Status { get; set; }

    public string? PaymentType { get; set; }

    public string? EmailComprador { get; set; }

    public int? IdUsuarios { get; set; }

    public int? Unidades { get; set; }

    public string? Concepto { get; set; }
}
