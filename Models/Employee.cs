using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Handphone { get; set; } = null!;

    public string Position { get; set; } = null!;

    public virtual ICollection<Headorder> Headorders { get; } = new List<Headorder>();
}
