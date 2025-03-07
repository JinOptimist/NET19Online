using Enums.SchoolUser;
using Enums.User;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.SchoolUser;
using WebStoryFroEveryting.SchoolAttributes.AuthorizeAttributes;

namespace WebStoryFroEveryting.Controllers;

[IsRole("Admin")]
public class SchoolRolesController : Controller
{
    private readonly SchoolRoleRepository _schoolRoleRepository;

    public SchoolRolesController(SchoolRoleRepository schoolRoleRepository)
    {
        _schoolRoleRepository = schoolRoleRepository;
    }
    public IActionResult Index()
    {
        var roles = _schoolRoleRepository.GetAll();
        var rolesViewModel = MapSchoolRoleDataToViewModel(roles);
        return View(rolesViewModel);
    }

    [HttpPost]
    public IActionResult Add(string roleName)
    {
        var role = new SchoolRoleData()
        {
            Name = roleName,
        };
        _schoolRoleRepository.Add(role);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int roleId)
    {
        _schoolRoleRepository.Remove(roleId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Update(int roleId, List<int> permissions)
    {
        var role = _schoolRoleRepository.Get(roleId);
    
        if (role == null)
        {
            return NotFound("Роль не найдена");
        }

        SchoolPermission updatedPermissions = 0;
        foreach (var perm in permissions)
        {
            updatedPermissions |= (SchoolPermission)perm;
        }

        _schoolRoleRepository.Update(new SchoolRoleData()
        {
            Id = role.Id,
            Name = role.Name,
            Permission = updatedPermissions
        });

        return RedirectToAction(nameof(Index));
    }


    private List<SchoolRoleViewModel> MapSchoolRoleDataToViewModel(List<SchoolRoleData> schoolRoleDataList)
    {
        return schoolRoleDataList
            .Select(x => new SchoolRoleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Permissions = x.Permission
            })
            .ToList();
    }
}