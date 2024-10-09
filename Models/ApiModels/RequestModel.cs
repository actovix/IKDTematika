using System.ComponentModel.DataAnnotations;

namespace IKDTematika.Models.ApiModels;

public class RequestModel
{  
    [Required]
    [MinLength(1, ErrorMessage = "Must have at least 1 character")]
    public string Subject { get; set; } = "";
    [Required]
    public string Link { get; set; } = "";
}
