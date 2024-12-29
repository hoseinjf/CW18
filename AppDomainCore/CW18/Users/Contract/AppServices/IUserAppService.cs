using AppDomainCore.CW18.Users.Entities;

namespace AppDomainCore.CW18.Users.Contract.AppServices
{
    public interface IUserAppService
    {
        public User Register(User user);
        public User Login(string username, string password);
    }
}
