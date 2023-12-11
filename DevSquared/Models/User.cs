namespace DevSquared.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Course>? MyCourses;

        public User(string Username, string Password)
        {
            MyCourses = new List<Course>();
            this.Username = Username;
            this.Password = Password;
        }
    }
}
