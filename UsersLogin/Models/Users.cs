namespace UsersLogin.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedData { get; set; }  
        public DateTime Last_Login { get; set; }
    }
}
