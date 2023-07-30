using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>()
            {
                new User { Id = 1, UserName = "Scooby", Password = "biscoito", Role = "admin"},
                new User { Id = 2, UserName = "Fred", Password = "daphine", Role = "employee"}
            };
     
            return users.FirstOrDefault(x => 
            x.UserName.ToLower() == username.ToLower() 
            && x.Password == password);
              
        }
    }
}
