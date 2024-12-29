using App.Infra.Data.Repos.Ef.CW18.Users;
using AppDomainCore.CW18.Users.Contract.AppServices;
using AppDomainCore.CW18.Users.Contract.Repositories;
using AppDomainCore.CW18.Users.Contract.Services;
using AppDomainCore.CW18.Users.Entities;
using AppDomainService.CW18.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService.CW18.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService userService;
        public UserAppService()
        {
            userService = new UserService();
        }
        public User Login(string username, string password)
        {
            return userService.Login(username, password);
        }
        public User Register(User user)
        {
            return userService.Register(user);
        }
    }
}
