using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// раздел дисцплины (для 4 команды)
/// </summary>
public partial class Razdel
{
    public int Id { get; set; }

    public int? Num { get; set; }

    public string Name { get; set; } = null!;

    public string? Lec { get; set; }

    public string? Lab { get; set; }

    public string? Prac { get; set; }

    public int? IdCourse { get; set; }

    public virtual Course? IdCourseNavigation { get; set; }

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
