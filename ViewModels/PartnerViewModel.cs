using Microsoft.AspNetCore.Mvc;

namespace Insurance.ViewModels
{
    public class PartnerViewModel
    {
        public int ID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PartnerNumber { get; set; } = string.Empty;

        public string? CroatianPIN { get; set; }

        public int PartnerTypeID { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public bool IsForeign { get; set; }

        public string Gender { get; set; } = string.Empty;

        public bool IsSpecial { get; set; }
    }
}
