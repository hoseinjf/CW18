using App.Infra.Data.Repos.Ef.CW18.Users;
using AppDomainCore.CW18.Users.Contract.Repositories;
using AppDomainCore.CW18.Users.Contract.Services;
using AppDomainCore.CW18.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainService.CW18.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User Login(string username, string password)
        {
            return _userRepository.Login(username, password);
        }
        public User Register(User user)
        {
            return _userRepository.Register(user);
        }
    }
}
