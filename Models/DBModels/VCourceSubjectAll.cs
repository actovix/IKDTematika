using System;
using System.Collections.Generic;

namespace IKDTematika.Models.DBModels;

public partial class VCourceSubjectAll
{
    public int? Id { get; set; }

    public string? NapCode { get; set; }

    public string? Napravlenie { get; set; }

    public string? OopType { get; set; }

    public string? OopName { get; set; }

    public int? FirstYear { get; set; }

    public string? UrlIstu { get; set; }

    public string? CourseName { get; set; }

    public string? UrlIstuRpd { get; set; }

    public string? SubjectName { get; set; }
}
