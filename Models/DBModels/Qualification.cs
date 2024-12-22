using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// квалиифкация
/// </summary>
public partial class Qualification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Napravlenie> Napravlenies { get; set; } = new List<Napravlenie>();
}
