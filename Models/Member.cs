using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Handphone { get; set; } = null!;

    public DateTime Joindate { get; set; }

    public virtual ICollection<Headorder> Headorders { get; } = new List<Headorder>();
}
