using System.Collections.Generic;

namespace MyClassLibrary.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}