using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// кафедра
/// </summary>
public partial class Dep
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdHead { get; set; }

    public int IdPodr { get; set; }

    public string? UrlIstu { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Head? IdHeadNavigation { get; set; }

    public virtual Podr IdPodrNavigation { get; set; } = null!;

    public virtual ICollection<Oop> Oops { get; set; } = new List<Oop>();
}
