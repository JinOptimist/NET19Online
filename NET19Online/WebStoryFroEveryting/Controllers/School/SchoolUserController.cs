using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Lessons;

namespace WebStoryFroEveryting.Controllers;

public class SchoolUserController : Controller
{
    private readonly SchoolUserRepository _schoolUserRepository;

    public SchoolUserController(SchoolUserRepository schoolUserRepository)
    {
        _schoolUserRepository = schoolUserRepository;
    }

    [HttpGet]
    public IActionResult PotentialBannedUsers()
    {
        var potentialBanUsers = _schoolUserRepository
            .GetPotentialBanUsers();
        var result = potentialBanUsers
            .Select(MapToPotentialBan)
            .ToList();
        return View(result);
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