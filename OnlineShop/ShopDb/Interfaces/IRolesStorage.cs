using ShopDb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopDb.Interfaces
{
    public interface IRolesStorage
    {
        void AddRole([Required] string name);
        List<Role> LoadRolesList();
        void RemoveRole(string name);
    }
}
