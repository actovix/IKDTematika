using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// Часть плана (внутри блока)
/// </summary>
public partial class PartPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
