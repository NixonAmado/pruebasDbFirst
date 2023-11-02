using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Talla
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual ICollection<Inventario> IdInvFks { get; set; } = new List<Inventario>();
}
