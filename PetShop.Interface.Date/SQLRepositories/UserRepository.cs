using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Entity;

namespace PetShop.Interface.Date.SQLRepositories
{
    public class UserRepository
    {
        private PetShopContext _ctx;

        public UserRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }

        public User GetByUsername(string user)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username == user);
        }
    }
}