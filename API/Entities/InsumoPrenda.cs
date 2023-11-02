using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class InsumoPrenda
{
    public int IdInsumoFk { get; set; }

    public int IdPrendaFk { get; set; }

    public int Cantidad { get; set; }

    public virtual Insumo IdInsumoFkNavigation { get; set; } = null!;

    public virtual Prenda IdPrendaFkNavigation { get; set; } = null!;
}
