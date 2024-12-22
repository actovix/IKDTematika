using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

public partial class VCourseAll2
{
    public int? CourseId { get; set; }

    public string? NapCode { get; set; }

    public string? Napravlenie { get; set; }

    public string? OopType { get; set; }

    public string? OopName { get; set; }

    public int? FirstYear { get; set; }

    public string? UrlIstu { get; set; }

    public string? CourseName { get; set; }

    public string? UrlIstuRpd { get; set; }

    public string? SubjectName { get; set; }

    public short? Semestr { get; set; }

    public short? Ze { get; set; }

    public short? LecHours { get; set; }

    public short? LabHours { get; set; }

    public short? PractHours { get; set; }

    public string? GradeForm { get; set; }

    public int? OopId { get; set; }

    public int? NapravlenieId { get; set; }

    public int? SubjectId { get; set; }

    public int? SemestrId { get; set; }
}
