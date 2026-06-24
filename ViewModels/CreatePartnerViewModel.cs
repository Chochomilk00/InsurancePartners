using System.ComponentModel.DataAnnotations;

namespace Insurance.ViewModels;

public class CreatePartnerViewModel
{
    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Address { get; set; }

    [Required]
    [RegularExpression(@"^\d{20}$", ErrorMessage = "Partner number must contain exactly 20 digits.")]
    public string PartnerNumber { get; set; } = string.Empty;

    [RegularExpression(@"^\d{11}$", ErrorMessage = "Croatian PIN must contain exactly 11 digits.")]
    public string? CroatianPIN { get; set; }

    [Required]
    [Range(1, 2)]
    public int PartnerTypeID { get; set; }

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
    [RegularExpression("^[MFN]$", ErrorMessage = "Gender must be M, F or N.")]
    public string Gender { get; set; } = string.Empty;
}