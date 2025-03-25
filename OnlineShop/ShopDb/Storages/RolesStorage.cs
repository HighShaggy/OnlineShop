using ShopDb.Interfaces;
using ShopDb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShopDb.Storages
{
    public class RolesStorage : IRolesStorage
    {
        readonly MyDbContext _dbContext;

        public RolesStorage(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRole([Required] string name)
        {
            var newRole = new Role()
            {
                Name = name,
            };
            _dbContext.Roles.Add(newRole);
            _dbContext.SaveChanges();
        }

        public List<Role> LoadRolesList()
        {
            var roles = new List<Role>()
            {
              new() { Id = 1, Name = "admin" },
              new() { Id = 2, Name = "user" }
            };
            _dbContext.Roles.AddRange(roles);
            _dbContext.SaveChanges();
            return roles;
        }
        public void RemoveRole(string name)
        {
            var role = LoadRolesList().FirstOrDefault(x => x.Name == name);
            _dbContext.Roles.Remove(role);
        }
    }
}
