using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// руководитель кафедры или ООП
/// </summary>
public partial class Head
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string FullFio { get; set; } = null!;

    public string? UrlIstu { get; set; }

    public virtual ICollection<Dep> Deps { get; set; } = new List<Dep>();

    public virtual ICollection<Oop> Oops { get; set; } = new List<Oop>();

    public virtual ICollection<Podr> Podrs { get; set; } = new List<Podr>();
}
