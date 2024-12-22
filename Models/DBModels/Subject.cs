using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// справочник тематик дисциплин (для 2 команды)
/// </summary>
public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Color { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
}
