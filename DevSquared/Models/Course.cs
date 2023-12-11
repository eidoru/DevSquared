namespace DevSquared.Models
{
    public class Course(int Id, string Name, string Description)
    {
        public int Id { get; set; } = Id;
        public string Name { get; set; } = Name;
        public string Description { get; set; } = Description;
    }
}
