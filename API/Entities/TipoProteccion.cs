using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class TipoProteccion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Prenda> Prenda { get; set; } = new List<Prenda>();
}
