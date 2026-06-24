namespace Insurance.ViewModels;

public class PolicyViewModel
{
    public int ID { get; set; }

    public string PolicyNumber { get; set; } = string.Empty;

    public decimal PolicyAmount { get; set; }
}