using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// форма обучения
/// </summary>
public partial class StudyForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Sokr { get; set; } = null!;

    public virtual ICollection<Oop> Oops { get; set; } = new List<Oop>();
}
