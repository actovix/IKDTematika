using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// формы контроля
/// </summary>
public partial class ControlType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Sokr { get; set; } = null!;

    public virtual ICollection<SemestrControl> SemestrControls { get; set; } = new List<SemestrControl>();
}
