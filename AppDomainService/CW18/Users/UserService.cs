using App.Domain.Core.CW18.Users.Entities;
using AppDomainCore.CW18.Users.Services;
using Quiz2.Entity;
using Quiz2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService.CW18.Users
{
    public class UserService:IUserService
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
