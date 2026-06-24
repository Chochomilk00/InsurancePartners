using System.ComponentModel.DataAnnotations;

namespace Insurance.Models;

public class Partner
{
    public int ID { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Address { get; set; }

    [Required]
    [RegularExpression(@"^\d{20}$")]
    public string PartnerNumber { get; set; } = string.Empty;

    [StringLength(11, MinimumLength = 11)]
    public string? CroatianPIN { get; set; }

    [Required]
    [Range(1, 2)]
    public int PartnerTypeID { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string CreatedByUser { get; set; } = string.Empty;

    [Required]
    public bool IsForeign { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 10)]
    public string ExternalCode { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^[MFN]$")]
    public string Gender { get; set; } = string.Empty;
}