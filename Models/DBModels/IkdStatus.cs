using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// статусы создания ИКД
/// </summary>
public partial class IkdStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Desription { get; set; } = null!;

    public virtual ICollection<Oop> Oops { get; set; } = new List<Oop>();
}
