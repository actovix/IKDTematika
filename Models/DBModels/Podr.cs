using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// подразделение: факультет или институт
/// </summary>
public partial class Podr
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdHead { get; set; }

    public string? UrlIstu { get; set; }

    public string? Sokr { get; set; }

    public virtual ICollection<Dep> Deps { get; set; } = new List<Dep>();

    public virtual Head? IdHeadNavigation { get; set; }
}
