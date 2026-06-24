using Insurance.Models;
using Insurance.ViewModels;

namespace Insurance.Data.Interface;

public interface IPartnerRepository
{
    Task<IEnumerable<PartnerViewModel>> GetPartners();
    Task<PartnerDetailsViewModel?> GetPartnerByID(int ID);
    Task<int> CreatePartner(CreatePartnerViewModel partner);
}