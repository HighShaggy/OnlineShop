using Microsoft.AspNetCore.Mvc;
using ShopDb.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        readonly IUserStorage _userStorage;

        public UserController(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public IActionResult WatchUsers()
        {
            return View(Mapping.Maps.ToUserListViewModel(_userStorage.LoadUsersList()));
        }

        public IActionResult WatchUserInfo(int id)
        {
            var users = _userStorage.LoadUsersList();
            var existingUser = users.FirstOrDefault(p => p.Id == id);
            return View(Mapping.Maps.ToUserViewModel(existingUser));
        }

        public IActionResult EditPassword(int id, string password)
        {
            var user = _userStorage.LoadUsersList().FirstOrDefault(p => p.Id == id);
            _userStorage.EditPassword(id, password);
            return View(Mapping.Maps.ToUserViewModel(user));
        }

        public IActionResult EditData(int id, string name)
        {
            var user = _userStorage.LoadUsersList().FirstOrDefault(p => p.Id == id);
            _userStorage.EditData(id, name);
            return View(Mapping.Maps.ToUserViewModel(user));
        }

        public IActionResult DeleteUser(int id)
        {
            _userStorage.DeleteUser(id);
            return RedirectToAction("WatchUsers");
        }

        public IActionResult AddUser(string name, string password)
        {
            _userStorage.UserRegistration(name, password);
            return RedirectToAction("WatchUsers");
        }

        public IActionResult AddUserForm()
        {
            return View();
        }
    }
}
