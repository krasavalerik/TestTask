using System.ComponentModel.DataAnnotations;

namespace MyClassLibrary.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1,10)]
        public byte Level { get; set; }
    }
}
