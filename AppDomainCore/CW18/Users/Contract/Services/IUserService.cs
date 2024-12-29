using AppDomainCore.CW18.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.CW18.Users.Contract.Services
{
    public interface IUserService
    {
        public User Register(User user);
        public User Login(string username, string password);
    }
}
