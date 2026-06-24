using Insurance.Data.Interface;
using Insurance.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers;

public class PartnersController : Controller
{
    private readonly IPartnerRepository _partnerRepository;

    public PartnersController(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }

    public async Task<IActionResult> Index(int? highlightedID)
    {
        var partners = await _partnerRepository.GetPartners();

        ViewBag.HighlightedID = TempData["HighlightedPartnerID"];

        return View(partners);
    }

    [HttpGet]
    public async Task<IActionResult> PartnerDetails(int ID)
    {
        var partner = await _partnerRepository.GetPartnerByID(ID);

        if (partner == null)
        {
            return NotFound();
        }

        return PartialView("_PartnerDetailsModal", partner);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePartnerViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var newPartnerID = await _partnerRepository.CreatePartner(model);

        TempData["HighlightedPartnerID"] = newPartnerID;

        return RedirectToAction(nameof(Index));
    }
}