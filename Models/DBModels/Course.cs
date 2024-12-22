using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// дисциплина
/// </summary>
public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int IdOop { get; set; }

    public int IdDep { get; set; }

    public string? Module { get; set; }

    public bool IsRequired { get; set; }

    public int IdBlock { get; set; }

    public int IdPart { get; set; }

    public string? UrlIstuRpd { get; set; }

    public string? UrlIstuAnnot { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();

    public virtual BlockPlan IdBlockNavigation { get; set; } = null!;

    public virtual Dep IdDepNavigation { get; set; } = null!;

    public virtual Oop IdOopNavigation { get; set; } = null!;

    public virtual PartPlan IdPartNavigation { get; set; } = null!;

    public virtual ICollection<Razdel> Razdels { get; set; } = new List<Razdel>();

    public virtual ICollection<Semestr> Semestrs { get; set; } = new List<Semestr>();
}
