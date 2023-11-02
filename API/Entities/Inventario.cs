using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Inventario
{
    public int Id { get; set; }

    public string CodInv { get; set; } = null!;

    public int IdPrendaFk { get; set; }

    public double ValorVtaCop { get; set; }

    public double ValorVtaUsd { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Prenda IdPrendaFkNavigation { get; set; } = null!;

    public virtual ICollection<Talla> IdTallaFks { get; set; } = new List<Talla>();
}
