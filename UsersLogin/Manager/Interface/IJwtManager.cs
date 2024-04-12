using UsersLogin.Models;

namespace UsersLogin.Manager.Interface
{
    public interface IJwtManager
    {
        Task<string> JwtToken(Users user);
    }
}
