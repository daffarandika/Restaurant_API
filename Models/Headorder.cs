using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Headorder
{
    public int OrderId { get; set; }

    public int EmployeeId { get; set; }

    public int MemberId { get; set; }

    public DateTime Date { get; set; }

    public string Payment { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public virtual ICollection<Detailorder> Detailorders { get; } = new List<Detailorder>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
