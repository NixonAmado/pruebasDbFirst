using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class FormaPago
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
