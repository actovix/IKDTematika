using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

public partial class VCourseAll
{
    public int? CourseId { get; set; }

    public string? SourceCode { get; set; }

    public string? NapravlenieCode { get; set; }

    public string? Napravlenie { get; set; }

    public string? OopType { get; set; }

    public string? OopName { get; set; }

    public int? FirstYear { get; set; }

    public string? StudyForm { get; set; }

    public string? StudyFormSokr { get; set; }

    public string? UrlIstu { get; set; }

    public string? CourseName { get; set; }

    public bool? IsRequired { get; set; }

    public string? Module { get; set; }

    public string? BlockName { get; set; }

    public string? PartName { get; set; }

    public string? UrlIstuRpd { get; set; }

    public string? UrlIstuAnnot { get; set; }

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

    public int? SemestrControlId { get; set; }

    public int? SemestrControlTypeId { get; set; }

    public int? SemestrControlSemestrId { get; set; }
}
