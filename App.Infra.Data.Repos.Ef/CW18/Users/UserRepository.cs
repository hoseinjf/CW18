using App.Infra.Data.Repos.Ef.CW18.Db;
using AppDomainCore.CW18.Users.Contract.Repositories;
using AppDomainCore.CW18.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CW18.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository()
        {
            appDbContext = new AppDbContext();
        }
        public User Login(string username, string password)
        {
            var user = appDbContext.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public User Register(User user)
        {
            User user1 = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password
            };
            appDbContext.Users.Add(user1);
            appDbContext.SaveChanges();
            return user1;
        }
    }
}
