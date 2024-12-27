
using Quiz2.Entity;

namespace App.Domain.Core.CW18.Users.Entities

{
    public interface IUserRepository
    {
        public User Register(User user);
        public User Login(string username, string password);
    }
}
