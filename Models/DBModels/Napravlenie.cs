using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// направление подготовки
/// </summary>
public partial class Napravlenie
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdQualification { get; set; }

    public virtual Qualification IdQualificationNavigation { get; set; } = null!;

    public virtual ICollection<Oop> Oops { get; set; } = new List<Oop>();
}
