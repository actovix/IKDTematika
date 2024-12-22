using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// конкретный семестр в к конкретной дисциплине с часами и з.е.
/// </summary>
public partial class Semestr
{
    public int Id { get; set; }

    public short Number { get; set; }

    public short Ze { get; set; }

    public int IdCourse { get; set; }

    public short Lec { get; set; }

    public short Lab { get; set; }

    public short Pract { get; set; }

    public short Srs { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual ICollection<SemestrControl> SemestrControls { get; set; } = new List<SemestrControl>();
}
