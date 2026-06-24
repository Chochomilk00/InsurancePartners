using System.ComponentModel.DataAnnotations;

namespace Insurance.ViewModels;

public class CreatePolicyViewModel
{
    [Required]
    public int PartnerID { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 10)]
    public string PolicyNumber { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 999999999)]
    public decimal PolicyAmount { get; set; }
}