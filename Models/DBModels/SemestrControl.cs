using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// форма контроля
/// </summary>
public partial class SemestrControl
{
    public int Id { get; set; }

    public int IdSemestr { get; set; }

    public int IdControlType { get; set; }

    public virtual ControlType IdControlTypeNavigation { get; set; } = null!;

    public virtual Semestr IdSemestrNavigation { get; set; } = null!;
}
