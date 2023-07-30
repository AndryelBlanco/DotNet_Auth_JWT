namespace ApiAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //String só para teste
        public string Role { get; set; }

    }
}
