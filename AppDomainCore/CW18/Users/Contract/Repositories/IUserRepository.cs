using AppDomainCore.CW18.Users.Entities;

namespace AppDomainCore.CW18.Users.Contract.Repositories

{
    public interface IUserRepository
    {
        public User Register(User user);
        public User Login(string username, string password);
    }
}
