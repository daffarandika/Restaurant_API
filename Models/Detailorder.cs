using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Detailorder
{
    public int Detailid { get; set; }

    public int OrderId { get; set; }

    public int MenuId { get; set; }

    public int Qty { get; set; }

    public int Price { get; set; }

    public string Status { get; set; } = null!;

    public virtual Menu Menu { get; set; } = null!;

    public virtual Headorder Order { get; set; } = null!;
}
