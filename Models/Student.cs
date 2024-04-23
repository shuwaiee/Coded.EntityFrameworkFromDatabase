using System;
using System.Collections.Generic;

namespace EntityFrameworkFromDatabase.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? Dob { get; set; }

    public string? CivilId { get; set; }

    public virtual Department? Department { get; set; }
}
