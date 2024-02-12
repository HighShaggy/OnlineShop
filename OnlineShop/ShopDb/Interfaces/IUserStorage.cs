using ShopDb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopDb.Interfaces
{
    public interface IUserStorage
    {
        void UserRegistration(string name, string password);
        bool UserLogin([Required] string username, [Required] string password);
        List<User> LoadUsersList();

        void EditPassword(int id, string password);

        void EditData(int id, string name);
        void DeleteUser(int id);
    }
}
