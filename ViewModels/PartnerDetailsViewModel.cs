namespace Insurance.ViewModels;

public class PartnerDetailsViewModel
{
    public int ID { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string PartnerNumber { get; set; } = string.Empty;

    public string? CroatianPIN { get; set; }

    public int PartnerTypeID { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public string CreatedByUser { get; set; } = string.Empty;

    public bool IsForeign { get; set; }

    public string ExternalCode { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public List<PolicyViewModel> Policies { get; set; } = new();

    public int PolicyCount => Policies.Count;

    public decimal TotalPolicyAmount => Policies.Sum(x => x.PolicyAmount);
}