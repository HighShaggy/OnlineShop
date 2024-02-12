using Microsoft.AspNetCore.Mvc;
using ShopDb.Interfaces;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoleController : Controller
    {
        readonly IRolesStorage _rolesStorage;

        public RoleController(IRolesStorage rolesStorage)
        {
            _rolesStorage = rolesStorage;
        }

        public IActionResult AddRolePanel()
        {
            return View();
        }
        public IActionResult AddRole(string name)
        {
            _rolesStorage.AddRole(name);
            return RedirectToAction("WatchRoles");
        }
        public IActionResult RemoveRole(string name)
        {
            _rolesStorage.RemoveRole(name);
            return RedirectToAction("WatchRoles");
        }

        public IActionResult WatchRoles()
        {
            return View(Mapping.Maps.ToRoleListViewModel(_rolesStorage.LoadRolesList()));
        }
    }
}
