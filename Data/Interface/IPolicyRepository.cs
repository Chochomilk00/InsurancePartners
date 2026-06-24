using Insurance.ViewModels;

namespace Insurance.Data.Interface;

public interface IPolicyRepository
{
    Task CreatePolicy(CreatePolicyViewModel policy);
}