using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// основная образовательная программа
/// </summary>
public partial class Oop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FirstYear { get; set; }

    public int IdHead { get; set; }

    public int IdDep { get; set; }

    public int IdNap { get; set; }

    public int IdStudyForm { get; set; }

    public int IdStatus { get; set; }

    public bool? Active { get; set; }

    public int? PreviousOopId { get; set; }

    public string? UrlIstu { get; set; }

    public string? UrlFile { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Dep IdDepNavigation { get; set; } = null!;

    public virtual Head IdHeadNavigation { get; set; } = null!;

    public virtual Napravlenie IdNapNavigation { get; set; } = null!;

    public virtual IkdStatus IdStatusNavigation { get; set; } = null!;

    public virtual StudyForm IdStudyFormNavigation { get; set; } = null!;

    public virtual ICollection<Oop> InversePreviousOop { get; set; } = new List<Oop>();

    public virtual Oop? PreviousOop { get; set; }
}
