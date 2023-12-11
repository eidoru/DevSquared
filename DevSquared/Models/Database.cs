namespace DevSquared.Models
{
    public sealed class Database
    {
        public static List<User> Users { get; set; } = [];
        public static User? CurrentUser { get; set; }
        public static List<Course>? Courses { get; set; } =
        [
            new Course(1, "Vector Math", "Test"),
            new Course(2, "Advanced Vector Math", "Test"),
            new Course(3, "Matrices and Transforms", "Test"),
            new Course(4, "Interpolation", "Test"),
            new Course(5, "Beziers", "Test"),
        ];

        private Database() { }

        public static bool Validate(string? Username, string? Password)
        {
            foreach (User user in Users)
            {
                if (user.Username.Equals(Username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
