using Insurance.Data.Interface;
using Insurance.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers;

public class PoliciesController : Controller
{
    private readonly IPolicyRepository _policyRepository;

    public PoliciesController(IPolicyRepository policyRepository)
    {
        _policyRepository = policyRepository;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePolicyViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["PolicyError"] = "Invalid policy data.";
            return RedirectToAction("Index", "Partners");
        }

        await _policyRepository.CreatePolicy(model);

        return RedirectToAction("Index", "Partners");
    }
}