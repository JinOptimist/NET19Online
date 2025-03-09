using Enums.SchoolUser;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Lessons;
using WebStoryFroEveryting.SchoolAttributes.AuthorizeAttributes;

namespace WebStoryFroEveryting.Controllers;

public class SchoolUserController : Controller
{
    private readonly SchoolUserRepository _schoolUserRepository;

    public SchoolUserController(SchoolUserRepository schoolUserRepository)
    {
        _schoolUserRepository = schoolUserRepository;
    }

    [HttpGet]
    [HasPermission(SchoolPermission.CanBanUsers)]
    public IActionResult PotentialBannedUsers()
    {
        var potentialBanUsers = _schoolUserRepository
            .GetPotentialBanUsers();
        var result = potentialBanUsers
            .Select(MapToPotentialBan)
            .ToList();
        return View(result);
    }

    [HttpPost]
    [HasPermission(SchoolPermission.CanBanUsers)]
    public IActionResult BanUser(int userId)
    {
        _schoolUserRepository.BanUser(userId);
        return RedirectToAction(nameof(PotentialBannedUsers));
    }

    private PotentialBanUserViewModel MapToPotentialBan(PotentialBanUsersData from)
    {
        return new PotentialBanUserViewModel()
        {
            CommentDescription = from.Description,
            Email = from.Email,
            Id = from.Id
        };
    }
}