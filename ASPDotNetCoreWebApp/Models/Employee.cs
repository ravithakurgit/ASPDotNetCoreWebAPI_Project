using System;
using System.Collections.Generic;

namespace ASPDotNetCoreWebApp.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int? Address { get; set; }

    public string Code { get; set; } = null!;
}
