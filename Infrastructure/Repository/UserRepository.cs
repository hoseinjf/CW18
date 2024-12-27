using Quiz2.Context;
using Quiz2.Continer;
using Quiz2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Repository
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
                .FirstOrDefault(x=>x.Username == username && x.Password == password);
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
