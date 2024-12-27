using Quiz2.Continer;
using Quiz2.Entity;
using Quiz2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Servise
{
    public class UserServise
    {
        private readonly IUserRepository _userRepository;
        public UserServise()
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
