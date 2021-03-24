namespace MyClassLibrary.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Skill[] Skills { get; set; }
    }
}