using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Photo { get; set; } = null!;

    public virtual ICollection<Detailorder> Detailorders { get; } = new List<Detailorder>();
}
