using Quiz2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2.Continer
{
    public interface IUserRepository
    {
        public User Register(User user);
        public User Login(string username, string password);
    }
}
