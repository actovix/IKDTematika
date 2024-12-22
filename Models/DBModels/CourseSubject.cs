using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

/// <summary>
/// связь тематики и дисцилпины
/// </summary>
public partial class CourseSubject
{
    public int Id { get; set; }

    public int IdCourse { get; set; }

    public int IdSubject { get; set; }

    public int? Rank { get; set; }

    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
