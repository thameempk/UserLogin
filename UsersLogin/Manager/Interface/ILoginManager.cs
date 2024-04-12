using UsersLogin.Models;

namespace UsersLogin.Manager.Interface
{
    public interface ILoginManager
    {
        Task<string> LoginUser(Login login);


    }
}
