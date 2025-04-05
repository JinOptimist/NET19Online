using Enums.User;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;
using WebStoryFroEveryting.Models.User;

namespace WebStoryFroEveryting.Controllers
{
    [IsAdmin]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private RoleRepository _roleRepository;

        public UserController(RoleRepository roleRepository,
            IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexUserViewModel();

            viewModel.Users = _userRepository
                .GetAllWithRole()
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Name = x.UserName,
                    RoleId = x.Role?.Id
                })
                .ToList();

            viewModel.Roles = _roleRepository
                .GetAll()
                .Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
            viewModel.Roles.Add(new RoleViewModel
            {
                Id = null,
                Name = "Нету роли"
            });

            return View(viewModel);
        }

        public IActionResult UpdateUserRole(int id, int? roleId)
        {
            _userRepository.UpdateRole(id, roleId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateRole(string roleName)
        {
            var role = new RoleData
            {
                Name = roleName
            };

            _roleRepository.Add(role);

            return RedirectToAction("Roles");
        }

        public IActionResult UpdateRole(int id, List<Permisson> permissons)
        {
            _roleRepository.UpdatePermission(id, permissons);
            return RedirectToAction("Roles");
        }

        public IActionResult DeleteRole(int id)
        {
            _roleRepository.Remove(id);
            return RedirectToAction("Roles");
        }

        public IActionResult Roles()
        {
            var viewModel = new RolesViewModel();

            viewModel.Roles = _roleRepository
                .GetAll()
                .Select(x => new RoleWithPermissionsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Permissons = GetPermissons(x.Permisson),
                })
                .ToList();
            viewModel.Permissions = Enum
                .GetValues<Permisson>()
                .Select(x => new PermissionViewModel
                {
                    Permisson = x,
                    PermissonName = GetDisplayName(x)
                })
                .ToList();

            return View(viewModel);
        }

        // TODO Move to enum helper
        private List<Permisson> GetPermissons(Permisson rolePpermisson)
        {
            return Enum
                .GetValues<Permisson>()
                .Where(availablePermisson => rolePpermisson.HasFlag(availablePermisson))
                .ToList();
        }

        // TODO Move to enum helper
        private string GetDisplayName(Permisson permisson)
        {
            return Enum.GetName(permisson);
        }
    }
}
