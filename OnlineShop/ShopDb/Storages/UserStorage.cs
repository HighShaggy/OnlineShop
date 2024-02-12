using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ShopDb.Interfaces;
using ShopDb.Models;

namespace ShopDb.Storages
{
    public class UserStorage : IUserStorage
    {
        readonly MyDbContext _dbContext;

        public UserStorage(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void UserRegistration([Required] string name, [Required] string password)
        {
            var userDb = new User
            {
                Name = name,
                Password = password
            };
            _dbContext.UserDb.Add(userDb);
            _dbContext.SaveChanges();
        }
        public List<User> LoadUsersList()
        {
            return _dbContext.UserDb.Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password
            }).ToList();
        }

        public bool UserLogin([Required] string name, [Required] string password)
        {
            var user = LoadUsersList().FirstOrDefault(x => x.Name == name);
            if (user == null) return false;
            if (user.Password != password) return false;
            else
                return true;
        }

        public void EditPassword(int id, string password)
        {
            var existingUser = _dbContext.UserDb.FirstOrDefault(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.Password = password;
            }
            _dbContext.SaveChanges();
        }

        public void EditData(int id, string name)
        {
            var existingUser = _dbContext.UserDb.FirstOrDefault(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = name;
            }
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var existingUser = _dbContext.UserDb.FirstOrDefault(x => x.Id == id);
            _dbContext.UserDb.Remove(existingUser);
            _dbContext.SaveChanges();
        }
    }
}
