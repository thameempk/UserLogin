using Microsoft.Data.SqlClient;
using RepoDb;
using System.Data;
using UsersLogin.Manager.Interface;
using UsersLogin.Models;

namespace UsersLogin.Manager
{
    public class LoginManager : ILoginManager
    {
        private readonly IDbConnection connection;
        //private readonly IHttpClientFactory clientFactory;
        private readonly IJwtManager jwtManager;
        public LoginManager(IDbConnection connection,  IJwtManager jwtManager)
        {
            this.connection = connection;
            //this.clientFactory = clientFactory;
            this.jwtManager = jwtManager;
        }
        public async Task<string> LoginUser(Login login)
        {
            try
            {
                if (login == null) 
                {
                    return "invalid user details";
                }
                string query = "select * from Users where UserName = @username And Password = @password ";
                IEnumerable<Users> user = null;
                using(IDbConnection connection = this.connection.EnsureOpen())
                {
                   user =  await connection.QueryAsync<Users>("users", new { username = login.UserName, password = login.Password });
                }
                
                if (user == null)
                {
                    return "user not found";
                }

                var userData =  user.ToList()[0];
                string token = await jwtManager.JwtToken(userData);

                return token;

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
